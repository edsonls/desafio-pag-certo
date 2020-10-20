using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioPagCerto.Repository.Migrations
{
    public partial class DesafioPagCertoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anticipation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SolicitationDate = table.Column<DateTime>(nullable: false),
                    AnalysisStartDate = table.Column<DateTime>(nullable: true),
                    AnalysisEndDate = table.Column<DateTime>(nullable: true),
                    ResultAnalysis = table.Column<int>(nullable: true),
                    StatusAnticipation = table.Column<int>(nullable: false),
                    RequestedAmount = table.Column<decimal>(nullable: false),
                    AnticipatedAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anticipation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    NSU = table.Column<Guid>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    ApprovedDate = table.Column<DateTime>(nullable: true),
                    ReprovedDate = table.Column<DateTime>(nullable: true),
                    StatusAnticipation = table.Column<bool>(nullable: false),
                    Confirmation = table.Column<bool>(nullable: false),
                    GrossValue = table.Column<decimal>(nullable: false),
                    NetValue = table.Column<decimal>(nullable: false),
                    FixedTax = table.Column<decimal>(nullable: false),
                    NumberParcel = table.Column<int>(nullable: false),
                    CreditCardSuffix = table.Column<string>(nullable: true),
                    AnticipationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.NSU);
                    table.ForeignKey(
                        name: "FK_Transaction_Anticipation_AnticipationId",
                        column: x => x.AnticipationId,
                        principalTable: "Anticipation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Installment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NumberParcel = table.Column<int>(nullable: false),
                    GrossValue = table.Column<decimal>(nullable: false),
                    NetValue = table.Column<decimal>(nullable: false),
                    AnticipationValue = table.Column<decimal>(nullable: true),
                    ExpectedDate = table.Column<DateTime>(nullable: false),
                    TransferDate = table.Column<DateTime>(nullable: true),
                    TransactionNSU = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Installment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Installment_Transaction_TransactionNSU",
                        column: x => x.TransactionNSU,
                        principalTable: "Transaction",
                        principalColumn: "NSU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Installment_TransactionNSU",
                table: "Installment",
                column: "TransactionNSU");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_AnticipationId",
                table: "Transaction",
                column: "AnticipationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Installment");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Anticipation");
        }
    }
}
