using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp2.Data.Migrations
{
    /// <inheritdoc />
    public partial class addTableUserAnsReceived : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AnsReceived",
                table: "UsersAnswer",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnsReceived",
                table: "UsersAnswer");
        }
    }
}
