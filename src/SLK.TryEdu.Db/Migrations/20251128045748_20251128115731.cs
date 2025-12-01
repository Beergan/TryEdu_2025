using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SLK.TryEdu.Db.Migrations
{
    /// <inheritdoc />
    public partial class _20251128115731 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COIN_BALANCES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    UserGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    Balance = table.Column<decimal>(type: "numeric(12,2)", nullable: false),
                    TotalEarned = table.Column<decimal>(type: "numeric(12,2)", nullable: false),
                    TotalSpent = table.Column<decimal>(type: "numeric(12,2)", nullable: false),
                    Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UserModified = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COIN_BALANCES", x => x.Id);
                    table.UniqueConstraint("AK_COIN_BALANCES_Guid", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "COIN_EXCHANGERATE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Currency = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Rate = table.Column<decimal>(type: "numeric(12,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UserModified = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COIN_EXCHANGERATE", x => x.Id);
                    table.UniqueConstraint("AK_COIN_EXCHANGERATE_Guid", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "COIN_TRANSACTION",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    UserGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    TransactionType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(12,2)", nullable: false),
                    Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ReferralCodeGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    RelatedTransactionGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UserModified = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COIN_TRANSACTION", x => x.Id);
                    table.UniqueConstraint("AK_COIN_TRANSACTION_Guid", x => x.Guid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COIN_BALANCES");

            migrationBuilder.DropTable(
                name: "COIN_EXCHANGERATE");

            migrationBuilder.DropTable(
                name: "COIN_TRANSACTION");
        }
    }
}
