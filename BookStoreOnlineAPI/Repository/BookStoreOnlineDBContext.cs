using BookStoreOnlineAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreOnlineAPI.Repository
{
    public class BookStoreOnlineDBContext :DbContext
    {
        public BookStoreOnlineDBContext (DbContextOptions<BookStoreOnlineDBContext> options)
            : base(options) { 
        }

        public DbSet<User> User { get; set; }
        public DbSet<Book> Book { get; set; }
    }
}
