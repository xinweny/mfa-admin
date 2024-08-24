using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MfaApi.Migrations
{
    /// <inheritdoc />
    public partial class AddStartDateColumnForMemberships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "start_date",
                table: "memberships",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "start_date",
                table: "memberships");
        }
    }
}
