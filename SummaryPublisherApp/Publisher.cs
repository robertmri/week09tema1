using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryPublisherApp
{
    class Publisher
    {

        public int PublisherId { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Publisher Id: {PublisherId}\n");
            sb.Append($"Name: {Name}\n");

            return sb.ToString();
        }
    }
    
}
