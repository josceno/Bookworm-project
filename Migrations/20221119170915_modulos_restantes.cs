using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookworm.Migrations
{
    /// <inheritdoc />
    public partial class modulosrestantes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    IdAutor = table.Column<int>(name: "Id_Autor", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameAutor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalNascimento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.IdAutor);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    cpf = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idade = table.Column<int>(type: "int", nullable: false),
                    edereco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.cpf);
                });

            migrationBuilder.CreateTable(
                name: "Editora",
                columns: table => new
                {
                    IdEditora = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nomefantasia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editora", x => x.IdEditora);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    idlivro = table.Column<int>(name: "id_livro", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    qtdpaginas = table.Column<int>(name: "qtd_paginas", type: "int", nullable: false),
                    Sinopse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeLivro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idEditora = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.idlivro);
                    table.ForeignKey(
                        name: "FK_Livro_Editora_idEditora",
                        column: x => x.idEditora,
                        principalTable: "Editora",
                        principalColumn: "IdEditora",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Autoria",
                columns: table => new
                {
                    LivroId = table.Column<int>(type: "int", nullable: false),
                    idAutor = table.Column<int>(type: "int", nullable: false),
                    DataPublicação = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Autoria_Autor_idAutor",
                        column: x => x.idAutor,
                        principalTable: "Autor",
                        principalColumn: "Id_Autor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Autoria_Livro_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livro",
                        principalColumn: "id_livro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Classifica",
                columns: table => new
                {
                    idLivro = table.Column<int>(type: "int", nullable: false),
                    idCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Classifica_Categorias_idCategoria",
                        column: x => x.idCategoria,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Classifica_Livro_idLivro",
                        column: x => x.idLivro,
                        principalTable: "Livro",
                        principalColumn: "id_livro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    IdCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clienteCpf = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LivroId = table.Column<int>(type: "int", nullable: false),
                    valorCompra = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.IdCompra);
                    table.ForeignKey(
                        name: "FK_Compra_Cliente_clienteCpf",
                        column: x => x.clienteCpf,
                        principalTable: "Cliente",
                        principalColumn: "cpf",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compra_Livro_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livro",
                        principalColumn: "id_livro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autoria_idAutor",
                table: "Autoria",
                column: "idAutor");

            migrationBuilder.CreateIndex(
                name: "IX_Autoria_LivroId",
                table: "Autoria",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_Classifica_idCategoria",
                table: "Classifica",
                column: "idCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Classifica_idLivro",
                table: "Classifica",
                column: "idLivro");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_clienteCpf",
                table: "Compra",
                column: "clienteCpf");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_LivroId",
                table: "Compra",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_idEditora",
                table: "Livro",
                column: "idEditora");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autoria");

            migrationBuilder.DropTable(
                name: "Classifica");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Livro");

            migrationBuilder.DropTable(
                name: "Editora");
        }
    }
}
