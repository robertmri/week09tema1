using InsertPublisher;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryBookApp
{
    public class BooksCrud : Connect
    {
        public static EnumerableRowCollection<DataRow> BooksPublishedIn2010()
        {
            string q_booksPublishedIn2010 = "SELECT * FROM Book WHERE YEAR = 2010";
            SqlCommand c_booksPublishedIn2010 = new SqlCommand(q_booksPublishedIn2010, week09con);
            SqlDataAdapter da_booksPublishedIn2010 = new SqlDataAdapter(c_booksPublishedIn2010);
            DataTable dt_booksPublishedIn2010 = new DataTable("Books published in 2010");
            da_booksPublishedIn2010.Fill(dt_booksPublishedIn2010);
            EnumerableRowCollection<DataRow> dr_booksPublishedIn2010 = dt_booksPublishedIn2010.AsEnumerable();
            return dr_booksPublishedIn2010;
        }

        public static EnumerableRowCollection<DataRow> BooksPublishedInMaxYear()
        {
            string q_booksPublishedInMaxYear = "SELECT * FROM Book WHERE Year = (SELECT Max(Year) FROM Book)";
            SqlCommand c_booksPublishedInMaxYear = new SqlCommand(q_booksPublishedInMaxYear, week09con);
            SqlDataAdapter da_booksPublishedInMaxYear = new SqlDataAdapter(c_booksPublishedInMaxYear);
            DataTable dt_booksPublishedInMaxYear = new DataTable("Books published in 2010");
            da_booksPublishedInMaxYear.Fill(dt_booksPublishedInMaxYear);
            EnumerableRowCollection<DataRow> dr_booksPublishedInMaxYear = dt_booksPublishedInMaxYear.AsEnumerable();
            return dr_booksPublishedInMaxYear;
        }

        public static EnumerableRowCollection<DataRow> GetTop10PBooks()
        {
            string selectString = "SELECT TOP 10 * FROM Book";
            SqlCommand getTop10PBooksCommand = new SqlCommand(selectString, week09con);
            SqlDataAdapter publisherDataAdapter = new SqlDataAdapter(getTop10PBooksCommand);
            DataTable publisherTable = new DataTable("Top 10 Book");
            publisherDataAdapter.Fill(publisherTable);

            EnumerableRowCollection<DataRow> tabledata = publisherTable.AsEnumerable();

            return tabledata;
        }
    }
}
