
using System.Data;
using System.Data.SqlClient;

namespace Database
{
    public class dbconnection
    {
        public static SqlConnection dbc()
        {
            SqlConnection connection = new SqlConnection(@"Server=ADMINISTRATOR;Database=Pastane;Trusted_Connection=True;");
            try { if (connection.State == ConnectionState.Closed) connection.Open(); } catch { connection.Close(); }
            return connection;
        }
    }
}
