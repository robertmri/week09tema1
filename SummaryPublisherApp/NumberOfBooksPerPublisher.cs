using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryPublisherApp
{
    class NumberOfBooksPerPublisher
    {
        public int NoOfBooks { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name: {Name}\n");
            sb.Append($"Number of Books: {NoOfBooks}\n");
            return sb.ToString();
        }
    }
}
