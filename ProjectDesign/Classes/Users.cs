using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDesign.Classes
{
    public class Users
    {
        int userId;
        string username;
        string password;
        string firstname;
        string lastname;
        string userType;
        string age;
        string sex;
        string position;
        public int UserId { get => userId; set => userId = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string UserType { get => userType; set => userType = value; }
        public string Age { get => age; set => age = value; }
        public string Sex { get => sex; set => sex = value; }
        public string Position { get => position; set => position = value; }
    }
}
