using MeetHub.API.Models;
using MeetHub.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MeetHub.API.Controllers
{
    /// <summary>
    /// The controller for user access level actions
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserAccessLevelController : ControllerBase
    {
        #region Fields

        private const string _cmGetByIdName = "GetUserAccessLevel";
        private readonly IUserAccessLevelRepository _rmUserAccessLevelRepository;

        #endregion Fields

        #region Constructor

        public UserAccessLevelController(IUserAccessLevelRepository userAccessLevelRepository)
        {
            _rmUserAccessLevelRepository = userAccessLevelRepository ?? throw new ArgumentNullException(nameof(userAccessLevelRepository));
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Gets all user access levels from repository
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpHead]
        public async Task<ActionResult<IEnumerable<UserAccessLevelModel>>> GetAllUserAccessLevels()
        {
            var user_access_levels = _rmUserAccessLevelRepository
                .GetAllUserAccessLevelsAsync()
                .GetAwaiter()
                .GetResult();

            return Ok(user_access_levels);
        }

        /// <summary>
        /// Gets a specific user access level using id
        /// </summary>
        /// <param name="id"> The id of the userAccessLevel </param>
        /// <returns></returns>
        [HttpGet("{id}", Name = _cmGetByIdName)]
        public async Task<ActionResult<UserAccessLevelModel>> GetUserAccessLevel(int id)
        {
            var user_access_level = _rmUserAccessLevelRepository
                .GetUserAccessLevelByIdAsync(id)
                .GetAwaiter()
                .GetResult();

            return Ok(user_access_level);
        }

        /// <summary>
        /// Adds new user access level
        /// </summary>
        /// <param name="userAccessLevel"> The user access level model </param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddUserAccessLevel(UserAccessLevelModel userAccessLevel)
        {
            _rmUserAccessLevelRepository.AddUserAccessLevel(userAccessLevel);
            return CreatedAtRoute(_cmGetByIdName, new { id = userAccessLevel.Id }, userAccessLevel);
        }

        /// <summary>
        /// Updates an existing user access level
        /// </summary>
        /// <param name="userAccessLevel"> The updated user access level model </param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateUserAccessLevel(UserAccessLevelModel userAccessLevel)
        {
            _rmUserAccessLevelRepository.UpdateUserAccessLevel(userAccessLevel);
            return NoContent();
        }

        /// <summary>
        /// Deletes an existion user access level
        /// </summary>
        /// <param name="id"> The user access level id </param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAccessLevel(int id)
        {
            _rmUserAccessLevelRepository.DeleteUserAccessLevel(id);
            return NoContent();
        }

        #endregion Methods

    }
}
