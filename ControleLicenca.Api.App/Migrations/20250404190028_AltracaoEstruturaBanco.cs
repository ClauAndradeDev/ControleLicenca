using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleLicenca.Api.App.Migrations
{
    /// <inheritdoc />
    public partial class AltracaoEstruturaBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Licenca_Cliente_IdCliente",
                table: "Licenca");

            migrationBuilder.DropColumn(
                name: "DataAtivacao",
                table: "Licenca");

            migrationBuilder.DropColumn(
                name: "DataUltimaAtivacao",
                table: "Licenca");

            migrationBuilder.DropColumn(
                name: "DataValidade",
                table: "Contrato");

            migrationBuilder.DropColumn(
                name: "PeriodoAnos",
                table: "Contrato");

            migrationBuilder.DropColumn(
                name: "ValorAnual",
                table: "Contrato");

            migrationBuilder.DropColumn(
                name: "ValorContratoTotal",
                table: "Contrato");

            migrationBuilder.RenameColumn(
                name: "IdCliente",
                table: "Licenca",
                newName: "IdProduto");

            migrationBuilder.RenameIndex(
                name: "IX_Licenca_IdCliente",
                table: "Licenca",
                newName: "IX_Licenca_IdProduto");

            migrationBuilder.RenameColumn(
                name: "PeriodoMeses",
                table: "Contrato",
                newName: "IdCliente");

            migrationBuilder.AddColumn<bool>(
                name: "IgnoraDataFinal",
                table: "Contrato",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoSistema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Situacao = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_IdCliente",
                table: "Contrato",
                column: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Contrato_Cliente_IdCliente",
                table: "Contrato",
                column: "IdCliente",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Licenca_Produto_IdProduto",
                table: "Licenca",
                column: "IdProduto",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contrato_Cliente_IdCliente",
                table: "Contrato");

            migrationBuilder.DropForeignKey(
                name: "FK_Licenca_Produto_IdProduto",
                table: "Licenca");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Contrato_IdCliente",
                table: "Contrato");

            migrationBuilder.DropColumn(
                name: "IgnoraDataFinal",
                table: "Contrato");

            migrationBuilder.RenameColumn(
                name: "IdProduto",
                table: "Licenca",
                newName: "IdCliente");

            migrationBuilder.RenameIndex(
                name: "IX_Licenca_IdProduto",
                table: "Licenca",
                newName: "IX_Licenca_IdCliente");

            migrationBuilder.RenameColumn(
                name: "IdCliente",
                table: "Contrato",
                newName: "PeriodoMeses");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtivacao",
                table: "Licenca",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataUltimaAtivacao",
                table: "Licenca",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataValidade",
                table: "Contrato",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PeriodoAnos",
                table: "Contrato",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorAnual",
                table: "Contrato",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorContratoTotal",
                table: "Contrato",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Licenca_Cliente_IdCliente",
                table: "Licenca",
                column: "IdCliente",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
