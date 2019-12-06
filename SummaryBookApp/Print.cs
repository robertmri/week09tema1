using InsertPublisher;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryBookApp
{
    internal class Print : Connect
    {
        public static void PrintBooks(List<Book> books)
        {
            foreach (Book book in books)
                Console.WriteLine(book);
        }

        public static void MainMenu()
        {

            Console.WriteLine("1 - Print Books Published In 2010");
            Console.WriteLine("2 - Print Books Published in Max Year");
            Console.WriteLine("3 - Print Top 10 Books");
            Console.WriteLine("4 - Exit");

            ConsoleKeyInfo cki = Console.ReadKey(true);
            if (cki.Key.Equals(ConsoleKey.D1) || cki.Key.Equals(ConsoleKey.NumPad1))
                PrintBooksPublishedIn2010(BooksCrud.BooksPublishedIn2010());
            else if (cki.Key.Equals(ConsoleKey.D2) || cki.Key.Equals(ConsoleKey.NumPad2))
                PrintBookMaxYear(BooksCrud.BooksPublishedInMaxYear());
            else if (cki.Key.Equals(ConsoleKey.D3) || cki.Key.Equals(ConsoleKey.NumPad3))
                PrintTop10Books(BooksCrud.GetTop10PBooks());
            else if (cki.Key.Equals(ConsoleKey.D4) || cki.Key.Equals(ConsoleKey.NumPad4))
            {
                Console.WriteLine("Program will now exit...");
                week09con.Close();
            }
            else
                MainMenu();
        }

        public static void PrintBookMaxYear(EnumerableRowCollection<DataRow> dr_booksMaxYear)
        {
            Console.Clear();
            List<Book> publishedInMaxYear = new List<Book>();
            publishedInMaxYear.Fill(dr_booksMaxYear);
            if (publishedInMaxYear.Count > 0)
                PrintBooks(publishedInMaxYear);
            MainMenu();
        }

        public static void PrintBooksPublishedIn2010(EnumerableRowCollection<DataRow> dr_booksPublishedIn2010)
        {
            Console.Clear();
            List<Book> publishedIn2010 = new List<Book>();
            publishedIn2010.Fill(dr_booksPublishedIn2010);
            if (publishedIn2010.Count > 0)
                PrintBooks(publishedIn2010);
            MainMenu();
        }

        public static void PrintTop10Books(EnumerableRowCollection<DataRow> dr_top10Books)
        {
            List<Book> top10Books = new List<Book>();
            Console.Clear();
            top10Books.Fill(dr_top10Books);
            if (top10Books.Count > 0)
                PrintBooks(top10Books);
            MainMenu();
        }
    }
}
