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
        bool sidebarpanelExpand = true;
        //private object sidebarpanel;
        //private object Width;
        public MainUI()
        {
            InitializeComponent();
            //panelLeft.Height = btnHome.Height;
            //panelLeft.Top = btnHome.Top;

            new LoginUI().ShowDialog();
        }

        private void MainUI_Load(object sender, EventArgs e)
        {
            
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

            //if (sidemenu.Width == 50)
            //{
            //    sidemenu.Visible = false;
            //    sidemenu.Width = 260;
            //    PanelAnimator.ShowSync(sidemenu);
            //    LogoAnimator.ShowSync(logo);
            //}
        }
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {

        }

        private void siderbarpanel_tick(object sender, EventArgs e)
        {
            //            if (sidebarpanelExpand)
            //            {
            //                //If sidebar is expand, minimize
            //                sidebarpanel.Width -= 10;
            //                if (sidebarpanel.Width-- sidebarpanel.MinSize.Width)
            //                        { 

            //                }

            //            {
            //                    sidebarpanelExpand = false;
            //                    sidePanelTimer.Stop();
            //                }
            //            }
            //            else
            //            {
            //                sidebarpanel.Width += 10;
            //                if (sidebarpanel.Width -- sidebarpanel.MaxSize.Width)
            //{
            //                    sidebarpanelExpand = true;
            ////                    sidePanelTimer.Stop();
            //                }
            //            }
        }

        private void MainUI_Load_2(object sender, EventArgs e)
        {
            StartPanel();
    
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            FormSelect("home");
            ////panelLeft.Height = btnHome.Height;
            ////panelLeft.Top = btnHome.Top;
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            FormSelect("profile");
            //panelLeft.Height = btnProfile.Height;
            //panelLeft.Top = btnProfile.Top;
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            //FormSelect("user");
            //panelLeft.Height = btnCreateUser.Height;
            //panelLeft.Top = btnCreateUser.Top;
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            FormSelect("products");
            //panelLeft.Height = btnProducts.Height;
            //panelLeft.Top = btnProducts.Top;
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            FormSelect("sales");
            //panelLeft.Height = btnSales.Height;
            //panelLeft.Top = btnSales.Top;
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            FormSelect("reports");
            //panelLeft.Height = btnReports.Height;
            //panelLeft.Top = btnReports.Top;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            //FormSelect("settings");

            //panelLeft.Height = btnSettings.Height;
            //panelLeft.Top = btnSettings.Top;
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
    }
}

//        private void menubutton_Click_1(object sender, EventArgs e)
//        {

//        }
//    }
//}








