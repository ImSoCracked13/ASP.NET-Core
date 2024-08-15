using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web2.Data.Migrations
{
    /// <inheritdoc />
    public partial class Forth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20b09302-1e8b-4366-a84f-060028cb01cc", "AQAAAAIAAYagAAAAECfIB6zMnnKVNr1vq5Zj/+SZgFdLna2bZ6jdYauzoaRTReqk/j11qV8/Tz9lLRA4RQ==", "84e1f49e-b608-4e0b-9991-bcdb438199ae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "542e1265-d3f8-4117-ae66-2139219ae27c", "AQAAAAIAAYagAAAAELlkEe6DjybVclj9NhF/JI3zmODoiwZYxzb9paMz1P/5E4HHv+fx4ntnekLdFXmujQ==", "728f14a5-82eb-476d-b966-9a338253dfb1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac61d8ff-1599-43bb-b8a2-90d8b390d83f", "AQAAAAIAAYagAAAAEIDn+jQBEe6m7qLScHJ7TsyWskxkCc1lgMy+bcGQ9CBkXFMhun8pAjOkqKIw6IhdCA==", "ad888c8c-5d99-44b9-94d7-71e183212e57" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a948e44-e3ad-4761-9e03-5d184905a4d6", "AQAAAAIAAYagAAAAEHHy2g/78Xxkprfv5bz4OKwL1+lthYV1cy2q3RW21680LTgjKdw0xUyEKbPBUz2WGQ==", "b3863d41-c0bb-4610-9029-141279f9db02" });
        }
    }
}
