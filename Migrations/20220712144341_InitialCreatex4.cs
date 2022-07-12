using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csharp_ecommerce_db.Migrations
{
    public partial class InitialCreatex4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuantitiesProducts");

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrdersOrderId = table.Column<int>(type: "int", nullable: false),
                    ProductsProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.OrdersOrderId, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_OrderProduct_order_OrdersOrderId",
                        column: x => x.OrdersOrderId,
                        principalTable: "order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_product_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductsProductId",
                table: "OrderProduct",
                column: "ProductsProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.CreateTable(
                name: "QuantitiesProducts",
                columns: table => new
                {
                    QuantityProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuantitiesProducts", x => x.QuantityProductId);
                    table.ForeignKey(
                        name: "FK_QuantitiesProducts_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customer",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_QuantitiesProducts_order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuantitiesProducts_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuantitiesProducts_CustomerId",
                table: "QuantitiesProducts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuantitiesProducts_OrderId",
                table: "QuantitiesProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_QuantitiesProducts_ProductId",
                table: "QuantitiesProducts",
                column: "ProductId");
        }
    }
}
