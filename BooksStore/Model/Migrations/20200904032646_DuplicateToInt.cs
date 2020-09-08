using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class DuplicateToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Duplicate",
                table: "Books",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1ffa9b7c-e021-4084-a14b-35839b9cc9d2"),
                column: "Duplicate",
                value: 7000);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("4b9c14fd-7788-4c89-b778-459ee7a4415b"),
                column: "Duplicate",
                value: 17000);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5628b2d6-4ed2-4b3e-b71f-6764a2489b25"),
                column: "Duplicate",
                value: 10000);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("7c7ef3fc-b918-41d5-9e9d-e0549b0f42bc"),
                column: "Duplicate",
                value: 50000);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("7d1e69bc-f0b2-4bbd-8d87-e2fc2bca53ac"),
                column: "Duplicate",
                value: 15000);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("7db924d8-00a7-4b46-9e31-73d95c38eb31"),
                column: "Duplicate",
                value: 2000);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("8c038acd-17db-4554-a741-de98ca121256"),
                column: "Duplicate",
                value: 15000);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("aa585855-0feb-418c-acc5-6e98e20b972a"),
                column: "Duplicate",
                value: 5000);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("d22d44a7-e987-4f8f-8cb2-0768cc6199c6"),
                column: "Duplicate",
                value: 5000);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("f0317cfb-e110-4b92-97b9-a52595cefccd"),
                column: "Duplicate",
                value: 3000);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "Duplicate",
                table: "Books",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1ffa9b7c-e021-4084-a14b-35839b9cc9d2"),
                column: "Duplicate",
                value: (short)7000);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("4b9c14fd-7788-4c89-b778-459ee7a4415b"),
                column: "Duplicate",
                value: (short)17000);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5628b2d6-4ed2-4b3e-b71f-6764a2489b25"),
                column: "Duplicate",
                value: (short)10000);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("7c7ef3fc-b918-41d5-9e9d-e0549b0f42bc"),
                column: "Duplicate",
                value: (short)-15536);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("7d1e69bc-f0b2-4bbd-8d87-e2fc2bca53ac"),
                column: "Duplicate",
                value: (short)15000);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("7db924d8-00a7-4b46-9e31-73d95c38eb31"),
                column: "Duplicate",
                value: (short)2000);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("8c038acd-17db-4554-a741-de98ca121256"),
                column: "Duplicate",
                value: (short)15000);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("aa585855-0feb-418c-acc5-6e98e20b972a"),
                column: "Duplicate",
                value: (short)5000);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("d22d44a7-e987-4f8f-8cb2-0768cc6199c6"),
                column: "Duplicate",
                value: (short)5000);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("f0317cfb-e110-4b92-97b9-a52595cefccd"),
                column: "Duplicate",
                value: (short)3000);
        }
    }
}
