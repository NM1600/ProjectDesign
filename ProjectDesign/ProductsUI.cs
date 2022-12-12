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
    public partial class ProductsUI : Form
    {
        List<Products> products;
        SqlConnection conn;
        SqlCommand cmd;
        public ProductsUI()
        {
            InitializeComponent();
        }

        private void ProductsUI_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(DBServer.ServerName);
            cmd = new SqlCommand();
            cmd.Connection = conn;
            FetchData();
        }
        private void FetchData()
        {
            string selectquery = "select * from Products";
            SqlDataAdapter adpt = new SqlDataAdapter(selectquery, conn);
            DataTable table = new DataTable();
            adpt.Fill(table);
            products = new List<Products>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Products product = new Products();
                product.ProductId = Convert.ToInt32(table.Rows[i]["ProductId"]);
                product.ProductName = Convert.ToString(table.Rows[i]["ProductName"]);
                product.Quantity = Convert.ToInt32(table.Rows[i]["Quantity"]);
                product.Cost = Convert.ToDecimal(table.Rows[i]["Cost"]);
                product.Price = Convert.ToDecimal(table.Rows[i]["Price"]);
                products.Add(product);
            }
            dtgRecords.DataSource = products;
        }
        private Products GetSelectedRow(DataGridViewRow row)
        {
            return new Products
            {
                ProductId = Convert.ToInt32(row.Cells["ProductId"].Value),
                ProductName = Convert.ToString(row.Cells["ProductName"].Value),
                Quantity = Convert.ToInt32(row.Cells["Quantity"].Value),
                Cost = Convert.ToDecimal(row.Cells["Cost"].Value),
                Price = Convert.ToDecimal(row.Cells["Price"].Value),
            };
        }
        private void button3_Click(object sender, EventArgs e)
        {
            new SevenUP().ShowDialog();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Sprite().ShowDialog();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            new AddProduct().ShowDialog();
            FetchData();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Products data = GetSelectedRow(dtgRecords.CurrentRow);
            DialogResult dialogResult = MessageBox.Show("Delete " + data.ProductName + "?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string query = $"Delete Products where ProductId='{data.ProductId}'";
                conn.Open();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Successfully Deleted.");
                FetchData();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Products data = GetSelectedRow(dtgRecords.CurrentRow);
            new AddProduct(data).ShowDialog();
            FetchData();
        }
    }
}
