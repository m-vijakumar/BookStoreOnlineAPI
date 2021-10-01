using BookStoreOnlineAPI.Models;
using BookStoreOnlineAPI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreOnlineAPI.Repository.Interfaces
{
    public interface IUserRepository
    {
        bool SaveChanges();
        IEnumerable<User> GetUsers();
        void Create(User user);
        User AuthenticateUser(User loginData);
        bool CheckUserAvailabity(string UserName);
        bool isUserExists(int UserId);
    }
}
