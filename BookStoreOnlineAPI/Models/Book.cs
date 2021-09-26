using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreOnlineAPI.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        [Range(1,10)]
        public int Rating { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string BookImage { get; set; }
        [Required]
        
        public int UserId { get; set; }
    }
}
