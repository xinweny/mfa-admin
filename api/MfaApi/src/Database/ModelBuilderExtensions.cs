using Microsoft.EntityFrameworkCore;
using Bogus;

using MfaApi.Modules.Membership;
using MfaApi.Modules.Member;
using MfaApi.Modules.Address;
using MfaApi.Modules.Due;
using MfaApi.Modules.Exchange;
using MfaApi.Common.Constants;

namespace MfaApi.Database;

public static class ModelBuilderExtensions {
    public static void Seed(this ModelBuilder modelBuilder) {
        Random random = new Random(MfaConstants.BogusSeed);
        Faker<MembershipModel> membershipFaker = new MembershipFaker()
            .UseSeed(MfaConstants.BogusSeed);
        Faker<MemberModel> memberFaker = new MemberFaker()
            .UseSeed(MfaConstants.BogusSeed);
        Faker<AddressModel> addressFaker = new AddressFaker()
            .UseSeed(MfaConstants.BogusSeed);
        Faker<DueModel> _dueFaker = new DueFaker()
            .UseSeed(MfaConstants.BogusSeed);
        Faker<ExchangeModel> exchangeFaker = new ExchangeFaker()
            .UseSeed(MfaConstants.BogusSeed);

        // Generate memberships
        var memberships = membershipFaker
            .RuleFor(
                m => m.StartDate,
                f => DateOnly.FromDateTime(f.Date
                    .Between(new DateTime(
                        DateTime.Now.AddYears(-5).Year, 1, 1),
                        DateTime.Now
                    )))
            .Generate(20);

        List<AddressModel> addresses = [];
        
        // 80% of memberships have an address
        foreach (MembershipModel membership in memberships) {
            bool hasAddress = random.NextDouble() > 0.2;

            if (hasAddress) {
                var address = addressFaker.Generate();

                membership.AddressId = address.Id;

                addresses.Add(address);
            }
        }
        
        modelBuilder.Entity<AddressModel>().HasData(addresses);
        modelBuilder.Entity<MembershipModel>().HasData(memberships);

        // Generate members
        List<MemberModel> members = [];

        // Single memberships only 1 member, family 1 to 4
        foreach (MembershipModel membership in memberships) {
            var mFaker = memberFaker
                .RuleFor(m => m.MembershipId, membership.Id)
                .RuleFor(m => m.JoinedDate, membership.StartDate);

            var membershipMembers = membership.MembershipType == MembershipType.Single
                ? mFaker.Generate(1)
                : mFaker.GenerateBetween(1, 4);
            
            foreach (MemberModel member in membershipMembers) {
                members.Add(member);
            }
        }

        modelBuilder.Entity<MemberModel>().HasData(members);

        // Generate membership dues
        List<DueModel> dues = [];

        foreach (MembershipModel membership in memberships) {
            int[] yearRange = Enumerable
                .Range(
                    membership.StartDate.Year,
                    DateTime.Now.Year + 1 - membership.StartDate.Year
                )
                .ToArray();
            
            for (int i = 0; i < yearRange.Length; i++) {
                // Pay all previous years and 75% chance to have already paid current year
                bool hasPaid = i != (yearRange.Length - 1)
                    || random.NextDouble() > 0.25;

                if (hasPaid) {
                    var due = _dueFaker
                        .RuleFor(d => d.MembershipId, membership.Id)
                        .RuleFor(d => d.AmountPaid, membership.MembershipType == MembershipType.Single
                            ? MfaConstants.SingleMembershipCost
                            : MfaConstants.FamilyMembershipCost)
                        .RuleFor(d => d.Year, yearRange[i])
                        .RuleFor(d => d.PaymentDate, membership.StartDate
                        .AddDays(random.Next(new DateOnly(yearRange[i] + 1, 1, 1).DayNumber - new DateOnly(yearRange[i], 1, 1).DayNumber)))
                        .Generate();

                    dues.Add(due);
                }
            }
        }

        modelBuilder.Entity<DueModel>().HasData(dues);

        // Add exchanges
        List<ExchangeModel> exchanges = [];

        int[] mfaYearsRange = Enumerable
            .Range(
                MfaConstants.MfaFoundingYear,
                DateTime.Now.Year + 1 - MfaConstants.MfaFoundingYear
            )
            .ToArray();
        ExchangeType currentExchange = ExchangeType.Delegate;
        
        for (int i = 0; i < mfaYearsRange.Length; i++) {
            foreach (MemberModel member in members) {                
                // 25% chance of going on exchange
                bool goesOnExchange = member.JoinedDate?.Year > mfaYearsRange[i]
                    && random.NextDouble() > 0.75;

                if (goesOnExchange) {
                    var exchange = exchangeFaker
                        .RuleFor(e => e.MemberId, member.Id)
                        .RuleFor(e => e.ExchangeType, currentExchange)
                        .RuleFor(e => e.Year, mfaYearsRange[i])
                        .Generate();

                    exchanges.Add(exchange);
                }
            }
            
            // Alternate years of hosting and delegation
            currentExchange = currentExchange == ExchangeType.Delegate
                ? ExchangeType.Host
                : ExchangeType.Delegate;
        }

        modelBuilder.Entity<ExchangeModel>().HasData(exchanges);
    }
}