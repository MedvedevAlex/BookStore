using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class ReworkBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBooks_Books_BookId",
                table: "AuthorBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_PainterBook_Books_BookId",
                table: "PainterBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AvgReview",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CountCustomers",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Edition",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "QuantityStock",
                table: "Books",
                newName: "Duplicate");

            migrationBuilder.RenameColumn(
                name: "NumbersPages",
                table: "Books",
                newName: "CountPage");

            migrationBuilder.RenameColumn(
                name: "Dimensions",
                table: "Books",
                newName: "Format");

            migrationBuilder.AddColumn<Guid>(
                name: "BookId1",
                table: "PainterBook",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Books",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GenreId",
                table: "Books",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LanguageId",
                table: "Books",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TypeCoverId",
                table: "Books",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "BookId",
                table: "AuthorBooks",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PainterBook_BookId1",
                table: "PainterBook",
                column: "BookId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBooks_Books_BookId",
                table: "AuthorBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PainterBook_Books_BookId1",
                table: "PainterBook",
                column: "BookId1",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBooks_Books_BookId",
                table: "AuthorBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_PainterBook_Books_BookId1",
                table: "PainterBook");

            migrationBuilder.DropIndex(
                name: "IX_PainterBook_BookId1",
                table: "PainterBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookId1",
                table: "PainterBook");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "TypeCoverId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Format",
                table: "Books",
                newName: "Dimensions");

            migrationBuilder.RenameColumn(
                name: "Duplicate",
                table: "Books",
                newName: "QuantityStock");

            migrationBuilder.RenameColumn(
                name: "CountPage",
                table: "Books",
                newName: "NumbersPages");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Books",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<decimal>(
                name: "AvgReview",
                table: "Books",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CountCustomers",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Cover",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Edition",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Genre",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Language",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "AuthorBooks",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBooks_Books_BookId",
                table: "AuthorBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PainterBook_Books_BookId",
                table: "PainterBook",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
