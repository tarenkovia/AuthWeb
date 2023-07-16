using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp2.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartureTimeToUserAns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureDate",
                table: "UsersAnswer",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartureDate",
                table: "UsersAnswer");
        }
    }
}
