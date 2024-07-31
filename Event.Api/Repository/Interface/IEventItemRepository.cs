using Event.Api.Models.Domain;

namespace Event.Api.Repository.Interface
{
    public interface IEventItemRepository
    {
        Task<EventItem> CreateEventItem(EventItem eventItem);
        Task<IEnumerable<EventItem>> GetAllEventItems();
        Task<EventItem?> GetEventItem(Guid id);
        Task<EventItem?> UpdateEventItem(EventItem eventItem);
        Task<EventItem?> DeleteEventItem(Guid id);

    }
}
