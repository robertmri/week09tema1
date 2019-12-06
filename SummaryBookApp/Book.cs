using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryBookApp
{
    class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int PublisherId { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Book Id: {BookId}\n");
            sb.Append($"Title: {Title}\n");
            sb.Append($"Publisher Id: {PublisherId}\n");
            sb.Append($"Year: {Year}\n");
            sb.Append($"Price: {Price}\n");

            return sb.ToString();
        }
    }
}
