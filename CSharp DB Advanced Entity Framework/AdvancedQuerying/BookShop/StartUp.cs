namespace BookShop
{
    using BookShop.Data;
    using BookShop.Initializer;
    using System.Linq;
    using System;
    using BookShop.Models;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Globalization;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                DbInitializer.ResetDatabase(db);

                //Problem 01
                //string command = Console.ReadLine();
                //foreach (var title in GetBooksByAgeRestriction(db, command))
                //{
                //    Console.Write(title);
                //}

                //Problem 02
                //foreach (var book in GetGoldenBooks(db))
                //{
                //    Console.Write(book);
                //}

                //Problem 03
                //foreach (var book in GetBooksByPrice(db))
                //{
                //    Console.Write(book);
                //}

                //Problem 04
                //int year = int.Parse(Console.ReadLine());
                //foreach (var book in GetBooksNotRealeasedIn(db, year))
                //{
                //    Console.Write(book);
                //}

                //Problem 05
                //string input = Console.ReadLine();
                //Console.WriteLine(GetBooksByCategory(db, input));

                //Problem 06
                //string input = Console.ReadLine();
                //Console.WriteLine(GetBooksReleasedBefore(db, input));

                //Problem 07
                //string input = Console.ReadLine();
                //Console.WriteLine(GetAuthorNamesEndingIn(db, input));

                //Problem 08
                //string input = Console.ReadLine();
                //Console.WriteLine(GetBookTitlesContaining(db, input));

                //Problem 09
                //string input = Console.ReadLine();
                //Console.WriteLine(GetBooksByAuthor(db, input));

                //Problem 10
                //int length = int.Parse(Console.ReadLine());
                //Console.WriteLine($"There are {CountBooks(db, length)} books with longer title than {length} symbols");

                //Problem 11
                //Console.WriteLine(CountCopiesByAuthor(db));

                //Problem 12
                //Console.WriteLine(GetTotalProfitByCategory(db));

                //Problem 13
                //Console.WriteLine(GetMostRecentBooks(db));

                //Problem 14
                //IncreasePrices(db);

                //Problem 15
                //Console.WriteLine($"{RemoveBooks(db)} books were deleted");
            }
        }

        public static int RemoveBooks(BookShopContext db)
        {
            var books = db.Books
                          .Where(e => e.Copies < 4200)
                          .ToList();

            int deleteCount = books.Count;

            db.Books.RemoveRange(books);

            db.SaveChanges();
            return deleteCount;
        }

        public static void IncreasePrices(BookShopContext db)
        {
            var books = db.Books
                          .Where(e => e.ReleaseDate.Value.Year < 2010)
                          .ToList();

            foreach (var book in books)
            {
                book.Price += 5m;
            }

            db.SaveChanges();
        }

        public static string GetMostRecentBooks(BookShopContext db)
        {
            var categories = db.Categories
                               .Select(e => new
                               {
                                   CategoryName = e.Name,
                                   Books = e.CategoryBooks
                                            .Select(x => new
                                                   {
                                                       BookName = x.Book.Title,
                                                       BookYear = x.Book.ReleaseDate.Value.Year,
                                                       Date = x.Book.ReleaseDate
                                                   })
                                                   .OrderByDescending(c => c.Date)
                                                   .Take(3)
                                                   .ToList()
                               })
                               .OrderBy(e => e.CategoryName)
                               .ToList();

            var resultSet = new List<string>();

            foreach (var category in categories)
            {
                string str = $"--{category.CategoryName}";
                resultSet.Add(str);

                foreach (var item in category.Books)
                {
                    string str2 = $"{item.BookName} ({item.BookYear})";
                    resultSet.Add(str2);
                }
            }

            string result = string.Join(Environment.NewLine, resultSet);

            return result.TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext db)
        {
            var categories = db.Categories.Select(e => new
                                            {
                                                CategoryName = e.Name,
                                                PricesAndCopies = e.CategoryBooks
                                                                   .Select(x => new
                                                                   {
                                                                       NumberOfCopies = x.Book.Copies,
                                                                       PriceOfBook = x.Book.Price
                                                                   })
                                                                   .ToList(),
                                            })
                                            .ToList();

            var profitByCategory = new Dictionary<string, decimal>();
            var sb = new StringBuilder();

            foreach (var category in categories)
            {
                decimal profit = 0.0m;

                foreach (var c in category.PricesAndCopies)
                {
                    profit += (c.PriceOfBook * c.NumberOfCopies);
                }

                profitByCategory.Add(category.CategoryName, profit);
            }

            foreach (var item in profitByCategory.OrderByDescending(e => e.Value).ThenBy(e => e.Key))
            {
                sb.AppendLine($"{item.Key} ${item.Value:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string CountCopiesByAuthor(BookShopContext db)
        {
            var books = db.Authors
                          .Select(e => new
                          {
                              Name = e.FirstName + ' ' + e.LastName,
                              Count = e.Books
                                       .Select(c => c.Copies).ToList()
                          })
                          .ToList();

            var sb = new StringBuilder();
            var authorsAndCopies = new Dictionary<string, int>();
            foreach (var book in books)
            {
                int numberOfCopies = 0;

                foreach (var b in book.Count)
                {
                    numberOfCopies += b;
                }

                authorsAndCopies.Add(book.Name, numberOfCopies);
            }

            foreach (var authorAndCopy in authorsAndCopies.OrderByDescending(e => e.Value))
            {
                sb.AppendLine($"{authorAndCopy.Key} - {authorAndCopy.Value}");
            }

            return sb.AppendLine().ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext db, int lengthCheck)
        {
            var books = db.Books
                          .Where(e => e.Title.Length > lengthCheck)
                          .Select(e => e.Title)
                          .Count();

            return books;
        }

        public static string GetBooksByAuthor(BookShopContext db, string input)
        {
            
            var authors = db.Authors
                            .Where(e => e.LastName.ToLower().StartsWith(input.ToLower()))
                            .Select(e => new
                            {
                                e.FirstName,
                                e.LastName,
                                Books = e.Books.Select(b => new
                                {
                                    b.BookId,
                                    b.Title

                                }).OrderBy(b => b.BookId)
                            })
                            .ToList();

            var sb = new StringBuilder();

            foreach (var a in authors.Select(e => new
                                                  {
                                                      Title = e.Books.Select(b => b.Title).ToList(),
                                                      AuthorName = e.FirstName + ' ' + e.LastName
                                                  }))
            {
                foreach (var title in a.Title)
                {
                    sb.AppendLine($"{title} ({a.AuthorName})");
                }
            }

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string GetBookTitlesContaining(BookShopContext db, string input)
        {
            var authors = db.Books
                            .Where(e => e.Title.ToLower().Contains(input.ToLower()))
                            .Select(e => e.Title)
                            .OrderBy(e => e)
                            .ToList();

            string result = string.Join(Environment.NewLine, authors);

            return result.TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext db, string input)
        {
            var authors = db.Authors
                            .Where(e => e.FirstName.EndsWith(input))
                            .Select(e => new
                            {
                                Name = e.FirstName + ' ' + e.LastName
                            })
                            .OrderBy(e => e.Name)
                            .ToList();

            string result = string.Join(Environment.NewLine, authors.Select(e => e.Name));

            return result.TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext db, string input)
        {
            var culture = CultureInfo.InvariantCulture;

            var date = DateTime.ParseExact(input, "dd-MM-yyyy", culture);

            var books = db.Books
                          .Where(e => e.ReleaseDate < date)
                          .Select(e => new
                          {
                              BookTitle = e.Title,
                              BookEditionType = e.EditionType,
                              BookPrice = e.Price,
                              Date = e.ReleaseDate
                          })
                          .OrderByDescending(e => e.Date)
                          .ToList();

            var b = books.Select(e => new
                                 {
                                    e.BookTitle,
                                    e.BookEditionType,
                                    e.BookPrice,
                                 });

            var sb = new StringBuilder();

            foreach (var book in b)
            {
                sb.AppendLine($"{book.BookTitle} - {book.BookEditionType} - ${book.BookPrice:F2}");
            }

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string GetBooksByCategory(BookShopContext db, string input)
        { 
            var categoryNames = input
                .ToLower()
                .Split();

            var bookTitles = db
                .Books
                .Include(b => b.BookCategories)
                .Where(b => b.BookCategories.Any(c => categoryNames.Contains(c.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            StringBuilder sb = new StringBuilder();


            bookTitles.ForEach(b => sb.AppendLine(b));

            var result = sb
                .ToString()
                .TrimEnd();

            return result;
        }

        public static string GetBooksNotRealeasedIn(BookShopContext db, int year)
        {
            var books = db.Books
                          .Where(e => e.ReleaseDate.Value.Year != year)
                          .OrderBy(e => e.BookId)
                          .Select(e => e.Title)
                          .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByPrice(BookShopContext db)
        {
            var books = db.Books
                          .Where(e => e.Price > 40)
                          .Select(e => new
                          {
                              BookTitle = e.Title,
                              BookPrice = e.Price
                          })
                          .OrderByDescending(e => e.BookPrice)
                          .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                string str = $"{book.BookTitle} - ${book.BookPrice:F2}";
                sb.AppendLine(str);
            }

            return sb.ToString();
        }

        public static string GetGoldenBooks(BookShopContext db)
        {
            string gold = "Gold";
            var goldenType =(EditionType)Enum.Parse(typeof(EditionType), gold, true);

            var books = db.Books
                          .Where(e => e.EditionType == goldenType && e.Copies < 5000)
                          .Select(e => e.Title)
                          .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageType = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), command, true);

            var books = context.Books
                               .Where(x => x.AgeRestriction == ageType)
                               .Select(x => x.Title)
                               .OrderBy(x => x)
                               .ToArray();

            return String.Join(Environment.NewLine, books);
        }
    }
}
