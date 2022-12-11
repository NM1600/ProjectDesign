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

namespace ProjectDesign
{
    public partial class AddUsers : Form
    {
        List<Users> users;
        Users user;
        SqlConnection conn;
        SqlCommand cmd;
        public AddUsers()
        {
            InitializeComponent();
            cboUserType.Text = "admin";
            cboSex.Text = "Female";
            cboPosition.Text = "Assistant Store Manager ";
        }
        public AddUsers(Users user):this()
        {
            this.user = user;
            btnConfirm.Text = "Update";
            DisplayRecords();
        }
        private void AddUsers_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(DBServer.ServerName);
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }
        public void DisplayRecords()
        {
            txtUsername.Text = user.Username;
            txtPassword.Text = user.Password;
            txtFirstname.Text = user.Firstname;
            txtLastname.Text = user.Lastname;
            txtAge.Text = user.Age;
            cboPosition.Text = user.Position;
            cboSex.Text = user.Sex;
            cboUserType.Text = user.UserType;
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (Validator() == true)
                return;
            Users data = GetData();
            string query = "";
            string msg = "Saved";
            if (btnConfirm.Text == "Save")
                query = $"insert into Users VALUES(@Username,@Password,@Firstname,@Lastname,@UserType,@Age,@Sex,@Position)";
            else
            {
                msg = "Updated";
                query = $"update Users set Username=@Username, Password=@Password, Firstname=@Firstname, Lastname=@Lastname, UserType=@UserType, Age=@Age, Sex=@Sex, Position=@Position where UserId='{user.UserId}'";
            }
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@Username", data.Username);
            cmd.Parameters.AddWithValue("@Password", data.Password);
            cmd.Parameters.AddWithValue("@Firstname", data.Firstname);
            cmd.Parameters.AddWithValue("@Lastname", data.Lastname);
            cmd.Parameters.AddWithValue("@UserType", data.UserType);
            cmd.Parameters.AddWithValue("@Age", data.Age);
            cmd.Parameters.AddWithValue("@Sex", data.Sex);
            cmd.Parameters.AddWithValue("@Position", data.Position);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Successfully "+msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }
        public bool Validator()
        {
            if (string.IsNullOrEmpty(txtFirstname.Text) || string.IsNullOrEmpty(txtLastname.Text) || string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtAge.Text))
            {
                MessageBox.Show("Empty Fields","Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }
        private Users GetData()
        {
            return new Users
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                Firstname = txtFirstname.Text,
                Lastname = txtLastname.Text,
                UserType = cboUserType.Text,
                Position = cboPosition.Text,
                Age = txtAge.Text,
                Sex = cboSex.Text,
            };
        }
    }
}
