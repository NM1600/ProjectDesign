using ProjectDesign.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDesign
{
    public partial class AddProduct : Form
    {
        Products product;
        SqlConnection conn;
        SqlCommand cmd;
        public AddProduct()
        {
            InitializeComponent();
        }
        public AddProduct(Products product):this()
        {
            btnSave.Text = "Update";
            this.product = product;
            DisplayRecords();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void DisplayRecords()
        {
            txtProductName.Text = product.ProductName;
            txtQuantity.Text = Convert.ToString(product.Quantity);
            txtCost.Text = Convert.ToString(product.Cost);
            txtPrice.Text = Convert.ToString(product.Price);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validators() == true)
            {
                MessageBox.Show("Empty Fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Products data = GetData();
            string query = "";
            string msg = "Saved";
            if (btnSave.Text == "Save")
                query = $"insert into Products VALUES(@ProductName,@Quantity,@Cost,@Price)";
            else
            {
                msg = "Updated";
                query = $"update Products set ProductName = @ProductName, Quantity = @Quantity, Cost = @Cost, Price = @Price where ProductId='{product.ProductId}'";
            }
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@ProductName", data.ProductName);
            cmd.Parameters.AddWithValue("@Quantity", data.Quantity);
            cmd.Parameters.AddWithValue("@Cost", data.Cost);
            cmd.Parameters.AddWithValue("@Price", data.Price);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Successfully " + msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }
        private bool Validators()
        {
            if (string.IsNullOrEmpty(txtProductName.Text) || string.IsNullOrEmpty(txtQuantity.Text) || string.IsNullOrEmpty(txtCost.Text) || string.IsNullOrEmpty(txtPrice.Text))
                return true;
            return false;
        }
        private void AddProduct_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(DBServer.ServerName);
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }

        private Products GetData()
        {
            return new Products
            {
                ProductName = txtProductName.Text,
                Quantity = Convert.ToInt32(txtQuantity.Text),
                Cost = Convert.ToDecimal(txtCost.Text),
                Price = Convert.ToDecimal(txtPrice.Text),
            };
        }
        
    }
}
