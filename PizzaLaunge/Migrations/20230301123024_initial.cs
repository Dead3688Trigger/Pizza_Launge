using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaLaunge.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ORDERs",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total_Price = table.Column<int>(type: "int", nullable: false),
                    Order_Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERs", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "PAYMENTs",
                columns: table => new
                {
                    PaymentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Payment_Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bill = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYMENTs", x => x.PaymentID);
                });

            migrationBuilder.CreateTable(
                name: "PIZZAs",
                columns: table => new
                {
                    PizzaID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Pizza_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Order_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PIZZAs", x => x.PizzaID);
                    table.ForeignKey(
                        name: "FK_PIZZAs_ORDERs_OrderId",
                        column: x => x.OrderId,
                        principalTable: "ORDERs",
                        principalColumn: "OrderId");
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMERs",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<int>(type: "int", nullable: false),
                    Order_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payment_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PaymentID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMERs", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_CUSTOMERs_ORDERs_OrderId",
                        column: x => x.OrderId,
                        principalTable: "ORDERs",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "FK_CUSTOMERs_PAYMENTs_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "PAYMENTs",
                        principalColumn: "PaymentID");
                });

            migrationBuilder.CreateTable(
                name: "TOPPINGS",
                columns: table => new
                {
                    ToppingID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Topping_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Topping_Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pizza_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PizzaID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TOPPINGS", x => x.ToppingID);
                    table.ForeignKey(
                        name: "FK_TOPPINGS_PIZZAs_PizzaID",
                        column: x => x.PizzaID,
                        principalTable: "PIZZAs",
                        principalColumn: "PizzaID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERs_OrderId",
                table: "CUSTOMERs",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERs_PaymentID",
                table: "CUSTOMERs",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_PIZZAs_OrderId",
                table: "PIZZAs",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TOPPINGS_PizzaID",
                table: "TOPPINGS",
                column: "PizzaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CUSTOMERs");

            migrationBuilder.DropTable(
                name: "TOPPINGS");

            migrationBuilder.DropTable(
                name: "PAYMENTs");

            migrationBuilder.DropTable(
                name: "PIZZAs");

            migrationBuilder.DropTable(
                name: "ORDERs");
        }
    }
}
