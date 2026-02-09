using Application.DTO;
using Domain.Entities;
using Application.interfaces;
namespace Application.Services.SupportTickets
{
    public class SupportTicketService : ISupportTicketService
    {
        private readonly ITicket _ticket;

        //constructor

        public SupportTicketService(ITicket ticket)
        {
            _ticket = ticket;
        }
       public List<SupportTicket> GetAllTickets()
       {
          List<SupportTicket> _tickets = _ticket.GetAllTickets();
          return _tickets;
       }


        public SupportTicket GetTicketById(int id)
        {
           return _ticket.GetTicketById(id);
        }
        public void CreateTicket(TicketCreateDTO ticketDTO)
        {
            _ticket.CreateTicket(ticketDTO);
        }
        public void UpdateTicket(int id, TicketUpdateDTO ticketDTO)
        {
            _ticket.UpdateTicket(id, ticketDTO);
        }
    }
}