using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class AddIntepreter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PainterBooks_Painters_PainterId1",
                table: "PainterBooks");

            migrationBuilder.DropIndex(
                name: "IX_PainterBooks_PainterId1",
                table: "PainterBooks");

            migrationBuilder.DropColumn(
                name: "PainterId1",
                table: "PainterBooks");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Painters",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_PainterBooks_PainterId",
                table: "PainterBooks",
                column: "PainterId");

            migrationBuilder.AddForeignKey(
                name: "FK_PainterBooks_Painters_PainterId",
                table: "PainterBooks",
                column: "PainterId",
                principalTable: "Painters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PainterBooks_Painters_PainterId",
                table: "PainterBooks");

            migrationBuilder.DropIndex(
                name: "IX_PainterBooks_PainterId",
                table: "PainterBooks");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Painters",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid))
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PainterId1",
                table: "PainterBooks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PainterBooks_PainterId1",
                table: "PainterBooks",
                column: "PainterId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PainterBooks_Painters_PainterId1",
                table: "PainterBooks",
                column: "PainterId1",
                principalTable: "Painters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
