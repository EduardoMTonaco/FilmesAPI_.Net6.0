using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosApi.Migrations
{
    public partial class AdicionandoCustomIdentityuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "4a14e82c-93ce-4064-aff2-850a2e2d7a77");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "b4ff5a36-e8ff-439e-8ee8-2c790adfe612");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d36e5161-c2bd-4c19-b2bc-f182d0771936", "AQAAAAEAACcQAAAAENtiQ5SQhdnl8VLdMt/ykaTCWRiOJC5d1Rl/KVj+Up48FSHk4+DpK+kZvYXLbbpHqg==", "94876747-e50d-4a44-b2ef-94266815c9b4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "35eb8968-c3d6-47e0-b4a1-73d20e42c8f0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "9b8e6d38-f8e8-4544-a13f-cd5d6458acc8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8df5051e-fe75-43d5-a3ff-2c10108c619f", "AQAAAAEAACcQAAAAEBOL40OZs1DXfmUVbIAQ7IBIKbTOZTByvQHPqzQY6RXfbu5r9TpTTd9crgGJdbfm2Q==", "a3249e4a-4a82-4d9a-9bac-3c6020a15ffc" });
        }
    }
}
