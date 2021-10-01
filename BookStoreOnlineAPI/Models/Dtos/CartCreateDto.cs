using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreOnlineAPI.Models.Dtos
{
    public class CartCreateDto
    {
        public int CartId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
