using Microsoft.EntityFrameworkCore.Migrations;

namespace Buyer.Service.Migrations
{
    public partial class initialbuy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buyer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyer", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Buyer",
                columns: new[] { "Id", "Address", "City", "Contact", "Email", "Name" },
                values: new object[] { 1, "ishi residencies", "Colombo", "1234567890", "binnie@gmail.com", "Binnie" });

            migrationBuilder.InsertData(
                table: "Buyer",
                columns: new[] { "Id", "Address", "City", "Contact", "Email", "Name" },
                values: new object[] { 2, "lucas residencies", "Sweden", "12345675590", "lucas@gmail.com", "Lucas" });

            migrationBuilder.InsertData(
                table: "Buyer",
                columns: new[] { "Id", "Address", "City", "Contact", "Email", "Name" },
                values: new object[] { 3, "Casper residencies", "Austrailia", "12346675590", "casper@gmail.com", "Casper" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buyer");
        }
    }
}
