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
    public class DbInsert
    {
        static SqlConnection cnn = dbconnection.dbc();
        public static void user(User user)
        {
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            SqlCommand command = new SqlCommand(@"Insert Into Users (FirstName, LastName, EmailAddress, Password) Values (@FirstName, @LastName, @EmailAddress, @Password)", cnn);
            command.Parameters.AddWithValue("@FirstName", user.FirstName);
            command.Parameters.AddWithValue("@LastName", user.LastName);
            command.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.ExecuteNonQuery();
            cnn.Close();
        }
        public static void product(Product product)
        {
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            SqlCommand command = new SqlCommand(@"Insert Into Products (ProductName, Contents, Recipe, TotalPrice, SellerPrice, TotalCalorie) Values (@ProductName, @Contents, @Recipe, @TotalPrice, @SellerPrice, @TotalCalorie)", cnn);
            command.Parameters.AddWithValue("@ProductName", product.ProductName);
            command.Parameters.AddWithValue("@Contents", product.Contents);
            command.Parameters.AddWithValue("@Recipe", product.Recipe);
            command.Parameters.AddWithValue("@TotalPrice", product.TotalPrice);
            command.Parameters.AddWithValue("@SellerPrice", product.SellerPrice);
            command.Parameters.AddWithValue("@TotalCalorie", product.TotalCalorie);
            command.ExecuteNonQuery();
            cnn.Close();
        }
        public static void rawMaterial(RawMaterial rawMaterial)
        {
            if (cnn.State == ConnectionState.Closed) cnn.Open();
            SqlCommand command = new SqlCommand(@"Insert Into RawMaterials (RawMaterialName, Price, Calorie, MeasurementUnit) Values (@RawMaterialName, @Price, @Calorie, @MeasurementUnit)", cnn);
            command.Parameters.AddWithValue("@RawMaterialName", rawMaterial.RawMaterialName);
            command.Parameters.AddWithValue("@Price", rawMaterial.Price);
            command.Parameters.AddWithValue("@Calorie", rawMaterial.Calorie);
            command.Parameters.AddWithValue("@MeasurementUnit", rawMaterial.MeasurementUnit);
            command.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
