using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesslibrary.DataAccess;
using DataAccesslibrary.Models;

namespace DataAccessAPI
{
    public class DataAccessApi : IDataAccessApi
    {
        IDataConnection dataConnection = new SqlConnector();
        //IDataConnection dataConnection = new TextConnector();

        public string[][] GetAllUses()
        {
            List<UserModel> gotUsers = dataConnection.GetUser_All();

            List<string[]> list = new List<string[]>();

            foreach (UserModel user in gotUsers)
            {
                list.Add(new[] { user.FirstName, user.LastName, user.EmailAddress, user.Password });
            }

            string[][] users = list.ToArray();
            return users;
        }

        public void AddNewUser(string firstName, string lastName, string email, string password)
        {
            UserModel user = new UserModel();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.EmailAddress = email;
            user.Password = password;
            dataConnection.PostUser(user);
        }

        public void DeleteUser(string firstName, string lastName, string email, string password)
        {
            UserModel user = new UserModel();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.EmailAddress = email;
            user.Password = password;
            dataConnection.DeleteUser(user);
        }
        public void UpdateUser(string oldFirstName, string oldLastName, string oldEmail, string oldPassword, string newFirstName, string newLastName, string newEmail, string newPassword)
        {
            UserModel oldUser = new UserModel();
            oldUser.FirstName = oldFirstName;
            oldUser.LastName = oldLastName;
            oldUser.EmailAddress = oldEmail;
            oldUser.Password = oldPassword;
            UserModel newUser = new UserModel();
            newUser.FirstName = newFirstName;
            newUser.LastName = newLastName;
            newUser.EmailAddress = newEmail;
            newUser.Password = newPassword;
            dataConnection.PutUser(oldUser, newUser);
        }
    }
}
