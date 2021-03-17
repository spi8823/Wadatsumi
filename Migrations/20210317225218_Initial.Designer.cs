﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wadatsumi.Data.Jinja;

namespace Wadatsumi.Migrations
{
    [DbContext(typeof(JinjaDbContext))]
    [Migration("20210317225218_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("Wadatsumi.Data.Jinja.Goshuin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("JinjaID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("VisitDate")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("JinjaID");

                    b.ToTable("GoshuinDbSet");
                });

            modelBuilder.Entity("Wadatsumi.Data.Jinja.Jinja", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Kana")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RyouseikokuID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("RyouseikokuID");

                    b.ToTable("JinjaDbSet");
                });

            modelBuilder.Entity("Wadatsumi.Data.Jinja.Kami", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("KamiDbSet");
                });

            modelBuilder.Entity("Wadatsumi.Data.Jinja.Region", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("RegionDbSet");
                });

            modelBuilder.Entity("Wadatsumi.Data.Jinja.Ryouseikoku", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RegionID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("RegionID");

                    b.ToTable("RyouseikokuDbSet");
                });

            modelBuilder.Entity("Wadatsumi.Data.Jinja.Saijin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("JinjaID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("KamiID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("JinjaID");

                    b.HasIndex("KamiID");

                    b.ToTable("SaijinDbSet");
                });

            modelBuilder.Entity("Wadatsumi.Data.Jinja.Shinmei", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("KamiID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Kana")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("KamiID");

                    b.ToTable("ShinmeiDbSet");
                });

            modelBuilder.Entity("Wadatsumi.Data.Jinja.Goshuin", b =>
                {
                    b.HasOne("Wadatsumi.Data.Jinja.Jinja", "Jinja")
                        .WithMany()
                        .HasForeignKey("JinjaID");

                    b.Navigation("Jinja");
                });

            modelBuilder.Entity("Wadatsumi.Data.Jinja.Jinja", b =>
                {
                    b.HasOne("Wadatsumi.Data.Jinja.Ryouseikoku", "Ryouseikoku")
                        .WithMany()
                        .HasForeignKey("RyouseikokuID");

                    b.Navigation("Ryouseikoku");
                });

            modelBuilder.Entity("Wadatsumi.Data.Jinja.Ryouseikoku", b =>
                {
                    b.HasOne("Wadatsumi.Data.Jinja.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionID");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Wadatsumi.Data.Jinja.Saijin", b =>
                {
                    b.HasOne("Wadatsumi.Data.Jinja.Jinja", "Jinja")
                        .WithMany("SaijinList")
                        .HasForeignKey("JinjaID");

                    b.HasOne("Wadatsumi.Data.Jinja.Kami", "Kami")
                        .WithMany()
                        .HasForeignKey("KamiID");

                    b.Navigation("Jinja");

                    b.Navigation("Kami");
                });

            modelBuilder.Entity("Wadatsumi.Data.Jinja.Shinmei", b =>
                {
                    b.HasOne("Wadatsumi.Data.Jinja.Kami", "Kami")
                        .WithMany("ShinmeiList")
                        .HasForeignKey("KamiID");

                    b.Navigation("Kami");
                });

            modelBuilder.Entity("Wadatsumi.Data.Jinja.Jinja", b =>
                {
                    b.Navigation("SaijinList");
                });

            modelBuilder.Entity("Wadatsumi.Data.Jinja.Kami", b =>
                {
                    b.Navigation("ShinmeiList");
                });
#pragma warning restore 612, 618
        }
    }
}