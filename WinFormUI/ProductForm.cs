using Database;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormUI
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }
        private void ProductForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void mnHammadde_Click(object sender, EventArgs e)
        {
            RawMaterialsForm form = new RawMaterialsForm();
            form.Show();
            this.Hide();
        }
        private void mnNewProduct_Click(object sender, EventArgs e)
        {
            NewProduct form = new NewProduct();
            form.Show();
            this.Hide();
        }
        private void mnSifreDegistir_Click(object sender, EventArgs e)
        {
            PasswordChange form = new PasswordChange();
            form.Show();
            this.Hide();
        }
        private void ProductForm_Load(object sender, EventArgs e)
        {
            dgwData.Rows.Clear();
            List<Product> products = DbSelected.product();
            foreach (var item in products)
            {
                dgwData.Rows.Add();
                int i = dgwData.Rows.Count - 1;
                dgwData.Rows[i].Cells[0].Value = item.ProductName;
                dgwData.Rows[i].Cells[1].Value = item.SellerPrice.ToString();
                dgwData.Rows[i].Cells[2].Value = item.TotalPrice.ToString();
            }
        }
        private void dgwData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwData.SelectedCells.Count > 0)
            {
                int rowIndex = dgwData.CurrentCell.RowIndex;
                string productName = dgwData.Rows[rowIndex].Cells[0].Value.ToString();

                Product product = DbSelected.product(productName);
                lblProductName.Text = product.ProductName;
                lblSalePrice.Text = product.SellerPrice.ToString();
                lblCost.Text = product.TotalPrice.ToString();
                lblTotalCalorie.Text = product.TotalCalorie.ToString();
                lblRecipe.Text = product.Recipe;

                dgwProduct.Top = lblRecipe.Top + lblRecipe.Height + 10;

                //Json datayı modele çevir ve datagridwiev e bas.

                dgwProduct.Rows.Clear();

                var contents = JsonConvert.DeserializeObject<List<RawMaterial>>(product.Contents);//Db de Json olarak tutulan datayı tekrar nesneye dönüştürüyoruz ve kullanıyoruz.

                foreach (var item in contents)
                {
                    dgwProduct.Rows.Add();
                    int i = dgwProduct.Rows.Count - 1;
                    dgwProduct.Rows[i].Cells[0].Value = item.RawMaterialName;
                    dgwProduct.Rows[i].Cells[1].Value = item.Price;
                    dgwProduct.Rows[i].Cells[2].Value = item.Calorie;
                    dgwProduct.Rows[i].Cells[3].Value = item.MeasurementUnit;
                }
            }
        }
    }
}
