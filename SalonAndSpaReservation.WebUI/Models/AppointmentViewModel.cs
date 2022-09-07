using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SalonAndSpaReservation.Domain.Entities;

namespace SalonAndSpaReservation.WebUI.Models
{
    public class AppointmentViewModel
    {
        public Service service { get; set; }
        public Appointment appointment { get; set; }
        public Customer customer { get; set; }
    }

   /** public class BookingModel
    {
        public string JustMe { get; set; }
        public string TwoPeople { get; set; }
        public string ThreePeople { get; set; }
        public string FourPeople { get; set; }
        public string FivePeople { get; set; }

    }**/
}