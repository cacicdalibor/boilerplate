using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required, StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
    }
}