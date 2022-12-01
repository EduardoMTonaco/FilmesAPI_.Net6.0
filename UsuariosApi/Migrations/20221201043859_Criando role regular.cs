using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosApi.Migrations
{
    public partial class Criandoroleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "9b8e6d38-f8e8-4544-a13f-cd5d6458acc8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99997, "35eb8968-c3d6-47e0-b4a1-73d20e42c8f0", "regula", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8df5051e-fe75-43d5-a3ff-2c10108c619f", "AQAAAAEAACcQAAAAEBOL40OZs1DXfmUVbIAQ7IBIKbTOZTByvQHPqzQY6RXfbu5r9TpTTd9crgGJdbfm2Q==", "a3249e4a-4a82-4d9a-9bac-3c6020a15ffc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "8873c3f9-1168-40a4-80db-2ec49f2dd385");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3814daf-d982-4d9e-b570-dea6fb0f179e", "AQAAAAEAACcQAAAAENajCU+wb6ZX35cBT0b467Xeu5EF6Ii4HC52jLNlyuTcNdTieC+ek467zrrYj31DeA==", "cac984e5-82f9-4027-abca-b9de3869c36a" });
        }
    }
}
