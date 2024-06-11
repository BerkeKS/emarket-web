using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace emarket.Migrations
{
    /// <inheritdoc />
    public partial class orders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PurchasedItem = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PurchasedAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Items_PurchasedItem",
                        column: x => x.PurchasedItem,
                        principalTable: "Items",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderUsers",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PurchaserUsername = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    totalPrice = table.Column<double>(type: "float", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderUsers", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_OrderUsers_Users_PurchaserUsername",
                        column: x => x.PurchaserUsername,
                        principalTable: "Users",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_PurchasedItem",
                table: "OrderItems",
                column: "PurchasedItem");

            migrationBuilder.CreateIndex(
                name: "IX_OrderUsers_PurchaserUsername",
                table: "OrderUsers",
                column: "PurchaserUsername");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "OrderUsers");
        }
    }
}
