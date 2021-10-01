using BookStoreOnlineAPI.Models;
using BookStoreOnlineAPI.Models.Dtos;
using BookStoreOnlineAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreOnlineAPI.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly BookStoreOnlineDBContext _context;

        public CartRepository(BookStoreOnlineDBContext context)
        {
            _context = context;                                
        }

        public int  CreateCart(int UserId)
        {
            try
            {
                Cart cart = new Cart { UserId = UserId };
                _context.Cart.AddAsync(cart);
                _context.SaveChanges();

                return cart.CartId;
            }
            catch
            {
                throw;
            }
        }

        public void AddBookToCart(int UserId, int BookId)
        {
            int cartId = GetCartId(UserId);
            int quantity = 1;

            CartItem existingCartItem = _context.CartItem.FirstOrDefault(x => x.BookId == BookId && x.CartId == cartId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += 1;
                _context.Entry(existingCartItem).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                CartItem cartItems = new CartItem
                {
                    CartId = cartId,
                    BookId = BookId,
                    Quantity = quantity
                };
                _context.CartItem.Add(cartItems);
                _context.SaveChanges();
            }
        }

        public int ClearCart(int UserId)
        {
            try
            {
                int cartId = GetCartId(UserId);
                List<CartItem> cartItem = _context.CartItem.Where(x => x.CartId == cartId).ToList();

                if (!string.IsNullOrEmpty(cartId.ToString()))
                {
                    foreach (CartItem item in cartItem)
                    {
                        _context.CartItem.Remove(item);
                        _context.SaveChanges();
                    }
                }
                return 0;
            }
            catch
            {
                throw;
            }
        }

        public int  GetCartId(int UserId)
        {
            try
            {
                Cart cart = _context.Cart.FirstOrDefault(x => x.UserId == UserId);

                if (cart != null)
                {
                    return cart.CartId;
                }
                else
                {
                   return  CreateCart(UserId);
                }

            }
            catch
            {
                throw;
            }
        }

        public int GetCartItemCount(int UserId)
        {
            int cartId = GetCartId(UserId);

            if (cartId == default(int) || cartId == null)
            {
                return 0;
            }
            else
            {
                int cartItemCount = _context.CartItem.Where(x => x.CartId == cartId).Sum(x => x.Quantity);

                return cartItemCount;
            }
        }

        public void RemoveCartItem(int UserId, int BookId)
        {
            try
            {
                int cartId = GetCartId(UserId);
                CartItem cartItem = _context.CartItem.FirstOrDefault(x => x.BookId == BookId && x.CartId == cartId);

                _context.CartItem.Remove(cartItem);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<CartItem> GetCartItems(int UserId)
        {
            int cartId = GetCartId(UserId);

            
            List<CartItem> cartItems = _context.CartItem.Where(x => x.CartId == cartId).ToList();

            return cartItems;
            

        }
    }
}
