using SalonAndSpaReservation.Domain.Entities;
using SalonAndSpaReservation.Domain.Abstract;
using System.Collections.Generic;

namespace SalonAndSpaReservation.Domain.Concrete
{
    public class EFMaterialRepository : IMaterialRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Material> Materials
        {
            get { return context.Materials; }
        }

        public void SaveMaterial(Material material)
        {
            if (context.Materials.Find(material.ID) == null)
            {
                context.Materials.Add(material);
            }
            else
            {
                Material dbEntry = context.Materials.Find(material.ID);
                if (dbEntry != null)
                {
                    dbEntry.Name = material.Name;
                    dbEntry.Description = material.Description;
                    dbEntry.Price = material.Price;
                    dbEntry.Category = material.Category;
                    dbEntry.ImageData = material.ImageData;
                    dbEntry.ImageMimeType = material.ImageMimeType;
                }
            }
            context.SaveChanges();
        }
        public Material DeleteMaterial(int materialID)
        {
            Material dbEntry = context.Materials.Find(materialID);
            if (dbEntry != null)
            {
                context.Materials.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        public Material GetMaterialById(int ID)
        {
            return context.Materials.Find(ID);
        }
    }
}

