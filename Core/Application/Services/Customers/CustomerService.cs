using Domain.Entities;
using Application.interfaces;
using Application.DTO;
using System.Security.Cryptography.X509Certificates;
namespace Application.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomer _customer;

        //constructor

        public CustomerService(ICustomer customer)
        {
            _customer = customer;
        }
       public List<Customer> GetAllCustomers()
       {
          List<Customer> _customers = _customer.GetAllCustomers();
          return _customers;
       }


        public Customer GetCustomerById(int id)
        {
           return _customer.GetCustomerById(id);
        }

        public void CreateCustomer(CustomerCreateDTO customerDTO)
        {
            _customer.CreateCustomer(customerDTO);
        }
        public void UpdateCustomer(int id, CustomerUpdateDTO customerDTO)
        {
            _customer.UpdateCustomer(id, customerDTO);
        }
    }
}