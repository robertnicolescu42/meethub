using MeetHub.API.Models;
using MeetHub.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MeetHub.API.Controllers
{
    /// <summary>
    /// The controller for event constraint type actions
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EventConstraintTypeController : ControllerBase
    {
        #region Fields

        private const string _cmGetByIdName = "GetEventConstraintType";
        private readonly IEventConstraintTypeRepository _rmEventConstraintTypeRepository;

        #endregion Fields

        #region Constructor

        public EventConstraintTypeController(IEventConstraintTypeRepository eventConstraintTypeRepository)
        {
            _rmEventConstraintTypeRepository = eventConstraintTypeRepository ?? throw new ArgumentNullException(nameof(eventConstraintTypeRepository));
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Gets all event constraint types from repository
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpHead]
        public async Task<ActionResult<IEnumerable<EventConstraintTypeModel>>> GetAllEventConstraintTypes()
        {
            var event_constraint_types = _rmEventConstraintTypeRepository
                .GetAllEventConstraintTypesAsync()
                .GetAwaiter()
                .GetResult();

            return Ok(event_constraint_types);
        }

        /// <summary>
        /// Gets a specific event constraint type using id
        /// </summary>
        /// <param name="id"> The id of the eventConstraintType </param>
        /// <returns></returns>
        [HttpGet("{id}", Name = _cmGetByIdName)]
        public async Task<ActionResult<EventConstraintTypeModel>> GetEventConstraintType(int id)
        {
            var event_constraint_type = _rmEventConstraintTypeRepository
                .GetEventConstraintTypeByIdAsync(id)
                .GetAwaiter()
                .GetResult();

            return Ok(event_constraint_type);
        }

        /// <summary>
        /// Adds new eventConstraintType
        /// </summary>
        /// <param name="eventConstraintType"> The event constraint type model </param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddEventConstraintType(EventConstraintTypeModel eventConstraintType)
        {
            _rmEventConstraintTypeRepository.AddEventConstraintType(eventConstraintType);
            return CreatedAtRoute(_cmGetByIdName, new { id = eventConstraintType.Id }, eventConstraintType);
        }

        /// <summary>
        /// Updates an existing event constraint type
        /// </summary>
        /// <param name="eventConstraintType"> The updated event constraint type model </param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateEventConstraintType(EventConstraintTypeModel eventConstraintType)
        {
            _rmEventConstraintTypeRepository.UpdateEventConstraintType(eventConstraintType);
            return NoContent();
        }

        /// <summary>
        /// Deletes an existion event constraint type
        /// </summary>
        /// <param name="id"> The event constraint type id </param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventConstraintType(int id)
        {
            _rmEventConstraintTypeRepository.DeleteEventConstraintType(id);
            return NoContent();
        }

        #endregion Methods

    }
}
