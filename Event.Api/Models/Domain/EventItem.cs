namespace Event.Api.Models.Domain
{
    public class EventItem
    {
        public Guid id { get; set; }
        public string Title { get; set; } 
        public string Location { get; set; }
        public int Capacity { get; set; }
        public string Status { get; set; }
    }
    
}
