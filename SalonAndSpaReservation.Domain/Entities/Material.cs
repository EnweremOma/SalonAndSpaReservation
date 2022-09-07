using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonAndSpaReservation.Domain.Entities
{
    public class Material
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter product name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a product descrption")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter a price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter a valid category")]
        public string Category { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
