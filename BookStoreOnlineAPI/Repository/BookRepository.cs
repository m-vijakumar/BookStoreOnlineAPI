using BookStoreOnlineAPI.Models;
using BookStoreOnlineAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreOnlineAPI.Repository
{
    public class BookRepository :IBookRepository
    {
        private readonly BookStoreOnlineDBContext _context;

        public BookRepository(BookStoreOnlineDBContext context)
        {
            _context = context;
        }

        public void Create(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException();
            }
            _context.Book.AddAsync(book);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _context.Book.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
