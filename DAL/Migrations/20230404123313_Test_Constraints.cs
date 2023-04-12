using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Test_Constraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "UserAccount",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Teacher",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_email",
                table: "UserAccount",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_email",
                table: "Teacher",
                column: "email",
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "Phone",
                table: "Teacher",
                sql: "Phone like '+374%'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserAccount_email",
                table: "UserAccount");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_email",
                table: "Teacher");

            migrationBuilder.DropCheckConstraint(
                name: "Phone",
                table: "Teacher");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "UserAccount",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Teacher",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
