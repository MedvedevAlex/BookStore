using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System;

namespace Model.Configurations
{
    class GoodsOrderConfigure : IEntityTypeConfiguration<GoodsOrder>
    {
        public void Configure(EntityTypeBuilder<GoodsOrder> builder)
        {
            builder.HasKey(go => go.Id);

            builder.Property(go => go.Amount)
                .HasColumnType("numeric(8,2)");

            builder.HasOne(go => go.Order);
            builder.HasOne(go => go.Book);

            builder.HasData(
                new { Id = Guid.Parse("f9a4622b-50ce-4de6-b980-d39579057724"), OrderId = Guid.Parse("d8607511-c1d8-4526-8f9f-52791d4158d4"), BookId = Guid.Parse("D22D44A7-E987-4F8F-8CB2-0768CC6199C6"), Amount = 406.00M },
                new { Id = Guid.Parse("5b49a70f-96ea-4daa-b0ee-8ba0607fd244"), OrderId = Guid.Parse("d8607511-c1d8-4526-8f9f-52791d4158d4"), BookId = Guid.Parse("1FFA9B7C-E021-4084-A14B-35839B9CC9D2"), Amount = 203.00M },
                
                new { Id = Guid.Parse("b4fb0847-3b64-4165-b7db-856722f97a29"), OrderId = Guid.Parse("daa03cd1-33a0-4d97-88b5-408cbacfc456"), BookId = Guid.Parse("4B9C14FD-7788-4C89-B778-459EE7A4415B"), Amount = 792.00M },
                new { Id = Guid.Parse("ee70a5b5-0c57-4f3c-ac52-4ea0c55ee72f"), OrderId = Guid.Parse("daa03cd1-33a0-4d97-88b5-408cbacfc456"), BookId = Guid.Parse("5628B2D6-4ED2-4B3E-B71F-6764A2489B25"), Amount = 250.00M },
              
                new { Id = Guid.Parse("1ac0af9e-9ce5-44c1-b137-0d1ec1dde4cc"), OrderId = Guid.Parse("a3de7602-4018-4718-90a9-e7d0a299f315"), BookId = Guid.Parse("AA585855-0FEB-418C-ACC5-6E98E20B972A"), Amount = 212.00M },
              
                new { Id = Guid.Parse("d47f8265-234e-4768-93ab-becfa12d30e1"), OrderId = Guid.Parse("5f98d03e-b6dc-41a7-9f3d-86fdda264f26"), BookId = Guid.Parse("7DB924D8-00A7-4B46-9E31-73D95C38EB31"), Amount = 330.00M },
                new { Id = Guid.Parse("e74e7c9b-ca11-4a15-9a3c-cd1bca6c106a"), OrderId = Guid.Parse("5f98d03e-b6dc-41a7-9f3d-86fdda264f26"), BookId = Guid.Parse("F0317CFB-E110-4B92-97B9-A52595CEFCCD"), Amount = 220.00M },
              
                new { Id = Guid.Parse("aa2c7025-9f16-46eb-8767-4bdb03e8db73"), OrderId = Guid.Parse("7faa8f3d-8557-43b3-9ace-69259a5ac75e"), BookId = Guid.Parse("8C038ACD-17DB-4554-A741-DE98CA121256"), Amount = 363.00M },
                new { Id = Guid.Parse("a2cd5cd8-cba4-466c-b10c-357a26e9953e"), OrderId = Guid.Parse("7faa8f3d-8557-43b3-9ace-69259a5ac75e"), BookId = Guid.Parse("7C7EF3FC-B918-41D5-9E9D-E0549B0F42BC"), Amount = 377.00M },
                new { Id = Guid.Parse("f79cd55b-4f2a-45f4-b6a5-c39f0f30e6e5"), OrderId = Guid.Parse("7faa8f3d-8557-43b3-9ace-69259a5ac75e"), BookId = Guid.Parse("7D1E69BC-F0B2-4BBD-8D87-E2FC2BCA53AC"), Amount = 605.00M },
              
                new { Id = Guid.Parse("08d4459e-53b6-4f53-820b-83f0a0feacfe"), OrderId = Guid.Parse("f59e96be-73a2-40fa-95b1-c931b9df6c57"), BookId = Guid.Parse("D22D44A7-E987-4F8F-8CB2-0768CC6199C6"), Amount = 350.00M },

                new { Id = Guid.Parse("cf24dab5-2cb5-48d5-b48a-aab6311bba73"), OrderId = Guid.Parse("102b2a76-87cd-41b5-ab47-7a6d78e2bf9e"), BookId = Guid.Parse("D22D44A7-E987-4F8F-8CB2-0768CC6199C6"), Amount = 406.00M },
                new { Id = Guid.Parse("f84c5095-e697-4d9d-9353-55c173e5d9fe"), OrderId = Guid.Parse("102b2a76-87cd-41b5-ab47-7a6d78e2bf9e"), BookId = Guid.Parse("1FFA9B7C-E021-4084-A14B-35839B9CC9D2"), Amount = 203.00M },
                new { Id = Guid.Parse("f81172a1-c56a-4132-b079-d140bbbf9e09"), OrderId = Guid.Parse("102b2a76-87cd-41b5-ab47-7a6d78e2bf9e"), BookId = Guid.Parse("4B9C14FD-7788-4C89-B778-459EE7A4415B"), Amount = 792.00M },
                new { Id = Guid.Parse("24528302-a0f6-4336-a619-ba214f7b541d"), OrderId = Guid.Parse("102b2a76-87cd-41b5-ab47-7a6d78e2bf9e"), BookId = Guid.Parse("5628B2D6-4ED2-4B3E-B71F-6764A2489B25"), Amount = 250.00M },
                new { Id = Guid.Parse("fb2da9fc-a79e-4ad2-a774-f60e4b4d7019"), OrderId = Guid.Parse("102b2a76-87cd-41b5-ab47-7a6d78e2bf9e"), BookId = Guid.Parse("AA585855-0FEB-418C-ACC5-6E98E20B972A"), Amount = 212.00M },
                new { Id = Guid.Parse("438dccf5-8d67-4041-a986-507260de9fc9"), OrderId = Guid.Parse("102b2a76-87cd-41b5-ab47-7a6d78e2bf9e"), BookId = Guid.Parse("7DB924D8-00A7-4B46-9E31-73D95C38EB31"), Amount = 330.00M },
                new { Id = Guid.Parse("c4d4bfc7-7eec-4cf9-b28b-c71b54bbb870"), OrderId = Guid.Parse("102b2a76-87cd-41b5-ab47-7a6d78e2bf9e"), BookId = Guid.Parse("F0317CFB-E110-4B92-97B9-A52595CEFCCD"), Amount = 220.00M },
                new { Id = Guid.Parse("eb63dc41-101e-4b92-bdf9-6de2f9543539"), OrderId = Guid.Parse("102b2a76-87cd-41b5-ab47-7a6d78e2bf9e"), BookId = Guid.Parse("8C038ACD-17DB-4554-A741-DE98CA121256"), Amount = 363.00M },
                new { Id = Guid.Parse("0b91f2ad-fe56-4a46-940a-da24d573e3fe"), OrderId = Guid.Parse("102b2a76-87cd-41b5-ab47-7a6d78e2bf9e"), BookId = Guid.Parse("7C7EF3FC-B918-41D5-9E9D-E0549B0F42BC"), Amount = 377.00M },
                new { Id = Guid.Parse("c2d2d8c8-0a7b-4b9d-a252-3b0a1fb93621"), OrderId = Guid.Parse("102b2a76-87cd-41b5-ab47-7a6d78e2bf9e"), BookId = Guid.Parse("7D1E69BC-F0B2-4BBD-8D87-E2FC2BCA53AC"), Amount = 605.00M }

            );
        }
    }
}
