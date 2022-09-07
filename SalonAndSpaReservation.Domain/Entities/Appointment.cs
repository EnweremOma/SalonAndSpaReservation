using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonAndSpaReservation.Domain.Entities
{
    public class Appointment
    {
        [Key]
        public int ID { get; set; }
        public int ServiceID { get; set; }
        public int ServicePrice { get; set; }
        public decimal ServiceDuration { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public int NumberOfGuest { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public string StreetAddress { get; set; }
        public string Gender { get; set; }
    }
}
