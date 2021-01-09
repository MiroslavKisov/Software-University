namespace ShopHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new ShopContext())
            {
                ResetDatabase(db);

                var input = Console.ReadLine();
                var salesmen = input.Split(";");
                var listOfSalesmen = new List<Salesman>();

                foreach (var salesmanName in salesmen)
                {
                    if (IsValid(salesmanName))
                    {
                        var salesman = new Salesman
                        {
                            Name = salesmanName,
                        };

                        listOfSalesmen.Add(salesman);
                    }
                }

                db.Salesmen.AddRange(listOfSalesmen);
                db.SaveChanges();

                var items = new List<Item>();

                while (true)
                {
                    input = Console.ReadLine();

                    if (input == "END")
                    {
                        break;
                    }

                    var itemArgs = input.Split(";");
                    var itemName = itemArgs[0];
                    var itemPrice = decimal.Parse(itemArgs[1]);

                    var item = new Item
                    {
                        Name = itemName,
                        Price = itemPrice,
                    };

                    if (IsValid(item))
                    {
                        items.Add(item);
                    }
                }

                db.Items.AddRange(items);
                db.SaveChanges();

                while (true)
                {
                    input = Console.ReadLine();

                    if (input == "END")
                    {
                        break;
                    }

                    var customerArgs = input.Split("-");
                    if (customerArgs[0] == "register")
                    {
                        var customerInfo = customerArgs[1].Split(";");
                        var customerName = customerInfo[0];
                        var salesmanId = int.Parse(customerInfo[1]);

                        var customer = new Customer
                        {
                            Name = customerName,
                            SalesmanId = salesmanId,
                        };

                        db.Customers.Add(customer);
                        db.SaveChanges();
                    }
                    else if (customerArgs[0] == "review")
                    {
                        var reviewArgs = input.Split("-");
                        var reviewInfo = reviewArgs[1].Split(";");
                        var customerId = int.Parse(reviewInfo[0]);
                        var itemId = int.Parse(reviewInfo[1]);

                        var customer = db.Customers.Find(customerId);

                        if (db.Items.Any(e => e.Id == itemId))
                        {
                            var review = new Review
                            {
                                CustomerId = customerId,
                                ItemId = itemId,
                            };

                            customer.Reviews.Add(review);
                        }
                    }
                    else if (customerArgs[0] == "order")
                    {
                        var orderArgs = input.Split("-");
                        var orderName = orderArgs[0];
                        var orderInfo = orderArgs[1].Split(";");
                        var customerId = int.Parse(orderInfo[0]);

                        var ids = orderInfo.Skip(1).Select(int.Parse);
                        var itemIds = db.Items.Where(e => ids.Contains(e.Id)).ToList();
                        var customer = db.Customers.Find(customerId);

                        var order = new Order
                        {
                            CustomerId = customerId,
                        };

                        customer.Orders.Add(order);
                        db.SaveChanges();

                        var itemOrders = new List<ItemOrder>();

                        foreach (var itemId in itemIds)
                        {
                            var itemOrder = new ItemOrder
                            {
                                OrderId = order.Id,
                                ItemId = itemId.Id,
                            };

                            itemOrders.Add(itemOrder);
                        }


                        db.ItemsOrders.AddRange(itemOrders);
                    }

                    db.SaveChanges();
                }

                var salesmenWithCustomers = db.Salesmen
                                              .Select(e => new
                                              {
                                                  SalesmanName = e.Name,
                                                  NumberOfCustomers = e.Customers.Count,
                                              })
                                              .OrderByDescending(e => e.NumberOfCustomers)
                                              .ThenBy(e => e.SalesmanName)
                                              .ToList();

                foreach (var salesman in salesmenWithCustomers)
                {
                    Console.WriteLine($"{salesman.SalesmanName} - {salesman.NumberOfCustomers} customers");
                }

                var customers = db.Customers
                                  .Select(e => new
                                  {
                                      CustomerName = e.Name,
                                      NumberOfOrders = e.Orders.Count,
                                      NumberOfReviews = e.Reviews.Count,
                                  })
                                  .OrderByDescending(e => e.NumberOfOrders)
                                  .ThenByDescending(e => e.NumberOfReviews)
                                  .ToList();

                foreach (var customer in customers)
                {
                    Console.WriteLine(customer.CustomerName);
                    Console.WriteLine($"Orders: {customer.NumberOfOrders}");
                    Console.WriteLine($"Reviews: {customer.NumberOfReviews}");
                }

                input = Console.ReadLine();

                var custId = int.Parse(input);

                var customerOrdersAndReviews = db.Customers
                                                 .Where(e => e.Id == custId)
                                                 .Select(e => new
                                                 {
                                                     ListOfOrders = e.Orders
                                                                     .Select(z => new
                                                                     {
                                                                         OrderId = z.Id,
                                                                         NumberOfItems = z.ItemsOrders.Count
                                                                     })
                                                                     .OrderBy(z => z.OrderId)
                                                                     .ToList(),

                                                     CustomerReviewsCount = e.Reviews.Count
                                                 })
                                                 .FirstOrDefault();


                foreach (var order in customerOrdersAndReviews.ListOfOrders)
                {
                    Console.WriteLine($"order {order.OrderId}: {order.NumberOfItems} items");
                }

                Console.WriteLine($"reviews: {customerOrdersAndReviews.CustomerReviewsCount}");

                var customerData = db.Customers
                                     .Where(e => e.Id == custId)
                                     .Select(e => new
                                     {
                                         CustomerName = e.Name,
                                         OrdersCount = e.Orders.Count,
                                         ReviewsCount = e.Reviews.Count,
                                         SalesmanName = e.Salesman.Name,
                                     })
                                     .FirstOrDefault();

                Console.WriteLine($"Customer: {customerData.CustomerName}");
                Console.WriteLine($"Orders count: {customerData.OrdersCount}");
                Console.WriteLine($"Reviews count: {customerData.ReviewsCount}");
                Console.WriteLine($"Salesman: {customerData.SalesmanName}");

                var ordersWithMorethanOneItem = db.Customers
                                                  .Where(e => e.Id == custId)
                                                  .Select(e => new
                                                  {
                                                      CustomerOrders = e.Orders.Where(z => z.ItemsOrders.Count > 1).ToList(),
                                                  })
                                                  .FirstOrDefault();

                Console.WriteLine($"Orders count: {ordersWithMorethanOneItem.CustomerOrders.Count}");
            }
        }

        private static void ResetDatabase(ShopContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}
