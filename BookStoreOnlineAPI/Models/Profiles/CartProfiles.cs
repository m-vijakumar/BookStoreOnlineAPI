using AutoMapper;
using BookStoreOnlineAPI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreOnlineAPI.Models.Profiles
{
    public class CartProfiles :Profile
    {
        public CartProfiles()
        {
            CreateMap<CartCreateDto, Cart>();
        }
    }
}
