using System.ComponentModel.DataAnnotations;

namespace api1.Models
{
    public class Product
    {
        public int Id { get; set; }

        //[StringLength(30,MinimumLength = 3)]
        public string Name { get; set; }

        //[Range(1,100)]
        public int Quantity { get; set; }
    }
}
