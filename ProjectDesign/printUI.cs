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
            e.Graphics.DrawString(txtResult.Text,new Font("Microsoft Sans Serif",18,FontStyle.Bold),Brushes.Black,new Point(10,10));  
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();    
        }

        private void printUI_Load(object sender, EventArgs e)
        {
            txtResult.Text += "             Sue Refreshment Order Receipt\n";
            txtResult.Text += "-------------------------------------------------------\n\n";
            txtResult.Text += "Date: " + sale.TransDate.ToString("MM/dd/yyyy") + "\n";
            txtResult.Text += "Customer's Name: " + sale.CustomerName + "\n";
            txtResult.Text += "-------------------------------------------------------\n\n";
            txtResult.Text += "Product: " + sale.ProductName + "\n\n";
            txtResult.Text += "Quantity: " + sale.Quantity + "\n\n";
            txtResult.Text += "Price: ₱ " + sale.Price.ToString("n2") + "\n\n";
            txtResult.Text += "Total Amount: ₱ " + sale.TotalAmount.ToString("n2") + "\n\n";
            txtResult.Text += "Total Amount Paid: ₱ " + sale.AmountPaid.ToString("n2") + "\n\n";
            txtResult.Text += "Change: ₱ " + (sale.AmountPaid - sale.TotalAmount).ToString("n2") + "\n\n";
        }
    }
}
