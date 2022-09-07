using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonAndSpaReservation.WebUI.Models
{
    public class EmailPayload
    {
        public string Mailbody { get; set; }
        public string Subject { get; set; }
        public string SenderEmail { get; set; }
        public string ReceiverEmail { get; set; }
        public string SmtpHost { get; set; }
        public int SmptPort { get; set; }
        public string SenderPassword { get; set; }
    }
}