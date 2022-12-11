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
    public partial class ProductsUI : Form
    {
        public ProductsUI()
        {
            InitializeComponent();
        }

        private void ProductsUI_Load(object sender, EventArgs e)
        {

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
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
