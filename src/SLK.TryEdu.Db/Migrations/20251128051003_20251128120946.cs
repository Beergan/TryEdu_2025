using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SLK.TryEdu.Db.Migrations
{
    /// <inheritdoc />
    public partial class _20251128120946 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
