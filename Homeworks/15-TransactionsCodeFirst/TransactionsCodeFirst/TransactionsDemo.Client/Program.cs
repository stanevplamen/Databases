using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionsDemo.Model;
using TransactionsDemo.Data;
using TransactionsDemo.Data.Migrations;
using System.Data.SqlClient;
using System.Transactions;

namespace TransactionsDemo.Client
{
    public class Program
    {
        // private const string CONNECTION_STRING = "Server=.; " + "Database=Northwind; Integrated Security=true";
        public static CardAccount card01;
        public static CardAccount card02;

        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogSystemContext, Configuration>()); // set the migration strategu
            // making database
            try
            {
                InitializeDatabase();
                Console.WriteLine("Execution of data creation successful");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Execution error : {0}", ex.Message);
            }

            // providing transacrion deposit
            using(BlogSystemContext db = new BlogSystemContext())
            {
                using (TransactionScope transaction = new TransactionScope())
                //using (var transaction = new TransactionScope(
                //        TransactionScopeOption.RequiresNew,
                //        new TransactionOptions()
                //        {
                //            IsolationLevel = IsolationLevel.RepeatableRead
                //        }
                //    ))
                {
                    try 
	                {
                        Deposit(300m, db);
                        transaction.Complete();
                        Console.WriteLine("Transaction comitted.");
	                }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Execution transaction error : {0}", ex.Message);
                    }
                }
               
            }

            // providing transacrion withdraw
            using (BlogSystemContext db = new BlogSystemContext())
            {
                using (TransactionScope transaction = new TransactionScope())
                //using (var transaction = new TransactionScope(
                //        TransactionScopeOption.RequiresNew,
                //        new TransactionOptions()
                //        {
                //            IsolationLevel = IsolationLevel.RepeatableRead
                //        }
                //    ))
                {
                    try
                    {
                        Withdraw(1300m, db);
                        transaction.Complete();
                        Console.WriteLine("Transaction comitted.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Execution transaction error : {0}", ex.Message);
                    }
                }
            }
        }

        private static void Deposit(decimal money, BlogSystemContext db)
        {
            Console.WriteLine("Transaction deposit started.");
            CardAccount cardtmp = new CardAccount() { CardNumber = "1234567890", CardPin = "1234"};

            var card = (from c in db.CardAccounts
                        where c.CardNumber == cardtmp.CardNumber
                        select c).First();
            if (card == null)
            {
                throw new ArgumentException("Incorect Card number");
            }
            Console.WriteLine("Number verified!");

            if (card.CardPin != cardtmp.CardPin)
            {
                throw new ArgumentException("Incorect Pin");
            }
            Console.WriteLine("Pin verified!");

            if (money < 0)
            {
                throw new ArgumentException("The sum should be a positive number");
            }
            Console.WriteLine("Money verified!");

            card.CardCash = card.CardCash + money;
            try
            {
                CopyTransLog(money, card, db);
                Console.WriteLine("Log successful");
            }
            catch (Exception)
            {
                throw new ArgumentException("Log failed");
            }

            db.SaveChanges();
        }

        private static void Withdraw(decimal money, BlogSystemContext db)
        {
            Console.WriteLine("Transaction withdraw started.");
            CardAccount cardtmp = new CardAccount() { CardNumber = "1234567891", CardPin = "1234" };

            var card = (from c in db.CardAccounts
                        where c.CardNumber == cardtmp.CardNumber
                        select c).First();
            if (card == null)
            {
                throw new ArgumentException("Incorect Card number");
            }
            Console.WriteLine("Number verified!");

            if (card.CardPin != cardtmp.CardPin)
            {
                throw new ArgumentException("Incorect Pin");
            }
            Console.WriteLine("Pin verified!");
            if (money > card.CardCash)
            {
                throw new ArgumentException("Your credit is lower that the required sum");
            }
            if (money < 0)
            {
                throw new ArgumentException("The sum should be a positive number");
            }
            Console.WriteLine("Money verified!");

            card.CardCash = card.CardCash - money;

            try
            {
                CopyTransLog(money, card, db);
                Console.WriteLine("Log successful");
            }
            catch (Exception)
            {
               throw new ArgumentException("Log failed");
            }

            db.SaveChanges();
        }

        private static void CopyTransLog(decimal money, CardAccount card, BlogSystemContext db)
        {
            TransactionInfo newInfo = new TransactionInfo() { Ammount = money, CardAccount = card, CardAccountId = card.CardAccountID };
            db.TransactionInfos.Add(newInfo);

            TransactionHistory newHist = new TransactionHistory();
            newHist.TransactionsList.Add(newInfo);
            db.TransactionHistories.Add(newHist);
        }

        private static void InitializeDatabase()
        {
            var db = new BlogSystemContext();
            card01 = new CardAccount() { CardNumber = "1234567890", CardPin = "1234", CardCash = 10000m };
            card02 = new CardAccount() { CardNumber = "1234567891", CardPin = "1234", CardCash = 20000m };
            db.CardAccounts.Add(card01);
            db.CardAccounts.Add(card02);
            db.SaveChanges();
        }      
    }
}
