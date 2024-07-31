using Event.Api.Models.Domain;
using Event.Api.Models.Dto.EventItem;
using Event.Api.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Event.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventItemController : ControllerBase
    {
        private readonly IEventItemRepository eventItemRepository;

        public EventItemController(IEventItemRepository eventItemRepository)
        {
            this.eventItemRepository = eventItemRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEventItem([FromBody]CreateEventItemDto request)
        {
            var newEventItem = new EventItem
            {
                Title = request.Title,
                Capacity = request.Capacity,
                Date = request.Date,
                Description = request.Description,
                IsFull = request.IsFull,
                Location = request.Location,
                Organizer = request.Organizer,
                Price = request.Price,
            };

            await eventItemRepository.CreateEventItem(newEventItem);

            //Map Through Dto and create new Respnose
            var response = new ReadEventItemDto
            {
                id = newEventItem.id,
                Title = newEventItem.Title,
                Price = newEventItem.Price,
                Capacity = newEventItem.Capacity,
                Description = newEventItem.Description,
                Date = newEventItem.Date,
                IsFull = newEventItem.IsFull,
                Location = newEventItem.Location,
                Organizer = newEventItem.Organizer,
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEventItem()
        {
            var eventItems = await eventItemRepository.GetAllEventItems();
            var response = new List<ReadEventItemDto>();

            //map through eventItem and create new Response
            foreach (var eventItem in eventItems)
            {
                response.Add(new ReadEventItemDto 
                { 
                    id= eventItem.id,
                    Title= eventItem.Title,
                    Price= eventItem.Price,
                    Capacity = eventItem.Capacity,
                    Organizer = eventItem.Organizer,
                    Location = eventItem.Location,
                    Date = eventItem.Date,
                    Description = eventItem.Description,
                    IsFull = eventItem.IsFull,
                });
            }

            return Ok(response);
        }


        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEventItem([FromRoute]Guid id)
        {
            var isEventItem = await eventItemRepository.GetEventItem(id);

            //Check Whether item exist in give Id
            if(isEventItem == null)
            {
                return NotFound();
            }

            var response = new ReadEventItemDto
            {
                id = isEventItem.id,
                Capacity = isEventItem.Capacity,
                Date = isEventItem.Date,
                Description = isEventItem.Description,
                IsFull = isEventItem.IsFull,
                Location = isEventItem.Location,
                Organizer = isEventItem.Organizer,
                Price = isEventItem.Price,
                Title = isEventItem.Title
            };

            return Ok(response);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEventItem([FromRoute]Guid id, [FromBody]UpdateEventItemDto request)
        {
            var newEventItem = new EventItem
            {
                id = id,
                Title = request.Title,
                Capacity = request.Capacity,
                Description = request.Description,
                Date = request.Date,
                IsFull = request.IsFull,
                Location = request.Location,
                Organizer = request.Organizer,
                Price = request.Price,

            };

           var isEventItem = await eventItemRepository.UpdateEventItem(newEventItem);

           if(isEventItem == null)
           {
                return NotFound();
           }

            var response = new ReadEventItemDto
           {
                id = isEventItem.id,
                Capacity = isEventItem.Capacity,
                Date = isEventItem.Date,
                Description = isEventItem.Description,
                IsFull = isEventItem.IsFull,
                Location = isEventItem.Location,
                Organizer = isEventItem.Organizer,
                Price = isEventItem.Price,
                Title = isEventItem.Title,

            };
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEventItem([FromRoute]Guid id)
        {
            var isEventItem = await eventItemRepository.DeleteEventItem(id);
            if(isEventItem == null)
            {  
                return NotFound(); 
            }
            return Ok(isEventItem.id);
        }
    }
}
