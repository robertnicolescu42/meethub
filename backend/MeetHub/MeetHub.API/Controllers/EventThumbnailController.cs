using MeetHub.API.Models;
using MeetHub.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MeetHub.API.Controllers
{
    /// <summary>
    /// The controller for event thumbnail actions
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EventThumbnailController : ControllerBase
    {
        #region Fields

        private const string _cmGetByIdName = "GetEventThumbnail";
        private readonly IEventThumbnailRepository _rmEventThumbnailRepository;

        #endregion Fields

        #region Constructor

        public EventThumbnailController(IEventThumbnailRepository eventThumbnailRepository)
        {
            _rmEventThumbnailRepository = eventThumbnailRepository ?? throw new ArgumentNullException(nameof(eventThumbnailRepository));
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Gets all event thumbnails from repository
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpHead]
        public async Task<ActionResult<IEnumerable<EventThumbnailModel>>> GetAllEventThumbnails()
        {
            var event_thumbnails = _rmEventThumbnailRepository
                .GetAllEventThumbnailsAsync()
                .GetAwaiter()
                .GetResult();

            return Ok(event_thumbnails);
        }

        /// <summary>
        /// Gets a specific event thumbnail using id
        /// </summary>
        /// <param name="id"> The id of the eventThumbnail </param>
        /// <returns></returns>
        [HttpGet("{id}", Name = _cmGetByIdName)]
        public async Task<ActionResult<EventThumbnailModel>> GetEventThumbnail(int id)
        {
            var event_thumbnail = _rmEventThumbnailRepository
                .GetEventThumbnailByIdAsync(id)
                .GetAwaiter()
                .GetResult();

            return Ok(event_thumbnail);
        }

        /// <summary>
        /// Adds new eventThumbnail
        /// </summary>
        /// <param name="eventThumbnail"> The event thumbnail model </param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddEventThumbnail(EventThumbnailModel eventThumbnail)
        {
            _rmEventThumbnailRepository.AddEventThumbnail(eventThumbnail);
            return CreatedAtRoute(_cmGetByIdName, new { id = eventThumbnail.Id }, eventThumbnail);
        }

        /// <summary>
        /// Updates an existing event thumbnail
        /// </summary>
        /// <param name="eventThumbnail"> The updated event thumbnail model </param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateEventThumbnail(EventThumbnailModel eventThumbnail)
        {
            _rmEventThumbnailRepository.UpdateEventThumbnail(eventThumbnail);
            return NoContent();
        }

        /// <summary>
        /// Deletes an existion event thumbnail
        /// </summary>
        /// <param name="id"> The event thumbnail id </param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventThumbnail(int id)
        {
            _rmEventThumbnailRepository.DeleteEventThumbnail(id);
            return NoContent();
        }

        #endregion Methods

    }
}
