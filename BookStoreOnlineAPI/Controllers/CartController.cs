using BookStoreOnlineAPI.Models.Dtos;
using BookStoreOnlineAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreOnlineAPI.Controllers
{
    [Route("api/cart")]
    [ApiController]
    [Authorize]
    public class CartController : Controller
    {
        readonly ICartService _cartService;
        readonly IBookService _bookService;

        public CartController(ICartService cartService, IBookService bookService)
        {
            _cartService = cartService;
            _bookService = bookService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<int>> GetCount(int userId)
        {
            return await _cartService.GetCartItemCount(userId);
             
        }

        [Route("cartitems/{UserId}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartReadDto>>> GetCartItems(int UserId)
        {
            return Ok((List<CartReadDto>) await _cartService.GetCartItems(UserId));
        }

        [HttpPost]
        [Route("addtocart/{userId}/{bookId}")]
        public async Task<ActionResult<int>> AddToCart(int userId, int bookId)
        {
            await _cartService.AddBookToCart(userId, bookId);
            return await _cartService.GetCartItemCount(userId);
        }

        [HttpDelete("removeitem/{userId}/{bookId}")]
        public async Task<ActionResult<int>> Delete(int userId, int bookId)
        {
           await  _cartService.RemoveCartItem(userId, bookId);
            return await _cartService.GetCartItemCount(userId);
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult<int>> Delete(int UserId)
        {
            return await _cartService.ClearCart(UserId);
        }
        }
}
