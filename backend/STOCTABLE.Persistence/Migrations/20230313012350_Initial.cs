using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace STOCTABLE.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientePFs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CPF = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    Nascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LimiteCredito = table.Column<decimal>(type: "numeric", nullable: false),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Endereco = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Numero = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Complemento = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CEP = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    Bairro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Cidade = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Estado = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    UF = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    Telefone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Celular = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Observacao = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientePFs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientePJs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Contato = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CNPJ = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    InscricaoEstadual = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Endereco = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Numero = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Complemento = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CEP = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    Bairro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Cidade = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Estado = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    UF = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    Telefone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Celular = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Observacao = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientePJs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fabricantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CNPJ = table.Column<string>(type: "text", nullable: false),
                    InscricaoEstadual = table.Column<string>(type: "text", nullable: true),
                    RefBancarias = table.Column<string>(type: "text", nullable: true),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Endereco = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Numero = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Complemento = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CEP = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    Bairro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Cidade = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Estado = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    UF = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    Telefone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Celular = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Observacao = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RG = table.Column<string>(type: "text", nullable: false),
                    Ocupacao = table.Column<string>(type: "text", nullable: false),
                    Salario = table.Column<double>(type: "double precision", nullable: false),
                    Admissao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Endereco = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Numero = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Complemento = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CEP = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    Bairro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Cidade = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Estado = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    UF = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    Telefone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Celular = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Observacao = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transportadoras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CNPJ = table.Column<string>(type: "text", nullable: false),
                    InscricaoEstadual = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Endereco = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Numero = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Complemento = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CEP = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    Bairro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Cidade = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Estado = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    UF = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    Telefone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Celular = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Observacao = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportadoras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Unidade = table.Column<int>(type: "integer", maxLength: 50, nullable: true),
                    FornecedorId = table.Column<int>(type: "integer", maxLength: 100, nullable: true),
                    FabricanteId = table.Column<int>(type: "integer", maxLength: 300, nullable: true),
                    Categoria = table.Column<string>(type: "text", nullable: true),
                    PrecoCusto = table.Column<decimal>(type: "numeric", nullable: false),
                    PrecoVenda = table.Column<decimal>(type: "numeric", nullable: false),
                    MargemLucro = table.Column<decimal>(type: "numeric", nullable: true),
                    CustoMedio = table.Column<decimal>(type: "numeric", nullable: true),
                    Quantidade = table.Column<int>(type: "integer", nullable: true),
                    QtMinima = table.Column<int>(type: "integer", nullable: true),
                    Observacao = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    AlicotaICMS = table.Column<decimal>(type: "numeric", nullable: true),
                    BaseCalcICMS = table.Column<decimal>(type: "numeric", nullable: true),
                    PesoBruto = table.Column<decimal>(type: "numeric", nullable: true),
                    PesoLiquido = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Fabricantes_FabricanteId",
                        column: x => x.FabricanteId,
                        principalTable: "Fabricantes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Produtos_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_FabricanteId",
                table: "Produtos",
                column: "FabricanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_FornecedorId",
                table: "Produtos",
                column: "FornecedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientePFs");

            migrationBuilder.DropTable(
                name: "ClientePJs");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Transportadoras");

            migrationBuilder.DropTable(
                name: "Fabricantes");

            migrationBuilder.DropTable(
                name: "Fornecedores");
        }
    }
}
