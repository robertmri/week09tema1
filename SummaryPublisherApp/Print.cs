using InsertPublisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryPublisherApp
{
    class Print : Connect
    {
        public static void MainMenu()
        {

            Console.WriteLine("1 - Print Number Of Rows");
            Console.WriteLine("2 - Print Top 10 Publishers");
            Console.WriteLine("3 - Print Number Of Books Per Publisher");
            Console.WriteLine("4 - Print Total Book Cost For A Publisher");
            Console.WriteLine("5 - Exit");

            ConsoleKeyInfo cki = Console.ReadKey(true);
            if (cki.Key.Equals(ConsoleKey.D1) || cki.Key.Equals(ConsoleKey.NumPad1))
                PrintNumberOfRows();
            else if (cki.Key.Equals(ConsoleKey.D2) || cki.Key.Equals(ConsoleKey.NumPad2))
                PrintTop10Publishers();
            else if (cki.Key.Equals(ConsoleKey.D3) || cki.Key.Equals(ConsoleKey.NumPad3))
                PrintNumberOfBooksPerPublisher();
            else if (cki.Key.Equals(ConsoleKey.D4) || cki.Key.Equals(ConsoleKey.NumPad4))
                PrintTotalBookCostOfPublisher();
            else if (cki.Key.Equals(ConsoleKey.D5) || cki.Key.Equals(ConsoleKey.NumPad5))
            {
                Console.WriteLine("Program will now exit...");
                week09con.Close();
            }
            else
                MainMenu();
        }

        private static void PrintPublishers(List<Publisher> publishers)
        {
            foreach (Publisher publisher in publishers)
                Console.WriteLine(publisher);
        }

        private static void NumberOfBooksPerPublisher(List<NumberOfBooksPerPublisher> publishers)
        {
            foreach (NumberOfBooksPerPublisher numberofbooks in publishers)
                Console.WriteLine(numberofbooks);
        }

        private static void PrintNumberOfRows()
        {
            Console.Clear();
            Console.WriteLine($"Number of rows: {CRUDPublisher.GetNumberOfRows()}");
            MainMenu();
        }

        private static void PrintTop10Publishers()
        {
            List<Publisher> top10Publishers = new List<Publisher>();
            Console.Clear();
            top10Publishers.Fill(CRUDPublisher.GetTop10Publishers());
            PrintPublishers(top10Publishers);
            MainMenu();
        }

        private static void PrintNumberOfBooksPerPublisher()
        {
            List<NumberOfBooksPerPublisher> numberOfBooksPerPublisher = new List<NumberOfBooksPerPublisher>();
            Console.Clear();
            numberOfBooksPerPublisher.Fill(CRUDPublisher.NumberOfBooksPerPublisher());
            NumberOfBooksPerPublisher(numberOfBooksPerPublisher);
            MainMenu();
        }

        private static void PrintTotalBookCostOfPublisher()
        {
            Console.WriteLine("Publisher Id:");
            int pId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(CRUDPublisher.TotalBookCostOfPublisher(pId));
            MainMenu();
        }
    } 
   
}
