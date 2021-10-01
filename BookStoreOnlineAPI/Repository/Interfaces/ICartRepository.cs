using BookStoreOnlineAPI.Models;
using BookStoreOnlineAPI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreOnlineAPI.Repository.Interfaces
{
    public interface ICartRepository
    {
       
        void AddBookToCart(int UserId, int BookId);
        void RemoveCartItem(int UserId, int BookId);
        int GetCartItemCount(int UserId);
        IEnumerable<CartItem> GetCartItems(int UserId);
        int ClearCart(int UserId);
        int GetCartId(int UserId);
        int CreateCart(int UserId);
    }
}
