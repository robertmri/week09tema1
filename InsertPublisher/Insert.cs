using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InsertPublisher
{
    class Insert : Connect
    {
        public static void InsertPublisher (int pId,string pName)
        {
            string insertString = "SET IDENTITY_INSERT dbo.Publisher ON;" +
                                  "INSERT INTO Publisher (PublisherId, Name) " +
                                  "VALUES (@publisherId, @publisherName);" +
                                  "SELECT CAST(scope_identity() AS INT)";

            SqlCommand insertPublisher = new SqlCommand
            {
                Connection = week09con,
                CommandText = insertString
            };

            SqlParameter publisherId = new SqlParameter { Value = pId, SqlDbType = System.Data.SqlDbType.Int, ParameterName = "publisherId" };
            SqlParameter publisherName = new SqlParameter { Value = pName, SqlDbType = System.Data.SqlDbType.VarChar, ParameterName = "publisherName" };

            insertPublisher.Parameters.Add(publisherId);
            insertPublisher.Parameters.Add(publisherName);

            try
            {
                week09con.Open();

                var pubId = insertPublisher.ExecuteScalar();
                Console.WriteLine($"Publisher with Id {pubId} has been successfully added", ConsoleColor.Green);

            }
            catch
            {
                Console.WriteLine("There is already a publisher with the same Id in the database");
            }
            finally
            {
                week09con.Close();
            }
        }

    }
}
