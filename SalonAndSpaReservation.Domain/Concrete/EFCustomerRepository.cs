using SalonAndSpaReservation.Domain.Entities;
using SalonAndSpaReservation.Domain.Abstract;
using System.Collections.Generic;

namespace SalonAndSpaReservation.Domain.Concrete
{
    public class EFCustomerRepository : ICustomerRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Customer> Customers
        {
            get { return context.Customers; }
        }

        public void SaveCustomer(Customer customer)
        {
            if (context.Customers.Find(customer.ID)==null)
            {
                context.Customers.Add(customer);
            }
            else
            {
                Customer dbEntry = context.Customers.Find(customer.ID);
                if (dbEntry != null)
                {
                    dbEntry.FirstName = customer.FirstName;
                    dbEntry.LastName = customer.LastName;
                    dbEntry.Gender = customer.Gender;
                    dbEntry.PhoneNumber = customer.PhoneNumber;
                    dbEntry.Email = customer.Email;
                    dbEntry.State = customer.State;
                    dbEntry.City = customer.City;
                    dbEntry.ZipCode = customer.ZipCode;
                    dbEntry.StreetAddress = customer.StreetAddress;
                }
            }
            context.SaveChanges();
        }

        public Customer DeleteCustomer(int customerID)
        {
            Customer dbEntry = context.Customers.Find(customerID);
            if (dbEntry != null)
            {
                context.Customers.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}