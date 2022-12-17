using ProjectDesign.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDesign
{
    public partial class printUI : Form
    {
        Sales sale;
        public printUI()
        {
            InitializeComponent();
        }
        public printUI(Sales sale):this()
        {
            this.sale = sale;
        }
        private void txtResult_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();    
        }

        private void printUI_Load(object sender, EventArgs e)
        {
            txtResult.Text += "Sue Refreshment Receipt System";
            txtResult.Text += "Date:" + sale.TransDate + "\n\n";

            txtResult.Text += "Customer's Name: " + sale.CustomerName + "\n\n";
            txtResult.Text += "Products: " + sale.ProductName + "\n\n";
            txtResult.Text += "Available Quantity: " + sale.Quantity + "\n\n";
            txtResult.Text += "Price: " + sale.Price + "\n\n";
            txtResult.Text += "Total Amount: " + sale.TotalAmount + "\n\n";
            txtResult.Text += "Total Amount Paid: " + sale.AmountPaid + "\n\n";
        }
    }
}
