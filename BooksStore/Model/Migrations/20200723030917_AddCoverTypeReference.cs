using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class AddCoverTypeReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeCoverId",
                table: "Books");

            migrationBuilder.AddColumn<Guid>(
                name: "CoverTypeId",
                table: "Books",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CoverTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CoverTypeId",
                table: "Books",
                column: "CoverTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_CoverTypes_CoverTypeId",
                table: "Books",
                column: "CoverTypeId",
                principalTable: "CoverTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_CoverTypes_CoverTypeId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "CoverTypes");

            migrationBuilder.DropIndex(
                name: "IX_Books_CoverTypeId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CoverTypeId",
                table: "Books");

            migrationBuilder.AddColumn<Guid>(
                name: "TypeCoverId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
