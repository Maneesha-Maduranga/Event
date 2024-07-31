using Event.Api.Models.Domain;

namespace Event.Api.Models.Dto.EventItem
{
    public class CreateEventItemDto
    {
        public string Title { get; set; }
      
        public string Location { get; set; }
        public int Capacity { get; set; }

        public string Status { get; set; }
    }
   
}
