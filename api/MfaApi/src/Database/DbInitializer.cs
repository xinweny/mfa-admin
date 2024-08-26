using Microsoft.EntityFrameworkCore;
using Bogus;

using MfaApi.Common.Constants;
using MfaApi.Modules.Membership;
using MfaApi.Modules.Member;
using MfaApi.Modules.Address;
using MfaApi.Modules.Due;
using MfaApi.Modules.Exchange;

namespace MfaApi.Database;

public class DbInitializer {
    private readonly ModelBuilder _modelBuilder;
    private readonly Random _random = new Random(MfaConstants.BogusSeed);
    private readonly Faker<MembershipModel> _membershipFaker = new MembershipFaker()
        .UseSeed(MfaConstants.BogusSeed);
    private readonly Faker<MemberModel> _memberFaker = new MemberFaker()
        .UseSeed(MfaConstants.BogusSeed);
    private readonly Faker<AddressModel> _addressFaker = new AddressFaker()
        .UseSeed(MfaConstants.BogusSeed);
    private readonly Faker<DueModel> _dueFaker = new DueFaker()
        .UseSeed(MfaConstants.BogusSeed);
    private readonly Faker<ExchangeModel> _exchangeFaker = new ExchangeFaker()
        .UseSeed(MfaConstants.BogusSeed);

    public DbInitializer(ModelBuilder modelBuilder) {
        _modelBuilder = modelBuilder;
    }

    public void Seed() {
        // Generate memberships
        var memberships = _membershipFaker.Generate(20);
        
        // 80% of memberships have an address
        foreach (MembershipModel membership in memberships) {
            bool hasAddress = _random.NextDouble() > 0.2;

            if (hasAddress) {
                var address = _addressFaker.Generate();

                membership.AddressId = address.Id;
                membership.Address = address;
            }
        }

        _modelBuilder.Entity<MembershipModel>().HasData(memberships);

        // Generate members
        List<MemberModel> members = [];

        // Single memberships only 1 member, family 1 to 4
        foreach (MembershipModel membership in memberships) {
            var membershipMembers = membership.MembershipType == MembershipType.Single
                ? _memberFaker.Generate(1)
                : _memberFaker.GenerateBetween(1, 4);
            
            foreach (MemberModel member in membershipMembers) {
                member.MembershipId = membership.Id;
                // Set joined date to be the same as membership start date
                member.JoinedDate = membership.StartDate;
                members.Add(member);
            }
        }

        _modelBuilder.Entity<MemberModel>().HasData(members);

        // Generate membership dues
        List<DueModel> dues = [];

        foreach (MembershipModel membership in memberships) {
            int[] yearRange = Enumerable
                .Range(membership.StartDate.Year, DateTime.UtcNow.Year)
                .ToArray();
            
            for (int i = 0; i < yearRange.Length; i++) {
                // Pay all previous years and 75% chance to have already paid current year
                bool hasPaid = i != (yearRange.Length - 1)
                    || _random.NextDouble() > 0.25;

                if (hasPaid) {
                    var due = _dueFaker.Generate();

                    due.MembershipId = membership.Id;
                    due.AmountPaid = membership.MembershipType == MembershipType.Single
                        ? MfaConstants.SingleMembershipCost
                        : MfaConstants.FamilyMembershipCost;
                    // Payment date within the year
                    due.PaymentDate = membership.StartDate
                        .AddDays(_random.Next(new DateOnly(yearRange[i] + 1, 1, 1).DayNumber - new DateOnly(yearRange[i], 1, 1).DayNumber));

                    dues.Add(due);
                }
            }
        }

        _modelBuilder.Entity<DueModel>().HasData(dues);

        // Add exchanges
        List<ExchangeModel> exchanges = [];

        int[] mfaYearsRange = Enumerable
            .Range(MfaConstants.MfaFoundingYear, DateTime.UtcNow.Year)
            .ToArray();
        ExchangeType currentExchange = ExchangeType.Delegate;
        
        for (int i = 0; i < mfaYearsRange.Length; i++) {
            foreach (MemberModel member in members) {
                // 25% chance of going on exchange
                bool goesOnExchange = _random.NextDouble() > 0.75;

                if (goesOnExchange) {
                    var exchange = _exchangeFaker.Generate();
                    exchange.ExchangeType = currentExchange;
                    exchange.Year = mfaYearsRange[i];
                    exchange.MemberId = member.Id;

                    exchanges.Add(exchange);
                }
            }
            
            // Alternate years of hosting and delegation
            currentExchange = currentExchange == ExchangeType.Delegate
                ? ExchangeType.Host
                : ExchangeType.Delegate;
        }

        _modelBuilder.Entity<DueModel>().HasData(exchanges);
    }
}