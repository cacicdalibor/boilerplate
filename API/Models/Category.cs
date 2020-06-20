using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Data;

namespace API.Models
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        [Required, StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }
        public int ParentCategoryId { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}