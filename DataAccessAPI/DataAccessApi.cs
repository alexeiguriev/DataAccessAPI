using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesslibrary.DataAccess;
using DataAccesslibrary.Models;

namespace DataAccessAPI
{
    public class DataAccessApi
    {
        SqlConnector sqlConn = new SqlConnector("Server=DESKTOP-N5N3TKU;Database=USERdb;Trusted_Connection=True;");

        public string[][] GetAllUses()
        {
            List<USER> gotUsers = sqlConn.GetUSER_All();

            List<string[]> list = new List<string[]>();

            foreach (USER user in gotUsers)
            {
                list.Add(new[] { user.FirstName, user.LastName, user.EmailAddress, user.Password });
            }

            string[][] users = list.ToArray();
            return users;
        }

        public void AddNewUser(string firstName, string lastName, string email, string password)
        {
            USER user = new USER();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.EmailAddress = email;
            user.Password = password;
            sqlConn.CreaUSER(user);
        }

        public void DeleteElement(string firstName, string lastName, string email, string password)
        {
            USER user = new USER();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.EmailAddress = email;
            user.Password = password;
            sqlConn.DeleteUSER(user);
        }
    }
}
