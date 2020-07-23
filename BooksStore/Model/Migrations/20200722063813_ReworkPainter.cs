using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class ReworkPainter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PainterBook_Books_BookId1",
                table: "PainterBook");

            migrationBuilder.DropForeignKey(
                name: "FK_PainterBook_Painters_PainterId",
                table: "PainterBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Painters",
                table: "Painters");

            migrationBuilder.DropIndex(
                name: "IX_PainterBook_BookId1",
                table: "PainterBook");

            migrationBuilder.DropIndex(
                name: "IX_PainterBook_PainterId",
                table: "PainterBook");

            migrationBuilder.DropColumn(
                name: "PainterId",
                table: "Painters");

            migrationBuilder.DropColumn(
                name: "Style",
                table: "Painters");

            migrationBuilder.DropColumn(
                name: "BookId1",
                table: "PainterBook");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Painters",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Painters",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StyleId",
                table: "Painters",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PainterId",
                table: "PainterBook",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "BookId",
                table: "PainterBook",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PainterId1",
                table: "PainterBook",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Painters",
                table: "Painters",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PainterStyles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PainterStyles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Painters_StyleId",
                table: "Painters",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_PainterBook_PainterId1",
                table: "PainterBook",
                column: "PainterId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PainterBook_Books_BookId",
                table: "PainterBook",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PainterBook_Painters_PainterId1",
                table: "PainterBook",
                column: "PainterId1",
                principalTable: "Painters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Painters_PainterStyles_StyleId",
                table: "Painters",
                column: "StyleId",
                principalTable: "PainterStyles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PainterBook_Books_BookId",
                table: "PainterBook");

            migrationBuilder.DropForeignKey(
                name: "FK_PainterBook_Painters_PainterId1",
                table: "PainterBook");

            migrationBuilder.DropForeignKey(
                name: "FK_Painters_PainterStyles_StyleId",
                table: "Painters");

            migrationBuilder.DropTable(
                name: "PainterStyles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Painters",
                table: "Painters");

            migrationBuilder.DropIndex(
                name: "IX_Painters_StyleId",
                table: "Painters");

            migrationBuilder.DropIndex(
                name: "IX_PainterBook_PainterId1",
                table: "PainterBook");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Painters");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Painters");

            migrationBuilder.DropColumn(
                name: "StyleId",
                table: "Painters");

            migrationBuilder.DropColumn(
                name: "PainterId1",
                table: "PainterBook");

            migrationBuilder.AddColumn<int>(
                name: "PainterId",
                table: "Painters",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Style",
                table: "Painters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PainterId",
                table: "PainterBook",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "PainterBook",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "BookId1",
                table: "PainterBook",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Painters",
                table: "Painters",
                column: "PainterId");

            migrationBuilder.CreateIndex(
                name: "IX_PainterBook_BookId1",
                table: "PainterBook",
                column: "BookId1");

            migrationBuilder.CreateIndex(
                name: "IX_PainterBook_PainterId",
                table: "PainterBook",
                column: "PainterId");

            migrationBuilder.AddForeignKey(
                name: "FK_PainterBook_Books_BookId1",
                table: "PainterBook",
                column: "BookId1",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PainterBook_Painters_PainterId",
                table: "PainterBook",
                column: "PainterId",
                principalTable: "Painters",
                principalColumn: "PainterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
