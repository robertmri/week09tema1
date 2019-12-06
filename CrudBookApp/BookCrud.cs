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
    internal class BookCrud : Connect
    {
        public static void InsertBook(string bTitle, int pId, int bYear, int bPrice)
        {

            string insertString = "INSERT INTO Book (Title, PublisherId, Year, Price) " +
                                  "VALUES (@bookTitle, @publisherId, @year, @price);" +
                                  "SELECT CAST(scope_identity() AS INT)";


            SqlCommand insertBook = new SqlCommand
            {
                Connection = week09con,
                CommandText = insertString
            };


            SqlParameter bookTitle = new SqlParameter { Value = bTitle, SqlDbType = SqlDbType.VarChar, ParameterName = "bookTitle" };
            SqlParameter bookPublisherId = new SqlParameter { Value = pId, SqlDbType = SqlDbType.Int, ParameterName = "publisherId" };
            SqlParameter bookYear = new SqlParameter { Value = bYear, SqlDbType = SqlDbType.Int, ParameterName = "year" };
            SqlParameter bookPrice = new SqlParameter { Value = bPrice, SqlDbType = SqlDbType.Int, ParameterName = "price" };


            insertBook.Parameters.Add(bookTitle);
            insertBook.Parameters.Add(bookPublisherId);
            insertBook.Parameters.Add(bookYear);
            insertBook.Parameters.Add(bookPrice);

            try
            {

                week09con.Open();

                var bkId = insertBook.ExecuteScalar();
                Console.WriteLine($"The book with id {bkId} has been successfully added", ConsoleColor.Green);
            }

            catch
            {

                Console.WriteLine("There is already a book with the same Id in the database");
            }

            finally
            {
                week09con.Close();
            }
        }

        private static void UpdateTitle(SqlParameter bookId)
        {
            Console.WriteLine("New book Title: ");
            string newBkTitle = Console.ReadLine();

            SqlParameter newBookTitle = new SqlParameter { Value = newBkTitle, SqlDbType = SqlDbType.VarChar, ParameterName = "newTitle" };
            string updateTitleString = "Update BOOK SET Title = @newTitle WHERE BookId = @bookId";
            SqlCommand updateTitleCommand = new SqlCommand(updateTitleString, week09con);
            updateTitleCommand.Parameters.Add(bookId);
            updateTitleCommand.Parameters.Add(newBookTitle);
            try
            {
                week09con.Open();
                updateTitleCommand.ExecuteNonQuery();
            }

            catch
            {
                Console.WriteLine("Invalid Book Id");
            }

            finally
            {
                week09con.Close();
            }
        }

        private static void UpdatePublisher(SqlParameter bookId)
        {
            Console.WriteLine("New Publisher Id: ");
            int newPbId = Convert.ToInt32(Console.ReadLine());

            SqlParameter newPublisherId = new SqlParameter { Value = newPbId, SqlDbType = SqlDbType.Int, ParameterName = "newPublisherId" };
            string updatePublisherIdString = "Update BOOK SET PublisherId = @newPublisherId WHERE BookId = @bookId";
            SqlCommand updatePublisherCommand = new SqlCommand(updatePublisherIdString, week09con);
            updatePublisherCommand.Parameters.Add(bookId);
            updatePublisherCommand.Parameters.Add(newPublisherId);
            try
            {
                week09con.Open();
                updatePublisherCommand.ExecuteNonQuery();
                Console.WriteLine($"Book price field for book id {bookId} Updated Successfully", ConsoleColor.Green);
            }

            catch
            {
                Console.WriteLine("Invalid Book Id");
            }

            finally
            {
                week09con.Close();
            }
        }

        private static void UpdateYear(SqlParameter bookId)
        {
            Console.WriteLine("New Year: ");
            int newBkYear = Convert.ToInt32(Console.ReadLine());

            SqlParameter newYear = new SqlParameter { Value = newBkYear, SqlDbType = SqlDbType.Int, ParameterName = "newYear" };
            string updateYearString = "Update BOOK SET Year = @newYear WHERE BookId = @bookId";
            SqlCommand updateYearCommand = new SqlCommand(updateYearString, week09con);
            updateYearCommand.Parameters.Add(bookId);
            updateYearCommand.Parameters.Add(newYear);
            try
            {
                week09con.Open();
                updateYearCommand.ExecuteNonQuery();
                Console.WriteLine($"Book year field for book id {bookId} Updated Successfully", ConsoleColor.Green);
            }

            catch
            {
                Console.WriteLine("Invalid Book Id");
            }

            finally
            {
                week09con.Close();
            }
        }

        private static void UpdatePrice(SqlParameter bookId)
        {
            Console.WriteLine("New Price: ");
            int newBkPrice = Convert.ToInt32(Console.ReadLine());

            SqlParameter newPrice = new SqlParameter { Value = newBkPrice, SqlDbType = SqlDbType.Int, ParameterName = "newPrice" };
            string updateYearString = "Update BOOK SET Price = @newPrice WHERE BookId = @bookId";
            SqlCommand updatePriceCommand = new SqlCommand(updateYearString, week09con);
            updatePriceCommand.Parameters.Add(bookId);
            updatePriceCommand.Parameters.Add(newPrice);
            try
            {
                week09con.Open();
                updatePriceCommand.ExecuteNonQuery();
                Console.WriteLine($"Book price field for book id {bookId} Updated Successfully", ConsoleColor.Green);
            }

            catch
            {
                Console.WriteLine("Invalid Book Id");
            }

            finally
            {
                week09con.Close();
            }
        }

        public static void UpdateBook(int bId, ConsoleKeyInfo cki)
        {
            SqlParameter bookId = new SqlParameter { Value = bId, SqlDbType = SqlDbType.Int, ParameterName = "bookId" };

            if (cki.Key.Equals(ConsoleKey.D1) || cki.Key.Equals(ConsoleKey.NumPad1))
            {
                UpdateTitle(bookId);
                UpdateMenu(bId);
            }

            else if (cki.Key.Equals(ConsoleKey.D2) || cki.Key.Equals(ConsoleKey.NumPad2))
            {
                UpdatePublisher(bookId);
                UpdateMenu(bId);
            }

            else if (cki.Key.Equals(ConsoleKey.D3) || cki.Key.Equals(ConsoleKey.NumPad3))
            {
                UpdateYear(bookId);
                UpdateMenu(bId);
            }

            else if (cki.Key.Equals(ConsoleKey.D4) || cki.Key.Equals(ConsoleKey.NumPad4))
            {
                UpdatePrice(bookId);
                UpdateMenu(bId);
            }

            else if (cki.Key.Equals(ConsoleKey.D5) || cki.Key.Equals(ConsoleKey.NumPad5))
            {
                return;
            }

            else
            {
                Console.WriteLine("Invalid menu option");
                UpdateMenu(bId);
            }
        }

        private static void UpdateMenu(int bId)
        {
            throw new NotImplementedException();
        }

        public static void DeleteBook(SqlParameter bookId)
        {
            string deleteString = "DELETE FROM Book WHERE BookId = @bookId";
            SqlCommand deleteCommand = new SqlCommand(deleteString, week09con);
            deleteCommand.Parameters.Add(bookId);
            try
            {
                week09con.Open();
                deleteCommand.ExecuteNonQuery();
                Console.WriteLine($"The book with the id {bookId.Value} has been removed from the database", ConsoleColor.Green);
            }

            catch
            {
                Console.WriteLine("Could not perform operation!");
            }

            finally
            {
                week09con.Close();
            }
        }

        public static EnumerableRowCollection<DataRow> ReadBook(SqlParameter bookId)
        {
            string selectString = "SELECT * FROM Book WHERE BookId = @bookId";
            SqlCommand selectCommand = new SqlCommand(selectString, week09con);
            selectCommand.Parameters.Add(bookId);

            SqlDataAdapter bookDataAdapter = new SqlDataAdapter(selectCommand);
            DataTable bookTable = new DataTable();
            bookDataAdapter.Fill(bookTable);

            EnumerableRowCollection<DataRow> tabledata = bookTable.AsEnumerable();

            return tabledata;
        }
    }
}
