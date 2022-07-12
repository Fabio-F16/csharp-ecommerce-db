using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csharp_ecommerce_db.Migrations
{
    public partial class UpdateEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_product_order_ProductOrderQuantityId",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_product_product_order_ProductOrderQuantityId",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product_order",
                table: "product_order");

            migrationBuilder.RenameTable(
                name: "product_order",
                newName: "product_order_quantity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product_order_quantity",
                table: "product_order_quantity",
                column: "ProductOrderQuantityId");

            migrationBuilder.AddForeignKey(
                name: "FK_order_product_order_quantity_ProductOrderQuantityId",
                table: "order",
                column: "ProductOrderQuantityId",
                principalTable: "product_order_quantity",
                principalColumn: "ProductOrderQuantityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_product_order_quantity_ProductOrderQuantityId",
                table: "product",
                column: "ProductOrderQuantityId",
                principalTable: "product_order_quantity",
                principalColumn: "ProductOrderQuantityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_product_order_quantity_ProductOrderQuantityId",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_product_product_order_quantity_ProductOrderQuantityId",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product_order_quantity",
                table: "product_order_quantity");

            migrationBuilder.RenameTable(
                name: "product_order_quantity",
                newName: "product_order");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product_order",
                table: "product_order",
                column: "ProductOrderQuantityId");

            migrationBuilder.AddForeignKey(
                name: "FK_order_product_order_ProductOrderQuantityId",
                table: "order",
                column: "ProductOrderQuantityId",
                principalTable: "product_order",
                principalColumn: "ProductOrderQuantityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_product_order_ProductOrderQuantityId",
                table: "product",
                column: "ProductOrderQuantityId",
                principalTable: "product_order",
                principalColumn: "ProductOrderQuantityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
