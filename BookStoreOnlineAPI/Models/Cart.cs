using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreOnlineAPI.Models
{
    public class Cart
    {
        [Key]
        [Required]
        public int CartId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
