﻿using ProjectDesign.Classes;
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
            txtResult.Text += "Sue Refreshment Receipt System";
            txtResult.Text += "Date:" + sale.TransDate.ToString("MM/dd/yyyy") + "\n\n";

            txtResult.Text += "Customer's Name: " + sale.CustomerName + "\n\n";
            txtResult.Text += "Products: " + sale.ProductName + "\n\n";
            txtResult.Text += "Available Quantity: " + sale.Quantity + "\n\n";
            txtResult.Text += "Price: PHP" + sale.Price.ToString("n2") + "\n\n";
            txtResult.Text += "Total Amount: PHP " + sale.TotalAmount.ToString("n2") + "\n\n";
            txtResult.Text += "Total Amount Paid: PHP " + sale.AmountPaid.ToString("n2") + "\n\n";
            txtResult.Text += "Change: PHP " + (sale.AmountPaid - sale.TotalAmount).ToString("n2") + "\n\n";
        }
    }
}
