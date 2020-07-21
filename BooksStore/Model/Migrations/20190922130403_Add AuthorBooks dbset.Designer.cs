﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Model.Models;

namespace Model.Migrations
{
    [DbContext(typeof(BookContext))]
    [Migration("20190922130403_Add AuthorBooks dbset")]
    partial class AddAuthorBooksdbset
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InterfaceDB.JoinTables.AuthorBook", b =>
                {
                    b.Property<int>("BookId");

                    b.Property<int>("AuthorId");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("AuthorBooks");
                });

            modelBuilder.Entity("InterfaceDB.JoinTables.PainterBook", b =>
                {
                    b.Property<int>("BookId");

                    b.Property<int>("PainterId");

                    b.HasKey("BookId", "PainterId");

                    b.HasIndex("PainterId");

                    b.ToTable("PainterBook");
                });

            modelBuilder.Entity("InterfaceDB.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Age");

                    b.Property<string>("Name");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("InterfaceDB.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("AgeLimit");

                    b.Property<decimal>("AvgReview");

                    b.Property<int>("CountCustomers");

                    b.Property<int>("Cover");

                    b.Property<string>("Description");

                    b.Property<string>("Dimensions");

                    b.Property<int>("Edition");

                    b.Property<int>("Genre");

                    b.Property<string>("ISBN_10");

                    b.Property<string>("ISBN_13");

                    b.Property<int>("Language");

                    b.Property<string>("Name");

                    b.Property<int>("NumbersPages");

                    b.Property<decimal>("Price");

                    b.Property<DateTime>("PublishDate");

                    b.Property<int?>("PublisherId");

                    b.Property<int>("QuantityStock");

                    b.Property<decimal>("Weight");

                    b.HasKey("BookId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("InterfaceDB.Models.Painter", b =>
                {
                    b.Property<int>("PainterId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Age");

                    b.Property<string>("Name");

                    b.Property<int>("Style");

                    b.HasKey("PainterId");

                    b.ToTable("Painters");
                });

            modelBuilder.Entity("InterfaceDB.Models.Publisher", b =>
                {
                    b.Property<int>("PublisherId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Corporation");

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.HasKey("PublisherId");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("InterfaceDB.JoinTables.AuthorBook", b =>
                {
                    b.HasOne("InterfaceDB.Models.Author", "Author")
                        .WithMany("AuthorBooks")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InterfaceDB.Models.Book", "Book")
                        .WithMany("AuthorBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InterfaceDB.JoinTables.PainterBook", b =>
                {
                    b.HasOne("InterfaceDB.Models.Book", "Book")
                        .WithMany("PainterBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InterfaceDB.Models.Painter", "Painter")
                        .WithMany("PainterBooks")
                        .HasForeignKey("PainterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InterfaceDB.Models.Book", b =>
                {
                    b.HasOne("InterfaceDB.Models.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId");
                });
#pragma warning restore 612, 618
        }
    }
}
