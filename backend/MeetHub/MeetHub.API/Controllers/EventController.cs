using MeetHub.API.Models;
using MeetHub.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MeetHub.API.Controllers
{
    /// <summary>
    /// The controller for event actions
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        #region Fields

        private const string _cmGetByIdName = "GetEvent";
        private readonly IEventRepository _rmEventRepository;

        #endregion Fields

        #region Constructor

        public EventController(IEventRepository eventRepository)
        {
            _rmEventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Gets all events from repository
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpHead]
        public async Task<ActionResult<IEnumerable<EventModel>>> GetAllEvents()
        {
            var events = _rmEventRepository
                .GetAllEventsAsync()
                .GetAwaiter()
                .GetResult();

            return Ok(events);
        }

        /// <summary>
        /// Gets a specific event using id
        /// </summary>
        /// <param name="id"> The id of the event </param>
        /// <returns></returns>
        [HttpGet("{id}", Name = _cmGetByIdName)]
        public async Task<ActionResult<EventModel>> GetEvent(int id)
        {
            var event_model = _rmEventRepository
                .GetEventByIdAsync(id)
                .GetAwaiter()
                .GetResult();

            return Ok(event_model);
        }

        /// <summary>
        /// Adds new event
        /// </summary>
        /// <param name="event"> The event model </param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddEvent(EventModel event_model)
        {
            _rmEventRepository.AddEvent(event_model);
            return CreatedAtRoute(_cmGetByIdName, new { id = event_model.Id }, event_model);
        }

        /// <summary>
        /// Updates an existing event
        /// </summary>
        /// <param name="event"> The updated event model </param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateEvent(EventModel event_model)
        {
            _rmEventRepository.UpdateEvent(event_model);
            return NoContent();
        }

        /// <summary>
        /// Deletes an existion event
        /// </summary>
        /// <param name="id"> The event id </param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            _rmEventRepository.DeleteEvent(id);
            return NoContent();
        }

        #endregion Methods

    }
}
