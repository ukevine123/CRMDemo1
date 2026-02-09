using Application.DTO;
using Domain.Entities;

namespace Application.interfaces
{
    public interface ICustomer
    {
        public List<Customer> GetAllCustomers();

        public Customer GetCustomerById(int id);

        void CreateCustomer(CustomerCreateDTO customerDTO);

        void UpdateCustomer(int id, CustomerUpdateDTO customerDTO);
    }
}