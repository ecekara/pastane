using Database;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WinFormUI
{
    public partial class NewProduct : Form
    {
        List<RawMaterial> rawMaterials;
        int buttonTop = 0;
        int txbTop = 0;
        int lblTop = 0;

        public NewProduct()
        {
            InitializeComponent();
        }
        private void NewProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProductForm form = new ProductForm();
            form.Show();
            this.Hide();
        }
        private void NewProduct_Load(object sender, EventArgs e)
        {
            dgwData.RowTemplate.Height = 30;//DatagridWiev de ki her bir satır yüksekliği
            buttonTop = btnSave.Top;
            txbTop = txbRecipe.Top;
            lblTop = label4.Top;

            rawMaterials = DbSelected.rawMaterial();
            foreach (var item in rawMaterials)
            {
                cbRawMaterials.Items.Add(item.RawMaterialName);
            }
        }
        void ObjectLocation()
        {
            int i = dgwData.Rows.Count - 1;
            int height = 55 + ((i + 1) * 30);
            dgwData.Height = height;
            label4.Top = lblTop + height - 40;
            txbRecipe.Top = txbTop + height - 40;
            btnSave.Top = buttonTop + height - 40;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Int64 mesurement = Convert.ToInt64(txbMesurement.Text);
            string mesurementUnit = mesurement.ToString() + " " + cbUnit.SelectedItem;
            RawMaterial rawMaterial = rawMaterials.Where(x => x.RawMaterialName == cbRawMaterials.SelectedItem.ToString()).FirstOrDefault();
            if (!String.IsNullOrEmpty(txbMesurement.Text) && !String.IsNullOrEmpty(cbUnit.SelectedItem.ToString()) && !String.IsNullOrEmpty(cbRawMaterials.SelectedItem.ToString()))
            {
                string[] rawMesurement = rawMaterial.MeasurementUnit.Split(' ');
                if (rawMesurement[1] == cbUnit.SelectedItem.ToString())
                {
                    int error = 0;
                    for (int ii = 0; ii < dgwData.Rows.Count; ii++)
                    {
                        if (dgwData.Rows[ii].Cells[1].Value.ToString() == rawMaterial.RawMaterialName.ToString())
                        {
                            error++;
                        }
                    }

                    var price = rawMaterial.Price * mesurement / Convert.ToInt64(rawMesurement[0]);
                    var calorie = rawMaterial.Calorie * mesurement / Convert.ToInt64(rawMesurement[0]);

                    if (error == 0)
                    {
                        dgwData.Rows.Add();
                        int i = dgwData.Rows.Count - 1;
                        ObjectLocation();

                        dgwData.Rows[i].Cells[0].Value = rawMaterial.RawMaterialId;
                        dgwData.Rows[i].Cells[1].Value = rawMaterial.RawMaterialName;
                        dgwData.Rows[i].Cells[2].Value = price;
                        dgwData.Rows[i].Cells[3].Value = calorie;
                        dgwData.Rows[i].Cells[4].Value = mesurementUnit;
                        dgwData.Rows[i].Cells[5].Value = "Row Delete";

                        txbMesurement.Text = null;
                    }
                    else
                    {
                        MessageBox.Show("You cannot record under an existing name.");
                    }
                }
                else
                {
                    MessageBox.Show("Units of measure cannot be different");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields.");
            }
        }
        private void dgwData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwData.SelectedCells.Count > 0)
            {
                int columnIndex = dgwData.CurrentCell.ColumnIndex;
                int rowIndex = dgwData.CurrentCell.RowIndex;
                string a = dgwData.Rows[rowIndex].Cells[columnIndex].Value.ToString();

                if (a == "Row Delete")
                {
                    dgwData.Rows.RemoveAt(rowIndex);
                    ObjectLocation();
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(txbProductName.Text) && !String.IsNullOrEmpty(txbSellerPrice.Text) && !String.IsNullOrEmpty(txbRecipe.Text))
            {
                if (dgwData.Rows.Count > 0)
                {
                    string productName = txbProductName.Text;
                    double totalPrice = 0;
                    double totalCalorie = 0;
                    double sellerPrice = Convert.ToDouble(txbSellerPrice.Text);
                    string recipe = txbRecipe.Text;

                    List<RawMaterial> rawMaterials = new List<RawMaterial>();
                    for (int i = 0; i < dgwData.Rows.Count; i++)
                    {
                        rawMaterials.Add(new RawMaterial { RawMaterialId = Convert.ToInt32(dgwData.Rows[i].Cells[0].Value.ToString()), RawMaterialName = dgwData.Rows[i].Cells[1].Value.ToString(), Price = Convert.ToDouble(dgwData.Rows[i].Cells[2].Value.ToString()), Calorie = Convert.ToDouble(dgwData.Rows[i].Cells[3].Value.ToString()), MeasurementUnit = dgwData.Rows[i].Cells[4].Value.ToString() });
                        totalPrice += Convert.ToDouble(dgwData.Rows[i].Cells[2].Value.ToString());
                        totalCalorie += Convert.ToDouble(dgwData.Rows[i].Cells[3].Value.ToString());
                    }

                    string contents = JsonConvert.SerializeObject(rawMaterials);
                    Product product = new Product
                    {
                        ProductName = productName,
                        Contents = contents,
                        Recipe = recipe,
                        SellerPrice = sellerPrice,
                        TotalPrice = totalPrice,
                        TotalCalorie = totalCalorie
                    };
                    DbInsert.product(product);

                    txbProductName.Text = null;
                    txbSellerPrice.Text = null;
                    txbRecipe.Text = null;
                    MessageBox.Show("Your recipe has been successfully saved");
                }
                else
                {
                    MessageBox.Show("You cannot cook without choosing raw materials.");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.");
            }
        }
    }
}
