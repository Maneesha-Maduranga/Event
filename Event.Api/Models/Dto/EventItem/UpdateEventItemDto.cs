namespace Event.Api.Models.Dto.EventItem
{
    public class UpdateEventItemDto
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Organizer { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public bool IsFull { get; set; }
    }
}
