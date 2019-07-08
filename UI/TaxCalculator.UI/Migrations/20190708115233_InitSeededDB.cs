using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxCalculator.UI.Migrations
{
    public partial class InitSeededDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IncomeTaxes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    IncomeTaxType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeTaxes", x => x.Id);
                    table.UniqueConstraint("AlternateKey_IncomeTaxType", x => x.IncomeTaxType);
                });

            migrationBuilder.CreateTable(
                name: "TaxQueryLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostCode = table.Column<string>(nullable: true),
                    TaxableIncome = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    DateQueried = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxQueryLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostalCodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostCode = table.Column<string>(maxLength: 4, nullable: false),
                    IncomeTaxId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostalCodes", x => x.Id);
                    table.UniqueConstraint("AlternateKey_PostCode", x => x.PostCode);
                    table.ForeignKey(
                        name: "FK_PostalCodes_IncomeTaxes_IncomeTaxId",
                        column: x => x.IncomeTaxId,
                        principalTable: "IncomeTaxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxBrackets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    StartIncome = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    EndIncome = table.Column<decimal>(type: "decimal(10, 2)", nullable: true),
                    BaseTax = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(4, 3)", nullable: false),
                    IncomeTaxId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxBrackets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxBrackets_IncomeTaxes_IncomeTaxId",
                        column: x => x.IncomeTaxId,
                        principalTable: "IncomeTaxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "IncomeTaxes",
                columns: new[] { "Id", "Description", "IncomeTaxType" },
                values: new object[] { 1, "Flat Rate", "FlatTaxRate" });

            migrationBuilder.InsertData(
                table: "IncomeTaxes",
                columns: new[] { "Id", "Description", "IncomeTaxType" },
                values: new object[] { 2, "Flat Value", "FlatValue" });

            migrationBuilder.InsertData(
                table: "IncomeTaxes",
                columns: new[] { "Id", "Description", "IncomeTaxType" },
                values: new object[] { 3, "Progressive", "Progressive" });

            migrationBuilder.InsertData(
                table: "PostalCodes",
                columns: new[] { "Id", "IncomeTaxId", "PostCode" },
                values: new object[,]
                {
                    { 3, 1, "7000" },
                    { 2, 2, "A100" },
                    { 1, 3, "7441" },
                    { 4, 3, "1000" }
                });

            migrationBuilder.InsertData(
                table: "TaxBrackets",
                columns: new[] { "Id", "BaseTax", "Description", "EndIncome", "IncomeTaxId", "StartIncome", "TaxRate" },
                values: new object[,]
                {
                    { 1, 0m, "Flat Tax Rate", null, 1, 0m, 0.175m },
                    { 2, 10000m, "Flat Value Tax", 200000m, 2, 0m, 0.05m },
                    { 3, 0m, "Progressive Tax Bracket 1", 8350m, 3, 0m, 0.1m },
                    { 4, 0m, "Progressive Tax Bracket 2", 33950m, 3, 8351m, 0.15m },
                    { 5, 0m, "Progressive Tax Bracket 3", 82250m, 3, 33951m, 0.25m },
                    { 6, 0m, "Progressive Tax Bracket 4", 171550m, 3, 82251m, 0.28m },
                    { 7, 0m, "Progressive Tax Bracket 5", 372950m, 3, 171551m, 0.33m },
                    { 8, 0m, "Progressive Tax Bracket 6", null, 3, 372951m, 0.35m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostalCodes_IncomeTaxId",
                table: "PostalCodes",
                column: "IncomeTaxId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxBrackets_IncomeTaxId",
                table: "TaxBrackets",
                column: "IncomeTaxId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostalCodes");

            migrationBuilder.DropTable(
                name: "TaxBrackets");

            migrationBuilder.DropTable(
                name: "TaxQueryLogs");

            migrationBuilder.DropTable(
                name: "IncomeTaxes");
        }
    }
}
