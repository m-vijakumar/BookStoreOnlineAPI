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
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<UserReadDto> Create(UserCreateDto userCreateDto)
        {
            User user = _mapper.Map<User>(userCreateDto);

            try
            {
                _repository.Create(user);
            }
            catch
            {
                return null;
            }
            if (_repository.SaveChanges() == false)
            {
                return null;
            }

            return Task.Run(() => _mapper.Map<UserReadDto>(user));

        }

        public Task<IEnumerable<UserReadDto>> GetUsers()
        {
            List<User> users = (List<User>)_repository.GetUsers();
            return Task.Run(() => _mapper.Map<IEnumerable<UserReadDto>>(users));
        }
    }
}
