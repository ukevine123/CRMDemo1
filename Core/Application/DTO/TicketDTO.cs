namespace Application.DTO
{
    public class TicketCreateDTO
    {
        public int CustomerId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime ResolvedAt { get; set; }
        public string Status { get; set; }

    }
    public class TicketUpdateDTO
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime ResolvedAt { get; set; }
        public string Status { get; set; }
    }
}