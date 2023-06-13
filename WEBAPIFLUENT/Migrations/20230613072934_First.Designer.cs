﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WEBAPIFLUENT.Context;

#nullable disable

namespace WEBAPIFLUENT.Migrations
{
    [DbContext(typeof(PDFContext))]
    [Migration("20230613072934_First")]
    partial class First
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WEBAPIFLUENT.Models.BareBoardDetails", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("IId")
                        .HasColumnType("bigint");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IId");

                    b.ToTable("BareBoardDetails");
                });

            modelBuilder.Entity("WEBAPIFLUENT.Models.Board", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("VId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("VId");

                    b.ToTable("Board");
                });

            modelBuilder.Entity("WEBAPIFLUENT.Models.Identity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("RId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RId");

                    b.ToTable("Identity");
                });

            modelBuilder.Entity("WEBAPIFLUENT.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("WEBAPIFLUENT.Models.Rivision", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("BId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("BId");

                    b.ToTable("Rivision");
                });

            modelBuilder.Entity("WEBAPIFLUENT.Models.Varient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("PId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PId");

                    b.ToTable("Varient");
                });

            modelBuilder.Entity("WEBAPIFLUENT.Models.BareBoardDetails", b =>
                {
                    b.HasOne("WEBAPIFLUENT.Models.Identity", "Identity")
                        .WithMany("BareBoardDetails")
                        .HasForeignKey("IId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Identity");
                });

            modelBuilder.Entity("WEBAPIFLUENT.Models.Board", b =>
                {
                    b.HasOne("WEBAPIFLUENT.Models.Varient", "Varient")
                        .WithMany("Boards")
                        .HasForeignKey("VId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Varient");
                });

            modelBuilder.Entity("WEBAPIFLUENT.Models.Identity", b =>
                {
                    b.HasOne("WEBAPIFLUENT.Models.Rivision", "Rivision")
                        .WithMany("Identity")
                        .HasForeignKey("RId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rivision");
                });

            modelBuilder.Entity("WEBAPIFLUENT.Models.Rivision", b =>
                {
                    b.HasOne("WEBAPIFLUENT.Models.Board", "Board")
                        .WithMany("Rivisions")
                        .HasForeignKey("BId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Board");
                });

            modelBuilder.Entity("WEBAPIFLUENT.Models.Varient", b =>
                {
                    b.HasOne("WEBAPIFLUENT.Models.Product", "Product")
                        .WithMany("Varients")
                        .HasForeignKey("PId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WEBAPIFLUENT.Models.Board", b =>
                {
                    b.Navigation("Rivisions");
                });

            modelBuilder.Entity("WEBAPIFLUENT.Models.Identity", b =>
                {
                    b.Navigation("BareBoardDetails");
                });

            modelBuilder.Entity("WEBAPIFLUENT.Models.Product", b =>
                {
                    b.Navigation("Varients");
                });

            modelBuilder.Entity("WEBAPIFLUENT.Models.Rivision", b =>
                {
                    b.Navigation("Identity");
                });

            modelBuilder.Entity("WEBAPIFLUENT.Models.Varient", b =>
                {
                    b.Navigation("Boards");
                });
#pragma warning restore 612, 618
        }
    }
}