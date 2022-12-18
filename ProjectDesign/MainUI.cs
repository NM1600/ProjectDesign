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
    public partial class MainUI : Form
    {
        //int PW;
        //bool Hided;
        bool isLoggedIn = false;
        bool sidebarpanelExpand = true;
        //private object sidebarpanel;
        //private object Width;
        public MainUI()
        {
            InitializeComponent();

            new LoginUI(this).ShowDialog();
            
        }

        public void SetIsLoggedIn(bool isLoggedIn, string userType)
        {
            this.isLoggedIn = isLoggedIn;
            if (userType != "admin")
            {
                CreateUserBtn.Visible = false;
                btnSales.Visible = false;
                reportsbtn.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void MainUI_Load_1(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Hide the logo
            //Slide the Panel 
            // 
        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel26_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MENUbutton_Click(object sender, EventArgs e)
        {
        }
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {

        }

        private void siderbarpanel_tick(object sender, EventArgs e)
        {

        }

        private void MainUI_Load_2(object sender, EventArgs e)
        {
            if (isLoggedIn == false)
                this.Close();
            StartPanel();
    
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            FormSelect("home");
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            FormSelect("profile");
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            FormSelect("products");

        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            FormSelect("sales");

        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            FormSelect("reports");

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {

        }
        public void FormSelect(string formName)
        {
            if (formName == "home")
            {

                HomeUI mdiHomeUI = new HomeUI();
                mdiHomeUI.MdiParent = this;
                mdiHomeUI.Show();

            }
            if (formName == "profile")
            {
                ProfileUI mdiProfileUI = new ProfileUI();
                mdiProfileUI.MdiParent = this;
                mdiProfileUI.Show();
            }
            if (formName == "user")
            {
                CreateUser mdiCreateUser = new CreateUser();
                mdiCreateUser.MdiParent = this;
                mdiCreateUser.Show();
            }
            if (formName == "products")
            {
                ProductsUI mdiProductsUI = new ProductsUI();
                mdiProductsUI.MdiParent = this;
                mdiProductsUI.Show();
            }
            if (formName == "sales")
            {
                SalesUI mdiSalesUI = new SalesUI();
                mdiSalesUI.MdiParent = this;
                mdiSalesUI.Show();
            }
            if (formName == "reports")
            {
                ReportsUI mdiReportsUI = new ReportsUI();
                mdiReportsUI.MdiParent = this;
                mdiReportsUI.Show();
            }
            if (formName == "home")
            {
                MainUI mdiMainUI = new MainUI();
                mdiMainUI.MdiParent = this;
                mdiMainUI.Show();
            }
        }

        private void MainUI_Click(object sender, EventArgs e)
        {

        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {

            StartPanel();
        }
        decimal i = 0;
        public void StartPanel()
        {
            timer1.Start();
            if (i % 2 == 0)
            {
                sidebarpanelExpand = true;
            }
            else
            {
                sidebarpanelExpand = false;
            }
            i++;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sidebarpanelExpand)
            {
                siderbarpanel.Width -= 200;
                if (siderbarpanel.Width == siderbarpanel.MinimumSize.Width)
                {
                    sidebarpanelExpand = false;
                    timer1.Stop();
                }
            }
            else
            {
                siderbarpanel.Width += 200;
                if (siderbarpanel.Width == siderbarpanel.MaximumSize.Width)
                {
                    sidebarpanelExpand = true;
                    timer1.Stop();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            
        }

        private void btnHome_Click_2(object sender, EventArgs e)
        {
            
        }

        private void CreateUserBtn_Click(object sender, EventArgs e)
        {
            FormSelect("user");

        }

       

        private void button2_Click_1(object sender, EventArgs e)
        {
            FormSelect("reports");
  
        }

        private void btnSignout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to Logout?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Dispose();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }
    }
}








