using Application.DTO;
using Application.interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class TicketRepository : ITicket
    {
        private readonly ApplicationDbContext _dbContext;

        public TicketRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        // Retrieving tickets

        public List<SupportTicket> GetAllTickets()
        {
            List<SupportTicket> _tickets = _dbContext.SupportTickets.ToList();
            return _tickets;
        }  
        public SupportTicket GetTicketById(int id)
        {
           return _dbContext.SupportTickets.FirstOrDefault(c=>c.Id==id);
        }
        public void CreateTicket(TicketCreateDTO ticketDTO)
        {
            SupportTicket ticket = new SupportTicket
            {
                CustomerId = ticketDTO.CustomerId,
                Subject = ticketDTO.Subject,
                Description = ticketDTO.Description,
                ResolvedAt = ticketDTO.ResolvedAt,
                Status = ticketDTO.Status,
                CreatedAt = DateTime.Now,
                CreatedById = 1
            };
            _dbContext.SupportTickets.Add(ticket);
            _dbContext.SaveChanges();
        }

        public void UpdateTicket(int id, TicketUpdateDTO ticketDTO)
        {
            var ticket = _dbContext.SupportTickets.Find(id);
            if (ticket == null) return;
            
                ticket.Subject = ticketDTO.Subject;
                ticket.Description = ticketDTO.Description;
                ticket.ResolvedAt = ticketDTO.ResolvedAt;
                ticket.Status = ticketDTO.Status;

                _dbContext.SaveChanges();
        }
    }
}