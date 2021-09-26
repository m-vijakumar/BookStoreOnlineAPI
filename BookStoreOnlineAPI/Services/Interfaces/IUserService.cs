using BookStoreOnlineAPI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreOnlineAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserReadDto>> GetUsers();
        Task<UserReadDto> Create(UserCreateDto userCreateDto);
    }
}
