using System;
using System.Collections.Generic;
using webapi_playground.Models;
using webapi_playground.Repositories;

namespace webapi_playground.Managers
{
    public class UsersManager
    {
        public List<User> GetUsers()
        {
            var repo = new UsersRepository();
            return repo.GetAllUsers();
        }

        public int AddUser(User user)
        {
            user.Password = "Password1";
            var repo = new UsersRepository();
            return repo.AddUser(user);
        }
    }
}