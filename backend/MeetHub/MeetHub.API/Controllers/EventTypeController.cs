using MeetHub.API.Models;
using MeetHub.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MeetHub.API.Controllers
{
    /// <summary>
    /// The controller for event type actions
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EventTypeController : ControllerBase
    {
        #region Fields

        private const string _cmGetByIdName = "GetEventType";
        private readonly IEventTypeRepository _rmEventTypeRepository;

        #endregion Fields

        #region Constructor

        public EventTypeController(IEventTypeRepository eventTypeRepository)
        {
            _rmEventTypeRepository = eventTypeRepository ?? throw new ArgumentNullException(nameof(eventTypeRepository));
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Gets all event types from repository
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpHead]
        public async Task<ActionResult<IEnumerable<EventTypeModel>>> GetAllEventTypes()
        {
            var event_types = _rmEventTypeRepository
                .GetAllEventTypesAsync()
                .GetAwaiter()
                .GetResult();

            return Ok(event_types);
        }

        /// <summary>
        /// Gets a specific event type using id
        /// </summary>
        /// <param name="id"> The id of the eventType </param>
        /// <returns></returns>
        [HttpGet("{id}", Name = _cmGetByIdName)]
        public async Task<ActionResult<EventTypeModel>> GetEventType(int id)
        {
            var event_type = _rmEventTypeRepository
                .GetEventTypeByIdAsync(id)
                .GetAwaiter()
                .GetResult();

            return Ok(event_type);
        }

        /// <summary>
        /// Adds new eventType
        /// </summary>
        /// <param name="eventType"> The event type model </param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddEventType(EventTypeModel eventType)
        {
            _rmEventTypeRepository.AddEventType(eventType);
            return CreatedAtRoute(_cmGetByIdName, new { id = eventType.Id }, eventType);
        }

        /// <summary>
        /// Updates an existing event type
        /// </summary>
        /// <param name="eventType"> The updated event type model </param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateEventType(EventTypeModel eventType)
        {
            _rmEventTypeRepository.UpdateEventType(eventType);
            return NoContent();
        }

        /// <summary>
        /// Deletes an existion event type
        /// </summary>
        /// <param name="id"> The event type id </param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventType(int id)
        {
            _rmEventTypeRepository.DeleteEventType(id);
            return NoContent();
        }

        #endregion Methods

    }
}
