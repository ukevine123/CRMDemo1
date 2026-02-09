using Application.DTO;
using Domain.Entities;

namespace Application.interfaces
{
    public interface ITicket
    {
        public List<SupportTicket> GetAllTickets();

        public SupportTicket GetTicketById(int id);
        void CreateTicket(TicketCreateDTO ticketDTO);

        void UpdateTicket(int id, TicketUpdateDTO ticketDTO);
    }
}