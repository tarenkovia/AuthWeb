using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp2.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddOverdueToUserAns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOverdue",
                table: "UsersAnswer",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOverdue",
                table: "UsersAnswer");
        }
    }
}
