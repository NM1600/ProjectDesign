using ProjectDesign.Classes;
using System;
using System.Collections;
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
    public partial class SalesUI : Form
    {
        List<Sales> sales;
        SqlConnection conn;
        SqlCommand cmd;
        public SalesUI()
        {
            InitializeComponent();
        }

        private void ButtonTransaction_Click(object sender, EventArgs e)
        {
            new paymentUI().ShowDialog();
            FetchData();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            new paymentUI().ShowDialog();
            FetchData();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private Sales GetSelectedRow(DataGridViewRow row)
        {
            return new Sales
            {
                ReceiptId = Convert.ToInt32(row.Cells["ReceiptId"].Value),
                TransDate = Convert.ToDateTime(row.Cells["TransDate"].Value),
                CustomerName = Convert.ToString(row.Cells["CustomerName"].Value),
                ProductId = Convert.ToInt32(row.Cells["ProductId"].Value),
                ProductName = Convert.ToString(row.Cells["ProductName"].Value),
                Price = Convert.ToDecimal(row.Cells["Price"].Value),
                Quantity = Convert.ToInt32(row.Cells["Quantity"].Value),
                TotalAmount = Convert.ToDecimal(row.Cells["TotalAmount"].Value),
                AmountPaid = Convert.ToDecimal(row.Cells["AmountPaid"].Value),
            };
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Sales data = GetSelectedRow(dtgRecords.CurrentRow);
            new paymentUI(data).ShowDialog();
            FetchData();
        }

        private void SalesUI_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(DBServer.ServerName);
            cmd = new SqlCommand();
            cmd.Connection = conn;
            FetchData();
        }
        private void FetchData()
        {
            string selectquery = "select * from Sales";
            SqlDataAdapter adpt = new SqlDataAdapter(selectquery, conn);
            DataTable table = new DataTable();
            adpt.Fill(table);
            sales = new List<Sales>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Sales sale = new Sales();
                sale.ReceiptId = Convert.ToInt32(table.Rows[i]["ReceiptId"]);
                sale.TransDate = Convert.ToDateTime(table.Rows[i]["TransDate"]);
                sale.CustomerName = Convert.ToString(table.Rows[i]["CustomerName"]);
                sale.ProductId = Convert.ToInt32(table.Rows[i]["ProductId"]);
                sale.ProductName = Convert.ToString(table.Rows[i]["ProductName"]);
                sale.Price = Convert.ToDecimal(table.Rows[i]["Price"]);
                sale.Quantity = Convert.ToInt32(table.Rows[i]["Quantity"]);
                sale.TotalAmount = Convert.ToDecimal(table.Rows[i]["TotalAmount"]);
                sale.AmountPaid = Convert.ToDecimal(table.Rows[i]["AmountPaid"]);
                sales.Add(sale);
            }
            dtgRecords.DataSource = sales;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sales data = GetSelectedRow(dtgRecords.CurrentRow);
            DialogResult dialogResult = MessageBox.Show("Delete " + data.CustomerName + "?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string query = $"Delete Sales where ReceiptId='{data.ReceiptId}'";
                conn.Open();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Successfully Deleted.");
                GetInventory(data);
                FetchData();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }
        private void GetInventory(Sales data)
        {
            string query = $"select * from Products where ProductId='{data.ProductId}'";
            SqlDataAdapter adpt = new SqlDataAdapter(query, conn);
            DataTable table = new DataTable();
            adpt.Fill(table);
            Products prod = new Products();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                prod.ProductId = Convert.ToInt32(table.Rows[i]["ProductId"]);
                prod.ProductName = Convert.ToString(table.Rows[i]["ProductName"]);
                prod.Price = Convert.ToDecimal(table.Rows[i]["Price"]);
                prod.Quantity = Convert.ToInt32(table.Rows[i]["Quantity"]);
            }
            decimal quantity = prod.Quantity+data.Quantity;
            UpdateInventory(prod,quantity);
        }
        private void UpdateInventory(Products data,decimal quantity)
        {
            cmd.Parameters.Clear();
            string query = "";
            query = $"update Products set Quantity=@Quantity where ProductId='{data.ProductId}'";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@Quantity", quantity);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
}
