using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class DbUpdate
    {
        static SqlConnection cnn = dbconnection.dbc();

        public static void user(User user)
        {
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            SqlCommand command = new SqlCommand(@"Update Users Set Password = @Password Where EmailAddress = @EmailAddress", cnn);
            command.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.ExecuteNonQuery();
            cnn.Close();
        }
        public static Product product()
        {
            return null;
        }
        public static RawMaterial rawMaterial()
        {
            return null;
        }
    }
}
