namespace CarDealer.App
{
    using AutoMapper;
    using CarDealer.App.Dto;
    using CarDealer.Data;
    using CarDealer.Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var mapConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<CarDealerProfiler>();
            });

            var mapper = mapConfiguration.CreateMapper();

            var context = new CarDealerContext();

            DatabaseInit(context);
            ImportSuppliers(context, mapper);
            ImportParts(context, mapper);
            ImportCars(context, mapper);
            ImportCustomers(context, mapper);
            ImportSales(context);
            ExportCustomers(context);
            ExportCars(context);
            ExportSuppliers(context);
            ExportCarsWithParts(context);
            ExportCustomersWithTotalSales(context);
            ExportSales(context);
        }

        private static void ExportSales(CarDealerContext context)
        {
            var sales = context.Sales
                               .Select(e => new SalesAndDiscountsExport
                               {
                                   Car = new SaleCarDto
                                   {
                                       Make = e.Car.Make,
                                       Model = e.Car.Model,
                                       TravelledDistance = e.Car.TravelledDistance,
                                   },
                                   CustomerName = e.Customer.Name,
                                   Discount = e.Discount,
                                   Price = e.Car.CarParts.Select(z => z.Part.Price).Sum(),
                                   PriceWithDiscount = e.Car.CarParts.Select(z => z.Part.Price).Sum() * (1.0m - e.Discount),

                               }).ToArray();

            var jsonSales = JsonConvert.SerializeObject(sales, Formatting.Indented);

            File.WriteAllText(@"../../../ExportJson/sales-discounts.json", jsonSales);              
        }

        private static void ExportCustomersWithTotalSales(CarDealerContext context)
        {
            var customersWithTotalSales = context.Customers
                                                 .Where(e => e.Sales.Count >= 1)
                                                 .Select(e => new CustomerWithTotalSalesExport
                                                 {
                                                     FullName = e.Name,
                                                     BoughtCars = e.Sales.Count,
                                                     SpentMoney = e.Sales.Sum(m => m.Car.CarParts.Sum(z => z.Part.Price)),
                                                 })
                                                 .OrderByDescending(e => e.SpentMoney)
                                                 .ThenByDescending(e => e.BoughtCars)
                                                 .ToArray();

            var jsonCustomersWithTotalSales = JsonConvert.SerializeObject(customersWithTotalSales, Formatting.Indented);
            File.WriteAllText(@"../../../ExportJson/customers-total-sales.json", jsonCustomersWithTotalSales);
        }

        private static void ExportCarsWithParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                                       .Select(e => new CarAndPartsExportDto
                                       {
                                           Car = new CarWithPartsExportDto
                                           {
                                               Make = e.Make,
                                               Model = e.Model,
                                               TravelledDistance = e.TravelledDistance,
                                           },

                                           Parts = e.CarParts
                                                    .Select(z => new PartExportDto
                                                    {
                                                        Name = z.Part.Name,
                                                        Price = z.Part.Price

                                                    }).ToArray(),

                                       }).ToArray();

            var jsonCarsWithParts = JsonConvert.SerializeObject(carsWithParts, Formatting.Indented);

            File.WriteAllText(@"../../../ExportJson/cars-and-parts.json", jsonCarsWithParts);
        }

        private static void ExportSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                                   .Where(e => e.IsImporter == false)
                                   .Select(e => new SupplierExportDto
                                   {
                                       Id = e.Id,
                                       Name = e.Name,
                                       PartsCount = e.Parts.Count,
                                   })
                                   .ToArray();

            var jsonSuppliers = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            File.WriteAllText(@"../../../ExportJson/local-suppliers.json", jsonSuppliers);

        }

        private static void ExportCars(CarDealerContext context)
        {
            var cars = context.Cars
                              .Where(e => e.Make == "Toyota")
                              .Select(e => new CarExportDto
                              {
                                  Id = e.Id,
                                  Make = e.Make,
                                  Model = e.Model,
                                  TravelledDistance = e.TravelledDistance,
                              })
                              .OrderBy(e => e.Model)
                              .ThenByDescending(e => e.TravelledDistance)
                              .ToArray();

            var jsonCars = JsonConvert.SerializeObject(cars, Formatting.Indented);

            File.WriteAllText(@"../../../ExportJson/toyota-cars.json", jsonCars);
        }

        private static void ExportCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                                   .Select(e => new CustomerExportDto
                                   {
                                        Id = e.Id,
                                        Name = e.Name,
                                        BirthDate = e.BirthDate,
                                        IsYoungDriver = e.IsYoungDriver,
                                   })
                                   .OrderBy(e => e.BirthDate)
                                   .ThenBy(e => e.IsYoungDriver)
                                   .ToArray();

            var jsonCustomers = JsonConvert.SerializeObject(customers, Formatting.Indented);

            File.WriteAllText(@"../../../ExportJson/ordered-customers.json", jsonCustomers);
        }

        private static void ImportSales(CarDealerContext context)
        {
            var sales = new List<Sale>();
            var random = new Random();
            var discounts = new[] { 0.0m, 0.1m, 0.2m, 0.3m, 0.4m, 0.5m };

            for (int i = 0; i <= 99; i++)
            {
                var discountIndex = random.Next(0, 6);

                var sale = new Sale()
                {
                    //Id = i + 1,
                    Discount = discounts[discountIndex],
                    CarId = random.Next(1, 359),
                    CustomerId = random.Next(1, 31),
                };

                sales.Add(sale);
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();
        }

        private static void ImportCustomers(CarDealerContext context, IMapper mapper)
        {
            var json = File.ReadAllText(@"../../../ImportJson/customers.json");

            var customersDto = JsonConvert.DeserializeObject<CustomerDto[]>(json);
            var customers = new List<Customer>();

            foreach (var customerDto in customersDto)
            {
                var customer = mapper.Map<Customer>(customerDto);

                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();
        }

        private static void ImportCars(CarDealerContext context, IMapper mapper)
        {
            var json = File.ReadAllText(@"../../../ImportJson/cars.json");

            var carsDto = JsonConvert.DeserializeObject<CarDto[]>(json);
            var cars = new List<Car>();
            var random = new Random();

            foreach (var carDto in carsDto)
            {
                var range = random.Next(10, 21);
                var randomPartId = random.Next(1, 111);
                var car = mapper.Map<Car>(carDto);

                for (int i = 0; i < range; i++)
                {
                    var carPart = new PartCar()
                    {
                        CarId = car.Id,
                        PartId = randomPartId++,
                    };

                    car.CarParts.Add(carPart);
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();
        }

        private static void ImportParts(CarDealerContext context, IMapper mapper)
        {
            var json = File.ReadAllText(@"../../../ImportJson/parts.json");

            var partsDto = JsonConvert.DeserializeObject<PartDto[]>(json);
            var parts = new List<Part>();
            var random = new Random();

            foreach (var partDto in partsDto)
            {
                var part = mapper.Map<Part>(partDto);
                part.SuplierId = random.Next(1, 32);
                parts.Add(part);
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();
        }

        private static void ImportSuppliers(CarDealerContext context, IMapper mapper)
        {
            var json = File.ReadAllText(@"../../../ImportJson/suppliers.json");

            var suppliersDto = JsonConvert.DeserializeObject<SupplierDto[]>(json);
            var suppliers = new List<Supplier>();

            foreach (var supplierDto in suppliersDto)
            {
                var supplier = mapper.Map<Supplier>(supplierDto);

                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
        }

        private static void DatabaseInit(CarDealerContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
