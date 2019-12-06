using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryBookApp
{
    static class BookListExt
    {
        public static void Fill(this List<Book> @this, EnumerableRowCollection<DataRow> tableData)
        {
            foreach (DataRow book in tableData)
                @this.Add(
                    new Book
                    {
                        BookId = (int)book[0],
                        Title = book[1] as string,
                        PublisherId = (int)book[2],
                        Year = (int)book[3],
                        Price = (decimal)book[4]
                    });
        }
    }
}
