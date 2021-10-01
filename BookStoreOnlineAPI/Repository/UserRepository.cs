using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreOnlineAPI.Models;
using BookStoreOnlineAPI.Repository.Interfaces;
namespace BookStoreOnlineAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BookStoreOnlineDBContext _context;

        public UserRepository(BookStoreOnlineDBContext context)
        {
            _context = context;
        }

        public User AuthenticateUser(User loginData)
        {
            User user = new User();
            var userDetails = _context.User.FirstOrDefault(
                u => u.UserName == loginData.UserName && u.Password == loginData.Password
                );
            if (userDetails != null)
            {

                user = new User
                {
                    UserName = userDetails.UserName,
                    UserId = userDetails.UserId,
                };
                return user;
            }
            else
            {
                return userDetails;
            }
        }

        public void Create(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }
            _context.User.AddAsync(user);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.User.ToList();
        }

        public bool CheckUserAvailabity(string UserName)
        {
            string user = _context.User.FirstOrDefault(x => x.UserName == UserName)?.ToString();

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isUserExists(int UserId)
        {
            string user = _context.User.FirstOrDefault(x => x.UserId == UserId)?.ToString();

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
