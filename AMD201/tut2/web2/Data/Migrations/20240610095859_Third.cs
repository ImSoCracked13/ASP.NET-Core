using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace web2.Data.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Laptop",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "role1", null, "Administrator", "ADMINISTRATOR" },
                    { "role2", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "user1", 0, "ac61d8ff-1599-43bb-b8a2-90d8b390d83f", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEIDn+jQBEe6m7qLScHJ7TsyWskxkCc1lgMy+bcGQ9CBkXFMhun8pAjOkqKIw6IhdCA==", null, false, "ad888c8c-5d99-44b9-94d7-71e183212e57", false, "admin@gmail.com" },
                    { "user2", 0, "3a948e44-e3ad-4761-9e03-5d184905a4d6", "user@gmail.com", true, false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAEHHy2g/78Xxkprfv5bz4OKwL1+lthYV1cy2q3RW21680LTgjKdw0xUyEKbPBUz2WGQ==", null, false, "b3863d41-c0bb-4610-9029-141279f9db02", false, "user@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Laptop",
                columns: new[] { "Id", "Brand", "Color", "Image", "Model", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "Apple", "Grey", "https://bizweb.dktcdn.net/100/444/581/products/macbook-m1-vs-intel-1536x1268-6c00654d-ad87-4caf-8b88-aa6c34048199.png?v=1656134590567", "Macbook Pro M2", 2345m, 10 },
                    { 2, "Dell", "Black", "https://thegioiso365.vn/wp-content/uploads/2023/04/Dell-xps-9530-3.png", "XPS15", 1999m, 15 },
                    { 3, "LG", "White", "https://product.hstatic.net/1000333506/product/pc-gram-17z90q-b-gallery-02_dd780c6249ec430b84f82ed466fffd6e.jpg", "Gram 17", 2024m, 22 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "role1", "user1" },
                    { "role2", "user2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "role1", "user1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "role2", "user2" });

            migrationBuilder.DeleteData(
                table: "Laptop",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Laptop",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Laptop",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Laptop",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
