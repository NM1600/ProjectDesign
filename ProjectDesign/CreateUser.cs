using ProjectDesign.Classes;
using ShutterPrism.MVC.FontAwesome;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDesign
{
    public partial class CreateUser : Form
    {
        List<Users> users;
        SqlConnection conn;
        SqlCommand cmd;
        public CreateUser()
        {
            InitializeComponent();
        }

        private void CreateUser_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(DBServer.ServerName);
            cmd = new SqlCommand();
            cmd.Connection = conn;
            FetchData();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void FetchData()
        {
            string selectquery = "select * from Users";
            SqlDataAdapter adpt = new SqlDataAdapter(selectquery, conn);
            DataTable table = new DataTable();
            adpt.Fill(table);
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
            dtgRecords.DataSource = users; 
        }
        private Users GetSelectedRow(DataGridViewRow row)
        {
            return new Users
            {
                UserId = Convert.ToInt32(row.Cells["UserId"].Value),
                Username = Convert.ToString(row.Cells["Username"].Value),
                Password = Convert.ToString(row.Cells["Password"].Value),
                Firstname = Convert.ToString(row.Cells["Firstname"].Value),
                Lastname = Convert.ToString(row.Cells["Lastname"].Value),
                UserType = Convert.ToString(row.Cells["UserType"].Value),
                Age = Convert.ToString(row.Cells["Age"].Value),
                Sex = Convert.ToString(row.Cells["Sex"].Value),
                Position = Convert.ToString(row.Cells["Position"].Value),
            };
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AddUsers().ShowDialog();
            FetchData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Users data = GetSelectedRow(dtgRecords.CurrentRow);
            new AddUsers(data).ShowDialog();
            FetchData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Users data = GetSelectedRow(dtgRecords.CurrentRow);
            DialogResult dialogResult = MessageBox.Show("Delete "+data.Firstname+"?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string query = $"Delete Users where UserId='{data.UserId}'";
                conn.Open();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Successfully Deleted.");
                FetchData();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }
    }
}
