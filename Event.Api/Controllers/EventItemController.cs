using Event.Api.Models.Domain;
using Event.Api.Models.Dto.EventItem;
using Event.Api.Repository.Interface;
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
               Capacity = request.Capacity,
               Title = request.Title,
               Status = request.Status,
               Location = request.Location,
              
            };

            await eventItemRepository.CreateEventItem(newEventItem);

            //Map Through Dto and create new Respnose
            var response = new ReadEventItemDto
            {
               id = newEventItem.id,
               Capacity = newEventItem.Capacity,
               Location = newEventItem.Location,
               Status = newEventItem.Status,
               Title = newEventItem.Title
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
                    Capacity = eventItem.Capacity,
                    Location = eventItem.Location,
                    Status = eventItem.Status,
                    Title =  eventItem.Title
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
                Location = isEventItem.Location,
                Title = isEventItem.Title,
                Status = isEventItem.Status
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
                Capacity = request.Capacity,
                Location = request.Location,
                Status = request.Status,
                Title = request.Title

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
               Title =  isEventItem.Title,
               Status = isEventItem.Status,
               Location = isEventItem.Location

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
