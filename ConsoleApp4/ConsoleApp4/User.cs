using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    public class User
    {
        private string name;
        private string surname;
        private string username;
        private string password;
        private DateTime registerDate;
        private string token = "";
        public User()
        {

        }
        public User(string username, string name, string surname, string password, DateTime registerDate)
        {
            this.username = username;
            this.name = name;
            this.surname = surname;
            this.password = password;
            this.registerDate = registerDate;

        }
        public User(string token)
        {
            this.token = token;
        }
        public string GetUsername()
        {
            return this.username;
        }
        public void SetUsername(string username)
        {
            // condition ? consequent : alternative
            //username != string.Empty && username != null ? this.username=username : throw new ArgumentNullException("username cannot be empty or null");
            this.username = username;
        }
        public string GetName()
        {
            return this.name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetSurname()
        {
            return this.surname;
        }
        public void SetSurname(string surname)
        {
            this.surname = surname;
        }
        public string GetPassword()
        {
            return this.password;
        }
        public void SetPassword(string password)
        {
            this.password = password;
        }
        public DateTime GetRegisterDate()
        {
            return this.registerDate;
        }
        public void SetRegisterDate(DateTime registerDate)
        {
            this.registerDate = registerDate;
        }
        public string GetToken()
        {
            return this.token;
        }
        public void SetToken(string token)
        {
            this.token = token;
        }
        public override string ToString()
        {
            return base.ToString() + ": " + name.ToString() + " " + surname.ToString() + ", username: " + username.ToString() + " password: " + password.ToString() + ", tokenAUTH: " + token.ToString();
        }
    }
}
