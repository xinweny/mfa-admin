﻿// <auto-generated />
using System;
using MfaApi.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MfaApi.Migrations
{
    [DbContext(typeof(MfaDbContext))]
    partial class MfaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MfaApi.Modules.Address.AddressModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("city");

                    b.Property<string>("Line1")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("line1");

                    b.Property<string>("Line2")
                        .HasColumnType("text")
                        .HasColumnName("line2");

                    b.Property<string>("Line3")
                        .HasColumnType("text")
                        .HasColumnName("line3");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("postal_code");

                    b.Property<int>("Province")
                        .HasColumnType("integer")
                        .HasColumnName("province");

                    b.HasKey("Id");

                    b.ToTable("addresses");
                });

            modelBuilder.Entity("MfaApi.Modules.BoardMember.BoardMemberModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("BoardPosition")
                        .HasColumnType("integer")
                        .HasColumnName("board_position");

                    b.Property<DateOnly?>("EndDate")
                        .HasColumnType("date")
                        .HasColumnName("end_date");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uuid")
                        .HasColumnName("member_id");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date")
                        .HasColumnName("start_date");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("board_members");
                });

            modelBuilder.Entity("MfaApi.Modules.Due.DueModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("AmountPaid")
                        .HasColumnType("integer")
                        .HasColumnName("amount_paid");

                    b.Property<Guid>("MembershipId")
                        .HasColumnType("uuid")
                        .HasColumnName("membership_id");

                    b.Property<DateOnly>("PaymentDate")
                        .HasColumnType("date")
                        .HasColumnName("payment_date");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("integer")
                        .HasColumnName("payment_method");

                    b.Property<int>("Year")
                        .HasColumnType("integer")
                        .HasColumnName("year");

                    b.HasKey("Id");

                    b.HasIndex("MembershipId");

                    b.ToTable("membership_dues");
                });

            modelBuilder.Entity("MfaApi.Modules.Exchange.ExchangeModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("ExchangeType")
                        .HasColumnType("integer")
                        .HasColumnName("exchange_type");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uuid")
                        .HasColumnName("member_id");

                    b.Property<int>("Year")
                        .HasColumnType("integer")
                        .HasColumnName("year");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("cultural_exchanges");
                });

            modelBuilder.Entity("MfaApi.Modules.Member.MemberModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<DateOnly?>("JoinedDate")
                        .HasColumnType("date")
                        .HasColumnName("joined_date");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<Guid>("MembershipId")
                        .HasColumnType("uuid")
                        .HasColumnName("membership_id");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("MembershipId");

                    b.ToTable("members");
                });

            modelBuilder.Entity("MfaApi.Modules.Membership.MembershipModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uuid")
                        .HasColumnName("address_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<int>("MembershipType")
                        .HasColumnType("integer")
                        .HasColumnName("membership_type");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("memberships");
                });

            modelBuilder.Entity("MfaApi.Modules.User.UserModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_name");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("MfaApi.Modules.BoardMember.BoardMemberModel", b =>
                {
                    b.HasOne("MfaApi.Modules.Member.MemberModel", "Member")
                        .WithMany("BoardPositions")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("MfaApi.Modules.Due.DueModel", b =>
                {
                    b.HasOne("MfaApi.Modules.Membership.MembershipModel", "Membership")
                        .WithMany("Dues")
                        .HasForeignKey("MembershipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Membership");
                });

            modelBuilder.Entity("MfaApi.Modules.Exchange.ExchangeModel", b =>
                {
                    b.HasOne("MfaApi.Modules.Member.MemberModel", "Member")
                        .WithMany("Exchanges")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("MfaApi.Modules.Member.MemberModel", b =>
                {
                    b.HasOne("MfaApi.Modules.Membership.MembershipModel", "Membership")
                        .WithMany("Members")
                        .HasForeignKey("MembershipId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Membership");
                });

            modelBuilder.Entity("MfaApi.Modules.Membership.MembershipModel", b =>
                {
                    b.HasOne("MfaApi.Modules.Address.AddressModel", "Address")
                        .WithOne("Membership")
                        .HasForeignKey("MfaApi.Modules.Membership.MembershipModel", "AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("MfaApi.Modules.Address.AddressModel", b =>
                {
                    b.Navigation("Membership");
                });

            modelBuilder.Entity("MfaApi.Modules.Member.MemberModel", b =>
                {
                    b.Navigation("BoardPositions");

                    b.Navigation("Exchanges");
                });

            modelBuilder.Entity("MfaApi.Modules.Membership.MembershipModel", b =>
                {
                    b.Navigation("Dues");

                    b.Navigation("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
