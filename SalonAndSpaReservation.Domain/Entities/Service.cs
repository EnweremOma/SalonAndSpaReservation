using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonAndSpaReservation.Domain.Entities
{
    public class Service
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter a service name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a service description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter service duration")]
        public decimal Duration { get; set; }
        [Required(ErrorMessage = "Please enter service price")]
        public int Price { get; set; }
    }
}