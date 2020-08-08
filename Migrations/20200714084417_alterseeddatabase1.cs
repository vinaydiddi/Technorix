using Microsoft.EntityFrameworkCore.Migrations;

namespace newmvccore.Migrations
{
    public partial class alterseeddatabase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "id", "department", "email", "name" },
                values: new object[] { 3, 2, "nikita@gmail.com", "nikita" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
