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
    public class CartService : ICartService
    {

        private readonly ICartRepository _repository;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public CartService(ICartRepository repository, IMapper mapper , IBookRepository bookRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _bookRepository = bookRepository;
        }
        public Task<string> AddBookToCart(int UserId, int BookId)
        {
            _repository.AddBookToCart(UserId, BookId);
            return Task.Run(() => _mapper.Map<string>("Added"));
        }

        public Task<int> ClearCart(int UserId)
        {
            
           int items = _repository.ClearCart(UserId);
            return Task.Run(() => _mapper.Map<int>(items));
        }

        public Task<int> CreateCart(int UserId)
        {
            Cart cart = _mapper.Map<Cart>(UserId);
            int cartId = _repository.CreateCart(UserId);
            return Task.Run(() => _mapper.Map<int>(cartId));

        }

        public Task<int> GetCartId(int UserId)
        {
            Cart cart = _mapper.Map<Cart>(UserId);
            int cartId = _repository.GetCartId(cart.UserId);
            return Task.Run(() => _mapper.Map<int>(cartId));
        }

        public Task<int> GetCartItemCount(int UserId)
        {
            int cartItems = _repository.GetCartItemCount(UserId);
            return Task.Run(() => _mapper.Map<int>(cartItems));
        }

        public Task<IEnumerable<CartReadDto>> GetCartItems(int UserId)
        {

            List<CartReadDto> cartItemList = new List<CartReadDto>();
            IEnumerable<CartItem> cartItems = _repository.GetCartItems(UserId);

            foreach (CartItem item in cartItems)
            {
                Book book = _bookRepository.GetBookDetails(item.BookId);

                CartReadDto cartlist = new CartReadDto
                {
                    Book = book,

                    Quantity = item.Quantity
                };

                cartItemList.Add(cartlist);
            }
            return Task.Run(() => _mapper.Map<IEnumerable<CartReadDto>>(cartItemList));
            
        }

        public Task<string> RemoveCartItem(int UserId, int BookId)
        {
            /*CartItem cartItem = _mapper.Map<CartItem>(CartItem);*/
            _repository.RemoveCartItem(UserId, BookId);
            return Task.Run(() => _mapper.Map<string>("Removed"));
        }
    }
}
