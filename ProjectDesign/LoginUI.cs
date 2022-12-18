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
    public partial class LoginUI : Form
    {
        MainUI ui;
        SqlConnection conn;
        SqlCommand cmd;
        List<Users> users;
        public LoginUI()
        {
            InitializeComponent();
        }
        public LoginUI(MainUI ui):this()
        {
            this.ui = ui;
        }
        private void LoginUI_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(DBServer.ServerName);
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }

        private void UsernameTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                
                MessageBox.Show("Empty Fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            string query = $"select * from Users where Username='{txtUsername.Text}' AND Password= '{txtPassword.Text}'";
            SqlDataAdapter adpt = new SqlDataAdapter(query, conn);
            DataTable table = new DataTable();
            adpt.Fill(table);
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Incorrect Username/Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            users = new List<Users>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Users user = new Users();
                user.UserId = Convert.ToInt32(table.Rows[i]["UserId"]);
                user.Username = Convert.ToString(table.Rows[i]["Username"]);
                user.Password = Convert.ToString(table.Rows[i]["Password"]);
                user.Firstname = Convert.ToString(table.Rows[i]["Firstname"]);
                user.Lastname = Convert.ToString(table.Rows[i]["Lastname"]);
                user.UserType = Convert.ToString(table.Rows[i]["UserType"]);
                user.Age = Convert.ToString(table.Rows[i]["Age"]);
                user.Sex = Convert.ToString(table.Rows[i]["Sex"]);
                user.Position = Convert.ToString(table.Rows[i]["Position"]);
                users.Add(user);
            }
            ui.SetIsLoggedIn(true, users[0].UserType);
            MessageBox.Show("Login Successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private void txtPassword_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                LoginButton_Click(sender, e);
            }
        }
    }
}


    





