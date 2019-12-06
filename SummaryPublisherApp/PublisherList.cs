using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryPublisherApp
{
    internal static class PublisherList
    {
       
        internal static void Fill(this List<Publisher> @this, EnumerableRowCollection<DataRow> tableData)
        {
            foreach (DataRow publisher in tableData)
                @this.Add(
                    new Publisher
                    {
                        PublisherId = (int)publisher[0],
                        Name = publisher[1] as string,
                    });
        }

        internal static void Fill(this List<NumberOfBooksPerPublisher> @this, EnumerableRowCollection<DataRow> tableData)
        {
            foreach (DataRow publisher in tableData)
                @this.Add(
                    new NumberOfBooksPerPublisher
                    {
                        NoOfBooks = (int)publisher[1],
                        Name = publisher[0] as string,
                    });
        }
    }
}
