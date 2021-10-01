using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreOnlineAPI.Models.Dtos
{
    public class CartReadDto
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
