using Core.Currencies;
using Core.ExchangesHistory;
using Core.Shared;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Peresistence.Helpers
{
    internal class DataSeeder
    {
        internal static ModelBuilder Seed(ModelBuilder builder)
        {
            #region InitialUsers
            builder.Entity<AppUser>().HasData(new AppUser()
            {

                Id = "663c6ddf-262a-4d6c-b298-bb92d406c274",
                FirstName = "Mohamed",
                LastName = "Magdy",
                Email = "mohamedmagdy@gmail.com",
                NormalizedEmail = "MOHAMEDMAGDY@GMAIL.COM",
                EmailConfirmed = true,
                UserName = "mohamedmagdy",
                NormalizedUserName = "MOHAMEDMAGDY",
                PhoneNumber = "0123456789",
                PhoneNumberConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEFz8RJX2aVKEu/YCPKmkuIGaziVOJ8tBmYgJwAn+6wq9vH0cFa5+K3be7ipBk2/UMQ==",
                SecurityStamp = "PNPSB6B6YP3GKYCEVLYBXNH3VPPDA34F",
                ConcurrencyStamp = "14120b41-99d3-4307-a1a3-ca9a4e347a12",
                TwoFactorEnabled = true,
                LockoutEnabled = true,
                AccessFailedCount = 0

            });
            #endregion

            #region InitialCurrencies
            #region US Dollar
            builder.Entity<Currency>().HasData(new Currency()
            {

                Id = CurrencyConverterDefaults.BaseCurrencyId,
                Name = CurrencyConverterDefaults.CurrencyName,
                Sign = CurrencyConverterDefaults.Sign,

            });

            builder.Entity<ExchangeHistory>().HasData(new ExchangeHistory
            {

                Id = new Guid("0406b360-0934-4a85-9693-51c9244a1add"),
                Rate = CurrencyConverterDefaults.Rate,
                CurrencyId = CurrencyConverterDefaults.BaseCurrencyId,
                ExchangeDate = DateTime.Parse("2022-08-15 12:24:39.9980887"),

            });
            #endregion

            #region Egyptian Pound
            builder.Entity<Currency>().HasData(new Currency()
            {

                Id = new Guid("0c62ae40-9828-414c-8d2d-8b68a784d4a3"),
                Name = "Egyptian Pound",
                Sign = "£",

            });

            builder.Entity<ExchangeHistory>().HasData(new ExchangeHistory
            {

                Id = new Guid("a6e28d87-0c4d-4285-a571-455c6fac0c60"),
                Rate = 0.052212328,
                CurrencyId = Guid.Parse("0c62ae40-9828-414c-8d2d-8b68a784d4a3"),
                ExchangeDate = DateTime.Parse("2022-08-15 12:24:39.9980887"),

            });
            #endregion

            #region British Pound
            builder.Entity<Currency>().HasData(new Currency()
            {

                Id = new Guid("55decdae-2ae6-4b22-ab4b-a4b7f6440818"),
                Name = "British Pound",
                Sign = "£",

            });

            builder.Entity<ExchangeHistory>().HasData(new ExchangeHistory
            {

                Id = new Guid("0be3622e-635a-4d1f-b574-f0c84aa09220"),
                Rate = 1.2068888,
                CurrencyId = Guid.Parse("55decdae-2ae6-4b22-ab4b-a4b7f6440818"),
                ExchangeDate = DateTime.Parse("2022-08-15 12:24:39.9980887"),

            });
            #endregion

            #region Syrian Pound
            builder.Entity<Currency>().HasData(new Currency()
            {

                Id = new Guid("21f8274e-f045-40ec-9ba6-3e6935f78788"),
                Name = "Syrian Pound",
                Sign = "£",

            });

            builder.Entity<ExchangeHistory>().HasData(new ExchangeHistory
            {

                Id = new Guid("3b4ab872-adb0-4b52-abc9-567febf3d5e9"),
                Rate = 0.00039800498,
                CurrencyId = Guid.Parse("21f8274e-f045-40ec-9ba6-3e6935f78788"),
                ExchangeDate = DateTime.Parse("2022-08-15 12:24:39.9980887"),

            });
            #endregion

            #region Euro
            builder.Entity<Currency>().HasData(new Currency()
            {

                Id = new Guid("c8797773-defd-461c-93c3-72dfdcfa7a8b"),
                Name = "Euro",
                Sign = "€",

            });

            builder.Entity<ExchangeHistory>().HasData(new ExchangeHistory
            {

                Id = new Guid("3c8e3fb5-35ef-4197-8e6b-5b4a86b6091c"),
                Rate = 1.0206144,
                CurrencyId = Guid.Parse("c8797773-defd-461c-93c3-72dfdcfa7a8b"),
                ExchangeDate = DateTime.Parse("2022-08-15 12:24:39.9980887"),

            });
            #endregion

            #region Kuwaiti Dinar
            builder.Entity<Currency>().HasData(new Currency()
            {

                Id = new Guid("da30519b-c209-421d-8b39-aac1ffad7874"),
                Name = "Kuwaiti Dinar",
                Sign = "KD",

            });

            builder.Entity<ExchangeHistory>().HasData(new ExchangeHistory
            {

                Id = new Guid("bbd93dc9-76f7-4a21-aa65-9e1cddb96455"),
                Rate = 3.2583528,
                CurrencyId = Guid.Parse("da30519b-c209-421d-8b39-aac1ffad7874"),
                ExchangeDate = DateTime.Parse("2022-08-15 12:24:39.9980887"),

            });
            #endregion

            #region Bahraini Dinar
            builder.Entity<Currency>().HasData(new Currency()
            {

                Id = new Guid("56ff9141-cac2-4037-b18a-2fe003c397a5"),
                Name = "Bahraini Dinar",
                Sign = "BHD",

            });

            builder.Entity<ExchangeHistory>().HasData(new ExchangeHistory
            {

                Id = new Guid("60ec8a2a-e58e-43a9-8538-a32b026d58d8"),
                Rate = 2.6595745,
                CurrencyId = Guid.Parse("56ff9141-cac2-4037-b18a-2fe003c397a5"),
                ExchangeDate = DateTime.Parse("2022-08-15 12:24:39.9980887"),

            });
            #endregion

            #region Emirati Dirham
            builder.Entity<Currency>().HasData(new Currency()
            {

                Id = new Guid("b1979be0-9433-4ef0-ba50-8e978fd37d43"),
                Name = "Emirati Dirham",
                Sign = "D.E",

            });

            builder.Entity<ExchangeHistory>().HasData(new ExchangeHistory
            {

                Id = new Guid("ab3b309e-0394-4572-8c51-28612c020d55"),
                Rate = 0.27229408,
                CurrencyId = Guid.Parse("b1979be0-9433-4ef0-ba50-8e978fd37d43"),
                ExchangeDate = DateTime.Parse("2022-08-15 12:24:39.9980887"),

            });
            #endregion

            #region Saudi Arabian Riyal
            builder.Entity<Currency>().HasData(new Currency()
            {

                Id = new Guid("830e30e7-c925-4d92-8cbb-427c7b4d7cca"),
                Name = "Saudi Arabian Riyal",
                Sign = "SAR",

            });

            builder.Entity<ExchangeHistory>().HasData(new ExchangeHistory
            {

                Id = new Guid("b45703b6-3492-40c1-ad35-bea2dcab055a"),
                Rate = 0.26666667,
                CurrencyId = Guid.Parse("830e30e7-c925-4d92-8cbb-427c7b4d7cca"),
                ExchangeDate = DateTime.Parse("2022-08-15 12:24:39.9980887"),

            });
            #endregion

            #region Qatari Riyal
            builder.Entity<Currency>().HasData(new Currency()
            {

                Id = new Guid("caaa5c58-ed89-4cc1-924c-1c2fe2e6f2f8"),
                Name = "Qatari Riyal",
                Sign = "QAR",

            });

            builder.Entity<ExchangeHistory>().HasData(new ExchangeHistory
            {

                Id = new Guid("7adccefd-8afe-4b1b-8e8d-65f347ec686c"),
                Rate = 0.27472527,
                CurrencyId = Guid.Parse("caaa5c58-ed89-4cc1-924c-1c2fe2e6f2f8"),
                ExchangeDate = DateTime.Parse("2022-08-15 12:24:39.9980887"),

            });
            #endregion

            #region Turkish Lira
            builder.Entity<Currency>().HasData(new Currency()
            {

                Id = new Guid("ad5de54c-dcd2-473a-8e65-3815596ec9dd"),
                Name = "Turkish Lira",
                Sign = "₺",

            });

            builder.Entity<ExchangeHistory>().HasData(new ExchangeHistory
            {

                Id = new Guid("2b3f23a3-b9b7-417e-bfb4-81d2bcf5550a"),
                Rate = 0.055657701,
                CurrencyId = Guid.Parse("ad5de54c-dcd2-473a-8e65-3815596ec9dd"),
                ExchangeDate = DateTime.Parse("2022-08-15 12:24:39.9980887"),

            });
            #endregion

            #region Bitcoin
            builder.Entity<Currency>().HasData(new Currency()
            {

                Id = new Guid("2e2b576d-6c35-434d-bc87-988a2fe6e375"),
                Name = "Bitcoin",
                Sign = "฿",

            });

            builder.Entity<ExchangeHistory>().HasData(new ExchangeHistory
            {

                Id = new Guid("45b4631c-9075-4995-81d9-3ce183a88c5c"),
                Rate = 24113.526,
                CurrencyId = Guid.Parse("2e2b576d-6c35-434d-bc87-988a2fe6e375"),
                ExchangeDate = DateTime.Parse("2022-08-15 12:24:39.9980887"),

            });
            #endregion
            #endregion

            return builder;
        }
    }
}
