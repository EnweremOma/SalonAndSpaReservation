using SalonAndSpaReservation.Domain.Entities;
using SalonAndSpaReservation.Domain.Abstract;
using System.Collections.Generic;


namespace SalonAndSpaReservation.Domain.Concrete
{
    public class EFServiceRepository : IServiceRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Service> Services
        {
            get { return context.Services; }
        }

        public void SaveServices(Service service)
        {
            if (context.Services.Find(service.ID) == null)
            {
                context.Services.Add(service);
            }
            else
            {
                Service dbEntry = context.Services.Find(service.ID);
                if (dbEntry != null)
                {
                    // db.Entry(Service).State = EntityState.Modified;

                    dbEntry.Name = service.Name;
                    dbEntry.Description = service.Description;
                    dbEntry.Duration = service.Duration;
                    dbEntry.Price = service.Price;
                }
            }
            context.SaveChanges();
        }
        public Service DeleteServices(int serviceID)
        {
            Service dbEntry = context.Services.Find(serviceID);
            if (dbEntry != null)
            {
                context.Services.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public Service GetServiceById(int ID)
        {
            return context.Services.Find(ID);
        }
    }
}
