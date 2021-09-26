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

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
