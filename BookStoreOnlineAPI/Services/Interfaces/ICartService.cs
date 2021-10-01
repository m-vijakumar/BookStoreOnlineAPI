using BookStoreOnlineAPI.Models;
using BookStoreOnlineAPI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreOnlineAPI.Services.Interfaces
{
    public interface ICartService
    {
        Task<string> AddBookToCart(int UserId, int BookId);
        Task<string> RemoveCartItem(int UserId, int bookId);
        Task<int> GetCartItemCount(int UserId);
        Task<IEnumerable<CartReadDto>> GetCartItems(int UserId);
        Task<int> ClearCart(int UserId);
        Task<int> GetCartId(int UserId);
        Task<int> CreateCart(int UserId);
    }
}
