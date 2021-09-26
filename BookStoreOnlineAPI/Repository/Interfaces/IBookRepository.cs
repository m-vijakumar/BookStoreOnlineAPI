using BookStoreOnlineAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreOnlineAPI.Repository.Interfaces
{
    public interface IBookRepository
    {
        bool SaveChanges();
        IEnumerable<Book> GetBooks();
        void Create(Book book);
    }
}
