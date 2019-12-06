using InsertPublisher;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryPublisherApp
{
    public class CRUDPublisher : Connect
    {
        public static int GetNumberOfRows()
        {
            week09con.Open();
            string selectString = "SELECT COUNT(*) FROM Publisher";
            SqlCommand fetchNumberOfRows = new SqlCommand(selectString, week09con);
            var numberOfRows = fetchNumberOfRows.ExecuteScalar();
            week09con.Close();
            return (int)numberOfRows;
        }

        public static EnumerableRowCollection<DataRow> GetTop10Publishers()
        {
            string selectString = "SELECT TOP 10 * FROM Publisher";
            SqlCommand getTop10PublishersCommand = new SqlCommand(selectString, week09con);
            SqlDataAdapter publisherDataAdapter = new SqlDataAdapter(getTop10PublishersCommand);
            DataTable publisherTable = new DataTable("Top 10 Publishers");
            publisherDataAdapter.Fill(publisherTable);

            EnumerableRowCollection<DataRow> tabledata = publisherTable.AsEnumerable();

            return tabledata;
        }

        public static EnumerableRowCollection<DataRow> NumberOfBooksPerPublisher()
        {
            string selectString = "SELECT Publisher.Name, Count(*) " +
                                    "FROM Publisher, Book " +
                                    "WHERE Publisher.PublisherId = Book.PublisherId " +
                                    "GROUP BY Publisher.Name; ";

            SqlCommand numberOfBooksPerPublisherCommand = new SqlCommand(selectString, week09con);
            SqlDataAdapter numberOfBooksPerPublisherAdapter = new SqlDataAdapter(numberOfBooksPerPublisherCommand);
            numberOfBooksPerPublisherAdapter.SelectCommand.Connection = week09con;

            DataTable numberOfBooksPerPublisherTable = new DataTable("Books Per Publisher");

            numberOfBooksPerPublisherAdapter.Fill(numberOfBooksPerPublisherTable);

            var tableData = numberOfBooksPerPublisherTable.AsEnumerable();

            return tableData;
        }

        public static dynamic TotalBookCostOfPublisher(int pId)
        {
            SqlParameter publisherId = new SqlParameter { Value = pId, ParameterName = "publisherId", DbType = DbType.Int32 };

            string selectString = "SELECT SUM(Book.Price) FROM Book " +
                                    "WHERE PublisherId = @publisherId";

            week09con.Open();
            SqlCommand totalBookCostOfPublisherCommand = new SqlCommand(selectString, week09con);
            totalBookCostOfPublisherCommand.Parameters.Add(publisherId);
            var numberOfBooks = totalBookCostOfPublisherCommand.ExecuteScalar();
            week09con.Close();
            return numberOfBooks;
        }
    }
}
