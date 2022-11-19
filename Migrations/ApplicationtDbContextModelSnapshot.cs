﻿// <auto-generated />
using System;
using Bookworm.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bookworm.Migrations
{
    [DbContext(typeof(ApplicationtDbContext))]
    partial class ApplicationtDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bookworm.Models.Autor", b =>
                {
                    b.Property<int>("Id_Autor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Autor"));

                    b.Property<string>("LocalNascimento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nameAutor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Autor");

                    b.ToTable("Autor");
                });

            modelBuilder.Entity("Bookworm.Models.Autoria", b =>
                {
                    b.Property<DateTime>("DataPublicação")
                        .HasColumnType("datetime2");

                    b.Property<int>("LivroId")
                        .HasColumnType("int");

                    b.Property<int>("idAutor")
                        .HasColumnType("int");

                    b.HasIndex("LivroId");

                    b.HasIndex("idAutor");

                    b.ToTable("Autoria");
                });

            modelBuilder.Entity("Bookworm.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Datacriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descrição")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Bookworm.Models.Classifica", b =>
                {
                    b.Property<int>("idCategoria")
                        .HasColumnType("int");

                    b.Property<int>("idLivro")
                        .HasColumnType("int");

                    b.HasIndex("idCategoria");

                    b.HasIndex("idLivro");

                    b.ToTable("Classifica");
                });

            modelBuilder.Entity("Bookworm.Models.Cliente", b =>
                {
                    b.Property<string>("cpf")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NomeCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("edereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idade")
                        .HasColumnType("int");

                    b.HasKey("cpf");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Bookworm.Models.Compra", b =>
                {
                    b.Property<int>("IdCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCompra"));

                    b.Property<int>("LivroId")
                        .HasColumnType("int");

                    b.Property<string>("clienteCpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("valorCompra")
                        .HasColumnType("float");

                    b.HasKey("IdCompra");

                    b.HasIndex("LivroId");

                    b.HasIndex("clienteCpf");

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("Bookworm.Models.Editora", b =>
                {
                    b.Property<int>("IdEditora")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEditora"));

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nomefantasia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEditora");

                    b.ToTable("Editora");
                });

            modelBuilder.Entity("Bookworm.Models.Livro", b =>
                {
                    b.Property<int>("id_livro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_livro"));

                    b.Property<string>("NomeLivro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sinopse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idEditora")
                        .HasColumnType("int");

                    b.Property<int>("qtd_paginas")
                        .HasColumnType("int");

                    b.HasKey("id_livro");

                    b.HasIndex("idEditora");

                    b.ToTable("Livro");
                });

            modelBuilder.Entity("Bookworm.Models.Autoria", b =>
                {
                    b.HasOne("Bookworm.Models.Livro", "Livro")
                        .WithMany()
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookworm.Models.Autor", "Autor")
                        .WithMany()
                        .HasForeignKey("idAutor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("Bookworm.Models.Classifica", b =>
                {
                    b.HasOne("Bookworm.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("idCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookworm.Models.Livro", "Livro")
                        .WithMany()
                        .HasForeignKey("idLivro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("Bookworm.Models.Compra", b =>
                {
                    b.HasOne("Bookworm.Models.Livro", "Livro")
                        .WithMany()
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookworm.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("clienteCpf")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("Bookworm.Models.Livro", b =>
                {
                    b.HasOne("Bookworm.Models.Editora", "Editora")
                        .WithMany()
                        .HasForeignKey("idEditora")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Editora");
                });
#pragma warning restore 612, 618
        }
    }
}
