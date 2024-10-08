﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using gerenciador_reservas_hotel.Repositories.Data;

#nullable disable

namespace gerenciador_reservas_hotel.Migrations
{
    [DbContext(typeof(ReservasDbContext))]
    [Migration("20241002134932_FirstMIgration")]
    partial class FirstMIgration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");
            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("gerenciador_reservas_hotel.Models.Hospede", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Hospede");
                });

            modelBuilder.Entity("gerenciador_reservas_hotel.Models.Quarto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Quarto");
                });

            modelBuilder.Entity("gerenciador_reservas_hotel.Models.Reserva", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataReservaDuracao")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("HospedeId")
                        .HasColumnType("int");

                    b.Property<int>("QuartoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HospedeId");

                    b.HasIndex("QuartoId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("gerenciador_reservas_hotel.Models.Reserva", b =>
                {
                    b.HasOne("gerenciador_reservas_hotel.Models.Hospede", "Hospede")
                        .WithMany()
                        .HasForeignKey("HospedeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("gerenciador_reservas_hotel.Models.Quarto", "Quarto")
                        .WithMany()
                        .HasForeignKey("QuartoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospede");

                    b.Navigation("Quarto");
                });
#pragma warning restore 612, 618
        }
    }
}
