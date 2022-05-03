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

namespace WinFormUI
{
    public partial class RawMaterialsForm : Form
    {
        public RawMaterialsForm()
        {
            InitializeComponent();
        }
        void RawMaterialRead()
        {
            dgwData.Rows.Clear();

            List<RawMaterial> rawMaterials = DbSelected.rawMaterial();

            foreach (var item in rawMaterials)
            {
                dgwData.Rows.Add();
                int i = dgwData.Rows.Count - 1;
                dgwData.Rows[i].Cells[0].Value = item.RawMaterialId.ToString();
                dgwData.Rows[i].Cells[1].Value = item.RawMaterialName.ToString();
                dgwData.Rows[i].Cells[2].Value = item.Price.ToString();
                dgwData.Rows[i].Cells[3].Value = item.Calorie.ToString();
                dgwData.Rows[i].Cells[4].Value = item.MeasurementUnit.ToString();
            }
        }
        private void RawMaterialsForm_Load(object sender, EventArgs e)
        {
            RawMaterialRead();
            cbUnit.SelectedIndex = 0;
        }
        private void RawMaterialsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProductForm form = new ProductForm();
            form.Show();
            this.Hide();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string rawMaterialName = txbName.Text;
                double rawMaterialPrice = Convert.ToDouble(txbPrice.Text);
                double rawMaterialCalorie = Convert.ToDouble(txbCalorie.Text);
                string rawMaterialMesurement = txbMesurement.Text + " " + cbUnit.SelectedItem;

                if(!String.IsNullOrEmpty(rawMaterialName) && !String.IsNullOrEmpty(txbMesurement.Text) && !String.IsNullOrEmpty(cbUnit.SelectedItem.ToString()))
                {
                    RawMaterial rawMaterial = new RawMaterial { RawMaterialName = rawMaterialName, Price = rawMaterialPrice, Calorie = rawMaterialCalorie, MeasurementUnit = rawMaterialMesurement };

                    var rm = DbSelected.rawMaterial(rawMaterialName);
                    if(rm.RawMaterialId == 0)
                    {
                        DbInsert.rawMaterial(rawMaterial);

                        txbName.Text = null;
                        txbPrice.Text = null;
                        txbCalorie.Text = null;
                        txbMesurement.Text = null;
                        RawMaterialRead();
                        MessageBox.Show("Raw material has been successfully saved.");
                    }
                    else
                    {
                        MessageBox.Show("You cannot record under an existing name.");
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in all fields.");
                }
            }
            catch
            {
                MessageBox.Show("I am detecting an error. Please check the entered values or contact the system administrator.");
            }
        }
    }
}
