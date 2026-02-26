using Application.DTO;
using Domain.Entities;

namespace Application.Services.Customers
{
    public interface ICustomerService
    {
        Customer GetCustomerById(int Id);
        List<Customer> GetAllCustomers(CustomerFilter filter);

        void CreateCustomer(CustomerCreateDTO customerDTO);
        void UpdateCustomer(int id, CustomerUpdateDTO customerDTO);
    }
}