using Application.DTO;
using Domain.Entities;
namespace Application.Services.SupportTickets
{
    public interface ISupportTicketService
    {
        SupportTicket GetTicketById(int Id);
        public List<SupportTicket> GetAllTickets();
        void CreateTicket(TicketCreateDTO ticketDTO);
        void UpdateTicket(int id, TicketUpdateDTO ticketDTO);
    }
}