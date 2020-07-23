﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model;

namespace Model.Migrations
{
    [DbContext(typeof(BookContext))]
    [Migration("20200723040010_AddShopAndWorkShedule")]
    partial class AddShopAndWorkShedule
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Model.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("Age")
                        .HasColumnType("tinyint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Model.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("AgeLimit")
                        .HasColumnType("tinyint");

                    b.Property<int>("CountPage")
                        .HasColumnType("int");

                    b.Property<Guid?>("CoverTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duplicate")
                        .HasColumnType("int");

                    b.Property<string>("Format")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("GenreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ISBN_10")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN_13")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LanguageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("PublisherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CoverTypeId");

                    b.HasIndex("GenreId");

                    b.HasIndex("LanguageId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Model.Entities.Interpreter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("Age")
                        .HasColumnType("tinyint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Interpreters");
                });

            modelBuilder.Entity("Model.Entities.JoinTables.AuthorBook", b =>
                {
                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("AuthorBooks");
                });

            modelBuilder.Entity("Model.Entities.JoinTables.InterpreterBook", b =>
                {
                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IntepreterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("InterpreterId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BookId", "IntepreterId");

                    b.HasIndex("InterpreterId");

                    b.ToTable("InterpreterBooks");
                });

            modelBuilder.Entity("Model.Entities.JoinTables.PainterBook", b =>
                {
                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PainterId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BookId", "PainterId");

                    b.HasIndex("PainterId");

                    b.ToTable("PainterBooks");
                });

            modelBuilder.Entity("Model.Entities.Painter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("Age")
                        .HasColumnType("tinyint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("StyleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StyleId");

                    b.ToTable("Painters");
                });

            modelBuilder.Entity("Model.Entities.Publisher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("Model.Entities.References.CoverType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CoverTypes");
                });

            modelBuilder.Entity("Model.Entities.References.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Model.Entities.References.Language", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Model.Entities.References.PainterStyle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PainterStyles");
                });

            modelBuilder.Entity("Model.Entities.References.WorkShedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<Guid?>("ShopId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.Property<int>("Weekday")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("WorkShedules");
                });

            modelBuilder.Entity("Model.Entities.Shop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("Model.Entities.Book", b =>
                {
                    b.HasOne("Model.Entities.References.CoverType", "CoverType")
                        .WithMany()
                        .HasForeignKey("CoverTypeId");

                    b.HasOne("Model.Entities.References.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId");

                    b.HasOne("Model.Entities.References.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId");

                    b.HasOne("Model.Entities.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId");
                });

            modelBuilder.Entity("Model.Entities.JoinTables.AuthorBook", b =>
                {
                    b.HasOne("Model.Entities.Author", "Author")
                        .WithMany("AuthorBooks")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Book", "Book")
                        .WithMany("AuthorBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Entities.JoinTables.InterpreterBook", b =>
                {
                    b.HasOne("Model.Entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Interpreter", "Interpreter")
                        .WithMany("InterpeterBooks")
                        .HasForeignKey("InterpreterId");
                });

            modelBuilder.Entity("Model.Entities.JoinTables.PainterBook", b =>
                {
                    b.HasOne("Model.Entities.Book", "Book")
                        .WithMany("PainterBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Painter", "Painter")
                        .WithMany("PainterBooks")
                        .HasForeignKey("PainterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Entities.Painter", b =>
                {
                    b.HasOne("Model.Entities.References.PainterStyle", "Style")
                        .WithMany()
                        .HasForeignKey("StyleId");
                });

            modelBuilder.Entity("Model.Entities.References.WorkShedule", b =>
                {
                    b.HasOne("Model.Entities.Shop", "Shop")
                        .WithMany("WorkShedule")
                        .HasForeignKey("ShopId");
                });
#pragma warning restore 612, 618
        }
    }
}
