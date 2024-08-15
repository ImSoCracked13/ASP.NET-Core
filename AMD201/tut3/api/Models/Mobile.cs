using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Mobile
    {
        //set custom name for primary key
        //[Key]
        //public int MobiId { get; set; }

        //public int MobileId { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
