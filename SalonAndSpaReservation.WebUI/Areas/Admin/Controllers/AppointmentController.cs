using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalonAndSpaReservation.Domain.Abstract;
using SalonAndSpaReservation.Domain.Entities;

namespace SalonAndSpaReservation.WebUI.Areas.Admin.Controllers
{
    public class AppointmentController : Controller
    {
        private IAppointmentRepository repository;
        public AppointmentController(IAppointmentRepository repo)
        {
            repository = repo;
        }
        // GET: Admin/Appointment
        public ActionResult Index()
        {
            var model = repository.Appointments;
            return View(model);
        }

    }
}