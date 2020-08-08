using Microsoft.EntityFrameworkCore.Migrations;

namespace newmvccore.Migrations
{
    public partial class seeddatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "id", "department", "email", "name" },
                values: new object[] { 1, 1, "diddivinay@gmail.com", "vinay" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "id",
                keyValue: 1);
        }
    }
}
