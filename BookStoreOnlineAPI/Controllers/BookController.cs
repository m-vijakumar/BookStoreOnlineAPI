using BookStoreOnlineAPI.Models.Dtos;
using BookStoreOnlineAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreOnlineAPI.Controllers
{
    [Route("api/books")]
    [ApiController]

    //Books Controller manages all BookApis
    public class BookController : ControllerBase
    {
        private readonly IBookService _services;

        public BookController(IBookService services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookReadDto>>> GetBooks()
        {

            return Ok((List<BookReadDto>)await _services.GetBooks());
        }

        [Route("add")]
        [HttpPost]
        public async Task<ActionResult<BookReadDto>> Create(BookCreateDto bookCreateDto)
        {
            BookReadDto book = await _services.Create(bookCreateDto);
            if (book == null)
            {
                return BadRequest();
            }
            return book;
        }

        [Route("{BookId}")]
        [HttpGet]
        public async Task<ActionResult<BookReadDto>> BookDetails(int BookId)
        {
            BookReadDto book = await _services.BookDeatails(BookId);
            return book;

        }

    }
}
