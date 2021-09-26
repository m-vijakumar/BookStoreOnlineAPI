using AutoMapper;
using BookStoreOnlineAPI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreOnlineAPI.Models.Profiles
{
    public class BookProfiles :Profile
    {
        public BookProfiles()
        {
            CreateMap<Book, BookReadDto>();
            CreateMap<BookCreateDto, Book>();
        }
    }
}
