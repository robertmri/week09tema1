using InsertPublisher;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudBookApp
{
    internal class IOHandler : Connect
    {
        public static void UpdateMenu(int bookId)
        {
            Console.WriteLine("1 - Update Title");
            Console.WriteLine("2 - Update Publisher");
            Console.WriteLine("3 - Update Year");
            Console.WriteLine("4 - Update Price");
            Console.WriteLine("5 - Back To Main Menu");
            ConsoleKeyInfo cki = Console.ReadKey(true);
            BookCrud.UpdateBook(bookId, cki);
        }

        public static void MainMenu()
        {
            
            Console.WriteLine("1 - Add a book");
            Console.WriteLine("2 - Print book info");
            Console.WriteLine("3 - Update book info");
            Console.WriteLine("4 - Delete book from database");
            Console.WriteLine("5 - Exit");

            ConsoleKeyInfo cki = Console.ReadKey(true);
            if (cki.Key.Equals(ConsoleKey.D1) || cki.Key.Equals(ConsoleKey.NumPad1))
            {
                Console.Clear();
                Console.WriteLine("Book Title: ");
                string title = Console.ReadLine();
                Console.WriteLine("PublisherId: ");
                int pId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Year: ");
                int year = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Price: ");
                int price = Convert.ToInt32(Console.ReadLine());
                BookCrud.InsertBook(title, pId, year, price);
                MainMenu();
            }

            else if (cki.Key.Equals(ConsoleKey.D2) || cki.Key.Equals(ConsoleKey.NumPad2))
            {
                Console.Clear();
                Console.WriteLine("Book Id:");
                int bId = Convert.ToInt32(Console.ReadLine());
                SqlParameter bookId = new SqlParameter { Value = bId, SqlDbType = SqlDbType.Int, ParameterName = "bookId" };
                EnumerableRowCollection<DataRow> bookInfo = BookCrud.ReadBook(bookId);

                foreach (DataRow row in bookInfo)
                {
                    Console.WriteLine($"Id: {row[0]}");
                    Console.WriteLine($"Title: {row[1]}");
                    Console.WriteLine($"Publisher: {row[2]}");
                    Console.WriteLine($"Year: {row[3]}");
                    Console.WriteLine($"Price: {row[4]}");
                }
                MainMenu();
            }

            else if (cki.Key.Equals(ConsoleKey.D3) || cki.Key.Equals(ConsoleKey.NumPad3))
            {
                Console.Clear();
                Console.WriteLine("Book Id:");
                int bId = Convert.ToInt32(Console.ReadLine());
                UpdateMenu(bId);
                MainMenu();
            }

            else if (cki.Key.Equals(ConsoleKey.D4) || cki.Key.Equals(ConsoleKey.NumPad4))
            {
                Console.WriteLine("Book Id:");
                int bId = Convert.ToInt32(Console.ReadLine());
                SqlParameter bookId = new SqlParameter { Value = bId, SqlDbType = SqlDbType.Int, ParameterName = "bookId" };
                BookCrud.DeleteBook(bookId);
                MainMenu();
            }

            else if (cki.Key.Equals(ConsoleKey.D5) || cki.Key.Equals(ConsoleKey.NumPad5))
            {
                Console.WriteLine("Program will now exit...");
                week09con.Close();
            }
            else
                MainMenu();
        }
    }
}
