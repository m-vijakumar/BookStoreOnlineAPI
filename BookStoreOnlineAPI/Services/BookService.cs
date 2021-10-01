using AutoMapper;
using BookStoreOnlineAPI.Models;
using BookStoreOnlineAPI.Models.Dtos;
using BookStoreOnlineAPI.Repository.Interfaces;
using BookStoreOnlineAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreOnlineAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<BookReadDto> BookDeatails(int BookId)
        {
            
            Book book = _repository.GetBookDetails(BookId);

            return Task.Run(() => _mapper.Map<BookReadDto>(book));

        }

        public Task<BookReadDto> Create(BookCreateDto bookCreateDto)
        {
            Book book = _mapper.Map<Book>(bookCreateDto);

            try
            {
                _repository.Create(book);
            }
            catch
            {
                return null;
            }
            if (_repository.SaveChanges() == false)
            {
                return null;
            }

            return Task.Run(() => _mapper.Map<BookReadDto>(book));
        }

        public Task<IEnumerable<BookReadDto>> GetBooks()
        {
            List<Book> books = (List<Book>)_repository.GetBooks();
            return Task.Run(() => _mapper.Map<IEnumerable<BookReadDto>>(books));
        }
    }
}
