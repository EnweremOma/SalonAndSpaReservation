using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalonAndSpaReservation.Domain.Entities;

namespace SalonAndSpaReservation.Domain.Abstract
{
    public interface IMaterialRepository
    {
        IEnumerable<Material> Materials { get; }
        void SaveMaterial(Material material);
        Material DeleteMaterial(int materialID);

        Material GetMaterialById(int ID);
    }
}
