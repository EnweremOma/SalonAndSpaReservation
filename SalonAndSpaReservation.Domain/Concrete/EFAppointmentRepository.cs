using SalonAndSpaReservation.Domain.Entities;
using SalonAndSpaReservation.Domain.Abstract;
using System.Collections.Generic;

namespace SalonAndSpaReservation.Domain.Concrete
{
    public class EFAppointmentRepository : IAppointmentRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Appointment> Appointments
        {
            get { return context.Appointments; }
        }

        public void SaveAppointment(Appointment appointment)
        {
            if (context.Appointments.Find(appointment.ID) == null)
            {
                context.Appointments.Add(appointment);
            }
            else
            {
                Appointment dbEntry = context.Appointments.Find(appointment.ID);
                if (dbEntry != null)
                {
                    // db.Entry(Appointment).State = EntityState.Modified;

                    dbEntry.ServiceID = appointment.ServiceID;
                    dbEntry.ServicePrice = appointment.ServicePrice;
                    dbEntry.ServiceDuration = appointment.ServiceDuration;
                    dbEntry.Date = appointment.Date;
                    dbEntry.Time = appointment.Time;
                    dbEntry.NumberOfGuest =appointment.NumberOfGuest;
                    dbEntry.FirstName = appointment.FirstName;
                    dbEntry.LastName = appointment.LastName;
                    dbEntry.PhoneNumber = appointment.PhoneNumber;
                    dbEntry.Email = appointment.Email;
                    dbEntry.State = appointment.State;
                    dbEntry.City = appointment.City;
                    dbEntry.ZipCode = appointment.ZipCode;
                    dbEntry.StreetAddress = appointment.StreetAddress;
                    dbEntry.Gender = appointment.Gender;
                }
            }
            context.SaveChanges();
        }
        public Appointment DeleteAppointment(int appointmentID)
        {
            Appointment dbEntry = context.Appointments.Find(appointmentID);
            if (dbEntry != null)
            {
                context.Appointments.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public Appointment GetAppointmentById(int ID)
        {
            return context.Appointments.Find(ID);
        }
    }
}
