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
    public class DbSelected
    {
        static SqlConnection cnn = dbconnection.dbc();
        static SqlDataReader sqldr;

        public static User user(string emailAddress)
        {
            User user = new User();

            if (cnn.State == ConnectionState.Closed) cnn.Open();
            SqlCommand command = new SqlCommand(@"SELECT * FROM Users Where EmailAddress = @EmailAddress", cnn);
            command.Parameters.AddWithValue("@EmailAddress", emailAddress);
            sqldr = command.ExecuteReader();

            while (sqldr.Read())
            {
                user.UserId = Convert.ToInt32(sqldr["UserId"].ToString());
                user.FirstName = sqldr["FirstName"].ToString();
                user.LastName = sqldr["LastName"].ToString();
                user.EmailAddress = sqldr["EmailAddress"].ToString();
                user.Password = sqldr["Password"].ToString();
            }
            sqldr.Close();
            cnn.Close();

            return user;
        }
        public static List<Product> product()
        {
            List<Product> products = new List<Product>();

            if (cnn.State == ConnectionState.Closed) cnn.Open();
            SqlCommand command = new SqlCommand(@"SELECT * FROM Products", cnn);
            sqldr = command.ExecuteReader();

            while (sqldr.Read())
            {
                Product product = new Product();
                product.ProductId = Convert.ToInt32(sqldr["ProductId"].ToString());
                product.TotalPrice = Convert.ToDouble(sqldr["TotalPrice"].ToString());
                product.TotalCalorie = Convert.ToDouble(sqldr["TotalCalorie"].ToString());
                product.SellerPrice = Convert.ToDouble(sqldr["SellerPrice"].ToString());
                product.ProductName = sqldr["ProductName"].ToString();
                product.Contents = sqldr["Contents"].ToString();
                product.Recipe = sqldr["Recipe"].ToString();
                products.Add(product);
            }
            sqldr.Close();
            cnn.Close();

            return products;
        }
        public static Product product(string productName)
        {
            Product product = new Product();

            if (cnn.State == ConnectionState.Closed) cnn.Open();
            SqlCommand command = new SqlCommand(@"SELECT * FROM Products Where ProductName = @ProductName", cnn);
            command.Parameters.AddWithValue("@ProductName", productName);
            sqldr = command.ExecuteReader();

            while (sqldr.Read())
            {
                product.ProductId = Convert.ToInt32(sqldr["ProductId"].ToString());
                product.TotalPrice = Convert.ToDouble(sqldr["TotalPrice"].ToString());
                product.TotalCalorie = Convert.ToDouble(sqldr["TotalCalorie"].ToString());
                product.SellerPrice = Convert.ToDouble(sqldr["SellerPrice"].ToString());
                product.ProductName = sqldr["ProductName"].ToString();
                product.Contents = sqldr["Contents"].ToString();
                product.Recipe = sqldr["Recipe"].ToString();
            }
            sqldr.Close();
            cnn.Close();

            return product;
        }
        public static List<RawMaterial> rawMaterial()
        {
            List<RawMaterial> rawMaterials = new List<RawMaterial>();

            if (cnn.State == ConnectionState.Closed) cnn.Open();
            SqlCommand command = new SqlCommand(@"SELECT * FROM RawMaterials", cnn);
            sqldr = command.ExecuteReader();

            while (sqldr.Read())
            {
                RawMaterial rawMaterial = new RawMaterial();
                rawMaterial.RawMaterialId = Convert.ToInt32(sqldr["RawMaterialId"].ToString());
                rawMaterial.RawMaterialName = sqldr["RawMaterialName"].ToString();
                rawMaterial.Price = Convert.ToDouble(sqldr["Price"].ToString());
                rawMaterial.Calorie = Convert.ToDouble(sqldr["Calorie"].ToString());
                rawMaterial.MeasurementUnit = sqldr["MeasurementUnit"].ToString();

                rawMaterials.Add(rawMaterial);
            }
            sqldr.Close();
            cnn.Close();

            return rawMaterials;
        }
        public static RawMaterial rawMaterial(string Name)
        {
            RawMaterial rawMaterial = new RawMaterial();

            if (cnn.State == ConnectionState.Closed) cnn.Open();
            SqlCommand command = new SqlCommand(@"SELECT * FROM RawMaterials Where RawMaterialName = @RawMaterialName", cnn);
            command.Parameters.AddWithValue("@RawMaterialName", Name);
            sqldr = command.ExecuteReader();

            while (sqldr.Read())
            {
                rawMaterial.RawMaterialId = Convert.ToInt32(sqldr["RawMaterialId"].ToString());
                rawMaterial.RawMaterialName = sqldr["RawMaterialName"].ToString();
                rawMaterial.Price = Convert.ToDouble(sqldr["Price"].ToString());
                rawMaterial.Calorie = Convert.ToDouble(sqldr["Calorie"].ToString());
                rawMaterial.MeasurementUnit = sqldr["MeasurementUnit"].ToString();
            }
            sqldr.Close();
            cnn.Close();

            return rawMaterial;
        }
    }
}
