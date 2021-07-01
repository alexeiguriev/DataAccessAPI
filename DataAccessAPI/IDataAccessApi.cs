using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessAPI
{
    public interface IDataAccessApi
    {
        string[][] GetAllUses();
        void AddNewUser(string firstName, string lastName, string email, string password);
        public void DeleteUser(string firstName, string lastName, string email, string password);
        public void UpdateUser(string oldFirstName, string oldLastName, string oldEmail, string oldPassword, string newFirstName, string newLastName, string newEmail, string newPassword);
    }
}
