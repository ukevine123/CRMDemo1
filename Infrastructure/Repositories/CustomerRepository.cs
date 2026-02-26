using Application.DTO;
using Application.interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomer
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        // Retrieving customers

        public List<Customer> GetAllCustomers(CustomerFilter filter)
        {
            IQueryable<Customer> query = _dbContext.Customers;
            if(!string.IsNullOrEmpty(filter.SearchTerm))
            {
                query = query.Where(c => c.Name.Contains(filter.SearchTerm));
            }
            if(!string.IsNullOrEmpty(filter.Address))
            {
                query = query.Where(c => c.Address.Contains(filter.Address));
            }
            if(!string.IsNullOrEmpty(filter.City))
            {
                query = query.Where(c => c.City.Contains(filter.City));
            }
            List<Customer> _customers = query.ToList();
            return _customers;
        }  
        public Customer GetCustomerById(int id)
        {
           return _dbContext.Customers.FirstOrDefault(c=>c.Id==id);
        }

        public void CreateCustomer(CustomerCreateDTO customerDTO)
        {
            Customer customer = new Customer
            {
                Name = customerDTO.Name,
                Email = customerDTO.Email,
                Phone = customerDTO.Phone,
                Address = customerDTO.Address,
                City = customerDTO.City,
                CreatedAt = DateTime.Now,
                CreatedById = 1
            };
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
        }

        public void UpdateCustomer(int id, CustomerUpdateDTO customerDTO)
        {
            var customer = _dbContext.Customers.Find(id);
            if (customer == null) return;
            
                customer.Name = customerDTO.Name;
                customer.Phone = customerDTO.Phone;
                customer.Address = customerDTO.Address;
                customer.City = customerDTO.City;

                _dbContext.SaveChanges();
        }
    }
}