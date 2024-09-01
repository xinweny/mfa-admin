using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MfaApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    line1 = table.Column<string>(type: "text", nullable: false),
                    line2 = table.Column<string>(type: "text", nullable: true),
                    city = table.Column<string>(type: "text", nullable: false),
                    postal_code = table.Column<string>(type: "text", nullable: false),
                    province = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    user_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "memberships",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    membership_type = table.Column<int>(type: "integer", nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    address_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_memberships", x => x.id);
                    table.ForeignKey(
                        name: "FK_memberships_addresses_address_id",
                        column: x => x.address_id,
                        principalTable: "addresses",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    joined_date = table.Column<DateOnly>(type: "date", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    membership_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_members", x => x.id);
                    table.ForeignKey(
                        name: "FK_members_memberships_membership_id",
                        column: x => x.membership_id,
                        principalTable: "memberships",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "membership_dues",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    payment_method = table.Column<int>(type: "integer", nullable: false),
                    amount_paid = table.Column<int>(type: "integer", nullable: false),
                    payment_date = table.Column<DateOnly>(type: "date", nullable: true),
                    membership_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_membership_dues", x => x.id);
                    table.ForeignKey(
                        name: "FK_membership_dues_memberships_membership_id",
                        column: x => x.membership_id,
                        principalTable: "memberships",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "board_members",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: true),
                    board_position = table.Column<int>(type: "integer", nullable: false),
                    member_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_board_members", x => x.id);
                    table.ForeignKey(
                        name: "FK_board_members_members_member_id",
                        column: x => x.member_id,
                        principalTable: "members",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cultural_exchanges",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    exchange_type = table.Column<int>(type: "integer", nullable: false),
                    member_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cultural_exchanges", x => x.id);
                    table.ForeignKey(
                        name: "FK_cultural_exchanges_members_member_id",
                        column: x => x.member_id,
                        principalTable: "members",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "addresses",
                columns: new[] { "id", "city", "line1", "line2", "postal_code", "province" },
                values: new object[,]
                {
                    { new Guid("0dfdcfc0-a255-ea7f-66f9-feedae6b07ba"), "Mississauga", "08549 Brown Harbors", "Apt. 275", "T7G 4H1", 1 },
                    { new Guid("0f8219bd-b3a4-f8f8-eb07-3c4cce1d8772"), "Mississauga", "582 Lane Neck", null, "J3F 9Z7", 1 },
                    { new Guid("1ce609a7-ae52-102a-a5f1-b4552c69f6b2"), "Mississauga", "659 Lesly Gateway", null, "R0Z 7N9", 1 },
                    { new Guid("246d00ad-4e18-604d-14ff-cff144462217"), "Mississauga", "180 Celestino Underpass", "Suite 770", "V9N 6V8", 1 },
                    { new Guid("275483e8-22f6-efe3-a385-7a8316ac6325"), "Mississauga", "39438 Okuneva Mews", "Suite 519", "Y4J 2K7", 1 },
                    { new Guid("3b224a6e-0a41-5242-f08e-b39184bc7b8c"), "Vaughan", "627 Harvey Circles", "Apt. 631", "E3P 3T2", 1 },
                    { new Guid("406dd318-a65b-8372-447f-4abb2840b9da"), "Mississauga", "7813 Horace Burgs", null, "J1Q 3Z4", 1 },
                    { new Guid("46b5cfae-25c5-3042-b6b5-bd2e17165309"), "Mississauga", "9226 Annamarie Summit", null, "N4X 5N0", 1 },
                    { new Guid("636db893-8095-e668-b125-723f716e9a17"), "Richmond Hill", "246 Konopelski Dale", null, "E4W 9A2", 1 },
                    { new Guid("69da26f1-a5f5-fabd-9aaf-54f16956d89b"), "Mississauga", "1026 Lesley Track", "Apt. 797", "S5A 8M4", 1 },
                    { new Guid("796c8985-90df-7f8a-025b-e7338fe32253"), "Mississauga", "193 Aiyana Loop", null, "J6E 8J0", 1 },
                    { new Guid("7dd10825-1c1b-1505-699b-439e98dc777b"), "Mississauga", "7230 Carter Road", "Apt. 957", "M2V 9J4", 1 },
                    { new Guid("948facfb-f66c-d12a-28c0-99ce8f435364"), "Mississauga", "034 Jacobi Springs", "Suite 647", "J9Q 7W5", 1 },
                    { new Guid("95668482-e62f-8eed-7896-8b9153efdf78"), "Mississauga", "845 Isobel Radial", null, "G6C 1J8", 1 },
                    { new Guid("aa245c06-f7c7-209e-012d-7e75d55ad827"), "Mississauga", "002 Cruickshank Ford", null, "J3R 0N8", 1 },
                    { new Guid("b97829fe-b20a-8ae5-b242-33acf80c7663"), "Mississauga", "1456 Ethelyn Route", "Suite 254", "Y3N 1C3", 1 },
                    { new Guid("bcaa99c1-ba8e-bc98-3eaf-5b1f60aa913d"), "Oakville", "207 Reichert Plains", "Apt. 791", "X9Y 8F4", 1 },
                    { new Guid("f2f95d1e-d0de-9d6e-43df-b042aa79031f"), "Mississauga", "123 Kirlin Course", null, "V7A 6U9", 1 }
                });

            migrationBuilder.InsertData(
                table: "memberships",
                columns: new[] { "id", "address_id", "created_at", "membership_type", "start_date", "updated_at" },
                values: new object[,]
                {
                    { new Guid("25c546b5-3042-b5b6-bd2e-171653095893"), null, new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(5530), 2, new DateOnly(2019, 1, 24), null },
                    { new Guid("c3a7ec26-e61d-0f2e-f563-45be5a925692"), null, new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(5810), 2, new DateOnly(2023, 12, 17), null }
                });

            migrationBuilder.InsertData(
                table: "members",
                columns: new[] { "id", "created_at", "email", "first_name", "joined_date", "last_name", "membership_id", "phone_number", "updated_at" },
                values: new object[,]
                {
                    { new Guid("0dfdcfc0-a255-ea7f-66f9-feedae6b07ba"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(9010), "Aron.Pfeffer31@gmail.com", "Jimmie", new DateOnly(2019, 1, 24), "Schowalter", new Guid("25c546b5-3042-b5b6-bd2e-171653095893"), "2747135765", null },
                    { new Guid("6c948fac-2af6-28d1-c099-ce8f435364a2"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(8960), "Elliot3@hotmail.com", "Alexandra", new DateOnly(2019, 1, 24), "Denesik", new Guid("25c546b5-3042-b5b6-bd2e-171653095893"), "4024797123", null },
                    { new Guid("7be73992-5ccf-9b4f-a800-e507ca186c10"), new DateTime(2024, 9, 1, 4, 1, 14, 982, DateTimeKind.Utc).AddTicks(1190), "Salvador_Howell73@hotmail.com", "Jarvis", new DateOnly(2023, 12, 17), "Olson", new Guid("c3a7ec26-e61d-0f2e-f563-45be5a925692"), "3586437032", null },
                    { new Guid("9879398d-b67e-7e3b-6be3-a0e08de81efd"), new DateTime(2024, 9, 1, 4, 1, 14, 982, DateTimeKind.Utc).AddTicks(1270), "Miles_Reinger@hotmail.com", "Jesse", new DateOnly(2023, 12, 17), "Batz", new Guid("c3a7ec26-e61d-0f2e-f563-45be5a925692"), "6353642248", null },
                    { new Guid("d178f2df-6ab2-f9c4-1699-cfdd16cb1e5c"), new DateTime(2024, 9, 1, 4, 1, 14, 982, DateTimeKind.Utc).AddTicks(1230), "Lue_Swaniawski@yahoo.com", "Elda", new DateOnly(2023, 12, 17), "Volkman", new Guid("c3a7ec26-e61d-0f2e-f563-45be5a925692"), "2558932435", null },
                    { new Guid("e05164d4-a6cd-b794-88b7-2929712c5f4c"), new DateTime(2024, 9, 1, 4, 1, 14, 982, DateTimeKind.Utc).AddTicks(1130), "Gisselle54@gmail.com", "Eda", new DateOnly(2023, 12, 17), "Kerluke", new Guid("c3a7ec26-e61d-0f2e-f563-45be5a925692"), "9999675152", null }
                });

            migrationBuilder.InsertData(
                table: "membership_dues",
                columns: new[] { "id", "amount_paid", "membership_id", "payment_date", "payment_method", "year" },
                values: new object[,]
                {
                    { new Guid("0dfdcfc0-a255-ea7f-66f9-feedae6b07ba"), 30, new Guid("25c546b5-3042-b5b6-bd2e-171653095893"), new DateOnly(2019, 1, 30), 2, 2020 },
                    { new Guid("0f8219bd-b3a4-f8f8-eb07-3c4cce1d8772"), 30, new Guid("25c546b5-3042-b5b6-bd2e-171653095893"), new DateOnly(2019, 2, 14), 1, 2023 },
                    { new Guid("1b4a3323-25bf-ca13-02b1-b12d28435550"), 30, new Guid("c3a7ec26-e61d-0f2e-f563-45be5a925692"), new DateOnly(2024, 10, 29), 1, 2023 },
                    { new Guid("275483e8-22f6-efe3-a385-7a8316ac6325"), 30, new Guid("25c546b5-3042-b5b6-bd2e-171653095893"), new DateOnly(2019, 4, 6), 3, 2024 },
                    { new Guid("796c8985-90df-7f8a-025b-e7338fe32253"), 30, new Guid("25c546b5-3042-b5b6-bd2e-171653095893"), new DateOnly(2019, 8, 29), 2, 2019 },
                    { new Guid("7dd10825-1c1b-1505-699b-439e98dc777b"), 30, new Guid("25c546b5-3042-b5b6-bd2e-171653095893"), new DateOnly(2019, 2, 5), 2, 2021 },
                    { new Guid("95668482-e62f-8eed-7896-8b9153efdf78"), 30, new Guid("25c546b5-3042-b5b6-bd2e-171653095893"), new DateOnly(2019, 7, 15), 2, 2022 }
                });

            migrationBuilder.InsertData(
                table: "memberships",
                columns: new[] { "id", "address_id", "created_at", "membership_type", "start_date", "updated_at" },
                values: new object[,]
                {
                    { new Guid("102aae52-f1a5-55b4-2c69-f6b2d0ad006d"), new Guid("636db893-8095-e668-b125-723f716e9a17"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(5570), 2, new DateOnly(2023, 6, 8), null },
                    { new Guid("14604d4e-cfff-44f1-4622-17356e4a223b"), new Guid("1ce609a7-ae52-102a-a5f1-b4552c69f6b2"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(5580), 1, new DateOnly(2019, 9, 12), null },
                    { new Guid("1b0007a5-6657-d25b-dca3-f0276d84d81a"), new Guid("aa245c06-f7c7-209e-012d-7e75d55ad827"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(5780), 1, new DateOnly(2020, 5, 30), null },
                    { new Guid("1ec52563-f95d-def2-d06e-9d43dfb042aa"), new Guid("0f8219bd-b3a4-f8f8-eb07-3c4cce1d8772"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(5730), 1, new DateOnly(2024, 4, 1), null },
                    { new Guid("5b406dd3-72a6-4483-7f4a-bb2840b9da88"), new Guid("406dd318-a65b-8372-447f-4abb2840b9da"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(5480), 1, new DateOnly(2019, 4, 30), null },
                    { new Guid("5baf3ebc-601f-91aa-3df6-fbac8f946cf6"), new Guid("3b224a6e-0a41-5242-f08e-b39184bc7b8c"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(5610), 2, new DateOnly(2023, 12, 23), null },
                    { new Guid("5c06a71f-aa24-f7c7-9e20-012d7e75d55a"), new Guid("275483e8-22f6-efe3-a385-7a8316ac6325"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(5750), 1, new DateOnly(2020, 4, 22), null },
                    { new Guid("68809563-b1e6-7225-3f71-6e9a17e1a709"), new Guid("46b5cfae-25c5-3042-b6b5-bd2e17165309"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(5550), 1, new DateOnly(2022, 6, 1), null },
                    { new Guid("69da26f1-a5f5-fabd-9aaf-54f16956d89b"), new Guid("69da26f1-a5f5-fabd-9aaf-54f16956d89b"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(3980), 2, new DateOnly(2021, 2, 14), null },
                    { new Guid("6baeedfe-ba07-25bd-08d1-7d1b1c051569"), new Guid("796c8985-90df-7f8a-025b-e7338fe32253"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(5670), 2, new DateOnly(2021, 10, 6), null },
                    { new Guid("77dc989e-027b-8482-6695-2fe6ed8e7896"), new Guid("0dfdcfc0-a255-ea7f-66f9-feedae6b07ba"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(5690), 1, new DateOnly(2022, 5, 13), null },
                    { new Guid("7829fe08-0ab9-e5b2-8ab2-4233acf80c76"), new Guid("f2f95d1e-d0de-9d6e-43df-b042aa79031f"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(5760), 2, new DateOnly(2023, 7, 26), null },
                    { new Guid("78dfef53-bdd2-8219-0fa4-b3f8f8eb073c"), new Guid("7dd10825-1c1b-1505-699b-439e98dc777b"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(5710), 2, new DateOnly(2020, 4, 18), null },
                    { new Guid("8ef05242-91b3-bc84-7b8c-a1c199aabc8e"), new Guid("246d00ad-4e18-604d-14ff-cff144462217"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(5600), 1, new DateOnly(2023, 10, 30), null },
                    { new Guid("8f33e75b-22e3-8d53-c0cf-fd0d55a27fea"), new Guid("948facfb-f66c-d12a-28c0-99ce8f435364"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(5640), 2, new DateOnly(2024, 3, 22), null },
                    { new Guid("ac72871d-83e8-2754-f622-e3efa3857a83"), new Guid("95668482-e62f-8eed-7896-8b9153efdf78"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(5720), 1, new DateOnly(2021, 2, 17), null },
                    { new Guid("ce99c028-438f-6453-a285-896c79df908a"), new Guid("bcaa99c1-ba8e-bc98-3eaf-5b1f60aa913d"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(5630), 1, new DateOnly(2020, 10, 16), null },
                    { new Guid("fbeea6da-3eaa-141f-b46b-730920071166"), new Guid("b97829fe-b20a-8ae5-b242-33acf80c7663"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(5790), 2, new DateOnly(2020, 12, 25), null }
                });

            migrationBuilder.InsertData(
                table: "cultural_exchanges",
                columns: new[] { "id", "exchange_type", "member_id", "year" },
                values: new object[,]
                {
                    { new Guid("04e7d116-3eea-1987-6805-767c6dbbc265"), 1, new Guid("9879398d-b67e-7e3b-6be3-a0e08de81efd"), 2006 },
                    { new Guid("0ca2e30c-aefe-08fd-481c-cf6ca39b83ec"), 2, new Guid("9879398d-b67e-7e3b-6be3-a0e08de81efd"), 1995 },
                    { new Guid("10afdfbc-7aa6-5892-272e-ad76fa8b7458"), 1, new Guid("7be73992-5ccf-9b4f-a800-e507ca186c10"), 2020 },
                    { new Guid("176b6975-edc0-f665-bfdd-fafefd9dccc1"), 2, new Guid("9879398d-b67e-7e3b-6be3-a0e08de81efd"), 2019 },
                    { new Guid("1abcf8df-8004-c6a2-fa6d-a221c7161c82"), 2, new Guid("0dfdcfc0-a255-ea7f-66f9-feedae6b07ba"), 2005 },
                    { new Guid("2f5b9ecb-8115-38b5-e2a9-17555d16ae56"), 2, new Guid("9879398d-b67e-7e3b-6be3-a0e08de81efd"), 2013 },
                    { new Guid("35b38f2d-c913-f851-8e89-87ab1de43514"), 1, new Guid("d178f2df-6ab2-f9c4-1699-cfdd16cb1e5c"), 1996 },
                    { new Guid("3b01f798-639f-f734-5a58-75dc7b31219e"), 2, new Guid("7be73992-5ccf-9b4f-a800-e507ca186c10"), 2001 },
                    { new Guid("49f93e30-f7aa-c4d4-0cbc-0493df7e41d6"), 2, new Guid("7be73992-5ccf-9b4f-a800-e507ca186c10"), 2003 },
                    { new Guid("50d77f87-12c8-fce9-6288-958246734147"), 2, new Guid("7be73992-5ccf-9b4f-a800-e507ca186c10"), 2007 },
                    { new Guid("5c1ab41c-c061-f7d7-b568-b53bca72ecb2"), 1, new Guid("6c948fac-2af6-28d1-c099-ce8f435364a2"), 2000 },
                    { new Guid("63c16be3-f21b-29f4-34b1-686c82b7b12e"), 1, new Guid("7be73992-5ccf-9b4f-a800-e507ca186c10"), 2002 },
                    { new Guid("67ebfdae-4c16-87a2-a3d3-d0412978ac11"), 1, new Guid("6c948fac-2af6-28d1-c099-ce8f435364a2"), 2016 },
                    { new Guid("6915051c-439b-989e-dc77-7b0282846695"), 2, new Guid("9879398d-b67e-7e3b-6be3-a0e08de81efd"), 1993 },
                    { new Guid("73b7d591-c4a0-8b03-8b9e-6ce4283a36eb"), 2, new Guid("6c948fac-2af6-28d1-c099-ce8f435364a2"), 2013 },
                    { new Guid("78b53946-95e6-2b51-8df3-a33bbfcd4756"), 2, new Guid("6c948fac-2af6-28d1-c099-ce8f435364a2"), 2015 },
                    { new Guid("78f2df3c-b2d1-c46a-f916-99cfdd16cb1e"), 1, new Guid("9879398d-b67e-7e3b-6be3-a0e08de81efd"), 2000 },
                    { new Guid("7b26b95d-f22c-9376-b287-a9eb1f9e12cf"), 2, new Guid("e05164d4-a6cd-b794-88b7-2929712c5f4c"), 2021 },
                    { new Guid("88e380f1-e343-86de-522a-099284266847"), 1, new Guid("7be73992-5ccf-9b4f-a800-e507ca186c10"), 2010 },
                    { new Guid("8938cf30-b8a9-5d65-57bd-5e4a0a40c2bf"), 2, new Guid("0dfdcfc0-a255-ea7f-66f9-feedae6b07ba"), 2017 },
                    { new Guid("8c450bd1-4c33-5df9-d482-c75fb6f5f94b"), 2, new Guid("d178f2df-6ab2-f9c4-1699-cfdd16cb1e5c"), 2003 },
                    { new Guid("8f435055-c0f0-d66d-f800-59b9df40ad4d"), 2, new Guid("e05164d4-a6cd-b794-88b7-2929712c5f4c"), 1999 },
                    { new Guid("9291855b-2b58-3f4a-9b2b-9f5c6d708cac"), 2, new Guid("7be73992-5ccf-9b4f-a800-e507ca186c10"), 2011 },
                    { new Guid("94e27be1-f475-9368-da8a-4dacfca78b15"), 1, new Guid("e05164d4-a6cd-b794-88b7-2929712c5f4c"), 2006 },
                    { new Guid("9900b509-e1ce-a2eb-f3c8-2c6f7eec251e"), 2, new Guid("6c948fac-2af6-28d1-c099-ce8f435364a2"), 2007 },
                    { new Guid("a03e9180-f5d3-e7ef-4c78-fc8918009686"), 1, new Guid("9879398d-b67e-7e3b-6be3-a0e08de81efd"), 2010 },
                    { new Guid("a4356394-221e-c9a6-63c9-745a3f7e679e"), 2, new Guid("0dfdcfc0-a255-ea7f-66f9-feedae6b07ba"), 2003 },
                    { new Guid("a8f358bc-a80c-e9ea-55a3-b5e20507e5a9"), 1, new Guid("e05164d4-a6cd-b794-88b7-2929712c5f4c"), 2002 },
                    { new Guid("aa927297-f205-6318-4d57-635904a537b4"), 1, new Guid("0dfdcfc0-a255-ea7f-66f9-feedae6b07ba"), 1998 },
                    { new Guid("b90da4d8-94f9-dd01-2df9-142562c319dd"), 1, new Guid("6c948fac-2af6-28d1-c099-ce8f435364a2"), 2002 },
                    { new Guid("b9c997b5-96e5-627d-2ee2-a1b530ea76a3"), 2, new Guid("e05164d4-a6cd-b794-88b7-2929712c5f4c"), 2015 },
                    { new Guid("bcf67b57-7c44-4975-53d1-6c629a5f6987"), 2, new Guid("6c948fac-2af6-28d1-c099-ce8f435364a2"), 2003 },
                    { new Guid("bebe8445-12ef-801e-4ea2-c06c70ab2be1"), 2, new Guid("e05164d4-a6cd-b794-88b7-2929712c5f4c"), 1997 },
                    { new Guid("c1dc000e-cf71-c3dd-6993-4e1bfa40cfa3"), 1, new Guid("0dfdcfc0-a255-ea7f-66f9-feedae6b07ba"), 2012 },
                    { new Guid("c2ca0459-0d89-b82c-2534-b0d834c08cc0"), 1, new Guid("0dfdcfc0-a255-ea7f-66f9-feedae6b07ba"), 2018 },
                    { new Guid("c3a3a911-0a94-2268-6fef-54043339ec43"), 1, new Guid("e05164d4-a6cd-b794-88b7-2929712c5f4c"), 2018 },
                    { new Guid("c4a6815a-b190-e055-e6f1-291fe904a131"), 2, new Guid("9879398d-b67e-7e3b-6be3-a0e08de81efd"), 2005 },
                    { new Guid("d03590a2-339f-5c04-0365-9cced53d1fdf"), 1, new Guid("e05164d4-a6cd-b794-88b7-2929712c5f4c"), 2012 },
                    { new Guid("d7dfef6c-2d45-f6f4-e9a3-6c05b51cfb6a"), 2, new Guid("7be73992-5ccf-9b4f-a800-e507ca186c10"), 2015 },
                    { new Guid("e4d74a5c-87cc-fe98-380f-cf7233758bb8"), 2, new Guid("6c948fac-2af6-28d1-c099-ce8f435364a2"), 2001 },
                    { new Guid("e882d35e-0616-07cf-f4b5-d2178907cd9a"), 1, new Guid("e05164d4-a6cd-b794-88b7-2929712c5f4c"), 1994 },
                    { new Guid("f6cfbc48-e110-8eb2-6c54-e60a7463f065"), 1, new Guid("d178f2df-6ab2-f9c4-1699-cfdd16cb1e5c"), 1994 },
                    { new Guid("f6e7f03a-e8b0-4b6e-0912-7c808b81abfb"), 1, new Guid("d178f2df-6ab2-f9c4-1699-cfdd16cb1e5c"), 2016 },
                    { new Guid("f8b3a40f-ebf8-3c07-4cce-1d8772ace883"), 1, new Guid("6c948fac-2af6-28d1-c099-ce8f435364a2"), 1994 },
                    { new Guid("f966ea7f-edfe-6bae-07ba-bd2508d17d1b"), 2, new Guid("d178f2df-6ab2-f9c4-1699-cfdd16cb1e5c"), 1993 },
                    { new Guid("fef0d890-db5c-01be-baba-6401ede84665"), 1, new Guid("d178f2df-6ab2-f9c4-1699-cfdd16cb1e5c"), 2020 }
                });

            migrationBuilder.InsertData(
                table: "members",
                columns: new[] { "id", "created_at", "email", "first_name", "joined_date", "last_name", "membership_id", "phone_number", "updated_at" },
                values: new object[,]
                {
                    { new Guid("1751221e-6ed4-de23-352a-f666e84b0e4c"), new DateTime(2024, 9, 1, 4, 1, 14, 982, DateTimeKind.Utc).AddTicks(1060), "Llewellyn.Wolff64@hotmail.com", "Dallin", new DateOnly(2020, 12, 25), "Rice", new Guid("fbeea6da-3eaa-141f-b46b-730920071166"), "8228789217", null },
                    { new Guid("1b0007a5-6657-d25b-dca3-f0276d84d81a"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(9280), "Yasmeen.Brakus48@hotmail.com", "Eda", new DateOnly(2023, 6, 8), "Friesen", new Guid("102aae52-f1a5-55b4-2c69-f6b2d0ad006d"), "5817609729", null },
                    { new Guid("1ce609a7-ae52-102a-a5f1-b4552c69f6b2"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(8740), "Adan_Schroeder52@hotmail.com", "Carrie", new DateOnly(2021, 2, 14), "Balistreri", new Guid("69da26f1-a5f5-fabd-9aaf-54f16956d89b"), "2453176918", null },
                    { new Guid("22b3e2cf-0e39-9424-a1b3-96e1a6137aaf"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(9700), "Einar_Cassin@gmail.com", "Adalberto", new DateOnly(2023, 12, 23), "Fadel", new Guid("5baf3ebc-601f-91aa-3df6-fbac8f946cf6"), "7684835384", null },
                    { new Guid("2545a485-bd29-8d46-5511-418d1abd50ff"), new DateTime(2024, 9, 1, 4, 1, 14, 982, DateTimeKind.Utc).AddTicks(210), "Angelica95@yahoo.com", "Aliza", new DateOnly(2021, 10, 6), "McKenzie", new Guid("6baeedfe-ba07-25bd-08d1-7d1b1c051569"), "8739036729", null },
                    { new Guid("2eeab11a-85eb-f3b3-e597-f27bfe661cae"), new DateTime(2024, 9, 1, 4, 1, 14, 982, DateTimeKind.Utc).AddTicks(420), "Dortha_Jacobi@gmail.com", "Raphael", new DateOnly(2020, 4, 18), "Jacobs", new Guid("78dfef53-bdd2-8219-0fa4-b3f8f8eb073c"), "7178818103", null },
                    { new Guid("36d56121-9fd8-6b08-7635-0e3a3dfb9be7"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(9950), "Onie.Pollich@gmail.com", "Ramona", new DateOnly(2024, 3, 22), "Hand", new Guid("8f33e75b-22e3-8d53-c0cf-fd0d55a27fea"), "6348912090", null },
                    { new Guid("3b224a6e-0a41-5242-f08e-b39184bc7b8c"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(8860), "Garnet.Lueilwitz85@hotmail.com", "Ollie", new DateOnly(2019, 4, 30), "Nader", new Guid("5b406dd3-72a6-4483-7f4a-bb2840b9da88"), "6017148489", null },
                    { new Guid("45871433-95dc-3f32-43f3-330dc5ddccc6"), new DateTime(2024, 9, 1, 4, 1, 14, 982, DateTimeKind.Utc).AddTicks(360), "Josianne82@hotmail.com", "Obie", new DateOnly(2020, 4, 18), "Bednar", new Guid("78dfef53-bdd2-8219-0fa4-b3f8f8eb073c"), "9464429752", null },
                    { new Guid("50b1399b-1b66-6732-adf6-a6620ee0bd87"), new DateTime(2024, 9, 1, 4, 1, 14, 982, DateTimeKind.Utc).AddTicks(170), "Janis31@yahoo.com", "Alexandre", new DateOnly(2021, 10, 6), "Kozey", new Guid("6baeedfe-ba07-25bd-08d1-7d1b1c051569"), "2159193542", null },
                    { new Guid("53ef3e4c-a09d-83bf-3379-dcc2793f72ba"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(9540), "Joshua.Jerde@yahoo.com", "Kiana", new DateOnly(2023, 10, 30), "Grimes", new Guid("8ef05242-91b3-bc84-7b8c-a1c199aabc8e"), "6568295041", null },
                    { new Guid("5c07cd32-b743-432a-e78d-543ee429115c"), new DateTime(2024, 9, 1, 4, 1, 14, 982, DateTimeKind.Utc).AddTicks(680), "Rowan7@hotmail.com", "Eugenia", new DateOnly(2020, 4, 22), "Langosh", new Guid("5c06a71f-aa24-f7c7-9e20-012d7e75d55a"), "6305365805", null },
                    { new Guid("68a8c93e-f238-c740-f9ba-81c0d1fe64c3"), new DateTime(2024, 9, 1, 4, 1, 14, 982, DateTimeKind.Utc).AddTicks(590), "Ethan_Huel69@yahoo.com", "Zaria", new DateOnly(2024, 4, 1), "Purdy", new Guid("1ec52563-f95d-def2-d06e-9d43dfb042aa"), "5217064750", null },
                    { new Guid("6a31f9e4-e30c-0ca2-feae-fd08481ccf6c"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(9780), "Bryce.OKeefe@gmail.com", "Xander", new DateOnly(2023, 12, 23), "Kuphal", new Guid("5baf3ebc-601f-91aa-3df6-fbac8f946cf6"), "3882428689", null },
                    { new Guid("73bc97cc-36b3-e260-45b9-90b332617070"), new DateTime(2024, 9, 1, 4, 1, 14, 982, DateTimeKind.Utc).AddTicks(740), "Nathanial72@hotmail.com", "Forrest", new DateOnly(2023, 7, 26), "Turcotte", new Guid("7829fe08-0ab9-e5b2-8ab2-4233acf80c76"), "7406711458", null },
                    { new Guid("783b89fd-f562-2d70-0168-cb610b38e5ff"), new DateTime(2024, 9, 1, 4, 1, 14, 982, DateTimeKind.Utc).AddTicks(290), "Curt.Keeling85@hotmail.com", "Demarcus", new DateOnly(2022, 5, 13), "Volkman", new Guid("77dc989e-027b-8482-6695-2fe6ed8e7896"), "3924891329", null },
                    { new Guid("95668482-e62f-8eed-7896-8b9153efdf78"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(9080), "Caroline.Oberbrunner26@hotmail.com", "Jacey", new DateOnly(2022, 6, 1), "Windler", new Guid("68809563-b1e6-7225-3f71-6e9a17e1a709"), "5119523101", null },
                    { new Guid("96d1e707-b5ce-4c34-d5b3-a9298f03e339"), new DateTime(2024, 9, 1, 4, 1, 14, 982, DateTimeKind.Utc), "Sallie14@yahoo.com", "Gerry", new DateOnly(2024, 3, 22), "Mueller", new Guid("8f33e75b-22e3-8d53-c0cf-fd0d55a27fea"), "7958983393", null },
                    { new Guid("976dfac1-c26d-e3e3-2643-e4ea668e0933"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(9860), "Margarete.DuBuque40@yahoo.com", "Marjorie", new DateOnly(2020, 10, 16), "Boehm", new Guid("ce99c028-438f-6453-a285-896c79df908a"), "2216394905", null },
                    { new Guid("a0795d3b-e6d1-3837-28cb-c933c2ee054f"), new DateTime(2024, 9, 1, 4, 1, 14, 982, DateTimeKind.Utc).AddTicks(790), "Brendon.Stehr39@hotmail.com", "Alexandra", new DateOnly(2023, 7, 26), "Feest", new Guid("7829fe08-0ab9-e5b2-8ab2-4233acf80c76"), "4334537769", null },
                    { new Guid("a210e2ac-d12b-742b-fce8-6a94df67c8d7"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(9740), "David_Barton@gmail.com", "Rae", new DateOnly(2023, 12, 23), "Marvin", new Guid("5baf3ebc-601f-91aa-3df6-fbac8f946cf6"), "3183608635", null },
                    { new Guid("b95900f8-40df-4dad-9655-cb676b5d9bda"), new DateTime(2024, 9, 1, 4, 1, 14, 982, DateTimeKind.Utc).AddTicks(980), "Conrad_Watsica@gmail.com", "Claudine", new DateOnly(2020, 12, 25), "Schroeder", new Guid("fbeea6da-3eaa-141f-b46b-730920071166"), "6803511365", null },
                    { new Guid("bd079070-1243-e8ce-216c-2eb1eab1f256"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(9630), "Sierra.OConner54@yahoo.com", "Keven", new DateOnly(2023, 12, 23), "Stamm", new Guid("5baf3ebc-601f-91aa-3df6-fbac8f946cf6"), "7173954237", null },
                    { new Guid("c24a3b4c-4605-1cd2-b41a-5c61c0d7f7b5"), new DateTime(2024, 9, 1, 4, 1, 14, 982, DateTimeKind.Utc).AddTicks(1020), "Aliza_McGlynn69@yahoo.com", "Teresa", new DateOnly(2020, 12, 25), "Hills", new Guid("fbeea6da-3eaa-141f-b46b-730920071166"), "5466050183", null },
                    { new Guid("c546b5cf-4225-b630-b5bd-2e1716530958"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(8660), "Dana2@gmail.com", "Vivien", new DateOnly(2021, 2, 14), "O'Conner", new Guid("69da26f1-a5f5-fabd-9aaf-54f16956d89b"), "3783196633", null },
                    { new Guid("c7aa245c-9ef7-0120-2d7e-75d55ad82708"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(9230), "Delilah_Schmidt@yahoo.com", "Nona", new DateOnly(2023, 6, 8), "DuBuque", new Guid("102aae52-f1a5-55b4-2c69-f6b2d0ad006d"), "9909957288", null },
                    { new Guid("c91335b3-f851-898e-87ab-1de435147f20"), new DateTime(2024, 9, 1, 4, 1, 14, 982, DateTimeKind.Utc).AddTicks(40), "Hudson34@yahoo.com", "Pearline", new DateOnly(2024, 3, 22), "Schiller", new Guid("8f33e75b-22e3-8d53-c0cf-fd0d55a27fea"), "6547935924", null },
                    { new Guid("ccf1bb8e-f7b3-92ec-6e53-6c5a7197afc4"), new DateTime(2024, 9, 1, 4, 1, 14, 982, DateTimeKind.Utc).AddTicks(530), "Kiera.Bins@yahoo.com", "Rozella", new DateOnly(2021, 2, 17), "Hodkiewicz", new Guid("ac72871d-83e8-2754-f622-e3efa3857a83"), "7996732418", null },
                    { new Guid("d0cddb9a-806f-0873-2384-5a34ee407ed7"), new DateTime(2024, 9, 1, 4, 1, 14, 982, DateTimeKind.Utc).AddTicks(80), "Nathanial24@yahoo.com", "Don", new DateOnly(2024, 3, 22), "Bergnaum", new Guid("8f33e75b-22e3-8d53-c0cf-fd0d55a27fea"), "4163086848", null },
                    { new Guid("d0f604f6-5b65-7852-f455-801023334a1b"), new DateTime(2024, 9, 1, 4, 1, 14, 982, DateTimeKind.Utc).AddTicks(860), "Graham85@yahoo.com", "Carley", new DateOnly(2020, 5, 30), "Wilderman", new Guid("1b0007a5-6657-d25b-dca3-f0276d84d81a"), "6022905417", null },
                    { new Guid("e12bab70-7297-aa92-05f2-18634d576359"), new DateTime(2024, 9, 1, 4, 1, 14, 982, DateTimeKind.Utc).AddTicks(460), "Jazlyn_Hane97@yahoo.com", "Ethelyn", new DateOnly(2020, 4, 18), "Kreiger", new Guid("78dfef53-bdd2-8219-0fa4-b3f8f8eb073c"), "3387959898", null },
                    { new Guid("ec26d1b4-c3a7-e61d-2e0f-f56345be5a92"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(9320), "Sebastian9@yahoo.com", "Delpha", new DateOnly(2023, 6, 8), "Koepp", new Guid("102aae52-f1a5-55b4-2c69-f6b2d0ad006d"), "5429173057", null },
                    { new Guid("f407cf06-d2b5-8917-07cd-9a48bccff610"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(9400), "Catharine84@yahoo.com", "Jade", new DateOnly(2019, 9, 12), "Senger", new Guid("14604d4e-cfff-44f1-4622-17356e4a223b"), "4839711940", null },
                    { new Guid("f569da26-bda5-9afa-af54-f16956d89b62"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(8150), "Kayden.Weimann60@gmail.com", "Garnett", new DateOnly(2021, 2, 14), "Reichel", new Guid("69da26f1-a5f5-fabd-9aaf-54f16956d89b"), "2648695004", null },
                    { new Guid("f6275483-e322-a3ef-857a-8316ac6325c5"), new DateTime(2024, 9, 1, 4, 1, 14, 981, DateTimeKind.Utc).AddTicks(9180), "Trycia.Beer2@yahoo.com", "Lavina", new DateOnly(2023, 6, 8), "Wilkinson", new Guid("102aae52-f1a5-55b4-2c69-f6b2d0ad006d"), "5902509535", null }
                });

            migrationBuilder.InsertData(
                table: "membership_dues",
                columns: new[] { "id", "amount_paid", "membership_id", "payment_date", "payment_method", "year" },
                values: new object[,]
                {
                    { new Guid("0b61cb68-e538-b6ff-3061-492624dae5af"), 20, new Guid("ac72871d-83e8-2754-f622-e3efa3857a83"), new DateOnly(2021, 11, 11), 1, 2022 },
                    { new Guid("0ca2e30c-aefe-08fd-481c-cf6ca39b83ec"), 20, new Guid("ce99c028-438f-6453-a285-896c79df908a"), new DateOnly(2021, 7, 14), 2, 2023 },
                    { new Guid("0d33f343-ddc5-c6cc-5d18-5df9d8af55c8"), 20, new Guid("5c06a71f-aa24-f7c7-9e20-012d7e75d55a"), new DateOnly(2020, 5, 1), 1, 2020 },
                    { new Guid("0e3922b3-9424-b3a1-96e1-a6137aaf0f74"), 30, new Guid("5baf3ebc-601f-91aa-3df6-fbac8f946cf6"), new DateOnly(2024, 2, 2), 1, 2024 },
                    { new Guid("107afa2b-97c7-6d9a-1d33-148745dc9532"), 20, new Guid("ac72871d-83e8-2754-f622-e3efa3857a83"), new DateOnly(2022, 1, 23), 1, 2023 },
                    { new Guid("1129e43e-455c-6d9a-980b-1183c3762167"), 20, new Guid("1b0007a5-6657-d25b-dca3-f0276d84d81a"), new DateOnly(2021, 1, 27), 2, 2024 },
                    { new Guid("1243bd07-e8ce-6c21-2eb1-eab1f2564d0a"), 20, new Guid("8ef05242-91b3-bc84-7b8c-a1c199aabc8e"), new DateOnly(2024, 6, 23), 2, 2023 },
                    { new Guid("1b0007a5-6657-d25b-dca3-f0276d84d81a"), 30, new Guid("102aae52-f1a5-55b4-2c69-f6b2d0ad006d"), new DateOnly(2024, 2, 16), 1, 2023 },
                    { new Guid("1ce609a7-ae52-102a-a5f1-b4552c69f6b2"), 20, new Guid("5b406dd3-72a6-4483-7f4a-bb2840b9da88"), new DateOnly(2019, 5, 24), 1, 2020 },
                    { new Guid("1e899099-c02a-dc0d-527d-d6fa6ab53dcf"), 30, new Guid("5baf3ebc-601f-91aa-3df6-fbac8f946cf6"), new DateOnly(2024, 3, 13), 1, 2023 },
                    { new Guid("20c27cf3-92c4-c490-6d05-5c7f720d3b70"), 20, new Guid("14604d4e-cfff-44f1-4622-17356e4a223b"), new DateOnly(2020, 8, 31), 3, 2024 },
                    { new Guid("246d00ad-4e18-604d-14ff-cff144462217"), 20, new Guid("5b406dd3-72a6-4483-7f4a-bb2840b9da88"), new DateOnly(2020, 3, 1), 3, 2021 },
                    { new Guid("26e3e3c2-e443-66ea-8e09-336b058ed355"), 30, new Guid("8f33e75b-22e3-8d53-c0cf-fd0d55a27fea"), new DateOnly(2024, 11, 18), 3, 2024 },
                    { new Guid("2bd12ba2-fc74-6ae8-94df-67c8d7cec786"), 20, new Guid("ce99c028-438f-6453-a285-896c79df908a"), new DateOnly(2020, 12, 20), 1, 2021 },
                    { new Guid("3b20fd96-995e-d652-4e7b-9adbcdd06f80"), 20, new Guid("77dc989e-027b-8482-6695-2fe6ed8e7896"), new DateOnly(2022, 11, 22), 1, 2024 },
                    { new Guid("3b224a6e-0a41-5242-f08e-b39184bc7b8c"), 20, new Guid("5b406dd3-72a6-4483-7f4a-bb2840b9da88"), new DateOnly(2020, 1, 1), 3, 2022 },
                    { new Guid("406dd318-a65b-8372-447f-4abb2840b9da"), 30, new Guid("69da26f1-a5f5-fabd-9aaf-54f16956d89b"), new DateOnly(2022, 1, 22), 1, 2022 },
                    { new Guid("46b5cfae-25c5-3042-b6b5-bd2e17165309"), 30, new Guid("69da26f1-a5f5-fabd-9aaf-54f16956d89b"), new DateOnly(2021, 12, 13), 2, 2023 },
                    { new Guid("4e801e12-c0a2-706c-ab2b-e1977292aa05"), 20, new Guid("5c06a71f-aa24-f7c7-9e20-012d7e75d55a"), new DateOnly(2021, 2, 11), 2, 2023 },
                    { new Guid("4f05eec2-458a-009b-c58a-ab4c788e91e6"), 30, new Guid("fbeea6da-3eaa-141f-b46b-730920071166"), new DateOnly(2021, 5, 10), 2, 2023 },
                    { new Guid("574d6318-5963-a504-37b4-8b28d42c2c6f"), 20, new Guid("5c06a71f-aa24-f7c7-9e20-012d7e75d55a"), new DateOnly(2021, 4, 2), 1, 2024 },
                    { new Guid("5a842308-ee34-7e40-d77a-2462bfbdbe38"), 30, new Guid("78dfef53-bdd2-8219-0fa4-b3f8f8eb073c"), new DateOnly(2020, 12, 29), 1, 2020 },
                    { new Guid("5b92151f-3123-c93e-a868-38f240c7f9ba"), 20, new Guid("1b0007a5-6657-d25b-dca3-f0276d84d81a"), new DateOnly(2020, 11, 9), 3, 2021 },
                    { new Guid("636db893-8095-e668-b125-723f716e9a17"), 20, new Guid("5b406dd3-72a6-4483-7f4a-bb2840b9da88"), new DateOnly(2019, 12, 7), 2, 2019 },
                    { new Guid("64fed1c0-cfc3-edf7-8a26-2d46e4f2168b"), 20, new Guid("1b0007a5-6657-d25b-dca3-f0276d84d81a"), new DateOnly(2021, 1, 2), 1, 2022 },
                    { new Guid("69da26f1-a5f5-fabd-9aaf-54f16956d89b"), 30, new Guid("69da26f1-a5f5-fabd-9aaf-54f16956d89b"), new DateOnly(2021, 9, 4), 3, 2021 },
                    { new Guid("6b089fd8-3576-3a0e-3dfb-9be7c644bed3"), 30, new Guid("6baeedfe-ba07-25bd-08d1-7d1b1c051569"), new DateOnly(2022, 2, 22), 3, 2022 },
                    { new Guid("6fe89242-26d7-d802-a929-5641d2e4f931"), 20, new Guid("ce99c028-438f-6453-a285-896c79df908a"), new DateOnly(2020, 12, 18), 2, 2022 },
                    { new Guid("706132b3-3770-8941-b01d-214a43e52250"), 30, new Guid("fbeea6da-3eaa-141f-b46b-730920071166"), new DateOnly(2021, 2, 25), 3, 2021 },
                    { new Guid("72e6ab73-fcdc-3536-7b6a-4a72c3fcace2"), 20, new Guid("ce99c028-438f-6453-a285-896c79df908a"), new DateOnly(2020, 10, 26), 1, 2020 },
                    { new Guid("7cccc3fd-798e-1fa7-fd89-3b7862f5702d"), 20, new Guid("ac72871d-83e8-2754-f622-e3efa3857a83"), new DateOnly(2021, 12, 23), 1, 2021 },
                    { new Guid("80bc9b92-5daa-fbc2-42b1-f05ed382e816"), 20, new Guid("14604d4e-cfff-44f1-4622-17356e4a223b"), new DateOnly(2019, 11, 30), 3, 2020 },
                    { new Guid("8add7cfa-a876-97cc-bc73-b33660e245b9"), 30, new Guid("fbeea6da-3eaa-141f-b46b-730920071166"), new DateOnly(2021, 11, 29), 1, 2020 },
                    { new Guid("8d411155-bd1a-ff50-a8d1-066040abbe95"), 30, new Guid("78dfef53-bdd2-8219-0fa4-b3f8f8eb073c"), new DateOnly(2020, 5, 7), 3, 2024 },
                    { new Guid("9275d351-9a56-fef9-652d-8fb33513c951"), 20, new Guid("77dc989e-027b-8482-6695-2fe6ed8e7896"), new DateOnly(2022, 9, 27), 2, 2022 },
                    { new Guid("948facfb-f66c-d12a-28c0-99ce8f435364"), 20, new Guid("5b406dd3-72a6-4483-7f4a-bb2840b9da88"), new DateOnly(2020, 4, 28), 3, 2024 },
                    { new Guid("96739472-31f4-8e0e-bbf1-ccb3f7ec926e"), 30, new Guid("7829fe08-0ab9-e5b2-8ab2-4233acf80c76"), new DateOnly(2024, 2, 2), 1, 2023 },
                    { new Guid("97715a6c-c4af-a97b-6a0b-e147d6feb527"), 20, new Guid("1b0007a5-6657-d25b-dca3-f0276d84d81a"), new DateOnly(2020, 8, 29), 3, 2020 },
                    { new Guid("a09d53ef-83bf-7933-dcc2-793f72badf7d"), 20, new Guid("14604d4e-cfff-44f1-4622-17356e4a223b"), new DateOnly(2019, 12, 15), 2, 2023 },
                    { new Guid("a1f91aba-04cb-53ce-cbd2-9128c1fa6d97"), 20, new Guid("ce99c028-438f-6453-a285-896c79df908a"), new DateOnly(2020, 12, 6), 1, 2024 },
                    { new Guid("a35f8ed0-0482-6d0e-1108-7e8707e7d196"), 30, new Guid("6baeedfe-ba07-25bd-08d1-7d1b1c051569"), new DateOnly(2022, 2, 15), 2, 2023 },
                    { new Guid("a6f6ad67-0e62-bde0-871f-2e748ebedca3"), 30, new Guid("78dfef53-bdd2-8219-0fa4-b3f8f8eb073c"), new DateOnly(2020, 7, 16), 1, 2022 },
                    { new Guid("aa245c06-f7c7-209e-012d-7e75d55ad827"), 20, new Guid("68809563-b1e6-7225-3f71-6e9a17e1a709"), new DateOnly(2022, 8, 10), 1, 2023 },
                    { new Guid("ab87898e-e41d-1435-7f20-d59ba570d17b"), 20, new Guid("77dc989e-027b-8482-6695-2fe6ed8e7896"), new DateOnly(2022, 12, 19), 2, 2023 },
                    { new Guid("b5f407cf-17d2-0789-cd9a-48bccff610e1"), 20, new Guid("14604d4e-cfff-44f1-4622-17356e4a223b"), new DateOnly(2019, 10, 21), 3, 2021 },
                    { new Guid("b64fa352-33d8-864f-6585-a4452529bd46"), 30, new Guid("78dfef53-bdd2-8219-0fa4-b3f8f8eb073c"), new DateOnly(2020, 10, 18), 1, 2023 },
                    { new Guid("b97829fe-b20a-8ae5-b242-33acf80c7663"), 20, new Guid("68809563-b1e6-7225-3f71-6e9a17e1a709"), new DateOnly(2022, 9, 4), 3, 2024 },
                    { new Guid("bcaa99c1-ba8e-bc98-3eaf-5b1f60aa913d"), 20, new Guid("5b406dd3-72a6-4483-7f4a-bb2840b9da88"), new DateOnly(2019, 10, 23), 3, 2023 },
                    { new Guid("bd30cc7d-f02f-d434-ce69-9b39b150661b"), 30, new Guid("78dfef53-bdd2-8219-0fa4-b3f8f8eb073c"), new DateOnly(2020, 8, 2), 2, 2021 },
                    { new Guid("c509da99-f6eb-f604-d065-5b5278f45580"), 30, new Guid("fbeea6da-3eaa-141f-b46b-730920071166"), new DateOnly(2021, 11, 13), 2, 2024 },
                    { new Guid("c938df2a-df40-b8d4-32db-6cdf862161d5"), 30, new Guid("6baeedfe-ba07-25bd-08d1-7d1b1c051569"), new DateOnly(2022, 6, 14), 3, 2021 },
                    { new Guid("caaf6b49-3bc7-795d-a0d1-e6373828cbc9"), 30, new Guid("fbeea6da-3eaa-141f-b46b-730920071166"), new DateOnly(2021, 11, 2), 2, 2022 },
                    { new Guid("d54c34b5-a9b3-8f29-03e3-39d16b97ad0b"), 30, new Guid("6baeedfe-ba07-25bd-08d1-7d1b1c051569"), new DateOnly(2021, 12, 16), 1, 2024 },
                    { new Guid("e6546c8e-740a-f063-6511-2d885a8d0d4c"), 20, new Guid("14604d4e-cfff-44f1-4622-17356e4a223b"), new DateOnly(2020, 6, 9), 2, 2022 },
                    { new Guid("ec26d1b4-c3a7-e61d-2e0f-f56345be5a92"), 20, new Guid("14604d4e-cfff-44f1-4622-17356e4a223b"), new DateOnly(2020, 4, 1), 1, 2019 },
                    { new Guid("eea6da7a-aafb-1f3e-14b4-6b7309200711"), 30, new Guid("102aae52-f1a5-55b4-2c69-f6b2d0ad006d"), new DateOnly(2024, 1, 19), 3, 2024 },
                    { new Guid("f0b276c9-33a0-9dc7-1ab1-ea2eeb85b3f3"), 20, new Guid("5c06a71f-aa24-f7c7-9e20-012d7e75d55a"), new DateOnly(2021, 4, 2), 3, 2021 },
                    { new Guid("f2f95d1e-d0de-9d6e-43df-b042aa79031f"), 20, new Guid("68809563-b1e6-7225-3f71-6e9a17e1a709"), new DateOnly(2022, 11, 2), 2, 2022 },
                    { new Guid("f7dc7ccd-2949-cd32-075c-43b72a43e78d"), 20, new Guid("1b0007a5-6657-d25b-dca3-f0276d84d81a"), new DateOnly(2020, 7, 13), 2, 2023 },
                    { new Guid("fe7bf297-1c66-4aae-697f-3c744584bebe"), 20, new Guid("5c06a71f-aa24-f7c7-9e20-012d7e75d55a"), new DateOnly(2020, 4, 24), 1, 2022 }
                });

            migrationBuilder.InsertData(
                table: "cultural_exchanges",
                columns: new[] { "id", "exchange_type", "member_id", "year" },
                values: new object[,]
                {
                    { new Guid("00e0c955-6d78-9f64-5029-c65adbbb2926"), 2, new Guid("2545a485-bd29-8d46-5511-418d1abd50ff"), 2007 },
                    { new Guid("010622a8-6535-c065-a24c-3b4ac20546d2"), 1, new Guid("3b224a6e-0a41-5242-f08e-b39184bc7b8c"), 2000 },
                    { new Guid("0134a3b9-08dc-7fe3-4f88-4bc5e26eda26"), 2, new Guid("36d56121-9fd8-6b08-7635-0e3a3dfb9be7"), 2015 },
                    { new Guid("04f30ef8-c32e-d434-ead0-4f3d2ae08924"), 2, new Guid("c7aa245c-9ef7-0120-2d7e-75d55ad82708"), 2021 },
                    { new Guid("056f1505-a681-6ef2-1b1f-31043eac0c56"), 2, new Guid("976dfac1-c26d-e3e3-2643-e4ea668e0933"), 2009 },
                    { new Guid("05f9c833-928d-097b-c70a-e76bdeff6132"), 2, new Guid("a210e2ac-d12b-742b-fce8-6a94df67c8d7"), 2019 },
                    { new Guid("07a56e63-1b00-6657-5bd2-dca3f0276d84"), 1, new Guid("e12bab70-7297-aa92-05f2-18634d576359"), 1994 },
                    { new Guid("07cd3229-435c-2ab7-43e7-8d543ee42911"), 1, new Guid("ccf1bb8e-f7b3-92ec-6e53-6c5a7197afc4"), 1998 },
                    { new Guid("08f924ce-d022-d96b-e3e9-252316ddb0c1"), 2, new Guid("96d1e707-b5ce-4c34-d5b3-a9298f03e339"), 2023 },
                    { new Guid("09b49fb9-f420-52e0-e3fa-f2eb36b27842"), 1, new Guid("45871433-95dc-3f32-43f3-330dc5ddccc6"), 2016 },
                    { new Guid("09bcba95-b157-2f0e-c206-0ae25cf26969"), 2, new Guid("95668482-e62f-8eed-7896-8b9153efdf78"), 2017 },
                    { new Guid("09da99f5-ebc5-04f6-f6d0-655b5278f455"), 2, new Guid("96d1e707-b5ce-4c34-d5b3-a9298f03e339"), 1999 },
                    { new Guid("0aee6a86-0236-219a-96fb-3892f7685c4b"), 2, new Guid("a210e2ac-d12b-742b-fce8-6a94df67c8d7"), 2011 },
                    { new Guid("0b61cb68-e538-b6ff-3061-492624dae5af"), 2, new Guid("e12bab70-7297-aa92-05f2-18634d576359"), 1997 },
                    { new Guid("0eb6c672-2c86-968e-3eb6-927e7e33976c"), 1, new Guid("68a8c93e-f238-c740-f9ba-81c0d1fe64c3"), 2010 },
                    { new Guid("0f181dee-0557-65e9-bb2b-2ce2a8323e24"), 2, new Guid("1ce609a7-ae52-102a-a5f1-b4552c69f6b2"), 2009 },
                    { new Guid("1371ce6a-ded5-6b76-fece-aea5125c43d2"), 2, new Guid("6a31f9e4-e30c-0ca2-feae-fd08481ccf6c"), 2003 },
                    { new Guid("143e11d8-7ceb-045d-47f4-50b0e4ddd4da"), 1, new Guid("c7aa245c-9ef7-0120-2d7e-75d55ad82708"), 2020 },
                    { new Guid("15e34c96-c35a-4138-79d9-4c2362817bc1"), 1, new Guid("c91335b3-f851-898e-87ab-1de435147f20"), 2006 },
                    { new Guid("16771b0d-3811-2dd1-1b98-66d9cdf3a102"), 1, new Guid("68a8c93e-f238-c740-f9ba-81c0d1fe64c3"), 2006 },
                    { new Guid("16f38a82-ce3d-cbec-ebff-6ee244edf3f4"), 2, new Guid("b95900f8-40df-4dad-9655-cb676b5d9bda"), 2007 },
                    { new Guid("183cf96b-c141-51e2-ef4c-34bef4a95df7"), 1, new Guid("45871433-95dc-3f32-43f3-330dc5ddccc6"), 2006 },
                    { new Guid("18fdaf24-0c81-16db-24b2-90755b765ba9"), 1, new Guid("45871433-95dc-3f32-43f3-330dc5ddccc6"), 2018 },
                    { new Guid("1c671d67-f922-e4d9-459b-74282f750e16"), 1, new Guid("c7aa245c-9ef7-0120-2d7e-75d55ad82708"), 2004 },
                    { new Guid("1ec6ab67-0ab1-e12e-ecce-8b7ce1a08f57"), 2, new Guid("3b224a6e-0a41-5242-f08e-b39184bc7b8c"), 2017 },
                    { new Guid("1ed8e148-0d82-3510-d42d-597a071a09d4"), 2, new Guid("53ef3e4c-a09d-83bf-3379-dcc2793f72ba"), 2003 },
                    { new Guid("1f523c27-370f-a804-51c7-7374ad62c23d"), 2, new Guid("73bc97cc-36b3-e260-45b9-90b332617070"), 2011 },
                    { new Guid("20399707-bebd-ef0a-2a17-3e0ff72f5ea3"), 1, new Guid("1751221e-6ed4-de23-352a-f666e84b0e4c"), 2004 },
                    { new Guid("224644f1-3517-4a6e-223b-410a4252f08e"), 2, new Guid("45871433-95dc-3f32-43f3-330dc5ddccc6"), 1993 },
                    { new Guid("22f62754-efe3-85a3-7a83-16ac6325c51e"), 1, new Guid("f6275483-e322-a3ef-857a-8316ac6325c5"), 1994 },
                    { new Guid("26632b9c-0a7e-fc61-557d-33f0d63c8399"), 2, new Guid("96d1e707-b5ce-4c34-d5b3-a9298f03e339"), 2011 },
                    { new Guid("268aedf7-462d-f2e4-168b-81cd7cdcf749"), 1, new Guid("e12bab70-7297-aa92-05f2-18634d576359"), 1998 },
                    { new Guid("26e6cb0b-85e3-7f00-c108-c7a2ae820065"), 2, new Guid("36d56121-9fd8-6b08-7635-0e3a3dfb9be7"), 2017 },
                    { new Guid("28189805-30d1-ffe5-ad7c-2b26c4765160"), 1, new Guid("f407cf06-d2b5-8917-07cd-9a48bccff610"), 2012 },
                    { new Guid("291b39e2-4be3-9b90-5587-86ea29961ba1"), 1, new Guid("2545a485-bd29-8d46-5511-418d1abd50ff"), 2014 },
                    { new Guid("2a4055d3-38df-40c9-dfd4-b832db6cdf86"), 1, new Guid("22b3e2cf-0e39-9424-a1b3-96e1a6137aaf"), 1996 },
                    { new Guid("2abc6074-0701-c62f-1d05-304625881c9b"), 2, new Guid("976dfac1-c26d-e3e3-2643-e4ea668e0933"), 2019 },
                    { new Guid("2cd4288b-6f2c-72fc-9473-96f4310e8ebb"), 1, new Guid("1b0007a5-6657-d25b-dca3-f0276d84d81a"), 1998 },
                    { new Guid("2e2c1af4-c788-2dea-2d21-b3e251667f4b"), 2, new Guid("f6275483-e322-a3ef-857a-8316ac6325c5"), 2015 },
                    { new Guid("2f78e4b8-d933-e471-0627-227d0a506834"), 1, new Guid("36d56121-9fd8-6b08-7635-0e3a3dfb9be7"), 2022 },
                    { new Guid("30d327c0-bb27-155c-89ab-e7021e577bfb"), 1, new Guid("95668482-e62f-8eed-7896-8b9153efdf78"), 2014 },
                    { new Guid("319c885f-8af3-7098-9be9-6c57fab8d464"), 1, new Guid("36d56121-9fd8-6b08-7635-0e3a3dfb9be7"), 2000 },
                    { new Guid("33231080-1b4a-25bf-13ca-02b1b12d2843"), 2, new Guid("73bc97cc-36b3-e260-45b9-90b332617070"), 1999 },
                    { new Guid("3460644d-9e5d-e58d-86c6-dea6b1facfa0"), 2, new Guid("2eeab11a-85eb-f3b3-e597-f27bfe661cae"), 2001 },
                    { new Guid("35de236e-f62a-e866-4b0e-4cccaf29f62f"), 1, new Guid("976dfac1-c26d-e3e3-2643-e4ea668e0933"), 2000 },
                    { new Guid("3654e682-b8ab-6f48-9fd9-f28658bcd443"), 2, new Guid("c91335b3-f851-898e-87ab-1de435147f20"), 2001 },
                    { new Guid("36942673-7e43-cd2e-a259-dc3368c0adcf"), 1, new Guid("ec26d1b4-c3a7-e61d-2e0f-f56345be5a92"), 2014 },
                    { new Guid("36d56121-9fd8-6b08-7635-0e3a3dfb9be7"), 1, new Guid("783b89fd-f562-2d70-0168-cb610b38e5ff"), 1996 },
                    { new Guid("36fcdc72-7b35-4a6a-72c3-fcace210a22b"), 2, new Guid("5c07cd32-b743-432a-e78d-543ee429115c"), 1995 },
                    { new Guid("37707061-8941-1db0-214a-43e522506a49"), 2, new Guid("95668482-e62f-8eed-7896-8b9153efdf78"), 1999 },
                    { new Guid("3868a8c9-40f2-f9c7-ba81-c0d1fe64c3cf"), 1, new Guid("783b89fd-f562-2d70-0168-cb610b38e5ff"), 1998 },
                    { new Guid("398dedb8-9879-b67e-3b7e-6be3a0e08de8"), 2, new Guid("95668482-e62f-8eed-7896-8b9153efdf78"), 2001 },
                    { new Guid("3a33460d-e226-e39c-d4c3-ea64c5d8a683"), 1, new Guid("c91335b3-f851-898e-87ab-1de435147f20"), 2022 },
                    { new Guid("3c93d302-76ff-947e-80d8-7d9ecf82ea72"), 2, new Guid("5c07cd32-b743-432a-e78d-543ee429115c"), 2013 },
                    { new Guid("3ca53b00-e593-8fb1-3419-20d3edf2a3dd"), 1, new Guid("1b0007a5-6657-d25b-dca3-f0276d84d81a"), 2010 },
                    { new Guid("3d6db0d7-fc2d-7591-c4cb-25d8776b99d5"), 1, new Guid("f569da26-bda5-9afa-af54-f16956d89b62"), 2002 },
                    { new Guid("3f79c2dc-ba72-7ddf-20f3-7cc220c49290"), 2, new Guid("f6275483-e322-a3ef-857a-8316ac6325c5"), 1995 },
                    { new Guid("40b237e6-04a7-0ac0-788f-4a7faea31a30"), 1, new Guid("95668482-e62f-8eed-7896-8b9153efdf78"), 2016 },
                    { new Guid("4165356a-753a-b429-7aad-7a4fa4cdb52b"), 1, new Guid("2eeab11a-85eb-f3b3-e597-f27bfe661cae"), 2016 },
                    { new Guid("443851ed-9bf5-e80f-4b11-932f412eec15"), 2, new Guid("50b1399b-1b66-6732-adf6-a6620ee0bd87"), 2009 },
                    { new Guid("455c1588-3b01-70e4-c379-894ce6733346"), 2, new Guid("c7aa245c-9ef7-0120-2d7e-75d55ad82708"), 2005 },
                    { new Guid("45c8f26f-6e00-74d0-6375-a75fe394b8ab"), 1, new Guid("96d1e707-b5ce-4c34-d5b3-a9298f03e339"), 2022 },
                    { new Guid("468e5c39-1de6-440f-7594-ccf6cf977c11"), 2, new Guid("bd079070-1243-e8ce-216c-2eb1eab1f256"), 2005 },
                    { new Guid("47e10b6a-fed6-27b5-751f-15925b23313e"), 1, new Guid("c91335b3-f851-898e-87ab-1de435147f20"), 1998 },
                    { new Guid("48f1ba41-f4f1-71b2-9f94-cb166ab5e6d5"), 1, new Guid("a0795d3b-e6d1-3837-28cb-c933c2ee054f"), 2006 },
                    { new Guid("4b1cc8b4-cfda-bd96-17e5-0d5d03a9beb5"), 2, new Guid("45871433-95dc-3f32-43f3-330dc5ddccc6"), 2013 },
                    { new Guid("4bbba79a-b431-fa0c-7600-fa291c09376b"), 2, new Guid("c546b5cf-4225-b630-b5bd-2e1716530958"), 2015 },
                    { new Guid("4c2db69e-1694-7bb5-09f1-b5b9ceaa4b59"), 2, new Guid("2eeab11a-85eb-f3b3-e597-f27bfe661cae"), 2011 },
                    { new Guid("4c4fe32a-066d-c692-96bf-0aeb01ae420e"), 2, new Guid("f407cf06-d2b5-8917-07cd-9a48bccff610"), 2013 },
                    { new Guid("4f05eec2-458a-009b-c58a-ab4c788e91e6"), 2, new Guid("a210e2ac-d12b-742b-fce8-6a94df67c8d7"), 1999 },
                    { new Guid("4f33d8b6-6586-a485-4525-29bd468d5511"), 2, new Guid("783b89fd-f562-2d70-0168-cb610b38e5ff"), 1997 },
                    { new Guid("4f8db9c3-572e-7e3c-a1cc-8ec18137d5b6"), 1, new Guid("f407cf06-d2b5-8917-07cd-9a48bccff610"), 2004 },
                    { new Guid("503763ca-b960-72af-e89d-c7029a765e57"), 2, new Guid("1b0007a5-6657-d25b-dca3-f0276d84d81a"), 2013 },
                    { new Guid("5073e884-70ab-1059-6fca-c11e0c3519b9"), 2, new Guid("d0f604f6-5b65-7852-f455-801023334a1b"), 2017 },
                    { new Guid("50e297d1-aa41-f7c7-abaa-5b0aaf315610"), 1, new Guid("a0795d3b-e6d1-3837-28cb-c933c2ee054f"), 2018 },
                    { new Guid("51f790b2-0c11-4d8d-515e-6e66a60675f8"), 2, new Guid("f569da26-bda5-9afa-af54-f16956d89b62"), 2007 },
                    { new Guid("52228319-28a9-c5f4-43a6-17756f06f94a"), 1, new Guid("976dfac1-c26d-e3e3-2643-e4ea668e0933"), 2008 },
                    { new Guid("52dc0dc0-d67d-6afa-b53d-cfe2b322390e"), 2, new Guid("2545a485-bd29-8d46-5511-418d1abd50ff"), 1995 },
                    { new Guid("5328eb37-07a0-865a-9261-ce869904f0a7"), 2, new Guid("3b224a6e-0a41-5242-f08e-b39184bc7b8c"), 2013 },
                    { new Guid("553bc4fe-17b6-9704-63bb-0ac926182d4f"), 2, new Guid("1ce609a7-ae52-102a-a5f1-b4552c69f6b2"), 2013 },
                    { new Guid("562c2f13-335a-9504-6b61-a3f313647793"), 1, new Guid("b95900f8-40df-4dad-9655-cb676b5d9bda"), 2018 },
                    { new Guid("5a882d11-0d8d-3e4c-ef53-9da0bf833379"), 2, new Guid("1ce609a7-ae52-102a-a5f1-b4552c69f6b2"), 1995 },
                    { new Guid("5b69f20c-ee87-348a-cec4-efa6dd868975"), 1, new Guid("22b3e2cf-0e39-9424-a1b3-96e1a6137aaf"), 2010 },
                    { new Guid("5c056dc4-727f-3b0d-7090-07bd4312cee8"), 2, new Guid("53ef3e4c-a09d-83bf-3379-dcc2793f72ba"), 1995 },
                    { new Guid("5e129f3a-48a6-e41b-7654-b6e3cfea5edc"), 2, new Guid("96d1e707-b5ce-4c34-d5b3-a9298f03e339"), 2003 },
                    { new Guid("5ede1cef-b220-7a77-db8f-085a575433ca"), 1, new Guid("f6275483-e322-a3ef-857a-8316ac6325c5"), 2014 },
                    { new Guid("601f5baf-91aa-f63d-fbac-8f946cf62ad1"), 2, new Guid("ccf1bb8e-f7b3-92ec-6e53-6c5a7197afc4"), 1993 },
                    { new Guid("652a6b56-b12e-c3f1-d071-baa0afc37039"), 2, new Guid("bd079070-1243-e8ce-216c-2eb1eab1f256"), 2013 },
                    { new Guid("6542a568-3af9-6baf-ffe9-1b261d472d1a"), 1, new Guid("1751221e-6ed4-de23-352a-f666e84b0e4c"), 2000 },
                    { new Guid("656eff88-50de-cbc2-26ba-2a61041736f1"), 1, new Guid("f569da26-bda5-9afa-af54-f16956d89b62"), 2014 },
                    { new Guid("65d11b48-96ba-bfd4-9771-d896bbe485bd"), 2, new Guid("3b224a6e-0a41-5242-f08e-b39184bc7b8c"), 2005 },
                    { new Guid("66110720-d1b4-ec26-a7c3-1de62e0ff563"), 1, new Guid("a0795d3b-e6d1-3837-28cb-c933c2ee054f"), 1994 },
                    { new Guid("674086e9-aa07-222e-b28c-9c8028939b14"), 2, new Guid("68a8c93e-f238-c740-f9ba-81c0d1fe64c3"), 2003 },
                    { new Guid("67cb5596-5d6b-da9b-dab4-f6fbe94552c8"), 1, new Guid("c546b5cf-4225-b630-b5bd-2e1716530958"), 2000 },
                    { new Guid("6808c645-865c-4ec0-4140-b524b41dcfbf"), 1, new Guid("1751221e-6ed4-de23-352a-f666e84b0e4c"), 2016 },
                    { new Guid("69b7abcc-6245-5880-09b7-d328bedc8678"), 1, new Guid("ccf1bb8e-f7b3-92ec-6e53-6c5a7197afc4"), 2006 },
                    { new Guid("69da26f1-a5f5-fabd-9aaf-54f16956d89b"), 2, new Guid("1ce609a7-ae52-102a-a5f1-b4552c69f6b2"), 1993 },
                    { new Guid("6a539b8a-8fb2-a0d5-c215-1b266fefac6c"), 2, new Guid("96d1e707-b5ce-4c34-d5b3-a9298f03e339"), 2009 },
                    { new Guid("6ab4ed42-f68c-05d1-2e8c-80040620227e"), 1, new Guid("36d56121-9fd8-6b08-7635-0e3a3dfb9be7"), 2012 },
                    { new Guid("6bd10d0a-e740-a4b5-6c59-a8596321bf93"), 2, new Guid("96d1e707-b5ce-4c34-d5b3-a9298f03e339"), 2019 },
                    { new Guid("6bfae7c7-3aaf-0904-4399-b38cd0207362"), 2, new Guid("1b0007a5-6657-d25b-dca3-f0276d84d81a"), 2007 },
                    { new Guid("6d9a455c-0b98-8311-c376-2167bffa7cdd"), 1, new Guid("73bc97cc-36b3-e260-45b9-90b332617070"), 1998 },
                    { new Guid("6dd31862-5b40-72a6-8344-7f4abb2840b9"), 2, new Guid("1b0007a5-6657-d25b-dca3-f0276d84d81a"), 1993 },
                    { new Guid("6f63e837-4a63-9e8c-934d-e4e006d3e446"), 2, new Guid("22b3e2cf-0e39-9424-a1b3-96e1a6137aaf"), 2019 },
                    { new Guid("6ff06141-d87e-94a0-0f84-26224cb1ee39"), 2, new Guid("d0f604f6-5b65-7852-f455-801023334a1b"), 2001 },
                    { new Guid("70603373-9380-9ce7-5213-6c6ecc68828b"), 1, new Guid("73bc97cc-36b3-e260-45b9-90b332617070"), 2008 },
                    { new Guid("7143f003-62e2-4f77-8dc6-7e50dbb8174c"), 1, new Guid("c546b5cf-4225-b630-b5bd-2e1716530958"), 2016 },
                    { new Guid("71bc543c-b03b-f717-088f-46512e9ff71f"), 1, new Guid("f569da26-bda5-9afa-af54-f16956d89b62"), 2018 },
                    { new Guid("725a9c46-761d-5084-c7a5-d30dff2d4237"), 2, new Guid("5c07cd32-b743-432a-e78d-543ee429115c"), 2019 },
                    { new Guid("77297d4e-d76b-8457-afe9-8f75bde2fb41"), 1, new Guid("68a8c93e-f238-c740-f9ba-81c0d1fe64c3"), 2020 },
                    { new Guid("7829fe08-0ab9-e5b2-8ab2-4233acf80c76"), 1, new Guid("36d56121-9fd8-6b08-7635-0e3a3dfb9be7"), 1994 },
                    { new Guid("7aa21ad8-a6da-fbee-aa3e-1f14b46b7309"), 1, new Guid("73bc97cc-36b3-e260-45b9-90b332617070"), 1994 },
                    { new Guid("7ad77e40-6224-bdbf-be38-347dcc30bd2f"), 2, new Guid("22b3e2cf-0e39-9424-a1b3-96e1a6137aaf"), 1997 },
                    { new Guid("7afa2b0c-c710-9a97-6d1d-33148745dc95"), 2, new Guid("68a8c93e-f238-c740-f9ba-81c0d1fe64c3"), 1997 },
                    { new Guid("7c4307bf-6266-911c-e877-5133662555f7"), 2, new Guid("c91335b3-f851-898e-87ab-1de435147f20"), 2011 },
                    { new Guid("7cbb6713-ff18-41a1-5997-24b3db22799a"), 2, new Guid("b95900f8-40df-4dad-9655-cb676b5d9bda"), 2009 },
                    { new Guid("7f3f1bdb-78e5-2f8a-2803-4c07003ec348"), 1, new Guid("a210e2ac-d12b-742b-fce8-6a94df67c8d7"), 2018 },
                    { new Guid("7fc8a3f9-14f5-0aa1-8c95-806f8ab74c3f"), 1, new Guid("ccf1bb8e-f7b3-92ec-6e53-6c5a7197afc4"), 2008 },
                    { new Guid("80c18603-3fbd-b1a6-866e-d9f98d4132b4"), 1, new Guid("2545a485-bd29-8d46-5511-418d1abd50ff"), 2018 },
                    { new Guid("81534ecb-b481-8556-35a4-07c4d262a146"), 2, new Guid("d0f604f6-5b65-7852-f455-801023334a1b"), 2007 },
                    { new Guid("8443af71-49ae-79c3-7723-5eb2c43b97e9"), 2, new Guid("c24a3b4c-4605-1cd2-b41a-5c61c0d7f7b5"), 2009 },
                    { new Guid("8887000c-cc7a-3ec2-a0d3-3b9884af3a13"), 2, new Guid("1751221e-6ed4-de23-352a-f666e84b0e4c"), 2017 },
                    { new Guid("8a84bdc5-747d-e689-9080-98c3b23da05f"), 1, new Guid("6a31f9e4-e30c-0ca2-feae-fd08481ccf6c"), 2004 },
                    { new Guid("8a8a86f1-2810-6665-f678-0f4985918fd4"), 2, new Guid("95668482-e62f-8eed-7896-8b9153efdf78"), 2003 },
                    { new Guid("8d2aeebb-189b-cc07-776c-4ed36524d63d"), 1, new Guid("53ef3e4c-a09d-83bf-3379-dcc2793f72ba"), 2006 },
                    { new Guid("8d62b85a-995c-4554-58d0-ae48041bc259"), 2, new Guid("22b3e2cf-0e39-9424-a1b3-96e1a6137aaf"), 2013 },
                    { new Guid("8e7cccc3-a779-fd1f-893b-7862f5702d01"), 2, new Guid("2eeab11a-85eb-f3b3-e597-f27bfe661cae"), 1997 },
                    { new Guid("8eede62f-9678-918b-53ef-df78d2bd1982"), 1, new Guid("f569da26-bda5-9afa-af54-f16956d89b62"), 1994 },
                    { new Guid("90d75d2f-420b-fd85-24d1-fa415aaf01c3"), 2, new Guid("ccf1bb8e-f7b3-92ec-6e53-6c5a7197afc4"), 2017 },
                    { new Guid("90f70881-8d65-53be-c58a-ea27ec14d122"), 2, new Guid("a210e2ac-d12b-742b-fce8-6a94df67c8d7"), 2005 },
                    { new Guid("925abe45-9256-bc9b-80aa-5dc2fb42b1f0"), 1, new Guid("b95900f8-40df-4dad-9655-cb676b5d9bda"), 1994 },
                    { new Guid("93580953-6db8-9563-8068-e6b125723f71"), 2, new Guid("f407cf06-d2b5-8917-07cd-9a48bccff610"), 1993 },
                    { new Guid("938e9f0d-e2e9-2a7b-64da-5bd0d59a176b"), 1, new Guid("f569da26-bda5-9afa-af54-f16956d89b62"), 2010 },
                    { new Guid("93ca0d9b-d7eb-fb06-91fc-3bcae7546d52"), 2, new Guid("f6275483-e322-a3ef-857a-8316ac6325c5"), 2011 },
                    { new Guid("95951763-dc84-eee0-1b56-f4922ae9ceda"), 2, new Guid("d0cddb9a-806f-0873-2384-5a34ee407ed7"), 2013 },
                    { new Guid("976bd139-0bad-5106-d375-92569af9fe65"), 1, new Guid("c24a3b4c-4605-1cd2-b41a-5c61c0d7f7b5"), 1996 },
                    { new Guid("9812e42a-b123-3799-45c9-30f372c5d47b"), 2, new Guid("36d56121-9fd8-6b08-7635-0e3a3dfb9be7"), 2005 },
                    { new Guid("983d61af-db2d-7eb5-d873-7106a4c11a6e"), 2, new Guid("2eeab11a-85eb-f3b3-e597-f27bfe661cae"), 2013 },
                    { new Guid("99f7a5a3-dc8d-0c28-b76a-a4ffde424888"), 1, new Guid("bd079070-1243-e8ce-216c-2eb1eab1f256"), 2004 },
                    { new Guid("9a7b4ed6-cddb-6fd0-8073-0823845a34ee"), 2, new Guid("bd079070-1243-e8ce-216c-2eb1eab1f256"), 1997 },
                    { new Guid("9abf9514-e5b4-e3e0-8a6d-99408a0fed92"), 1, new Guid("2eeab11a-85eb-f3b3-e597-f27bfe661cae"), 2000 },
                    { new Guid("9acf3e5d-daf4-62d8-b724-7446b8fddcb1"), 1, new Guid("976dfac1-c26d-e3e3-2643-e4ea668e0933"), 2010 },
                    { new Guid("9bd5207f-70a5-7bd1-0196-fd203b5e9952"), 2, new Guid("95668482-e62f-8eed-7896-8b9153efdf78"), 1997 },
                    { new Guid("9c4a8763-b143-9c0b-668b-76d33e5b7fef"), 1, new Guid("53ef3e4c-a09d-83bf-3379-dcc2793f72ba"), 2002 },
                    { new Guid("a3f612b1-c1f9-313b-3953-a3e20317664b"), 1, new Guid("bd079070-1243-e8ce-216c-2eb1eab1f256"), 2008 },
                    { new Guid("a4696c19-d706-a9a5-3ce0-ef860222d8ff"), 1, new Guid("f407cf06-d2b5-8917-07cd-9a48bccff610"), 2016 },
                    { new Guid("a4eb5774-562a-5275-5f27-d8f809ac1b5c"), 2, new Guid("96d1e707-b5ce-4c34-d5b3-a9298f03e339"), 2015 },
                    { new Guid("a56bb2eb-ba17-2b45-9832-e7886235e43f"), 2, new Guid("d0cddb9a-806f-0873-2384-5a34ee407ed7"), 2019 },
                    { new Guid("a60e5554-3f88-a4bb-134b-568af656e087"), 2, new Guid("ec26d1b4-c3a7-e61d-2e0f-f56345be5a92"), 2005 },
                    { new Guid("a6586eb5-e30b-dbc3-c266-fae82f3d045c"), 2, new Guid("d0f604f6-5b65-7852-f455-801023334a1b"), 2005 },
                    { new Guid("a6cde051-b794-b788-2929-712c5f4c81c6"), 1, new Guid("96d1e707-b5ce-4c34-d5b3-a9298f03e339"), 2000 },
                    { new Guid("a8b46848-d85f-c9d0-a442-04f4a0ee7d1d"), 1, new Guid("1ce609a7-ae52-102a-a5f1-b4552c69f6b2"), 2010 },
                    { new Guid("aa245c06-f7c7-209e-012d-7e75d55ad827"), 1, new Guid("976dfac1-c26d-e3e3-2643-e4ea668e0933"), 1994 },
                    { new Guid("ad280ae6-7d32-476e-3724-a15856f523e7"), 2, new Guid("5c07cd32-b743-432a-e78d-543ee429115c"), 2015 },
                    { new Guid("ade8279f-2285-1195-b070-6ecff60ab1ad"), 1, new Guid("c91335b3-f851-898e-87ab-1de435147f20"), 2010 },
                    { new Guid("ae8e2715-4097-c0cc-794f-e207bfd70154"), 1, new Guid("a210e2ac-d12b-742b-fce8-6a94df67c8d7"), 2006 },
                    { new Guid("af76aa8f-0823-31e8-1a06-a3627a447cd1"), 1, new Guid("783b89fd-f562-2d70-0168-cb610b38e5ff"), 2010 },
                    { new Guid("af7f3d8e-724f-2a33-c215-10124d726576"), 2, new Guid("53ef3e4c-a09d-83bf-3379-dcc2793f72ba"), 2009 },
                    { new Guid("b12e6c21-b1ea-56f2-4d0a-3a9990891e2a"), 2, new Guid("a210e2ac-d12b-742b-fce8-6a94df67c8d7"), 1995 },
                    { new Guid("b187ba09-fa1e-75c3-40cf-436c8acbfe2b"), 2, new Guid("2545a485-bd29-8d46-5511-418d1abd50ff"), 2009 },
                    { new Guid("b2f6692c-add0-6d00-2418-4e4d6014ffcf"), 2, new Guid("36d56121-9fd8-6b08-7635-0e3a3dfb9be7"), 1993 },
                    { new Guid("b3a19424-e196-13a6-7aaf-0f743873abe6"), 2, new Guid("68a8c93e-f238-c740-f9ba-81c0d1fe64c3"), 1995 },
                    { new Guid("b3eff69a-6d8d-bb4a-af70-77e84a72bb75"), 1, new Guid("a0795d3b-e6d1-3837-28cb-c933c2ee054f"), 2010 },
                    { new Guid("b5073de8-dc9e-3af0-a8be-ea846c086cad"), 1, new Guid("2eeab11a-85eb-f3b3-e597-f27bfe661cae"), 2010 },
                    { new Guid("b51c0529-fa68-f24d-8ec2-032558a25d7f"), 2, new Guid("d0f604f6-5b65-7852-f455-801023334a1b"), 2009 },
                    { new Guid("b68c3f31-6003-fb74-2912-e4806d47be5a"), 2, new Guid("22b3e2cf-0e39-9424-a1b3-96e1a6137aaf"), 2021 },
                    { new Guid("b6a06167-f01b-04bd-5573-bed6c21095a6"), 2, new Guid("68a8c93e-f238-c740-f9ba-81c0d1fe64c3"), 2017 },
                    { new Guid("b7571f8c-9330-b754-4ebb-ce0e91362514"), 1, new Guid("ec26d1b4-c3a7-e61d-2e0f-f56345be5a92"), 2016 },
                    { new Guid("b7de3a6f-7c20-69ff-6a6c-1fb45e6a2377"), 2, new Guid("ccf1bb8e-f7b3-92ec-6e53-6c5a7197afc4"), 2003 },
                    { new Guid("b8737d8f-28ba-d097-a555-5e48e01dce64"), 2, new Guid("ec26d1b4-c3a7-e61d-2e0f-f56345be5a92"), 2007 },
                    { new Guid("b8e1ae8f-a779-5b7d-e88f-7fea85710f00"), 1, new Guid("ec26d1b4-c3a7-e61d-2e0f-f56345be5a92"), 2018 },
                    { new Guid("b8e69cf4-fb02-b20e-b93c-07651e64c511"), 1, new Guid("73bc97cc-36b3-e260-45b9-90b332617070"), 2010 },
                    { new Guid("bb502483-2149-af51-4568-c6f3ace3d6ac"), 2, new Guid("a210e2ac-d12b-742b-fce8-6a94df67c8d7"), 2017 },
                    { new Guid("bc1190ad-ac3a-3118-f00a-c51e225117d4"), 1, new Guid("1b0007a5-6657-d25b-dca3-f0276d84d81a"), 2000 },
                    { new Guid("bc8491b3-8c7b-c1a1-99aa-bc8eba98bc3e"), 2, new Guid("e12bab70-7297-aa92-05f2-18634d576359"), 1993 },
                    { new Guid("bd1a8d41-ff50-d1a8-0660-40abbe9518fd"), 2, new Guid("45871433-95dc-3f32-43f3-330dc5ddccc6"), 1997 },
                    { new Guid("bde00e62-1f87-742e-8ebe-dca39952a34f"), 2, new Guid("50b1399b-1b66-6732-adf6-a6620ee0bd87"), 1997 },
                    { new Guid("be9e4f38-0a0c-cf48-b0f6-55342e5ed2d3"), 2, new Guid("c91335b3-f851-898e-87ab-1de435147f20"), 2007 },
                    { new Guid("bf57e7ed-9cc9-8d60-5805-064e9fff9891"), 2, new Guid("50b1399b-1b66-6732-adf6-a6620ee0bd87"), 2001 },
                    { new Guid("c209eb1a-f275-7b9a-216a-134b36ff0ca0"), 1, new Guid("d0cddb9a-806f-0873-2384-5a34ee407ed7"), 2006 },
                    { new Guid("c2652579-43bf-fbb9-e208-edb2a1d6b5fa"), 1, new Guid("45871433-95dc-3f32-43f3-330dc5ddccc6"), 2002 },
                    { new Guid("c2bb3ef1-4f06-6f41-8e7a-0d1810df85c2"), 1, new Guid("b95900f8-40df-4dad-9655-cb676b5d9bda"), 2002 },
                    { new Guid("c45b8033-a216-bb2c-466c-7e82bbcf5900"), 1, new Guid("a210e2ac-d12b-742b-fce8-6a94df67c8d7"), 2008 },
                    { new Guid("c470776e-2d1d-8c0e-56e5-713c846bae8b"), 1, new Guid("73bc97cc-36b3-e260-45b9-90b332617070"), 2022 },
                    { new Guid("c5190da0-e503-7e8a-9e25-0177043c5cf3"), 2, new Guid("53ef3e4c-a09d-83bf-3379-dcc2793f72ba"), 2013 },
                    { new Guid("c542ebcf-71da-7721-c710-098822e48e7d"), 1, new Guid("c546b5cf-4225-b630-b5bd-2e1716530958"), 2020 },
                    { new Guid("c64e4a21-7c18-0f31-e63a-5c8c43b8766a"), 1, new Guid("d0cddb9a-806f-0873-2384-5a34ee407ed7"), 2008 },
                    { new Guid("c6bcf72b-6452-bed3-d1f3-3cc3d8aec2db"), 2, new Guid("a0795d3b-e6d1-3837-28cb-c933c2ee054f"), 2011 },
                    { new Guid("c7caaf6b-5d3b-a079-d1e6-373828cbc933"), 2, new Guid("f407cf06-d2b5-8917-07cd-9a48bccff610"), 1999 },
                    { new Guid("c82fcf71-e9f8-ebf6-5838-7e9f048550d3"), 2, new Guid("1751221e-6ed4-de23-352a-f666e84b0e4c"), 2005 },
                    { new Guid("c8cad137-7c1f-0209-b5d6-bef5eb74e9f0"), 1, new Guid("45871433-95dc-3f32-43f3-330dc5ddccc6"), 2012 },
                    { new Guid("c956c855-b276-a0f0-33c7-9d1ab1ea2eeb"), 2, new Guid("b95900f8-40df-4dad-9655-cb676b5d9bda"), 1997 },
                    { new Guid("c9e33f97-36ac-d9ac-129e-72665d8f1856"), 2, new Guid("73bc97cc-36b3-e260-45b9-90b332617070"), 2013 },
                    { new Guid("c9f79cf9-338e-4332-9f09-7df7a917f291"), 2, new Guid("95668482-e62f-8eed-7896-8b9153efdf78"), 2011 },
                    { new Guid("cb7bac30-7a3d-0d54-a943-3982fbc1842e"), 1, new Guid("b95900f8-40df-4dad-9655-cb676b5d9bda"), 2008 },
                    { new Guid("cc1cad68-97bc-43c4-7500-8f727990ae16"), 1, new Guid("b95900f8-40df-4dad-9655-cb676b5d9bda"), 2016 },
                    { new Guid("cca8768a-bc97-b373-3660-e245b990b332"), 1, new Guid("c24a3b4c-4605-1cd2-b41a-5c61c0d7f7b5"), 1998 },
                    { new Guid("cd5d0584-0639-1326-b2e6-b8a461d2a19f"), 1, new Guid("2eeab11a-85eb-f3b3-e597-f27bfe661cae"), 2004 },
                    { new Guid("ce99c028-438f-6453-a285-896c79df908a"), 2, new Guid("b95900f8-40df-4dad-9655-cb676b5d9bda"), 1993 },
                    { new Guid("ced434f0-9b69-b139-5066-1b3267adf6a6"), 2, new Guid("36d56121-9fd8-6b08-7635-0e3a3dfb9be7"), 1997 },
                    { new Guid("cf7be739-4f5c-a89b-00e5-07ca186c104f"), 1, new Guid("e12bab70-7297-aa92-05f2-18634d576359"), 2000 },
                    { new Guid("cf907e26-b322-76aa-b703-544a252977da"), 1, new Guid("1751221e-6ed4-de23-352a-f666e84b0e4c"), 2010 },
                    { new Guid("cfae88da-46b5-25c5-4230-b6b5bd2e1716"), 2, new Guid("ec26d1b4-c3a7-e61d-2e0f-f56345be5a92"), 1993 },
                    { new Guid("cffeb464-8f90-10f3-e0e8-7b556b17630d"), 1, new Guid("22b3e2cf-0e39-9424-a1b3-96e1a6137aaf"), 2004 },
                    { new Guid("d1604bed-f52d-8df2-aa18-bda75ed663fc"), 2, new Guid("783b89fd-f562-2d70-0168-cb610b38e5ff"), 2019 },
                    { new Guid("d1bd96ba-36ec-c6d3-e4b1-b4b538db1aba"), 1, new Guid("d0f604f6-5b65-7852-f455-801023334a1b"), 2012 },
                    { new Guid("d1e70787-ce96-34b5-4cd5-b3a9298f03e3"), 1, new Guid("ccf1bb8e-f7b3-92ec-6e53-6c5a7197afc4"), 1996 },
                    { new Guid("d3be44c6-d080-5f8e-a382-040e6d11087e"), 1, new Guid("2eeab11a-85eb-f3b3-e597-f27bfe661cae"), 1996 },
                    { new Guid("d3c9fd1e-486f-b44d-46f3-40c1e2f79084"), 2, new Guid("1b0007a5-6657-d25b-dca3-f0276d84d81a"), 2001 },
                    { new Guid("d456fc5b-6457-deda-1adc-14f5a3b7fef2"), 1, new Guid("6a31f9e4-e30c-0ca2-feae-fd08481ccf6c"), 2012 },
                    { new Guid("d4ed20d4-3ece-a4de-b268-f4efb0ec0a7a"), 1, new Guid("2eeab11a-85eb-f3b3-e597-f27bfe661cae"), 2006 },
                    { new Guid("d5bb7cd7-b404-873c-d381-c2858ba95f5c"), 2, new Guid("d0cddb9a-806f-0873-2384-5a34ee407ed7"), 2021 },
                    { new Guid("d6049fbf-6823-42a5-af90-0f34e76b1200"), 1, new Guid("c91335b3-f851-898e-87ab-1de435147f20"), 2002 },
                    { new Guid("d736d26f-8c7e-beb1-a0a8-f3392867860c"), 2, new Guid("d0f604f6-5b65-7852-f455-801023334a1b"), 2003 },
                    { new Guid("d76fe892-0226-a9d8-2956-41d2e4f9316a"), 2, new Guid("d0f604f6-5b65-7852-f455-801023334a1b"), 1995 },
                    { new Guid("d8b49067-00d2-8c69-a7cd-29c4dd2e455a"), 1, new Guid("bd079070-1243-e8ce-216c-2eb1eab1f256"), 2012 },
                    { new Guid("de3ff512-803c-f901-de53-c73d5965a191"), 2, new Guid("95668482-e62f-8eed-7896-8b9153efdf78"), 2009 },
                    { new Guid("def2f95d-6ed0-439d-dfb0-42aa79031fa7"), 1, new Guid("6a31f9e4-e30c-0ca2-feae-fd08481ccf6c"), 1994 },
                    { new Guid("e0692fcd-510b-a051-735a-cbd4659fcced"), 2, new Guid("1751221e-6ed4-de23-352a-f666e84b0e4c"), 2007 },
                    { new Guid("e1179a6e-09a7-1ce6-52ae-2a10a5f1b455"), 2, new Guid("6a31f9e4-e30c-0ca2-feae-fd08481ccf6c"), 1993 },
                    { new Guid("e3551065-9d63-058c-0c17-41d5e959559e"), 2, new Guid("a210e2ac-d12b-742b-fce8-6a94df67c8d7"), 2021 },
                    { new Guid("e3c26d97-26e3-e443-ea66-8e09336b058e"), 1, new Guid("f407cf06-d2b5-8917-07cd-9a48bccff610"), 1996 },
                    { new Guid("e5e43675-fdf1-e1e5-20ae-56ec15906b3f"), 2, new Guid("1b0007a5-6657-d25b-dca3-f0276d84d81a"), 2021 },
                    { new Guid("e5f3b385-f297-fe7b-661c-ae4a697f3c74"), 2, new Guid("c24a3b4c-4605-1cd2-b41a-5c61c0d7f7b5"), 1997 },
                    { new Guid("e6c7f553-07ef-7376-680d-c3efea1a83de"), 2, new Guid("2545a485-bd29-8d46-5511-418d1abd50ff"), 2017 },
                    { new Guid("e75b027f-8f33-22e3-538d-c0cffd0d55a2"), 2, new Guid("1751221e-6ed4-de23-352a-f666e84b0e4c"), 1993 },
                    { new Guid("e7998394-9e2f-4cb8-5ffa-01c977f73d34"), 2, new Guid("bd079070-1243-e8ce-216c-2eb1eab1f256"), 2011 },
                    { new Guid("e8712e3f-d739-0dd1-af58-5497b201be34"), 1, new Guid("976dfac1-c26d-e3e3-2643-e4ea668e0933"), 2014 },
                    { new Guid("e872da65-333f-4963-1403-cbbe32120172"), 1, new Guid("d0cddb9a-806f-0873-2384-5a34ee407ed7"), 2022 },
                    { new Guid("e9974d37-cb14-f73e-69b4-c355487dfe5f"), 2, new Guid("c7aa245c-9ef7-0120-2d7e-75d55ad82708"), 2013 },
                    { new Guid("ea4f9006-529a-786a-fd72-cbc1881dde21"), 1, new Guid("f6275483-e322-a3ef-857a-8316ac6325c5"), 2004 },
                    { new Guid("eb7d47e7-6f97-cc29-a41c-138b8b81d6d9"), 2, new Guid("bd079070-1243-e8ce-216c-2eb1eab1f256"), 2021 },
                    { new Guid("ebccaac3-e485-d0ed-6fbf-4b9c5ccae100"), 2, new Guid("ccf1bb8e-f7b3-92ec-6e53-6c5a7197afc4"), 2005 },
                    { new Guid("ec16c573-c774-ef61-8c6b-1fa1fba55e93"), 2, new Guid("2eeab11a-85eb-f3b3-e597-f27bfe661cae"), 2009 },
                    { new Guid("ed0845cf-4f5f-ac21-9d3b-815c32e85861"), 2, new Guid("45871433-95dc-3f32-43f3-330dc5ddccc6"), 2005 },
                    { new Guid("ef7547b2-fd20-2692-9971-526d1e2d9ed1"), 1, new Guid("783b89fd-f562-2d70-0168-cb610b38e5ff"), 2002 },
                    { new Guid("ef8136ce-da7a-65ce-2b51-a6cbe3d6d7f9"), 1, new Guid("5c07cd32-b743-432a-e78d-543ee429115c"), 2012 },
                    { new Guid("f016e18b-9188-c4a4-cc21-a84e1cb55d57"), 2, new Guid("22b3e2cf-0e39-9424-a1b3-96e1a6137aaf"), 2001 },
                    { new Guid("f0a31a50-a2e1-05ba-568f-bd3d11d03ba8"), 2, new Guid("c7aa245c-9ef7-0120-2d7e-75d55ad82708"), 2015 },
                    { new Guid("f0a845bc-e88c-b055-d4cd-0fe1da077963"), 1, new Guid("f6275483-e322-a3ef-857a-8316ac6325c5"), 2022 },
                    { new Guid("f0d39f77-e024-39e4-0fd1-3d07b92d9630"), 2, new Guid("e12bab70-7297-aa92-05f2-18634d576359"), 2011 },
                    { new Guid("f255cee2-1b81-25f4-8c16-c10be5ba738a"), 1, new Guid("ccf1bb8e-f7b3-92ec-6e53-6c5a7197afc4"), 2016 },
                    { new Guid("f3433f32-0d33-ddc5-ccc6-5d185df9d8af"), 2, new Guid("d0f604f6-5b65-7852-f455-801023334a1b"), 1997 },
                    { new Guid("f43285d5-4b6a-583b-3664-b33f7b85532a"), 1, new Guid("f6275483-e322-a3ef-857a-8316ac6325c5"), 2020 },
                    { new Guid("f6217579-8fe6-c2cf-0ddd-3db215382481"), 1, new Guid("68a8c93e-f238-c740-f9ba-81c0d1fe64c3"), 2002 },
                    { new Guid("f7b3ccf1-92ec-536e-6c5a-7197afc47ba9"), 1, new Guid("bd079070-1243-e8ce-216c-2eb1eab1f256"), 1998 },
                    { new Guid("f88f1d77-45c2-70b8-ed10-bbc7d644121b"), 1, new Guid("d0cddb9a-806f-0873-2384-5a34ee407ed7"), 2014 },
                    { new Guid("f91aba91-cba1-ce04-53cb-d29128c1fa6d"), 1, new Guid("c7aa245c-9ef7-0120-2d7e-75d55ad82708"), 1996 },
                    { new Guid("fb3ee895-59a3-d2d8-98a7-50af9e1e6c0f"), 2, new Guid("783b89fd-f562-2d70-0168-cb610b38e5ff"), 2001 },
                    { new Guid("fc742bd1-6ae8-df94-67c8-d7cec7863242"), 2, new Guid("a0795d3b-e6d1-3837-28cb-c933c2ee054f"), 1995 },
                    { new Guid("fe2f8192-4372-c79f-790a-6b4cf4b2f780"), 2, new Guid("1b0007a5-6657-d25b-dca3-f0276d84d81a"), 2005 },
                    { new Guid("ffe636cc-8faf-9b43-748d-f9769f90a1e6"), 1, new Guid("68a8c93e-f238-c740-f9ba-81c0d1fe64c3"), 2018 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_board_members_member_id",
                table: "board_members",
                column: "member_id");

            migrationBuilder.CreateIndex(
                name: "IX_cultural_exchanges_member_id",
                table: "cultural_exchanges",
                column: "member_id");

            migrationBuilder.CreateIndex(
                name: "IX_members_membership_id",
                table: "members",
                column: "membership_id");

            migrationBuilder.CreateIndex(
                name: "IX_membership_dues_membership_id",
                table: "membership_dues",
                column: "membership_id");

            migrationBuilder.CreateIndex(
                name: "IX_memberships_address_id",
                table: "memberships",
                column: "address_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "board_members");

            migrationBuilder.DropTable(
                name: "cultural_exchanges");

            migrationBuilder.DropTable(
                name: "membership_dues");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "members");

            migrationBuilder.DropTable(
                name: "memberships");

            migrationBuilder.DropTable(
                name: "addresses");
        }
    }
}
