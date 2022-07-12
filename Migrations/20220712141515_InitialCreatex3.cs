using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csharp_ecommerce_db.Migrations
{
    public partial class InitialCreatex3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customer_order_OrderId",
                table: "customer");

            migrationBuilder.DropForeignKey(
                name: "FK_order_product_order_quantity_ProductOrderQuantityId",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_product_product_order_quantity_ProductOrderQuantityId",
                table: "product");

            migrationBuilder.DropTable(
                name: "product_order_quantity");

            migrationBuilder.DropIndex(
                name: "IX_product_ProductOrderQuantityId",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_order_ProductOrderQuantityId",
                table: "order");

            migrationBuilder.DropIndex(
                name: "IX_customer_OrderId",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "ProductOrderQuantityId",
                table: "product");

            migrationBuilder.DropColumn(
                name: "ProductOrderQuantityId",
                table: "order");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "customer");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "order",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_order_CustomerId",
                table: "order",
                column: "CustomerId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_order_customer_CustomerId",
                table: "order",
                column: "CustomerId",
                principalTable: "customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_customer_CustomerId",
                table: "order");

            migrationBuilder.DropTable(
                name: "QuantitiesProducts");

            migrationBuilder.DropIndex(
                name: "IX_order_CustomerId",
                table: "order");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "order");

            migrationBuilder.AddColumn<int>(
                name: "ProductOrderQuantityId",
                table: "product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductOrderQuantityId",
                table: "order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "customer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "product_order_quantity",
                columns: table => new
                {
                    ProductOrderQuantityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_order_quantity", x => x.ProductOrderQuantityId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_ProductOrderQuantityId",
                table: "product",
                column: "ProductOrderQuantityId");

            migrationBuilder.CreateIndex(
                name: "IX_order_ProductOrderQuantityId",
                table: "order",
                column: "ProductOrderQuantityId");

            migrationBuilder.CreateIndex(
                name: "IX_customer_OrderId",
                table: "customer",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_customer_order_OrderId",
                table: "customer",
                column: "OrderId",
                principalTable: "order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_product_order_quantity_ProductOrderQuantityId",
                table: "order",
                column: "ProductOrderQuantityId",
                principalTable: "product_order_quantity",
                principalColumn: "ProductOrderQuantityId");

            migrationBuilder.AddForeignKey(
                name: "FK_product_product_order_quantity_ProductOrderQuantityId",
                table: "product",
                column: "ProductOrderQuantityId",
                principalTable: "product_order_quantity",
                principalColumn: "ProductOrderQuantityId");
        }
    }
}
