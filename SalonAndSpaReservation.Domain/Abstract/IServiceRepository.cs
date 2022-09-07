using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalonAndSpaReservation.Domain.Entities;

namespace SalonAndSpaReservation.Domain.Abstract
{
    public interface IServiceRepository
    {
        IEnumerable<Service> Services { get; }
        void SaveServices(Service services);
        Service DeleteServices(int serviceID);
        Service GetServiceById(int ID);
    }
}
