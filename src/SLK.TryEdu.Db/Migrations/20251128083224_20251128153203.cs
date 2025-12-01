using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SLK.TryEdu.Db.Migrations
{
    /// <inheritdoc />
    public partial class _20251128153203 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_COIN_TRANSACTION_DateCreated",
                table: "COIN_TRANSACTION");

            migrationBuilder.DropIndex(
                name: "IX_COIN_TRANSACTION_TransactionType",
                table: "COIN_TRANSACTION");

            migrationBuilder.DropIndex(
                name: "IX_COIN_TRANSACTION_UserGuid",
                table: "COIN_TRANSACTION");

            migrationBuilder.DropIndex(
                name: "IX_COIN_EXCHANGERATE_Currency_IsActive",
                table: "COIN_EXCHANGERATE");

            migrationBuilder.DropIndex(
                name: "IX_COIN_BALANCES_UserGuid",
                table: "COIN_BALANCES");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "COIN_TRANSACTION",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldDefaultValue: "PENDING");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "COIN_EXCHANGERATE",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalSpent",
                table: "COIN_BALANCES",
                type: "numeric(12,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(12,2)",
                oldPrecision: 12,
                oldScale: 2,
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalEarned",
                table: "COIN_BALANCES",
                type: "numeric(12,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(12,2)",
                oldPrecision: 12,
                oldScale: 2,
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "COIN_BALANCES",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldDefaultValue: "ACTIVE");

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "COIN_BALANCES",
                type: "numeric(12,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(12,2)",
                oldPrecision: 12,
                oldScale: 2,
                oldDefaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "PARTNER_CENTER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    CenterName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CetnterCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LogoUrl = table.Column<string>(type: "text", nullable: true),
                    LicenseUrl = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Tier = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CommissionRate = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    ApprovedByEmployeeGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    ApprovedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RejectionReason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UserModified = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARTNER_CENTER", x => x.Id);
                    table.UniqueConstraint("AK_PARTNER_CENTER_Guid", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "COMMISSION_TRANSACTION",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    PartnerGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    PartnerCenterId = table.Column<int>(type: "integer", nullable: false),
                    UserGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    TransactionAmount = table.Column<decimal>(type: "numeric(12,2)", nullable: false),
                    CommissionAmount = table.Column<decimal>(type: "numeric(12,2)", nullable: false),
                    CommissionRate = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    TransactionType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    PaidAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UserModified = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMMISSION_TRANSACTION", x => x.Id);
                    table.UniqueConstraint("AK_COMMISSION_TRANSACTION_Guid", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_COMMISSION_TRANSACTION_PARTNER_CENTER_PartnerCenterId",
                        column: x => x.PartnerCenterId,
                        principalTable: "PARTNER_CENTER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REFERRAL_CODE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    PartnerCenterId = table.Column<int>(type: "integer", nullable: false),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    DisscountPercent = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    MaxUsage = table.Column<int>(type: "integer", nullable: false),
                    UsedCount = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUsedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UserModified = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REFERRAL_CODE", x => x.Id);
                    table.UniqueConstraint("AK_REFERRAL_CODE_Guid", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_REFERRAL_CODE_PARTNER_CENTER_PartnerCenterId",
                        column: x => x.PartnerCenterId,
                        principalTable: "PARTNER_CENTER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COMMISSION_TRANSACTION_PartnerCenterId",
                table: "COMMISSION_TRANSACTION",
                column: "PartnerCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_REFERRAL_CODE_PartnerCenterId",
                table: "REFERRAL_CODE",
                column: "PartnerCenterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COMMISSION_TRANSACTION");

            migrationBuilder.DropTable(
                name: "REFERRAL_CODE");

            migrationBuilder.DropTable(
                name: "PARTNER_CENTER");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "COIN_TRANSACTION",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "PENDING",
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "COIN_EXCHANGERATE",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalSpent",
                table: "COIN_BALANCES",
                type: "numeric(12,2)",
                precision: 12,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(12,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalEarned",
                table: "COIN_BALANCES",
                type: "numeric(12,2)",
                precision: 12,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(12,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "COIN_BALANCES",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                defaultValue: "ACTIVE",
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "COIN_BALANCES",
                type: "numeric(12,2)",
                precision: 12,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(12,2)");

            migrationBuilder.CreateIndex(
                name: "IX_COIN_TRANSACTION_DateCreated",
                table: "COIN_TRANSACTION",
                column: "DateCreated");

            migrationBuilder.CreateIndex(
                name: "IX_COIN_TRANSACTION_TransactionType",
                table: "COIN_TRANSACTION",
                column: "TransactionType");

            migrationBuilder.CreateIndex(
                name: "IX_COIN_TRANSACTION_UserGuid",
                table: "COIN_TRANSACTION",
                column: "UserGuid");

            migrationBuilder.CreateIndex(
                name: "IX_COIN_EXCHANGERATE_Currency_IsActive",
                table: "COIN_EXCHANGERATE",
                columns: new[] { "Currency", "IsActive" });

            migrationBuilder.CreateIndex(
                name: "IX_COIN_BALANCES_UserGuid",
                table: "COIN_BALANCES",
                column: "UserGuid",
                unique: true);
        }
    }
}
