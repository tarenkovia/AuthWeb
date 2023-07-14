using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp2.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToTableUserAns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UsersAnswer",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UsersAnswer");
        }
    }
}
