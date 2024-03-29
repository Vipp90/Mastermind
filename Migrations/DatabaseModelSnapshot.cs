﻿// <auto-generated />
using System;
using Mastermind.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mastermind.Migrations
{
    [DbContext(typeof(Database))]
    partial class DatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mastermind.Models.Code", b =>
                {
                    b.Property<long>("CodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FourthColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Game_infoId")
                        .HasColumnType("bigint");

                    b.Property<string>("SecondColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdColor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodeId");

                    b.HasIndex("Game_infoId")
                        .IsUnique();

                    b.ToTable("Code");
                });

            modelBuilder.Entity("Mastermind.Models.Game_info", b =>
                {
                    b.Property<long>("Game_infoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Mode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Player_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SessionID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.HasKey("Game_infoId");

                    b.ToTable("Game_info");
                });

            modelBuilder.Entity("Mastermind.Models.Highscores", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Table");
                });

            modelBuilder.Entity("Mastermind.Models.Code", b =>
                {
                    b.HasOne("Mastermind.Models.Game_info", "Game")
                        .WithOne("Code")
                        .HasForeignKey("Mastermind.Models.Code", "Game_infoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Mastermind.Models.Game_info", b =>
                {
                    b.Navigation("Code");
                });
#pragma warning restore 612, 618
        }
    }
}
