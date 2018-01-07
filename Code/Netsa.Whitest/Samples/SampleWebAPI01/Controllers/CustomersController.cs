using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using SampleWebAPI01.Models;

namespace SampleWebAPI01.Controllers
{
    public class CustomersController : ApiController
    {
        private static readonly List<Customer> Customers = new List<Customer>();
        public Customer GetById(long id)
        {
            return Customers.FirstOrDefault(a => a.Id == id);
        }

        public long Post(CreateCustomerDTO dto)
        {
            var id = GetNextId();
            var customer = new Customer()
            {
                Id = id,
                Firstname = dto.Firstname,
                Lastname = dto.Lastname
            };
            Customers.Add(customer);
            return id;
        }

        private long GetNextId()
        {
            if (!Customers.Any()) return 1;
            return Customers.Max(a => a.Id);
        }
    }

}
