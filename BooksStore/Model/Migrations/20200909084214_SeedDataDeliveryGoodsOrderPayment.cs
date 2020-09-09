using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class SeedDataDeliveryGoodsOrderPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Shops",
                type: "nvarchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Shops",
                type: "nvarchar(40)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Publishers",
                type: "nvarchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Painters",
                type: "nvarchar(40)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Painters",
                type: "nvarchar(1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreate",
                table: "Orders",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Orders",
                type: "nvarchar(255)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Interpreters",
                type: "nvarchar(40)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Interpreters",
                type: "nvarchar(1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Books",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Format",
                table: "Books",
                type: "nvarchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Books",
                type: "nvarchar(1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Authors",
                type: "nvarchar(40)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Authors",
                type: "nvarchar(1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password", "RefreshToken", "Role", "Salt" },
                values: new object[,]
                {
                    { new Guid("30be92d8-e0db-4386-9131-93d6cc4b7c47"), "Admin", "zkf+O+PEIGXDH1e3QH4VxzSZ+KmyTRdEAMcdTTZG2Us=", "6tSd7w8IIfn/hjALkg956tmNv9B4D6Hln55ex5eeaqM=", "Admin", "TZWr5bFhm/4Q9aBMIcoWHg==" },
                    { new Guid("54b6722e-1e29-4cc6-ada7-8d4edd5a13e4"), "User", "Vw1VEVsmrCT7Tatr3BjWm6AJ6qNQuDXQRy5g37Yn5G0=", "deVLGazeUzcekUIV3z35EDt6pV83KJT6bQvBPshdb9c=", "Common", "/bcwNvLg4NREg8EO13xenw==" },
                    { new Guid("108c5883-e2b7-4937-a04d-f7c059b8acd3"), "Granula", "T/e1VM+cbVU1QVb/NrU7u22Ozs985MqQxlXY0vsgLqU=", "0FV7lKM5tM0tGfxe37/Ka4xOnaYgdjU5/T8VPPpJBfA=", "Common", "Ln6EgB8gS3TyirdJ537Z4g==" },
                    { new Guid("367c6b4e-8650-481c-80d5-6db6bf583095"), "1", "joGTNbiLAhq6eGZC/IuVZ6vBOVyWNpxtusxSuK0CFX0=", "2kYrPG5rPVJwzi6skdwjXtngll0So2C14EvA4JIoq3U=", "Common", "ZbG5fC/42FHLxbnUY3UhPQ==" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Amount", "DateCreate", "Description", "Status", "UserId" },
                values: new object[,]
                {
                    { new Guid("d8607511-c1d8-4526-8f9f-52791d4158d4"), 609.00m, new DateTime(2020, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, (byte)0, new Guid("30be92d8-e0db-4386-9131-93d6cc4b7c47") },
                    { new Guid("daa03cd1-33a0-4d97-88b5-408cbacfc456"), 1042.00m, new DateTime(2020, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, (byte)1, new Guid("30be92d8-e0db-4386-9131-93d6cc4b7c47") },
                    { new Guid("a3de7602-4018-4718-90a9-e7d0a299f315"), 212.00m, new DateTime(2020, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, (byte)2, new Guid("54b6722e-1e29-4cc6-ada7-8d4edd5a13e4") },
                    { new Guid("5f98d03e-b6dc-41a7-9f3d-86fdda264f26"), 550.00m, new DateTime(2020, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, (byte)3, new Guid("54b6722e-1e29-4cc6-ada7-8d4edd5a13e4") },
                    { new Guid("7faa8f3d-8557-43b3-9ace-69259a5ac75e"), 1345.00m, new DateTime(2020, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, (byte)4, new Guid("108c5883-e2b7-4937-a04d-f7c059b8acd3") },
                    { new Guid("f59e96be-73a2-40fa-95b1-c931b9df6c57"), 305.00m, new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, (byte)5, new Guid("108c5883-e2b7-4937-a04d-f7c059b8acd3") },
                    { new Guid("102b2a76-87cd-41b5-ab47-7a6d78e2bf9e"), 3758.00m, new DateTime(2020, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, (byte)6, new Guid("367c6b4e-8650-481c-80d5-6db6bf583095") }
                });

            migrationBuilder.InsertData(
                table: "Deliveries",
                columns: new[] { "Id", "DateCreate", "DateDelivery", "OrderId", "ShopId", "Status" },
                values: new object[,]
                {
                    { new Guid("0fd51bef-3c0e-4cd4-946a-d1f2982d0eab"), new DateTime(2020, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("d8607511-c1d8-4526-8f9f-52791d4158d4"), new Guid("c99eca84-3aa1-4a38-abe2-6b551571246d"), (byte)0 },
                    { new Guid("9370693c-5d3d-4bd1-9077-9d4cc9c3a23b"), new DateTime(2020, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("daa03cd1-33a0-4d97-88b5-408cbacfc456"), new Guid("905d9ed8-0bd5-402a-be16-73c021176c78"), (byte)1 },
                    { new Guid("97680b55-e371-4653-b017-ce128ab423d9"), new DateTime(2020, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a3de7602-4018-4718-90a9-e7d0a299f315"), new Guid("06c5d83e-ac7f-4c4c-8ad5-79bb9e914ef8"), (byte)2 },
                    { new Guid("8c7a2ffb-36a4-4e48-af52-b2dc4e7b810b"), new DateTime(2020, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5f98d03e-b6dc-41a7-9f3d-86fdda264f26"), new Guid("bd0f8083-8072-4a25-8d13-90a85f2caeca"), (byte)3 }
                });

            migrationBuilder.InsertData(
                table: "GoodsOrders",
                columns: new[] { "Id", "Amount", "BookId", "OrderId" },
                values: new object[,]
                {
                    { new Guid("eb63dc41-101e-4b92-bdf9-6de2f9543539"), 363.00m, new Guid("8c038acd-17db-4554-a741-de98ca121256"), new Guid("102b2a76-87cd-41b5-ab47-7a6d78e2bf9e") },
                    { new Guid("c4d4bfc7-7eec-4cf9-b28b-c71b54bbb870"), 220.00m, new Guid("f0317cfb-e110-4b92-97b9-a52595cefccd"), new Guid("102b2a76-87cd-41b5-ab47-7a6d78e2bf9e") },
                    { new Guid("438dccf5-8d67-4041-a986-507260de9fc9"), 330.00m, new Guid("7db924d8-00a7-4b46-9e31-73d95c38eb31"), new Guid("102b2a76-87cd-41b5-ab47-7a6d78e2bf9e") },
                    { new Guid("fb2da9fc-a79e-4ad2-a774-f60e4b4d7019"), 212.00m, new Guid("aa585855-0feb-418c-acc5-6e98e20b972a"), new Guid("102b2a76-87cd-41b5-ab47-7a6d78e2bf9e") },
                    { new Guid("24528302-a0f6-4336-a619-ba214f7b541d"), 250.00m, new Guid("5628b2d6-4ed2-4b3e-b71f-6764a2489b25"), new Guid("102b2a76-87cd-41b5-ab47-7a6d78e2bf9e") },
                    { new Guid("f81172a1-c56a-4132-b079-d140bbbf9e09"), 792.00m, new Guid("4b9c14fd-7788-4c89-b778-459ee7a4415b"), new Guid("102b2a76-87cd-41b5-ab47-7a6d78e2bf9e") },
                    { new Guid("f84c5095-e697-4d9d-9353-55c173e5d9fe"), 203.00m, new Guid("1ffa9b7c-e021-4084-a14b-35839b9cc9d2"), new Guid("102b2a76-87cd-41b5-ab47-7a6d78e2bf9e") },
                    { new Guid("cf24dab5-2cb5-48d5-b48a-aab6311bba73"), 406.00m, new Guid("d22d44a7-e987-4f8f-8cb2-0768cc6199c6"), new Guid("102b2a76-87cd-41b5-ab47-7a6d78e2bf9e") },
                    { new Guid("08d4459e-53b6-4f53-820b-83f0a0feacfe"), 350.00m, new Guid("d22d44a7-e987-4f8f-8cb2-0768cc6199c6"), new Guid("f59e96be-73a2-40fa-95b1-c931b9df6c57") },
                    { new Guid("f79cd55b-4f2a-45f4-b6a5-c39f0f30e6e5"), 605.00m, new Guid("7d1e69bc-f0b2-4bbd-8d87-e2fc2bca53ac"), new Guid("7faa8f3d-8557-43b3-9ace-69259a5ac75e") },
                    { new Guid("a2cd5cd8-cba4-466c-b10c-357a26e9953e"), 377.00m, new Guid("7c7ef3fc-b918-41d5-9e9d-e0549b0f42bc"), new Guid("7faa8f3d-8557-43b3-9ace-69259a5ac75e") },
                    { new Guid("c2d2d8c8-0a7b-4b9d-a252-3b0a1fb93621"), 605.00m, new Guid("7d1e69bc-f0b2-4bbd-8d87-e2fc2bca53ac"), new Guid("102b2a76-87cd-41b5-ab47-7a6d78e2bf9e") },
                    { new Guid("0b91f2ad-fe56-4a46-940a-da24d573e3fe"), 377.00m, new Guid("7c7ef3fc-b918-41d5-9e9d-e0549b0f42bc"), new Guid("102b2a76-87cd-41b5-ab47-7a6d78e2bf9e") },
                    { new Guid("e74e7c9b-ca11-4a15-9a3c-cd1bca6c106a"), 220.00m, new Guid("f0317cfb-e110-4b92-97b9-a52595cefccd"), new Guid("5f98d03e-b6dc-41a7-9f3d-86fdda264f26") },
                    { new Guid("d47f8265-234e-4768-93ab-becfa12d30e1"), 330.00m, new Guid("7db924d8-00a7-4b46-9e31-73d95c38eb31"), new Guid("5f98d03e-b6dc-41a7-9f3d-86fdda264f26") },
                    { new Guid("1ac0af9e-9ce5-44c1-b137-0d1ec1dde4cc"), 212.00m, new Guid("aa585855-0feb-418c-acc5-6e98e20b972a"), new Guid("a3de7602-4018-4718-90a9-e7d0a299f315") },
                    { new Guid("ee70a5b5-0c57-4f3c-ac52-4ea0c55ee72f"), 250.00m, new Guid("5628b2d6-4ed2-4b3e-b71f-6764a2489b25"), new Guid("daa03cd1-33a0-4d97-88b5-408cbacfc456") },
                    { new Guid("b4fb0847-3b64-4165-b7db-856722f97a29"), 792.00m, new Guid("4b9c14fd-7788-4c89-b778-459ee7a4415b"), new Guid("daa03cd1-33a0-4d97-88b5-408cbacfc456") },
                    { new Guid("5b49a70f-96ea-4daa-b0ee-8ba0607fd244"), 203.00m, new Guid("1ffa9b7c-e021-4084-a14b-35839b9cc9d2"), new Guid("d8607511-c1d8-4526-8f9f-52791d4158d4") },
                    { new Guid("f9a4622b-50ce-4de6-b980-d39579057724"), 406.00m, new Guid("d22d44a7-e987-4f8f-8cb2-0768cc6199c6"), new Guid("d8607511-c1d8-4526-8f9f-52791d4158d4") },
                    { new Guid("aa2c7025-9f16-46eb-8767-4bdb03e8db73"), 363.00m, new Guid("8c038acd-17db-4554-a741-de98ca121256"), new Guid("7faa8f3d-8557-43b3-9ace-69259a5ac75e") }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "DateCreate", "DatePayment", "OrderId", "Status" },
                values: new object[,]
                {
                    { new Guid("5efb4e85-c71e-4c68-ad5e-8af4cd2148f8"), 212.00m, new DateTime(2020, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a3de7602-4018-4718-90a9-e7d0a299f315"), (byte)2 },
                    { new Guid("3d9d3cbc-8494-4e01-9228-e686ac5658fa"), 1042.00m, new DateTime(2020, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("daa03cd1-33a0-4d97-88b5-408cbacfc456"), (byte)1 },
                    { new Guid("230c4b58-5f99-4279-a2d4-4af5c3af28db"), 303.00m, new DateTime(2020, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("d8607511-c1d8-4526-8f9f-52791d4158d4"), (byte)0 },
                    { new Guid("62a2d8b3-144b-49b8-8285-2c07e1d52456"), 550.00m, new DateTime(2020, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5f98d03e-b6dc-41a7-9f3d-86fdda264f26"), (byte)2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: new Guid("0fd51bef-3c0e-4cd4-946a-d1f2982d0eab"));

            migrationBuilder.DeleteData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: new Guid("8c7a2ffb-36a4-4e48-af52-b2dc4e7b810b"));

            migrationBuilder.DeleteData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: new Guid("9370693c-5d3d-4bd1-9077-9d4cc9c3a23b"));

            migrationBuilder.DeleteData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: new Guid("97680b55-e371-4653-b017-ce128ab423d9"));

            migrationBuilder.DeleteData(
                table: "GoodsOrders",
                keyColumn: "Id",
                keyValue: new Guid("08d4459e-53b6-4f53-820b-83f0a0feacfe"));

            migrationBuilder.DeleteData(
                table: "GoodsOrders",
                keyColumn: "Id",
                keyValue: new Guid("0b91f2ad-fe56-4a46-940a-da24d573e3fe"));

            migrationBuilder.DeleteData(
                table: "GoodsOrders",
                keyColumn: "Id",
                keyValue: new Guid("1ac0af9e-9ce5-44c1-b137-0d1ec1dde4cc"));

            migrationBuilder.DeleteData(
                table: "GoodsOrders",
                keyColumn: "Id",
                keyValue: new Guid("24528302-a0f6-4336-a619-ba214f7b541d"));

            migrationBuilder.DeleteData(
                table: "GoodsOrders",
                keyColumn: "Id",
                keyValue: new Guid("438dccf5-8d67-4041-a986-507260de9fc9"));

            migrationBuilder.DeleteData(
                table: "GoodsOrders",
                keyColumn: "Id",
                keyValue: new Guid("5b49a70f-96ea-4daa-b0ee-8ba0607fd244"));

            migrationBuilder.DeleteData(
                table: "GoodsOrders",
                keyColumn: "Id",
                keyValue: new Guid("a2cd5cd8-cba4-466c-b10c-357a26e9953e"));

            migrationBuilder.DeleteData(
                table: "GoodsOrders",
                keyColumn: "Id",
                keyValue: new Guid("aa2c7025-9f16-46eb-8767-4bdb03e8db73"));

            migrationBuilder.DeleteData(
                table: "GoodsOrders",
                keyColumn: "Id",
                keyValue: new Guid("b4fb0847-3b64-4165-b7db-856722f97a29"));

            migrationBuilder.DeleteData(
                table: "GoodsOrders",
                keyColumn: "Id",
                keyValue: new Guid("c2d2d8c8-0a7b-4b9d-a252-3b0a1fb93621"));

            migrationBuilder.DeleteData(
                table: "GoodsOrders",
                keyColumn: "Id",
                keyValue: new Guid("c4d4bfc7-7eec-4cf9-b28b-c71b54bbb870"));

            migrationBuilder.DeleteData(
                table: "GoodsOrders",
                keyColumn: "Id",
                keyValue: new Guid("cf24dab5-2cb5-48d5-b48a-aab6311bba73"));

            migrationBuilder.DeleteData(
                table: "GoodsOrders",
                keyColumn: "Id",
                keyValue: new Guid("d47f8265-234e-4768-93ab-becfa12d30e1"));

            migrationBuilder.DeleteData(
                table: "GoodsOrders",
                keyColumn: "Id",
                keyValue: new Guid("e74e7c9b-ca11-4a15-9a3c-cd1bca6c106a"));

            migrationBuilder.DeleteData(
                table: "GoodsOrders",
                keyColumn: "Id",
                keyValue: new Guid("eb63dc41-101e-4b92-bdf9-6de2f9543539"));

            migrationBuilder.DeleteData(
                table: "GoodsOrders",
                keyColumn: "Id",
                keyValue: new Guid("ee70a5b5-0c57-4f3c-ac52-4ea0c55ee72f"));

            migrationBuilder.DeleteData(
                table: "GoodsOrders",
                keyColumn: "Id",
                keyValue: new Guid("f79cd55b-4f2a-45f4-b6a5-c39f0f30e6e5"));

            migrationBuilder.DeleteData(
                table: "GoodsOrders",
                keyColumn: "Id",
                keyValue: new Guid("f81172a1-c56a-4132-b079-d140bbbf9e09"));

            migrationBuilder.DeleteData(
                table: "GoodsOrders",
                keyColumn: "Id",
                keyValue: new Guid("f84c5095-e697-4d9d-9353-55c173e5d9fe"));

            migrationBuilder.DeleteData(
                table: "GoodsOrders",
                keyColumn: "Id",
                keyValue: new Guid("f9a4622b-50ce-4de6-b980-d39579057724"));

            migrationBuilder.DeleteData(
                table: "GoodsOrders",
                keyColumn: "Id",
                keyValue: new Guid("fb2da9fc-a79e-4ad2-a774-f60e4b4d7019"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("230c4b58-5f99-4279-a2d4-4af5c3af28db"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("3d9d3cbc-8494-4e01-9228-e686ac5658fa"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("5efb4e85-c71e-4c68-ad5e-8af4cd2148f8"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("62a2d8b3-144b-49b8-8285-2c07e1d52456"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("102b2a76-87cd-41b5-ab47-7a6d78e2bf9e"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("5f98d03e-b6dc-41a7-9f3d-86fdda264f26"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("7faa8f3d-8557-43b3-9ace-69259a5ac75e"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("a3de7602-4018-4718-90a9-e7d0a299f315"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("d8607511-c1d8-4526-8f9f-52791d4158d4"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("daa03cd1-33a0-4d97-88b5-408cbacfc456"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("f59e96be-73a2-40fa-95b1-c931b9df6c57"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("108c5883-e2b7-4937-a04d-f7c059b8acd3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("30be92d8-e0db-4386-9131-93d6cc4b7c47"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("367c6b4e-8650-481c-80d5-6db6bf583095"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("54b6722e-1e29-4cc6-ada7-8d4edd5a13e4"));

            migrationBuilder.DropColumn(
                name: "DateCreate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Shops",
                type: "varchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Shops",
                type: "varchar(40)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Publishers",
                type: "varchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Painters",
                type: "varchar(40)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Painters",
                type: "varchar(1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Interpreters",
                type: "varchar(40)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Interpreters",
                type: "varchar(1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Books",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Format",
                table: "Books",
                type: "varchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Books",
                type: "varchar(1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Authors",
                type: "varchar(40)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Authors",
                type: "varchar(1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldNullable: true);
        }
    }
}
