using Microsoft.EntityFrameworkCore.Migrations;

namespace Payment.Service.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cardType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cardNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "id", "amount", "cardNo", "cardType", "customerId", "description" },
                values: new object[,]
                {
                    { 1, "5000", "1234567890", "Debit", "10", "imergency payment" },
                    { 2, "7800", "99900033", "Credit", "20", "bill payment" },
                    { 3, "9100", "44455666", "Debit", "30", "notmal payment" },
                    { 4, "8000", "77711123", "Credit", "4", "bank payment" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");
        }
    }
}
