using Microsoft.EntityFrameworkCore.Migrations;

namespace Currency.Migrations
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    CurrencyID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CurrencyFullName = table.Column<string>(nullable: false),
                    CurrencyCode = table.Column<string>(nullable: false),
                    Unit = table.Column<string>(nullable: false),
                    Rate = table.Column<decimal>(nullable: false),
                    PrevRate = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.CurrencyID);
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "CurrencyID", "CurrencyCode", "CurrencyFullName", "PrevRate", "Rate", "Unit" },
                values: new object[] { 1, "USD", "US Dollar", 40694.543m, 40694.543m, "$" });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "CurrencyID", "CurrencyCode", "CurrencyFullName", "PrevRate", "Rate", "Unit" },
                values: new object[] { 2, "BTC", "Bitcoin", 1.0m, 1.0m, "BTC" });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "CurrencyID", "CurrencyCode", "CurrencyFullName", "PrevRate", "Rate", "Unit" },
                values: new object[] { 3, "PHP", "Philipine Peso", 2083596.208m, 2083596.208m, "₱" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currency");
        }
    }
}
