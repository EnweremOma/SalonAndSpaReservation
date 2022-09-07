using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalonAndSpaReservation.Domain.Entities;

namespace SalonAndSpaReservation.Domain.Abstract
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> Customers { get; }

        void SaveCustomer(Customer customer);

        Customer DeleteCustomer(int customerID);
    }
}