using BookStoreOnlineAPI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreOnlineAPI.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookReadDto>> GetBooks();
        Task<BookReadDto> Create(BookCreateDto bookCreateDto);

        Task<BookReadDto> BookDeatails(int BookId);
    }
}
