using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalonAndSpaReservation.Domain.Entities;

namespace SalonAndSpaReservation.Domain.Abstract
{
    public interface IMaterialToServiceRepository
    {
        IEnumerable<MaterialToService> MaterialsToServices { get; }
        void SaveMaterialToService(MaterialToService materialToService);
        MaterialToService DeleteMaterialToService(int materialToServiceID);
    }
}
