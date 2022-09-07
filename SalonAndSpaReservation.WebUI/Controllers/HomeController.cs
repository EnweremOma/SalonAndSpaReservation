using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalonAndSpaReservation.Domain.Abstract;
using SalonAndSpaReservation.Domain.Entities;
using SalonAndSpaReservation.WebUI.Models;
using System.Threading.Tasks;
using SalonAndSpaReservation.WebUI.HtmlHelper;
using System.Data;

namespace SalonAndSpaReservation.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IServiceRepository repository;
        private IAppointmentRepository aptRepository;
        private ICustomerRepository custRepository;
        public HomeController(IServiceRepository repo, IAppointmentRepository aptrepo, ICustomerRepository custrepo)
        {
            repository = repo;
            aptRepository = aptrepo;
            custRepository = custrepo;
        }

        public ActionResult Index()
        {
            var model = repository.Services;
            return View(model);
        }
        [Authorize]
        public ActionResult BookAppointment(int Id)
        {
            //var model = new AppointmentViewModel();
            var service = repository.GetServiceById(Id);
            ViewBag.service = service;
            //model.service = service;
            var appt = new Appointment { ServiceID = Id, ServicePrice=service.Price, ServiceDuration=service.Duration };

            return View(appt);
        }

        [HttpPost]
      
        public async Task<ActionResult> BookAppointment(Appointment appointment)
        {
            try
            {
                var service = repository.GetServiceById(appointment.ServiceID);
                ViewBag.service = service;
                appointment.ServiceDuration = service.Duration;
                appointment.ServicePrice = service.Price;

                string useremail = "enweremiruoma@gmail.com";
                string senderpassword = "cmdizzaoqbzxkfgf";

                Customer customer = new Customer();

                var send = new EmailPayload
                {
                    Mailbody = "Thank you for booking an appointment with Oma Salon reservation",
                    Subject = "Notice of Appointment",
                    SenderEmail = useremail,
                    SenderPassword = senderpassword,
                    ReceiverEmail = appointment.Email,
                    SmptPort = 587,
                    SmtpHost = "smtp.gmail.com"
                };

                var email = new EmailHelper();
                var s = await email.SendEmailAsync(send);

                if (ModelState.IsValid)
                {
                    appointment.Date = DateTime.Today;
                    appointment.Time = DateTime.UtcNow.ToLocalTime();
                    aptRepository.SaveAppointment(appointment);
                    return RedirectToAction("ViewAppointment", new { ID = appointment.ID });
                }
                else
                {
                    // there is something wrong with the data values
                    return View(appointment);
                }
            }
            catch(DataException)
            {
                ModelState.AddModelError("", "Unable to book appointment, check your network connection and try again");
            }
            return View(appointment);
        }

        public ActionResult ViewAppointment(int ID)
        {
            var model = new AppointmentViewModel();
            var appt = aptRepository.GetAppointmentById(ID);
            model.appointment = appt;
            model.service = repository.GetServiceById(appt.ServiceID);
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Services ()
        {
            ViewBag.Message = "Your services page.";
            return View();
        }
    }
}