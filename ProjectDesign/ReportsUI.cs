using ProjectDesign.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDesign
{
    public partial class ReportsUI : Form
    {
        List<Sales> sales;
        SqlConnection conn;
        SqlCommand cmd;
        public ReportsUI()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            FetchData();
            TotalSales();
        }

        private void ReportsUI_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(DBServer.ServerName);
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }
        private void FetchData()
        {
            string selectquery = $"select * from Sales where TransDate>='{dtFrom.Value.Date}' AND TransDate<='{dtTo.Value.Date}'";
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
        public void TotalSales()
        {
            lblTotalSale.Text = "TOTAL SALES : "+sales.Select(x => x.TotalAmount).Sum();
        }
    }
}
