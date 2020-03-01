using Celo.Common;
using Celo.Data.Contracts;
using Celo.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Celo.Service
{
    //Service Layer. For simplicity of this challenge. I have decided to do filtering after loading all user from Data. To maximise efficiency I would have done filtering in DAL layer.
    public class UserService : IUserService
    {
        private readonly IDataHandler _dataHandler;

        public UserService(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        } 

        public IEnumerable<User> GetAllUsers()
        {
            try
            {
                return _dataHandler.GetData();
            }
            catch
            {
            }
            return null;
        }

        public IEnumerable<User> GetNumberOfUsers(int number)
        {
            try
            {
                var filteredUserList = _dataHandler.GetData().Take(number);
                return filteredUserList;
            }
            catch
            {
            }
            return null;
        }

        public IEnumerable<User> GetUserByFirstOrLastName(string first, string last)
        {
            var filteredUserList = Enumerable.Empty<User>();
            try
            {
                if (!string.IsNullOrEmpty(first))
                    filteredUserList = _dataHandler.GetData().Where(element => element.Name.First.ToLower() == first.ToLower());
                else if (!string.IsNullOrEmpty(last))
                    filteredUserList = _dataHandler.GetData().Where(element => element.Name.Last.ToLower() == last.ToLower());
            }
            catch
            {
            }
            return filteredUserList;
        }
        public User GetUser()
        {
            try
            {
                var user = _dataHandler.GetData().FirstOrDefault();
                return user;
            }
            catch 
            {
            }
            return null;
        }

        public User GetUserById(int id)
        {
            try
            {
                var user = _dataHandler.GetData().Where(element => element.Id == id).FirstOrDefault();
                return user;
            }
            catch
            {
            }
            return null;
        }

        public void AddUser(User user)
        {
            try
            {
                var existingData = _dataHandler.GetData();
                existingData.Add(user);
                _dataHandler.UpdateFile(existingData);
            }
            catch
            {
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                var userList = _dataHandler.GetData();
                var userToUpdate = userList.Where(element => element.Id == user.Id).FirstOrDefault();
                if (userToUpdate != null)
                {
                    userList.RemoveAll(element => element.Id == user.Id);

                    userToUpdate.Email = user.Email;
                    userToUpdate.DateOfBirth = user.DateOfBirth;
                    userToUpdate.Name = user.Name;
                    userToUpdate.PhoneNumber = user.PhoneNumber;
                    userToUpdate.ProfileImage = user.ProfileImage;

                    userList.Add(userToUpdate);
                    _dataHandler.UpdateFile(userList);
                }
            }
            catch
            {
            }
        }

        public void DeleteUser(int id)
        {
            try
            {
                var userList = _dataHandler.GetData();
                var userToDelete = userList.Where(element => element.Id == id).FirstOrDefault();
                if (userToDelete != null)
                {
                    userList.RemoveAll(element => element.Id == id);
                    _dataHandler.UpdateFile(userList);
                }
            }
            catch
            {
            }
        }
    }
}
