using SalonAndSpaReservation.Domain.Entities;
using SalonAndSpaReservation.Domain.Abstract;
using System.Collections.Generic;

namespace SalonAndSpaReservation.Domain.Concrete
{
    public class EFMaterialToServiceRepository : IMaterialToServiceRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<MaterialToService> MaterialsToServices
        {
            get { return context.MaterialToServices; }
        }

        public void SaveMaterialToService(MaterialToService materialToService)
        {
            if (context.MaterialToServices.Find(materialToService.ID) == null)
            {
                context.MaterialToServices.Add(materialToService);
            }
            else
            {
                MaterialToService dbEntry = context.MaterialToServices.Find(materialToService.ID);
                if (dbEntry != null)
                {
                    dbEntry.ServiceID = materialToService.ServiceID;
                    dbEntry.MaterialID = materialToService.MaterialID;
                }
            }
            context.SaveChanges();
        }
        public MaterialToService DeleteMaterialToService(int materialToServiceID)
        {
            MaterialToService dbEntry = context.MaterialToServices.Find(materialToServiceID);
            if (dbEntry != null)
            {
                context.MaterialToServices.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
       
    }
}

