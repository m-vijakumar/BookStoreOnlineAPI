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

        public Task<UserReadDto> AuthenticateUser(UserLoginDto loginData)
        {

            User userlog = _mapper.Map<User>(loginData);
            User user = _repository.AuthenticateUser(userlog);
            

            return Task.Run(() => _mapper.Map<UserReadDto>(user));
        }

        public Task<bool> CheckUserAvailabity(string UserName)
        {
            bool user = (bool)_repository.CheckUserAvailabity(UserName);

            return Task.Run(() => _mapper.Map<bool>(user));
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

        public Task<bool> isUserExists(int UserId)
        {
            bool user = (bool)_repository.isUserExists(UserId);

            return Task.Run(() => _mapper.Map<bool>(UserId));
        }
    }
}
