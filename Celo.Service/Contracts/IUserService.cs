using Celo.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Celo.Service.Contracts
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        IEnumerable<User> GetNumberOfUsers(int number);
        IEnumerable<User> GetUserByFirstOrLastName(string first, string last);
        void AddUser(User user);
        User GetUser();
        User GetUserById(int id);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
