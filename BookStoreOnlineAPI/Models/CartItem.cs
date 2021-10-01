using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreOnlineAPI.Models
{
    public class CartItem
    {
        [Key]
        [Required]
        public int CartItemId { get; set; }
        [Required]
        public int CartId { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
