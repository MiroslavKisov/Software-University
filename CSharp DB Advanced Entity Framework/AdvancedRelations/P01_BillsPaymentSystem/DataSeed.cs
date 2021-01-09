using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Data.Models;
using P01_BillsPaymentSystem.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01_BillsPaymentSystem
{
    public class DataSeed
    {
        private const int userSeedRange = 21;
        private const int creditCardSeedRange = 60;
        private const int bankAccountSeedRange = 60;
        private const int paymentMethodSeedRange = 84;

        private Random random;

        public DataSeed()
        {
            this.random = new Random();
        }

        private string[] firstNames =
        {
            "Gosho",
            "Tosho",
            "Pesho",
            "Ivan",
            "Maria",
            "Gabriela",
            "Teodora",
            "Martin",
            "Dimitur",
            "Robert",
            "Jim",
            "Sarah",
            "Stefani",
            "Yoda",
            "Donald",
            "Albert",
            "Ricardo",
            "Wesley",
            "Jill",
            "Jenna",
            "Jonh",
        };

        private string[] lastNames =
        {
            "Ivanov",
            "Drago",
            "Marciano",
            "Al Sahib",
            "De Niro",
            "Pacino",
            "Carrey",
            "Smith",
            "Timbers",
            "Staton",
            "Sanchez",
            "Williams",
            "Stone",
            "Earp",
            "Dixon",
            "Einstein",
            "Todd",
            "Foreman",
            "Da Silva",
            "Cobb",
            "McTavish",
        };

        private string[] emails =
        {
            "Ivanov@abv.bg",
            "Drago@abv.bg",
            "Marciano@abv.bg",
            "Sahib@abv.bg",
            "De_Niro@abv.bg",
            "Pacino@abv.bg",
            "Carrey@abv.bg",
            "Smith@abv.bg",
            "Jameson@abv.bg",
            "Staton@abv.bg",
            "Sanchez@abv.bg",
            "Williams@abv.bg",
        };

        private string[] passwords =
        {
            "alabala23",
            "peshoelud",
            "obichamspageti",
            "!!givethelight!!",
            "Chronic_Weed",
            "BeNice:D",
            "ManyynaM",
            "000000000000",
            "1234554321",
            "StayTrue999",
            "Martinezzzz",
            "BatmanStinks",
        };

        private decimal[] creditCardLimits =
        {
            1600.00m,
            122500.00m,
            200.00m,
            75200.00m,
            4200.00m,
            9212.00m,
            6100.00m,
            7770.00m,
            231200.00m,
            581200.00m,
            64400.00m,
            97400.00m,
        };

        private decimal[] moneyOwed =
        {
            256.00m,
            75000.00m,
            120.00m,
            8000.00m,
            1234.00m,
            560.00m,
            9213.00m,
            2000.00m,
            1530.00m,
            1204.00m,
            5000.00m,
            3600.00m,
        };

        private decimal[] balance =
        {
            479.00m,
            12345.00m,
            8734.00m,
            1205.00m,
            6849.00m,
            1129.00m,
            8553.00m,
            9042.00m,
            1458.00m,
            1568.00m,
            723.00m,
            5247.00m,
        };

        private string[] bankName =
        {
            "Bank Of Europe",
            "Bank Of America",
            "JP Morgan",
            "Bank of Dubai",
            "CCB Bank",
            "UBB",
            "First Private Bank",
            "Bank Of Sofia",
            "The Most Cool Bank Ever",
            "Poor Peoples Bank",
            "The Bank Of All Banks",
            "Just Bank It",
        };

        private string[] swiftCode =
        {
            "BGNBGSF999",
            "BGNEURF999",
            "USABGSF999",
            "JPNBGSF999",
            "BGNBGSF999",
            "FDNBVCS999",
            "QWERTYU999",
            "WASDPOI999",
            "SQLPOTF999",
            "MGMGNDS999",
            "GTREQCG999",
            "PLKFGHA999",
        };

        private int[] userIndexes =
        {
            1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3,
            4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6,
            7, 7, 7, 7, 8, 8, 8, 8, 9, 9, 9, 9,
            10, 10, 10, 10, 11, 11, 11, 11, 12,
            12, 12, 12, 13, 13, 13, 13, 14, 14,
            14, 14, 15, 15, 15, 15, 16, 16, 16,
            16, 17, 17, 17, 17, 18, 18, 18, 18,
            19, 19, 19, 19, 20, 20, 20, 20, 21,
            21, 21, 21
        };

        public void Seed(BillsPaymentSystemContext paymentSystemContext)
        {
            InsertUsersInfo(paymentSystemContext);
            InsertBankAccountsInfo(paymentSystemContext);
            InsertCreditCardsInfo(paymentSystemContext);
            InsertPaymentMethodsInfo(paymentSystemContext);
        }

        private void InsertUsersInfo(BillsPaymentSystemContext paymentSystemContext)
        {
            try
            {
                for (int i = 0; i < userSeedRange; i++)
                {
                    var users = paymentSystemContext.Set<User>();
                    users.Add(new User()
                    {
                        FirstName = this.firstNames[random.Next(0, 21)],
                        LastName = this.lastNames[random.Next(0, 21)],
                        Email = this.emails[random.Next(0, 12)],
                        Password = this.passwords[random.Next(0, 12)]
                    });
                }

                paymentSystemContext.SaveChanges();
                Console.WriteLine($"{nameof(User)} data inserted succcessfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void InsertCreditCardsInfo(BillsPaymentSystemContext paymentSystemContext)
        {
            try
            {
                for (int i = 0; i < creditCardSeedRange; i++)
                {
                    var userCreditCards = paymentSystemContext.Set<CreditCard>();
                    userCreditCards.Add(new CreditCard(this.creditCardLimits[random.Next(0, 12)], this.moneyOwed[random.Next(0, 12)], DateTime.Now));                
                }

                paymentSystemContext.SaveChanges();
                Console.WriteLine($"{nameof(CreditCard)} data inserted succcessfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void InsertBankAccountsInfo(BillsPaymentSystemContext paymentSystemContext)
        {
            try
            {
                for (int i = 0; i < bankAccountSeedRange; i++)
                {
                    var userBankAccounts = paymentSystemContext.Set<BankAccount>();
                    userBankAccounts.Add(new BankAccount(this.balance[random.Next(0, 12)], this.bankName[random.Next(0, 12)], this.swiftCode[random.Next(0, 12)]));
                }

                paymentSystemContext.SaveChanges();
                Console.WriteLine($"{nameof(BankAccount)} data inserted succcessfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void InsertPaymentMethodsInfo(BillsPaymentSystemContext paymentSystemContext)
        {
            bool isAccount = true;
            int bankAccId = 1;
            int cardId = 1;

            try
            {
                for (int i = 0; i < paymentMethodSeedRange; i++)
                {
                    if (isAccount)
                    {
                        var userPaymentMethods = paymentSystemContext.Set<PaymentMethod>();
                        userPaymentMethods.Add(new PaymentMethod()
                        {
                            BankAccountId = bankAccId++,
                            CreditCardId = null,
                            Type = PaymentMethodType.BankAccount,
                            UserId = userIndexes[i],
                        });

                        isAccount = false;
                    }

                    else if (!isAccount)
                    {
                        var userPaymentMethods = paymentSystemContext.Set<PaymentMethod>();
                        userPaymentMethods.Add(new PaymentMethod()
                        {
                            BankAccountId = null,
                            CreditCardId = cardId++,
                            Type = PaymentMethodType.CreditCard,
                            UserId = userIndexes[i],
                        });

                        isAccount = true;
                    }
                }

                paymentSystemContext.SaveChanges();
                Console.WriteLine($"{nameof(BankAccount)} data inserted succcessfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
