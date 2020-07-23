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
                    Name = table.Column<string>(type: "varchar(40)", nullable: true),
                    Age = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", nullable: true)
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
                    Name = table.Column<string>(type: "varchar(30)", nullable: true)
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
                    Name = table.Column<string>(type: "varchar(20)", nullable: true)
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
                    Name = table.Column<string>(type: "varchar(40)", nullable: true),
                    Age = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", nullable: true)
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
                    Name = table.Column<string>(type: "varchar(20)", nullable: true)
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
                    Name = table.Column<string>(type: "varchar(30)", nullable: true)
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
                    Name = table.Column<string>(type: "varchar(40)", nullable: true),
                    Age = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", nullable: true),
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
                    Name = table.Column<string>(type: "varchar(50)", nullable: true),
                    PublishDate = table.Column<DateTime>(type: "Date", nullable: false),
                    CoverTypeId = table.Column<Guid>(nullable: true),
                    GenreId = table.Column<Guid>(nullable: true),
                    LanguageId = table.Column<Guid>(nullable: true),
                    Description = table.Column<string>(type: "varchar(1000)", nullable: true),
                    ISBN_13 = table.Column<string>(type: "char(17)", nullable: true),
                    Format = table.Column<string>(type: "varchar(30)", nullable: true),
                    CountPage = table.Column<short>(type: "smallint", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(8,2)", nullable: false),
                    Weight = table.Column<short>(type: "smallint", nullable: false),
                    Duplicate = table.Column<short>(type: "smallint", nullable: false),
                    AgeLimit = table.Column<byte>(type: "tinyint", nullable: false),
                    PublisherId = table.Column<Guid>(nullable: true)
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
                        name: "FK_Books_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
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
                table: "Authors",
                columns: new[] { "Id", "Age", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("6be1a08c-550c-447f-bb67-d1e1f5275dbf"), (byte)91, "В 1937 году Брэдбери вступил в лос-анджелесскую «Лигу научных фантастов», которая была одним из многих объединений молодых писателей, активно возникавших в возрождающейся после Великой Депрессии Америке.", "Рэй Дуглас Брэдбери" },
                    { new Guid("d1ecb608-293b-40df-bcaf-02ada7abf05a"), (byte)46, "Начиная с основанной на автобиографическом материале повести «Фунты лиха в Париже и Лондоне» (1933), публиковался под псевдонимом «Джордж Оруэлл», взятом в честь реки Оруэлл, одного из его любимых мест в Англии.", "Джордж Оруэлл" },
                    { new Guid("1157dee0-8f67-43d2-8aa1-3d7a2272e3d7"), (byte)68, "Во время своего второго пребывания в австралийской тюрьме Робертс начинает работу над романом «Шантарам». Дважды рукописи уничтожались тюремными надзирателями.", "Грегори Дэвид Робертс" },
                    { new Guid("11476765-e104-4900-bea9-17100d084ed6"), (byte)48, "В 1923 году Булгаков вступил во Всероссийский союз писателей. В 1924 году он познакомился с недавно вернувшейся из-за границы Любовью Евгеньевной Белозерской (1895—1987), которая в 1925 году стала его женой.", "Михаил Афанасьевич Булгаков" },
                    { new Guid("6b6f819c-2a9d-4ef9-92dd-55f69097f36c"), (byte)72, "В 1929 году вышел в свет роман «На Западном фронте без перемен», описывающий жестокость войны с точки зрения 20-летнего солдата. Роман мгновенно стал настоящей сенсацией. За год было продано полтора миллиона экземпляров. Позднее он был переведён на 36 языков мира.", "Эрих Мария Ремарк" },
                    { new Guid("bc72faf4-f5ea-41b4-b85b-835731bdb0f7"), (byte)44, "В апреле 1935 года, в качестве корреспондента газеты «Пари-Суар», Сент-Экзюпери посетил СССР и описал этот визит в пяти очерках. Очерк «Преступление и наказание перед лицом советского правосудия» стал одним из первых произведений писателей Запада, в котором делалась попытка осмыслить сталинизм.", "Антуан де Сент-Экзюпери" }
                });

            migrationBuilder.InsertData(
                table: "CoverTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("f586ce45-08d0-46a5-931a-7a10fdab654d"), "Твердая глянцевая" },
                    { new Guid("6804baa3-f2fe-4062-84e1-e3d636ade0d7"), "Мягкая глянцевая" },
                    { new Guid("33aa3511-8c70-4e19-9719-321d4b79f588"), "Твердая стеклянная" },
                    { new Guid("07b46856-7089-4d71-a07a-40068f79ff2d"), "Мягкая стеклянная" },
                    { new Guid("47b06aac-5e4a-4541-b1b6-dcb5ec8f69dc"), "Твердая картонная" },
                    { new Guid("fc4519df-a67d-4686-904b-4ee105f37d22"), "Мягкая картонная" },
                    { new Guid("56d180ca-f9bd-4dad-87ef-af334f636be1"), "Твердая бумажная" },
                    { new Guid("f3ff3c04-893a-40bc-9854-1c2ba98c8265"), "Мягкая бумажная" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("29c1b4ad-05e6-4752-ba67-47dc45a0fe46"), "Триллер" },
                    { new Guid("cfb89ffe-f0c9-4821-a499-2fcaf38fca16"), "Антиутопия" },
                    { new Guid("4edb8ea0-d704-4e41-babb-c90017b0abed"), "Детектив" },
                    { new Guid("e36af307-b334-4074-91b4-c2e14d043743"), "Роман" },
                    { new Guid("7bb337b5-6b47-4613-8657-6f78506fe117"), "Мемуары" },
                    { new Guid("8171d6b3-425a-40d9-a7dc-0bf26d3576bc"), "Пьеса" },
                    { new Guid("29388b16-5322-4b77-bd19-eb6844a05e27"), "Мьюзикл" },
                    { new Guid("0adc9006-ccc6-4d89-87ae-f9373d08152f"), "Сатира" },
                    { new Guid("2916347b-080c-4196-8585-6de05fbc430f"), "Хайку" },
                    { new Guid("7cf21233-4caf-4902-bcc1-85a677bf1c59"), "Ужасы" },
                    { new Guid("6aed17e9-b4f9-4997-b115-6da1dfdcca80"), "Классика" },
                    { new Guid("a333d616-ee40-4f7c-a08f-f6542bacc1e1"), "Мистика" },
                    { new Guid("cc169b1e-d765-4186-8d2a-7b52700c6920"), "Вестерн" },
                    { new Guid("081e6e09-02df-4942-b799-c7235de02793"), "Биография" },
                    { new Guid("e8e4d3c5-1bd3-44f2-9120-5c39e44c553f"), "Фантастика" },
                    { new Guid("7fb2db94-ebb6-4235-a3e5-182e735b8bf8"), "Научная фантастика" }
                });

            migrationBuilder.InsertData(
                table: "Interpreters",
                columns: new[] { "Id", "Age", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("fec297d0-8287-42f3-81bd-311ae1b0c6c6"), (byte)75, "Известный писатель уверял, что взялся за перевод «Рэгтайма» Доктороу (вышел в 1976 году) только для того, чтобы подтянуть свой английский; но, кажется, всё-таки несколько лукавил.", "Василий Аксёнов" },
                    { new Guid("9a46e40f-57dc-465c-8d2b-67edf3cf5b4e"), (byte)53, "Именно с Раисой Яковлевной Ковалевой, писавшей под псевдонимом Рита Райт, связано возникновение литературного анекдота (зафиксированного или придуманного Довлатовым) о «писателях, сильно выигрывающих в переводе».", "Рита Райт-Ковалева" },
                    { new Guid("a549b273-8114-420c-ae56-e9d9163c1668"), (byte)76, "В отличие от Мандельштама и Цветаевой, к переводу обращавшихся пылко и стихийно, Пастернак был весьма трудолюбивым и продуктивным переводчиком.", "Борис Пастернак" },
                    { new Guid("11b6c2ed-98fe-4322-93c6-50197766fd9f"), (byte)45, "Виднейший представитель Серебряного века, поэт-символист и пропагандист французских символистов, всё-таки как переводчик больше всего запомнился переложением античных классиков.", "Иннокентий Анненский" },
                    { new Guid("9dfae902-8fd6-4551-be3a-3b8f5aa53bb8"), (byte)66, "Оригинальный поэт и переводчик разноликой, но всегда пылкой испанской поэзии, как нельзя лучше соответствующей его собственному пылкому темпераменту.", "Павел Грушко" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("8d13a346-389b-48b3-9299-a565bf2a6658"), "Французский" },
                    { new Guid("90b9df3b-581f-4f92-adee-251630a72a9e"), "Бразильский" },
                    { new Guid("3206ceea-d1f4-4659-a0cd-3f7b5100c73d"), "Китайский" },
                    { new Guid("ae0cf116-c244-4997-93cd-f7760a93fe0f"), "Японский" },
                    { new Guid("08fee749-b64b-4815-823a-b36b1ab6371e"), "Русский" },
                    { new Guid("f1f085b5-689c-4675-ad84-4f47a5d0883e"), "Немецкий" },
                    { new Guid("02a20c75-b5ce-4c81-8fd4-02ba505aca1a"), "Португальский" },
                    { new Guid("67cbe600-e220-42c5-b526-6fe821476273"), "Английский" }
                });

            migrationBuilder.InsertData(
                table: "PainterStyles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("d6247b75-b2fc-4c7f-926c-bf2e0b011cf0"), "Аналитический кубизм" },
                    { new Guid("128bc5f7-3842-4a74-91d0-dd62064f9802"), "Арт-Деко" },
                    { new Guid("b08f1f01-d09c-42c7-9a6d-4e355c3fb599"), "Бедное искусство" },
                    { new Guid("a713584e-be49-4b35-8dac-c114213c1a2b"), "Арт-Брут" },
                    { new Guid("f0c8630d-2e1b-4536-b0d1-f2e4a0e1da81"), "Модерн" },
                    { new Guid("af18c5dc-800c-485b-ab1a-16b15dcded18"), "Подземный" },
                    { new Guid("27078d1d-666a-4827-8f61-2683ae305f4d"), "Анахронизм" },
                    { new Guid("018c691d-5f4a-47fe-8fee-19d45877dabd"), "Абстракция" },
                    { new Guid("fe4bb701-b2c2-40b5-ae4e-4e46edad36d1"), "Абстракция Импрессионизм" },
                    { new Guid("6801a5c4-fc35-468d-884f-75af47a288d6"), "Авангард" },
                    { new Guid("603e8dca-6fe7-440a-821a-a27086742778"), "Академизм" },
                    { new Guid("791ddbdc-05ee-4a15-afbb-f866a978d5e7"), "Искусство действия" },
                    { new Guid("d680babb-53dc-430e-a267-11669c07fa5c"), "Империализм" },
                    { new Guid("e2dec289-43bb-4087-9b67-bfde445587db"), "Аналитическое искусство" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("fe0f989d-1eb9-467e-8fbf-c783d70171bc"), "Эксмо" },
                    { new Guid("b9af4688-e273-4676-a92a-656023a2d216"), "Рипол Классик" },
                    { new Guid("6a8c18f9-b8c3-4964-8494-81c26d6af209"), "Вече" },
                    { new Guid("5ec79a9a-93ac-4956-861e-ccfa8696e13d"), "Азбука" },
                    { new Guid("94834ccb-a363-4566-bf2c-d73ff9ba958f"), "Детская литература" },
                    { new Guid("3f755440-89bf-4335-99a7-db1d9226d666"), "Амфора" }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { new Guid("06c5d83e-ac7f-4c4c-8ad5-79bb9e914ef8"), "Красный проспект 234", "Звенящий брелок" },
                    { new Guid("cab1c429-3a2d-4e30-b8a4-f9281b71ed7e"), "Советская 65", "Книжная штучка" },
                    { new Guid("c99eca84-3aa1-4a38-abe2-6b551571246d"), "Мира 22", "Большая закладка" },
                    { new Guid("bd0f8083-8072-4a25-8d13-90a85f2caeca"), "Маркса проспект 3", "Скрытая обложка" },
                    { new Guid("27cf46b3-a2aa-4351-af82-e33f36f1c553"), "Заельцовская 123", "Глубокий кошелек" },
                    { new Guid("905d9ed8-0bd5-402a-be16-73c021176c78"), "Революции 89", "Теплый носок" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AgeLimit", "CountPage", "CoverTypeId", "Description", "Duplicate", "Format", "GenreId", "ISBN_13", "LanguageId", "Name", "Price", "PublishDate", "PublisherId", "Weight" },
                values: new object[,]
                {
                    { new Guid("aa585855-0feb-418c-acc5-6e98e20b972a"), (byte)16, (short)350, new Guid("f3ff3c04-893a-40bc-9854-1c2ba98c8265"), "О дивный новый мир - изысканная и остроумная антиутопия о генетически программируемом обществе потребления, в котором разворачивается трагическая история Дикаря - Гамлета этого мира.", (short)5000, "18 x 11.6 x 1.9", new Guid("cfb89ffe-f0c9-4821-a499-2fcaf38fca16"), "978-5-17-080085-8", new Guid("67cbe600-e220-42c5-b526-6fe821476273"), "О дивный новый мир", 212m, new DateTime(2014, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fe0f989d-1eb9-467e-8fbf-c783d70171bc"), (short)200 },
                    { new Guid("5628b2d6-4ed2-4b3e-b71f-6764a2489b25"), (byte)16, (short)220, new Guid("56d180ca-f9bd-4dad-87ef-af334f636be1"), "Алхимик» – самый известный роман бразильского писателя Пауло Коэльо, любимая книга миллионов людей во всем мире.", (short)10000, "18 x 11.5 x 1.3", new Guid("e8e4d3c5-1bd3-44f2-9120-5c39e44c553f"), "978-5-17-087921-2", new Guid("67cbe600-e220-42c5-b526-6fe821476273"), "Алхимик", 250m, new DateTime(2015, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5ec79a9a-93ac-4956-861e-ccfa8696e13d"), (short)160 },
                    { new Guid("1ffa9b7c-e021-4084-a14b-35839b9cc9d2"), (byte)16, (short)318, new Guid("07b46856-7089-4d71-a07a-40068f79ff2d"), "Своеобразный антипод второй великой антиутопии XX века - О дивный новый мир Олдоса Хаксли. Что, в сущности, страшнее: доведенное до абсурда общество потребления - или доведенное до абсолюта общество идеи? По Оруэллу, нет и не может быть ничего ужаснее тотальной несвободы...", (short)7000, "18.1 x 11.7 x 2", new Guid("cfb89ffe-f0c9-4821-a499-2fcaf38fca16"), "978-5-17-080115-2", new Guid("67cbe600-e220-42c5-b526-6fe821476273"), "1984", 203m, new DateTime(2014, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b9af4688-e273-4676-a92a-656023a2d216"), (short)230 },
                    { new Guid("7db924d8-00a7-4b46-9e31-73d95c38eb31"), (byte)18, (short)400, new Guid("47b06aac-5e4a-4541-b1b6-dcb5ec8f69dc"), "В детстве маленького Мики было всё, как у обычных детей: любимые герои, каши по утрам, дни рождения, скучные линейки в школе и сочинения на заданные темы.", (short)2000, "21 x 14 x 3.2", new Guid("29c1b4ad-05e6-4752-ba67-47dc45a0fe46"), "978-5-6043606-3-7", new Guid("f1f085b5-689c-4675-ad84-4f47a5d0883e"), "Дни нашей жизни", 330m, new DateTime(2020, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6a8c18f9-b8c3-4964-8494-81c26d6af209"), (short)380 },
                    { new Guid("8c038acd-17db-4554-a741-de98ca121256"), (byte)18, (short)320, new Guid("fc4519df-a67d-4686-904b-4ee105f37d22"), "Андре Асимана называют одним из важнейших романистов современности. «Найди меня» — долгожданное продолжение его бестселлера «Назови меня своим именем», покорившего миллионы читателей во всем мире.", (short)15000, "21 x 14 x 1.9", new Guid("e36af307-b334-4074-91b4-c2e14d043743"), "978-5-6042628-9-4", new Guid("08fee749-b64b-4815-823a-b36b1ab6371e"), "Найди меня", 363m, new DateTime(2020, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6a8c18f9-b8c3-4964-8494-81c26d6af209"), (short)330 },
                    { new Guid("4b9c14fd-7788-4c89-b778-459ee7a4415b"), (byte)15, (short)436, new Guid("f586ce45-08d0-46a5-931a-7a10fdab654d"), "В первой части читатели знакомятся с главными героями, гениальными предпринимателями, которым противостоят их антиподы - бездарные государственные чиновники. Повествование начинается с вопроса: кто такой Джон Голт? И на этот вопрос будут искать ответ герои романа и его читатели.", (short)17000, "21.7 x 14.8 x 2", new Guid("6aed17e9-b4f9-4997-b115-6da1dfdcca80"), "978-5-9614-6742-0", new Guid("ae0cf116-c244-4997-93cd-f7760a93fe0f"), "Атлант расправил плечи (комплект из 3 книг)", 792m, new DateTime(2018, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("94834ccb-a363-4566-bf2c-d73ff9ba958f"), (short)1700 },
                    { new Guid("d22d44a7-e987-4f8f-8cb2-0768cc6199c6"), (byte)14, (short)384, new Guid("33aa3511-8c70-4e19-9719-321d4b79f588"), "На первый взгляд Уве — самый угрюмый человек на свете. Он, как и многие из нас, полагает, что его окружают преимущественно идиоты — соседи, которые неправильно паркуют свои машины; продавцы в магазине, говорящие на птичьем языке; бюрократы, портящие жизнь нормальным людям.", (short)5000, "20.5 x 13 x 2.4", new Guid("7bb337b5-6b47-4613-8657-6f78506fe117"), "978-5-905891-97-7", new Guid("90b9df3b-581f-4f92-adee-251630a72a9e"), "Вторая жизнь Уве", 406m, new DateTime(2017, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3f755440-89bf-4335-99a7-db1d9226d666"), (short)400 },
                    { new Guid("7d1e69bc-f0b2-4bbd-8d87-e2fc2bca53ac"), (byte)12, (short)960, new Guid("56d180ca-f9bd-4dad-87ef-af334f636be1"), "На окраине города, среди стандартных новостроек, стоит Серый Дом, в котором живут Сфинкс, Слепой, Лорд, Табаки, Македонский, Черный и многие другие.", (short)15000, "22 x 15 x 5", new Guid("7cf21233-4caf-4902-bcc1-85a677bf1c59"), "978-5-904584-69-6", new Guid("8d13a346-389b-48b3-9299-a565bf2a6658"), "Дом, в котором…", 605m, new DateTime(2016, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3f755440-89bf-4335-99a7-db1d9226d666"), (short)1050 },
                    { new Guid("f0317cfb-e110-4b92-97b9-a52595cefccd"), (byte)6, (short)320, new Guid("fc4519df-a67d-4686-904b-4ee105f37d22"), "Сорок лет назад это считалось фантастикой. Сорок лет назад это читалось как фантастика. Исследующая и расширяющая границы жанра, жадно впитывающая всевозможные новейшие веяния, примеряющая общечеловеческое лицо, отважно игнорирующая каинову печать жанрового гетто.", (short)3000, "18 x 11.5 x 1.4", new Guid("7fb2db94-ebb6-4235-a3e5-182e735b8bf8"), "978-5-699-41332-4", new Guid("8d13a346-389b-48b3-9299-a565bf2a6658"), "Цветы для Элджернона", 220m, new DateTime(2010, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("94834ccb-a363-4566-bf2c-d73ff9ba958f"), (short)170 },
                    { new Guid("7c7ef3fc-b918-41d5-9e9d-e0549b0f42bc"), (byte)6, (short)544, new Guid("56d180ca-f9bd-4dad-87ef-af334f636be1"), "Одна из величайших книг ХХ века. Странная, поэтичная, причудливая история города Макондо, затерянного где-то в джунглях, – от сотворения до упадка. История рода Буэндиа – семьи, в которой чудеса столь повседневны, что на них даже не обращают внимания.", (short)-15536, "18 x 11.5 x 2.6", new Guid("7fb2db94-ebb6-4235-a3e5-182e735b8bf8"), "978-5-17-090831-8", new Guid("02a20c75-b5ce-4c81-8fd4-02ba505aca1a"), "Сто лет одиночества", 377m, new DateTime(2015, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("94834ccb-a363-4566-bf2c-d73ff9ba958f"), (short)330 }
                });

            migrationBuilder.InsertData(
                table: "Painters",
                columns: new[] { "Id", "Age", "Description", "Name", "StyleId" },
                values: new object[,]
                {
                    { new Guid("20035c22-62c5-4688-b21a-cff0007e871e"), (byte)82, "Гойя начал свой творческий путь с юношеской пылкостью и идеализмом. Даже стал придворным художником при испанском дворе. Но вскоре пресытился жизнью, увидев алчность мира, тупость, ханжество.", "Франсиско Хосе де Гойя-и-Лусьентес", new Guid("27078d1d-666a-4827-8f61-2683ae305f4d") },
                    { new Guid("14587f65-7b1c-4171-b0f0-bf707284710f"), (byte)82, "йвазовский по праву находится в рейтинге самых известных художников. Его «Девятый вал» поражает своим масштабом.", "Иван Константинович Айвазовский", new Guid("791ddbdc-05ee-4a15-afbb-f866a978d5e7") },
                    { new Guid("549903f5-66ab-48e8-b126-8610c4bb08b9"), (byte)63, "Рембрандт изображал мир таким, какой он был. Без прикрас и лакировок. Но получалось у него это очень душевно.", "Рембрандт Ха́рменс ван Рейн", new Guid("6801a5c4-fc35-468d-884f-75af47a288d6") },
                    { new Guid("d18d0a39-9a5f-476f-8d52-bc0a23a371af"), (byte)66, "Полулюди-полумутанты, громадные птицы и рыбы, невиданные растения и толпы обнаженных грешников… Всё это перемешано и сплетено в многофигурные композиции.", "Иероним Босх", new Guid("018c691d-5f4a-47fe-8fee-19d45877dabd") },
                    { new Guid("b849554a-3b05-4aff-9f81-ac1a4abbfc01"), (byte)67, "Благодаря его картинам мировая живопись вышла на новый качественный уровень. Он двигался в сторону реализма, постигая законы перспективы и разбираясь в анатомическом строении человека.", "Леонардо да Винчи", new Guid("018c691d-5f4a-47fe-8fee-19d45877dabd") },
                    { new Guid("8e9093a9-8f64-4ef5-8d03-090c1ed062a5"), (byte)37, "Самый знаменитый представитель Эпохи Возрождения поражает гармоничными композициями и лиризмом.", "Рафаэль Санти", new Guid("fe4bb701-b2c2-40b5-ae4e-4e46edad36d1") }
                });

            migrationBuilder.InsertData(
                table: "WorkShedules",
                columns: new[] { "Id", "EndTime", "ShopId", "StartTime", "Weekday" },
                values: new object[,]
                {
                    { new Guid("2b832724-0faa-4e71-9af5-373052d6c368"), new TimeSpan(0, 18, 0, 0, 0), new Guid("c99eca84-3aa1-4a38-abe2-6b551571246d"), new TimeSpan(0, 7, 30, 0, 0), (byte)3 },
                    { new Guid("f4c53bb7-ff07-4be6-8657-72c5e54ed18d"), new TimeSpan(0, 20, 0, 0, 0), new Guid("bd0f8083-8072-4a25-8d13-90a85f2caeca"), new TimeSpan(0, 7, 0, 0, 0), (byte)4 },
                    { new Guid("5bab269a-e2be-45d1-a867-ea7295bb6671"), new TimeSpan(0, 18, 0, 0, 0), new Guid("bd0f8083-8072-4a25-8d13-90a85f2caeca"), new TimeSpan(0, 10, 30, 0, 0), (byte)3 },
                    { new Guid("e750f5d4-b698-4196-8337-4551a672a4f4"), new TimeSpan(0, 16, 0, 0, 0), new Guid("bd0f8083-8072-4a25-8d13-90a85f2caeca"), new TimeSpan(0, 10, 30, 0, 0), (byte)1 },
                    { new Guid("17a51ded-63d8-4eb7-9286-cced1e0a03ce"), new TimeSpan(0, 18, 0, 0, 0), new Guid("c99eca84-3aa1-4a38-abe2-6b551571246d"), new TimeSpan(0, 7, 30, 0, 0), (byte)5 },
                    { new Guid("d5d62b05-72c2-45ec-841a-3f1fb3c05938"), new TimeSpan(0, 18, 0, 0, 0), new Guid("c99eca84-3aa1-4a38-abe2-6b551571246d"), new TimeSpan(0, 7, 30, 0, 0), (byte)4 },
                    { new Guid("f99f1587-e3b0-4ac7-8b97-a552b2bb9423"), new TimeSpan(0, 18, 0, 0, 0), new Guid("c99eca84-3aa1-4a38-abe2-6b551571246d"), new TimeSpan(0, 7, 30, 0, 0), (byte)2 },
                    { new Guid("905d9ed8-0bd5-402a-be16-73c021176c78"), new TimeSpan(0, 16, 0, 0, 0), new Guid("cab1c429-3a2d-4e30-b8a4-f9281b71ed7e"), new TimeSpan(0, 7, 30, 0, 0), (byte)1 },
                    { new Guid("e416bca8-0534-42a2-9002-46b3bf016d44"), new TimeSpan(0, 14, 0, 0, 0), new Guid("cab1c429-3a2d-4e30-b8a4-f9281b71ed7e"), new TimeSpan(0, 9, 0, 0, 0), (byte)7 },
                    { new Guid("e1137b08-edf1-4159-b0a1-0484e28eac72"), new TimeSpan(0, 14, 0, 0, 0), new Guid("cab1c429-3a2d-4e30-b8a4-f9281b71ed7e"), new TimeSpan(0, 9, 0, 0, 0), (byte)6 },
                    { new Guid("d549b3f0-775b-45af-b425-d207b5afb637"), new TimeSpan(0, 18, 0, 0, 0), new Guid("cab1c429-3a2d-4e30-b8a4-f9281b71ed7e"), new TimeSpan(0, 7, 30, 0, 0), (byte)5 },
                    { new Guid("b3e031f0-73c0-4d37-94a9-bd82339882d8"), new TimeSpan(0, 18, 0, 0, 0), new Guid("cab1c429-3a2d-4e30-b8a4-f9281b71ed7e"), new TimeSpan(0, 7, 30, 0, 0), (byte)4 },
                    { new Guid("39e04286-1a37-4e7e-b00e-5b255b83fc10"), new TimeSpan(0, 18, 0, 0, 0), new Guid("cab1c429-3a2d-4e30-b8a4-f9281b71ed7e"), new TimeSpan(0, 7, 30, 0, 0), (byte)3 },
                    { new Guid("da0a5d81-8a06-495e-be79-71cc5973b2b7"), new TimeSpan(0, 18, 0, 0, 0), new Guid("cab1c429-3a2d-4e30-b8a4-f9281b71ed7e"), new TimeSpan(0, 7, 30, 0, 0), (byte)2 },
                    { new Guid("49efd4d4-624f-4a55-bf22-198b9e6924ac"), new TimeSpan(0, 18, 0, 0, 0), new Guid("bd0f8083-8072-4a25-8d13-90a85f2caeca"), new TimeSpan(0, 8, 0, 0, 0), (byte)5 },
                    { new Guid("d8fa07de-df5d-46e6-abe1-eb3552f083f4"), new TimeSpan(0, 16, 0, 0, 0), new Guid("c99eca84-3aa1-4a38-abe2-6b551571246d"), new TimeSpan(0, 7, 30, 0, 0), (byte)1 },
                    { new Guid("39dc4a1a-0bfc-4c7c-8d6b-77274d0d2947"), new TimeSpan(0, 15, 0, 0, 0), new Guid("bd0f8083-8072-4a25-8d13-90a85f2caeca"), new TimeSpan(0, 9, 0, 0, 0), (byte)6 }
                });

            migrationBuilder.InsertData(
                table: "AuthorBooks",
                columns: new[] { "BookId", "AuthorId" },
                values: new object[,]
                {
                    { new Guid("aa585855-0feb-418c-acc5-6e98e20b972a"), new Guid("6be1a08c-550c-447f-bb67-d1e1f5275dbf") },
                    { new Guid("5628b2d6-4ed2-4b3e-b71f-6764a2489b25"), new Guid("6be1a08c-550c-447f-bb67-d1e1f5275dbf") },
                    { new Guid("7c7ef3fc-b918-41d5-9e9d-e0549b0f42bc"), new Guid("bc72faf4-f5ea-41b4-b85b-835731bdb0f7") },
                    { new Guid("1ffa9b7c-e021-4084-a14b-35839b9cc9d2"), new Guid("6b6f819c-2a9d-4ef9-92dd-55f69097f36c") },
                    { new Guid("7db924d8-00a7-4b46-9e31-73d95c38eb31"), new Guid("6b6f819c-2a9d-4ef9-92dd-55f69097f36c") },
                    { new Guid("f0317cfb-e110-4b92-97b9-a52595cefccd"), new Guid("bc72faf4-f5ea-41b4-b85b-835731bdb0f7") },
                    { new Guid("8c038acd-17db-4554-a741-de98ca121256"), new Guid("6be1a08c-550c-447f-bb67-d1e1f5275dbf") },
                    { new Guid("8c038acd-17db-4554-a741-de98ca121256"), new Guid("d1ecb608-293b-40df-bcaf-02ada7abf05a") },
                    { new Guid("8c038acd-17db-4554-a741-de98ca121256"), new Guid("1157dee0-8f67-43d2-8aa1-3d7a2272e3d7") },
                    { new Guid("7d1e69bc-f0b2-4bbd-8d87-e2fc2bca53ac"), new Guid("bc72faf4-f5ea-41b4-b85b-835731bdb0f7") },
                    { new Guid("d22d44a7-e987-4f8f-8cb2-0768cc6199c6"), new Guid("6b6f819c-2a9d-4ef9-92dd-55f69097f36c") },
                    { new Guid("4b9c14fd-7788-4c89-b778-459ee7a4415b"), new Guid("bc72faf4-f5ea-41b4-b85b-835731bdb0f7") }
                });

            migrationBuilder.InsertData(
                table: "InterpreterBooks",
                columns: new[] { "BookId", "InterpreterId" },
                values: new object[,]
                {
                    { new Guid("7c7ef3fc-b918-41d5-9e9d-e0549b0f42bc"), new Guid("fec297d0-8287-42f3-81bd-311ae1b0c6c6") },
                    { new Guid("f0317cfb-e110-4b92-97b9-a52595cefccd"), new Guid("fec297d0-8287-42f3-81bd-311ae1b0c6c6") },
                    { new Guid("7d1e69bc-f0b2-4bbd-8d87-e2fc2bca53ac"), new Guid("9a46e40f-57dc-465c-8d2b-67edf3cf5b4e") },
                    { new Guid("d22d44a7-e987-4f8f-8cb2-0768cc6199c6"), new Guid("9a46e40f-57dc-465c-8d2b-67edf3cf5b4e") },
                    { new Guid("8c038acd-17db-4554-a741-de98ca121256"), new Guid("9a46e40f-57dc-465c-8d2b-67edf3cf5b4e") },
                    { new Guid("8c038acd-17db-4554-a741-de98ca121256"), new Guid("a549b273-8114-420c-ae56-e9d9163c1668") },
                    { new Guid("8c038acd-17db-4554-a741-de98ca121256"), new Guid("11b6c2ed-98fe-4322-93c6-50197766fd9f") },
                    { new Guid("7db924d8-00a7-4b46-9e31-73d95c38eb31"), new Guid("a549b273-8114-420c-ae56-e9d9163c1668") },
                    { new Guid("1ffa9b7c-e021-4084-a14b-35839b9cc9d2"), new Guid("a549b273-8114-420c-ae56-e9d9163c1668") },
                    { new Guid("5628b2d6-4ed2-4b3e-b71f-6764a2489b25"), new Guid("9dfae902-8fd6-4551-be3a-3b8f5aa53bb8") },
                    { new Guid("aa585855-0feb-418c-acc5-6e98e20b972a"), new Guid("9dfae902-8fd6-4551-be3a-3b8f5aa53bb8") },
                    { new Guid("4b9c14fd-7788-4c89-b778-459ee7a4415b"), new Guid("fec297d0-8287-42f3-81bd-311ae1b0c6c6") }
                });

            migrationBuilder.InsertData(
                table: "PainterBooks",
                columns: new[] { "BookId", "PainterId" },
                values: new object[,]
                {
                    { new Guid("4b9c14fd-7788-4c89-b778-459ee7a4415b"), new Guid("14587f65-7b1c-4171-b0f0-bf707284710f") },
                    { new Guid("7d1e69bc-f0b2-4bbd-8d87-e2fc2bca53ac"), new Guid("549903f5-66ab-48e8-b126-8610c4bb08b9") },
                    { new Guid("d22d44a7-e987-4f8f-8cb2-0768cc6199c6"), new Guid("549903f5-66ab-48e8-b126-8610c4bb08b9") },
                    { new Guid("8c038acd-17db-4554-a741-de98ca121256"), new Guid("549903f5-66ab-48e8-b126-8610c4bb08b9") },
                    { new Guid("1ffa9b7c-e021-4084-a14b-35839b9cc9d2"), new Guid("8e9093a9-8f64-4ef5-8d03-090c1ed062a5") },
                    { new Guid("5628b2d6-4ed2-4b3e-b71f-6764a2489b25"), new Guid("b849554a-3b05-4aff-9f81-ac1a4abbfc01") },
                    { new Guid("8c038acd-17db-4554-a741-de98ca121256"), new Guid("8e9093a9-8f64-4ef5-8d03-090c1ed062a5") },
                    { new Guid("8c038acd-17db-4554-a741-de98ca121256"), new Guid("d18d0a39-9a5f-476f-8d52-bc0a23a371af") },
                    { new Guid("aa585855-0feb-418c-acc5-6e98e20b972a"), new Guid("b849554a-3b05-4aff-9f81-ac1a4abbfc01") },
                    { new Guid("7c7ef3fc-b918-41d5-9e9d-e0549b0f42bc"), new Guid("20035c22-62c5-4688-b21a-cff0007e871e") },
                    { new Guid("7db924d8-00a7-4b46-9e31-73d95c38eb31"), new Guid("8e9093a9-8f64-4ef5-8d03-090c1ed062a5") },
                    { new Guid("f0317cfb-e110-4b92-97b9-a52595cefccd"), new Guid("20035c22-62c5-4688-b21a-cff0007e871e") }
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
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

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
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "PainterStyles");
        }
    }
}
