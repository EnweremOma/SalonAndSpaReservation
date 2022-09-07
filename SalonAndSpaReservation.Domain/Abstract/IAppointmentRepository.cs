using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalonAndSpaReservation.Domain.Entities;

namespace SalonAndSpaReservation.Domain.Abstract
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> Appointments { get; }
        void SaveAppointment(Appointment appointment);
        Appointment DeleteAppointment(int appointmentID);
        Appointment GetAppointmentById(int ID);
    }
}