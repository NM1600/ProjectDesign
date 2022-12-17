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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectDesign
{
    public partial class paymentUI : Form
    {
        Sales sale;
        List<Products> products;
        SqlConnection conn;
        SqlCommand cmd;
        public paymentUI()
        {
            InitializeComponent();

        }
        public paymentUI(Sales sale) : this()
        {
            btnSave.Text = "Update";
            this.sale = sale;

        }
        private void paymentUI_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(DBServer.ServerName);
            cmd = new SqlCommand();
            cmd.Connection = conn;
            LoadProducts();
            if (btnSave.Text == "Update")
                DisplayRecords();

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void DisplayRecords()
        {
            dtTransDate.Value = sale.TransDate;
            txtCustomerName.Text = sale.CustomerName;
            cboProducts.Text = sale.ProductName;
            txtAvailableQuantity.Text = (products[cboProducts.SelectedIndex].Quantity + sale.Quantity).ToString("n0");
            txtQuantity.Text = sale.Quantity.ToString("n0");
            txtAmountPaid.Text = sale.AmountPaid.ToString("n2");
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(txtQuantity.Text, out parsedValue))
            {
                MessageBox.Show("Quantity must be numeric.");
                return;
            }
            if (string.IsNullOrEmpty(txtCustomerName.Text) || string.IsNullOrEmpty(txtAmountPaid.Text))
            {
                MessageBox.Show("Empty Fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Convert.ToDecimal(txtAmountPaid.Text) < Convert.ToDecimal(txtTotalAmount.Text))
            {
                MessageBox.Show("Amountpaid must be equal or greaterthan TotalAmount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Sales data = GetData();
            string query = "";
            string msg = "Saved";
            if (btnSave.Text == "Save")
                query = $"insert into Sales VALUES(@TransDate,@CustomerName,@ProductId,@ProductName,@Price,@Quantity,@TotalAmount,@AmountPaid)";
            else
            {
                msg = "Updated";
                query = $"update Sales set TransDate=@TransDate, CustomerName=@CustomerName, ProductId=@ProductId, ProductName=@ProductName, Price=@Price, Quantity=@Quantity, TotalAmount=@TotalAmount, AmountPaid=@AmountPaid where ReceiptId='{sale.ReceiptId}'";
            }

            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@TransDate", data.TransDate);
            cmd.Parameters.AddWithValue("@CustomerName", data.CustomerName);
            cmd.Parameters.AddWithValue("@ProductId", data.ProductId);
            cmd.Parameters.AddWithValue("@ProductName", data.ProductName);
            cmd.Parameters.AddWithValue("@Price", data.Price);
            cmd.Parameters.AddWithValue("@Quantity", data.Quantity);
            cmd.Parameters.AddWithValue("@TotalAmount", data.TotalAmount);
            cmd.Parameters.AddWithValue("@AmountPaid", data.AmountPaid);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            UpdateInventory();
            MessageBox.Show("Successfully " + msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }
        private void UpdateInventory()
        {
            cmd.Parameters.Clear();
            string query = "";
            query = $"update Products set Quantity=@Quantity where ProductId='{products[cboProducts.SelectedIndex].ProductId}'";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(txtAvailableQuantity.Text));
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void LoadProducts()
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
            products.Add(new Products
            {
                ProductName = "NA"
            });
            cboProducts.DataSource = products;
            cboProducts.DisplayMember = "ProductName";
            cboProducts.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboProducts.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboProducts.Text = "NA";
        }

        private void cboProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPrice.Text = products[cboProducts.SelectedIndex].Price.ToString("n2");
            txtAvailableQuantity.Text = products[cboProducts.SelectedIndex].Quantity.ToString("n0");
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(txtQuantity.Text, out parsedValue))
                return;
            txtTotalAmount.Text = (Convert.ToDecimal(txtPrice.Text) * Convert.ToDecimal(txtQuantity.Text)).ToString("n2");
            if (btnSave.Text == "Save")
                txtAvailableQuantity.Text = (products[cboProducts.SelectedIndex].Quantity - Convert.ToDecimal(txtQuantity.Text)).ToString("n0");
            else
                txtAvailableQuantity.Text = (products[cboProducts.SelectedIndex].Quantity + sale.Quantity - Convert.ToDecimal(txtQuantity.Text)).ToString("n0");
        }
        private Sales GetData()
        {
            return new Sales
            {
                TransDate = dtTransDate.Value.Date,
                CustomerName = txtCustomerName.Text,
                ProductId = products[cboProducts.SelectedIndex].ProductId,
                ProductName = cboProducts.Text,
                Price = Convert.ToDecimal(txtPrice.Text),
                Quantity = Convert.ToInt32(txtQuantity.Text),
                TotalAmount = Convert.ToDecimal(txtTotalAmount.Text),
                AmountPaid = Convert.ToDecimal(txtAmountPaid.Text)
            };
        }

        private void txtTotalAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            txtResult.Clear();
            txtResult.Text += "               Sue Refreshment Receipt System\n";
            txtResult.Text += "----------------------------------------------------------\n";
            txtResult.Text += "Date: " + dtTransDate.Text + "\n\n";

            txtResult.Text += "Customer's Name: " + txtCustomerName.Text + "\n";
            txtResult.Text += "Products: " + cboProducts.Text + "\n";
            txtResult.Text += "Available Quantity: " + txtQuantity.Text + "\n";
            txtResult.Text += "Price: " + txtPrice.Text + "\n";
            txtResult.Text += "Total Amount " + txtTotalAmount.Text + "\n";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //printPreviewDialog.printDocument = printPayment
        }

        private void printPreviewDialog_Load(object sender, EventArgs e)
        {

        }

        private void txtResult_TextChanged(object sender, EventArgs e)
        {

        }
    }
 }

//        private void txtPrice_TextChanged(object sender, EventArgs e)
//        {

//        }
//    }
//}


