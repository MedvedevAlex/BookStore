using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(20)", nullable: true),
                    Age = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

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
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", nullable: true),
                    Address = table.Column<string>(type: "varchar(40)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Painters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(20)", nullable: true),
                    Age = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", nullable: true),
                    StyleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Painters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Painters_PainterStyles_StyleId",
                        column: x => x.StyleId,
                        principalTable: "PainterStyles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(20)", nullable: true),
                    PublishDate = table.Column<DateTime>(type: "Date", nullable: false),
                    CoverTypeId = table.Column<Guid>(nullable: true),
                    GenreId = table.Column<Guid>(nullable: true),
                    LanguageId = table.Column<Guid>(nullable: true),
                    Description = table.Column<string>(type: "varchar(200)", nullable: true),
                    ISBN_10 = table.Column<string>(type: "char(10)", nullable: true),
                    ISBN_13 = table.Column<string>(type: "char(13)", nullable: true),
                    Format = table.Column<string>(type: "varchar(20)", nullable: true),
                    CountPage = table.Column<short>(type: "smallint", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(8,2)", nullable: false),
                    Weight = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    Duplicate = table.Column<int>(type: "int", nullable: false),
                    AgeLimit = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_CoverTypes_CoverTypeId",
                        column: x => x.CoverTypeId,
                        principalTable: "CoverTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_Id",
                        column: x => x.Id,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkShedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ShopId = table.Column<Guid>(nullable: true),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Weekday = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkShedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkShedules_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBooks",
                columns: table => new
                {
                    BookId = table.Column<Guid>(nullable: false),
                    AuthorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBooks", x => new { x.BookId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_AuthorBooks_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterpreterBooks",
                columns: table => new
                {
                    BookId = table.Column<Guid>(nullable: false),
                    InterpreterId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterpreterBooks", x => new { x.BookId, x.InterpreterId });
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PainterBooks",
                columns: table => new
                {
                    BookId = table.Column<Guid>(nullable: false),
                    PainterId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PainterBooks", x => new { x.BookId, x.PainterId });
                    table.ForeignKey(
                        name: "FK_PainterBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PainterBooks_Painters_PainterId",
                        column: x => x.PainterId,
                        principalTable: "Painters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { new Guid("cab1c429-3a2d-4e30-b8a4-f9281b71ed7e"), "Советская 65", "Книжная штучка" },
                    { new Guid("c99eca84-3aa1-4a38-abe2-6b551571246d"), "Мира 22", "Большая закладка" },
                    { new Guid("bd0f8083-8072-4a25-8d13-90a85f2caeca"), "Маркса проспект 3", "Скрытая обложка" },
                    { new Guid("27cf46b3-a2aa-4351-af82-e33f36f1c553"), "Заельцовская 123", "Глубокий кошелек" },
                    { new Guid("06c5d83e-ac7f-4c4c-8ad5-79bb9e914ef8"), "Красный проспект 234", "Звенящий брелок" },
                    { new Guid("905d9ed8-0bd5-402a-be16-73c021176c78"), "Революции 89", "Теплый носок" }
                });

            migrationBuilder.InsertData(
                table: "WorkShedules",
                columns: new[] { "Id", "EndTime", "ShopId", "StartTime", "Weekday" },
                values: new object[,]
                {
                    { new Guid("905d9ed8-0bd5-402a-be16-73c021176c78"), new TimeSpan(0, 16, 0, 0, 0), new Guid("cab1c429-3a2d-4e30-b8a4-f9281b71ed7e"), new TimeSpan(0, 7, 30, 0, 0), (byte)1 },
                    { new Guid("f4c53bb7-ff07-4be6-8657-72c5e54ed18d"), new TimeSpan(0, 20, 0, 0, 0), new Guid("bd0f8083-8072-4a25-8d13-90a85f2caeca"), new TimeSpan(0, 7, 0, 0, 0), (byte)4 },
                    { new Guid("5bab269a-e2be-45d1-a867-ea7295bb6671"), new TimeSpan(0, 18, 0, 0, 0), new Guid("bd0f8083-8072-4a25-8d13-90a85f2caeca"), new TimeSpan(0, 10, 30, 0, 0), (byte)3 },
                    { new Guid("e750f5d4-b698-4196-8337-4551a672a4f4"), new TimeSpan(0, 16, 0, 0, 0), new Guid("bd0f8083-8072-4a25-8d13-90a85f2caeca"), new TimeSpan(0, 10, 30, 0, 0), (byte)1 },
                    { new Guid("17a51ded-63d8-4eb7-9286-cced1e0a03ce"), new TimeSpan(0, 18, 0, 0, 0), new Guid("c99eca84-3aa1-4a38-abe2-6b551571246d"), new TimeSpan(0, 7, 30, 0, 0), (byte)5 },
                    { new Guid("d5d62b05-72c2-45ec-841a-3f1fb3c05938"), new TimeSpan(0, 18, 0, 0, 0), new Guid("c99eca84-3aa1-4a38-abe2-6b551571246d"), new TimeSpan(0, 7, 30, 0, 0), (byte)4 },
                    { new Guid("2b832724-0faa-4e71-9af5-373052d6c368"), new TimeSpan(0, 18, 0, 0, 0), new Guid("c99eca84-3aa1-4a38-abe2-6b551571246d"), new TimeSpan(0, 7, 30, 0, 0), (byte)3 },
                    { new Guid("49efd4d4-624f-4a55-bf22-198b9e6924ac"), new TimeSpan(0, 18, 0, 0, 0), new Guid("bd0f8083-8072-4a25-8d13-90a85f2caeca"), new TimeSpan(0, 8, 0, 0, 0), (byte)5 },
                    { new Guid("f99f1587-e3b0-4ac7-8b97-a552b2bb9423"), new TimeSpan(0, 18, 0, 0, 0), new Guid("c99eca84-3aa1-4a38-abe2-6b551571246d"), new TimeSpan(0, 7, 30, 0, 0), (byte)2 },
                    { new Guid("e416bca8-0534-42a2-9002-46b3bf016d44"), new TimeSpan(0, 14, 0, 0, 0), new Guid("cab1c429-3a2d-4e30-b8a4-f9281b71ed7e"), new TimeSpan(0, 9, 0, 0, 0), (byte)7 },
                    { new Guid("e1137b08-edf1-4159-b0a1-0484e28eac72"), new TimeSpan(0, 14, 0, 0, 0), new Guid("cab1c429-3a2d-4e30-b8a4-f9281b71ed7e"), new TimeSpan(0, 9, 0, 0, 0), (byte)6 },
                    { new Guid("d549b3f0-775b-45af-b425-d207b5afb637"), new TimeSpan(0, 18, 0, 0, 0), new Guid("cab1c429-3a2d-4e30-b8a4-f9281b71ed7e"), new TimeSpan(0, 7, 30, 0, 0), (byte)5 },
                    { new Guid("b3e031f0-73c0-4d37-94a9-bd82339882d8"), new TimeSpan(0, 18, 0, 0, 0), new Guid("cab1c429-3a2d-4e30-b8a4-f9281b71ed7e"), new TimeSpan(0, 7, 30, 0, 0), (byte)4 },
                    { new Guid("39e04286-1a37-4e7e-b00e-5b255b83fc10"), new TimeSpan(0, 18, 0, 0, 0), new Guid("cab1c429-3a2d-4e30-b8a4-f9281b71ed7e"), new TimeSpan(0, 7, 30, 0, 0), (byte)3 },
                    { new Guid("da0a5d81-8a06-495e-be79-71cc5973b2b7"), new TimeSpan(0, 18, 0, 0, 0), new Guid("cab1c429-3a2d-4e30-b8a4-f9281b71ed7e"), new TimeSpan(0, 7, 30, 0, 0), (byte)2 },
                    { new Guid("d8fa07de-df5d-46e6-abe1-eb3552f083f4"), new TimeSpan(0, 16, 0, 0, 0), new Guid("c99eca84-3aa1-4a38-abe2-6b551571246d"), new TimeSpan(0, 7, 30, 0, 0), (byte)1 },
                    { new Guid("39dc4a1a-0bfc-4c7c-8d6b-77274d0d2947"), new TimeSpan(0, 15, 0, 0, 0), new Guid("bd0f8083-8072-4a25-8d13-90a85f2caeca"), new TimeSpan(0, 9, 0, 0, 0), (byte)6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBooks_AuthorId",
                table: "AuthorBooks",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CoverTypeId",
                table: "Books",
                column: "CoverTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_LanguageId",
                table: "Books",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_InterpreterBooks_InterpreterId",
                table: "InterpreterBooks",
                column: "InterpreterId");

            migrationBuilder.CreateIndex(
                name: "IX_PainterBooks_PainterId",
                table: "PainterBooks",
                column: "PainterId");

            migrationBuilder.CreateIndex(
                name: "IX_Painters_StyleId",
                table: "Painters",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShedules_ShopId",
                table: "WorkShedules",
                column: "ShopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBooks");

            migrationBuilder.DropTable(
                name: "InterpreterBooks");

            migrationBuilder.DropTable(
                name: "PainterBooks");

            migrationBuilder.DropTable(
                name: "WorkShedules");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Interpreters");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Painters");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "CoverTypes");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "PainterStyles");
        }
    }
}
