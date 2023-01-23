using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManageLibraryItemsAndEmployees.Data.Migrations
{
    public partial class UpdateDatabse2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f9296d9-eda0-4c4e-a8ac-299adde5c63a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "289aeaab-b235-4d91-8221-37752aa5c7cf", "16ad27a5-fc4f-4331-bb8c-b59268bf1685", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "289aeaab-b235-4d91-8221-37752aa5c7cf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1f9296d9-eda0-4c4e-a8ac-299adde5c63a", "1a0251bc-4000-4998-9574-45e2af6867e8", "Administrator", "ADMINISTRATOR" });
        }
    }
}
