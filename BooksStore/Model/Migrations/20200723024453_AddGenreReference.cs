using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class AddGenreReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "GenreId",
                table: "Books",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interpreters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<byte>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interpreters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InterpreterBooks",
                columns: table => new
                {
                    BookId = table.Column<Guid>(nullable: false),
                    IntepreterId = table.Column<Guid>(nullable: false),
                    InterpreterId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterpreterBooks", x => new { x.BookId, x.IntepreterId });
                    table.ForeignKey(
                        name: "FK_InterpreterBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterpreterBooks_Interpreters_InterpreterId",
                        column: x => x.InterpreterId,
                        principalTable: "Interpreters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_InterpreterBooks_InterpreterId",
                table: "InterpreterBooks",
                column: "InterpreterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Genres_GenreId",
                table: "Books",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Genres_GenreId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "InterpreterBooks");

            migrationBuilder.DropTable(
                name: "Interpreters");

            migrationBuilder.DropIndex(
                name: "IX_Books_GenreId",
                table: "Books");

            migrationBuilder.AlterColumn<Guid>(
                name: "GenreId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}
