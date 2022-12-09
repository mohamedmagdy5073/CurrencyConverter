using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class SeedCurrencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "exchangeHistories",
                keyColumn: "Id",
                keyValue: new Guid("498531c9-af8c-41a4-9530-d0cad1fa3674"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("9c37c1e5-5e1b-4f06-ad7c-16e7a10d212d"));

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy", "Name", "Sign" },
                values: new object[,]
                {
                    { new Guid("0c62ae40-9828-414c-8d2d-8b68a784d4a3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, "Egyptian Pound", "£" },
                    { new Guid("21f8274e-f045-40ec-9ba6-3e6935f78788"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, "Syrian Pound", "£" },
                    { new Guid("2e2b576d-6c35-434d-bc87-988a2fe6e375"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, "Bitcoin", "฿" },
                    { new Guid("4dd667b1-381d-4d5e-a8ee-a5d690040c9b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, "US Dollar", "$" },
                    { new Guid("55decdae-2ae6-4b22-ab4b-a4b7f6440818"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, "British Pound", "£" },
                    { new Guid("56ff9141-cac2-4037-b18a-2fe003c397a5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, "Bahraini Dinar", "BHD" },
                    { new Guid("830e30e7-c925-4d92-8cbb-427c7b4d7cca"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, "Saudi Arabian Riyal", "SAR" },
                    { new Guid("ad5de54c-dcd2-473a-8e65-3815596ec9dd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, "Turkish Lira", "₺" },
                    { new Guid("b1979be0-9433-4ef0-ba50-8e978fd37d43"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, "Emirati Dirham", "D.E" },
                    { new Guid("c8797773-defd-461c-93c3-72dfdcfa7a8b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, "Euro", "€" },
                    { new Guid("caaa5c58-ed89-4cc1-924c-1c2fe2e6f2f8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, "Qatari Riyal", "QAR" },
                    { new Guid("da30519b-c209-421d-8b39-aac1ffad7874"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, "Kuwaiti Dinar", "KD" }
                });

            migrationBuilder.InsertData(
                table: "exchangeHistories",
                columns: new[] { "Id", "Created", "CreatedBy", "CurrencyId", "ExchangeDate", "IsDeleted", "LastModified", "LastModifiedBy", "Rate" },
                values: new object[,]
                {
                    { new Guid("0406b360-0934-4a85-9693-51c9244a1add"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("4dd667b1-381d-4d5e-a8ee-a5d690040c9b"), new DateTime(2022, 8, 15, 12, 24, 39, 998, DateTimeKind.Unspecified).AddTicks(887), false, null, null, 1.0 },
                    { new Guid("0be3622e-635a-4d1f-b574-f0c84aa09220"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("55decdae-2ae6-4b22-ab4b-a4b7f6440818"), new DateTime(2022, 8, 15, 12, 24, 39, 998, DateTimeKind.Unspecified).AddTicks(887), false, null, null, 1.2068888 },
                    { new Guid("2b3f23a3-b9b7-417e-bfb4-81d2bcf5550a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ad5de54c-dcd2-473a-8e65-3815596ec9dd"), new DateTime(2022, 8, 15, 12, 24, 39, 998, DateTimeKind.Unspecified).AddTicks(887), false, null, null, 0.055657700999999997 },
                    { new Guid("3b4ab872-adb0-4b52-abc9-567febf3d5e9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("21f8274e-f045-40ec-9ba6-3e6935f78788"), new DateTime(2022, 8, 15, 12, 24, 39, 998, DateTimeKind.Unspecified).AddTicks(887), false, null, null, 0.00039800498000000002 },
                    { new Guid("3c8e3fb5-35ef-4197-8e6b-5b4a86b6091c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("c8797773-defd-461c-93c3-72dfdcfa7a8b"), new DateTime(2022, 8, 15, 12, 24, 39, 998, DateTimeKind.Unspecified).AddTicks(887), false, null, null, 1.0206143999999999 },
                    { new Guid("45b4631c-9075-4995-81d9-3ce183a88c5c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("2e2b576d-6c35-434d-bc87-988a2fe6e375"), new DateTime(2022, 8, 15, 12, 24, 39, 998, DateTimeKind.Unspecified).AddTicks(887), false, null, null, 24113.526000000002 },
                    { new Guid("60ec8a2a-e58e-43a9-8538-a32b026d58d8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("56ff9141-cac2-4037-b18a-2fe003c397a5"), new DateTime(2022, 8, 15, 12, 24, 39, 998, DateTimeKind.Unspecified).AddTicks(887), false, null, null, 2.6595745000000002 },
                    { new Guid("7adccefd-8afe-4b1b-8e8d-65f347ec686c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("caaa5c58-ed89-4cc1-924c-1c2fe2e6f2f8"), new DateTime(2022, 8, 15, 12, 24, 39, 998, DateTimeKind.Unspecified).AddTicks(887), false, null, null, 0.27472527000000002 },
                    { new Guid("a6e28d87-0c4d-4285-a571-455c6fac0c60"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("0c62ae40-9828-414c-8d2d-8b68a784d4a3"), new DateTime(2022, 8, 15, 12, 24, 39, 998, DateTimeKind.Unspecified).AddTicks(887), false, null, null, 0.052212328000000002 },
                    { new Guid("ab3b309e-0394-4572-8c51-28612c020d55"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("b1979be0-9433-4ef0-ba50-8e978fd37d43"), new DateTime(2022, 8, 15, 12, 24, 39, 998, DateTimeKind.Unspecified).AddTicks(887), false, null, null, 0.27229407999999999 },
                    { new Guid("b45703b6-3492-40c1-ad35-bea2dcab055a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("830e30e7-c925-4d92-8cbb-427c7b4d7cca"), new DateTime(2022, 8, 15, 12, 24, 39, 998, DateTimeKind.Unspecified).AddTicks(887), false, null, null, 0.26666666999999999 },
                    { new Guid("bbd93dc9-76f7-4a21-aa65-9e1cddb96455"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("da30519b-c209-421d-8b39-aac1ffad7874"), new DateTime(2022, 8, 15, 12, 24, 39, 998, DateTimeKind.Unspecified).AddTicks(887), false, null, null, 3.2583527999999999 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "exchangeHistories",
                keyColumn: "Id",
                keyValue: new Guid("0406b360-0934-4a85-9693-51c9244a1add"));

            migrationBuilder.DeleteData(
                table: "exchangeHistories",
                keyColumn: "Id",
                keyValue: new Guid("0be3622e-635a-4d1f-b574-f0c84aa09220"));

            migrationBuilder.DeleteData(
                table: "exchangeHistories",
                keyColumn: "Id",
                keyValue: new Guid("2b3f23a3-b9b7-417e-bfb4-81d2bcf5550a"));

            migrationBuilder.DeleteData(
                table: "exchangeHistories",
                keyColumn: "Id",
                keyValue: new Guid("3b4ab872-adb0-4b52-abc9-567febf3d5e9"));

            migrationBuilder.DeleteData(
                table: "exchangeHistories",
                keyColumn: "Id",
                keyValue: new Guid("3c8e3fb5-35ef-4197-8e6b-5b4a86b6091c"));

            migrationBuilder.DeleteData(
                table: "exchangeHistories",
                keyColumn: "Id",
                keyValue: new Guid("45b4631c-9075-4995-81d9-3ce183a88c5c"));

            migrationBuilder.DeleteData(
                table: "exchangeHistories",
                keyColumn: "Id",
                keyValue: new Guid("60ec8a2a-e58e-43a9-8538-a32b026d58d8"));

            migrationBuilder.DeleteData(
                table: "exchangeHistories",
                keyColumn: "Id",
                keyValue: new Guid("7adccefd-8afe-4b1b-8e8d-65f347ec686c"));

            migrationBuilder.DeleteData(
                table: "exchangeHistories",
                keyColumn: "Id",
                keyValue: new Guid("a6e28d87-0c4d-4285-a571-455c6fac0c60"));

            migrationBuilder.DeleteData(
                table: "exchangeHistories",
                keyColumn: "Id",
                keyValue: new Guid("ab3b309e-0394-4572-8c51-28612c020d55"));

            migrationBuilder.DeleteData(
                table: "exchangeHistories",
                keyColumn: "Id",
                keyValue: new Guid("b45703b6-3492-40c1-ad35-bea2dcab055a"));

            migrationBuilder.DeleteData(
                table: "exchangeHistories",
                keyColumn: "Id",
                keyValue: new Guid("bbd93dc9-76f7-4a21-aa65-9e1cddb96455"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("0c62ae40-9828-414c-8d2d-8b68a784d4a3"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("21f8274e-f045-40ec-9ba6-3e6935f78788"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("2e2b576d-6c35-434d-bc87-988a2fe6e375"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("4dd667b1-381d-4d5e-a8ee-a5d690040c9b"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("55decdae-2ae6-4b22-ab4b-a4b7f6440818"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("56ff9141-cac2-4037-b18a-2fe003c397a5"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("830e30e7-c925-4d92-8cbb-427c7b4d7cca"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("ad5de54c-dcd2-473a-8e65-3815596ec9dd"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("b1979be0-9433-4ef0-ba50-8e978fd37d43"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("c8797773-defd-461c-93c3-72dfdcfa7a8b"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("caaa5c58-ed89-4cc1-924c-1c2fe2e6f2f8"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("da30519b-c209-421d-8b39-aac1ffad7874"));

        }
    }
}
