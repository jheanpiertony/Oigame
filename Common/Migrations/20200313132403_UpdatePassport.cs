using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.Migrations
{
    public partial class UpdatePassport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Customer_Passport",
                table: "Customer",
                column: "Passport",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customer_Passport",
                table: "Customer");
        }
    }
}
