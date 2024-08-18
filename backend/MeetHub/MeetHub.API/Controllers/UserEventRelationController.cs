using MeetHub.API.Models;
using MeetHub.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MeetHub.API.Controllers
{
    /// <summary>
    /// The controller for user event relation actions
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserEventRelationController : ControllerBase
    {
        #region Fields

        private const string _cmGetByIdName = "GetRelation";
        private readonly IUserEventRelationRepository _rmUserEventRelationRepository;

        #endregion Fields

        #region Constructor

        public UserEventRelationController(IUserEventRelationRepository userEventRelationRepository)
        {
            _rmUserEventRelationRepository = userEventRelationRepository ?? throw new ArgumentNullException(nameof(userEventRelationRepository));
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Gets all user event relations from repository
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpHead]
        public async Task<ActionResult<IEnumerable<UserEventRelationModel>>> GetAllRelations()
        {
            var relations = _rmUserEventRelationRepository
                .GetAllUserEventRelationsAsync()
                .GetAwaiter()
                .GetResult();

            return Ok(relations);
        }

        /// <summary>
        /// Gets all user event relations from repository by user id
        /// </summary>
        /// <param name="id"> The id of the user </param>
        /// <returns></returns>
        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<UserEventRelationModel>>> GetRelationByUserId(int id)
        {
            var relations = _rmUserEventRelationRepository
                .GetAllUserEventRelationByUserIdAsync(id)
                .GetAwaiter()
                .GetResult();
            return Ok(relations);
        }

        /// <summary>
        /// Gets all user event relations from repository by event id
        /// </summary>
        /// <param name="id"> The id of the event </param>
        /// <returns></returns>
        [HttpGet("event/{id}")]
        public async Task<ActionResult<IEnumerable<UserEventRelationModel>>> GetRelationByEventId(int id)
        {
            var relations = _rmUserEventRelationRepository
                .GetAllUserEventRelationByEventIdAsync(id)
                .GetAwaiter()
                .GetResult();
            return Ok(relations);
        }

        /// <summary>
        /// Gets the user event relation
        /// </summary>
        /// <param name="userId"> The user id</param>
        /// <param name="eventId"> The event id</param>
        /// <returns></returns>
        [HttpGet("user/{userId}/event/{eventId}",Name = _cmGetByIdName)]
        public async Task<ActionResult<UserEventRelationModel>> GetUserEventRelation(int userId, int eventId)
        {
            var relation = _rmUserEventRelationRepository
                .GetUserEventRelationByIdAsync(userId, eventId)
                .GetAwaiter()
                .GetResult();

            return Ok(relation);
        }

        /// <summary>
        /// Adds new user event relation
        /// </summary>
        /// <param name="relation"> The user event relation model </param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddRelation(UserEventRelationModel relation)
        {
            _rmUserEventRelationRepository.AddUserEventRelation(relation);
            return CreatedAtRoute(_cmGetByIdName, new { userId = relation.UserId, eventId = relation.EventId }, relation);
        }

        /// <summary>
        /// Deletes an existing relation
        /// </summary>
        /// <param name="userId"> The user id </param>
        /// <param name="eventId"> The event id </param>
        /// <returns></returns>
        [HttpDelete("user/{userId}/event/{eventId}")]
        public async Task<IActionResult> DeleteRelation(int userId, int eventId)
        {
            _rmUserEventRelationRepository.DeleteUserEventRelation(userId, eventId);
            return NoContent();
        }

        #endregion Methods
    }
}
