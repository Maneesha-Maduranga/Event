using Event.Api.Context;
using Event.Api.Models.Domain;
using Event.Api.Repository.Interface;
using Microsoft.EntityFrameworkCore;


namespace Event.Api.Repository.Implementation
{
    public class EventItemRepository : IEventItemRepository
    {
        private readonly ApplicationDbContext dbContext;

        public EventItemRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<EventItem> CreateEventItem(EventItem eventItem)
        {
            await dbContext.AddAsync(eventItem);
            await dbContext.SaveChangesAsync();
            return eventItem;
        }

        public async Task<IEnumerable<EventItem>> GetAllEventItems()
        {
            return await dbContext.EventItems.ToListAsync();
        }

        public async Task<EventItem?> GetEventItem(Guid id)
        {
            return await dbContext.EventItems.FirstOrDefaultAsync(item => item.id == id);
        }

        public async Task<EventItem?> UpdateEventItem(EventItem eventItem)
        {
           var exEventItem = await dbContext.EventItems.FirstOrDefaultAsync(item => item.id == eventItem.id);
           if (exEventItem != null)
            {

                exEventItem.Title = eventItem.Title;
                exEventItem.Location = eventItem.Location;
                exEventItem.Status = eventItem.Status;
                exEventItem.Date = eventItem.Date;
                exEventItem.Capacity = eventItem.Capacity;
               

               
                dbContext.EventItems.Update(exEventItem);
                await dbContext.SaveChangesAsync();
                return exEventItem;
            }

            return null;
        }

        public async Task<EventItem?> DeleteEventItem(Guid id)
        {
           var isEventItem = await dbContext.EventItems.FirstOrDefaultAsync(item => item.id == id);

           if (isEventItem != null)
           {
                dbContext.EventItems.Remove(isEventItem);
                await dbContext.SaveChangesAsync();
                return isEventItem;
           }
            return null; 
        }
    }
}
