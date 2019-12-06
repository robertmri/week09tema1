using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace InsertPublisher
{
    public abstract class Connect
    {
        const string con = "Data Source=.;Initial Catalog=week09tema1;Integrated Security=True";

        public static SqlConnection week09con { get; } = new SqlConnection(con);
        
    }
}
