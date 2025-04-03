using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleLicenca.Api.App.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CNPJ",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "Cliente");
        }
    }
}
