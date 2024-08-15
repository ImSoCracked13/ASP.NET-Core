using System.ComponentModel.DataAnnotations;

namespace web2.Models
{
    public class Laptop
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Brand name can not be empty")]
        public string Brand { get; set; }

        [MinLength(5, ErrorMessage = "Min name length is 5 characters")]
        [MaxLength(30 , ErrorMessage = "Max name length is 30 characters")]
        public string Model { get; set; }

        [Range(1, 100, ErrorMessage = "Quantity must be from 1 to 100")]
        public int Quantity { get; set; }

        [Range(1, 100, ErrorMessage = "Price must be from 100$ to $5000")]
        public decimal Price { get; set; }

        public string Image { get; set; }

        public string Color { get; set; }   
    }
}
