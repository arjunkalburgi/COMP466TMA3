﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using part4.Contexts;
using System;

namespace part4.Migrations.Computer
{
    [DbContext(typeof(ComputerContext))]
    partial class ComputerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("part4.Models.ComputerItem", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CPUid");

                    b.Property<Guid?>("Displayid");

                    b.Property<Guid?>("HDid");

                    b.Property<Guid?>("OSid");

                    b.Property<Guid?>("RAMid");

                    b.Property<Guid?>("SoundCardid");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(700);

                    b.Property<string>("image")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<double>("price");

                    b.HasKey("id");

                    b.HasIndex("CPUid");

                    b.HasIndex("Displayid");

                    b.HasIndex("HDid");

                    b.HasIndex("OSid");

                    b.HasIndex("RAMid");

                    b.HasIndex("SoundCardid");

                    b.ToTable("computeritems");
                });

            modelBuilder.Entity("part4.Models.ProductItem", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(700);

                    b.Property<string>("image")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<double>("price");

                    b.HasKey("id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("part4.Models.ComputerItem", b =>
                {
                    b.HasOne("part4.Models.ProductItem", "CPU")
                        .WithMany()
                        .HasForeignKey("CPUid");

                    b.HasOne("part4.Models.ProductItem", "Display")
                        .WithMany()
                        .HasForeignKey("Displayid");

                    b.HasOne("part4.Models.ProductItem", "HD")
                        .WithMany()
                        .HasForeignKey("HDid");

                    b.HasOne("part4.Models.ProductItem", "OS")
                        .WithMany()
                        .HasForeignKey("OSid");

                    b.HasOne("part4.Models.ProductItem", "RAM")
                        .WithMany()
                        .HasForeignKey("RAMid");

                    b.HasOne("part4.Models.ProductItem", "SoundCard")
                        .WithMany()
                        .HasForeignKey("SoundCardid");
                });
#pragma warning restore 612, 618
        }
    }
}
