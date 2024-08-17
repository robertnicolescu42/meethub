using MeetHub.API.Models;
using MeetHub.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MeetHub.API.Controllers
{
    /// <summary>
    /// The controller for user actions
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        #region Fields

        private const string _cmGetByIdName = "GetUser";
        private readonly IUserRepository _rmUserRepository;

        #endregion Fields

        #region Constructor

        public UserController(IUserRepository userRepository)
        {
            _rmUserRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Gets all users from repository
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpHead]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetAllUsers()
        {
            var users = _rmUserRepository
                .GetAllUsersAsync()
                .GetAwaiter()
                .GetResult();

            return Ok(users);
        }

        /// <summary>
        /// Gets a specific user using id
        /// </summary>
        /// <param name="id"> The id of the user </param>
        /// <returns></returns>
        [HttpGet("{id}", Name = _cmGetByIdName)]
        public async Task<ActionResult<UserModel>> GetUser(int id)
        {
            var user = _rmUserRepository
                .GetUserByIdAsync(id)
                .GetAwaiter()
                .GetResult();

            return Ok(user);
        }

        /// <summary>
        /// Adds new user
        /// </summary>
        /// <param name="user"> The user model </param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddUser(UserModel user)
        {
            _rmUserRepository.AddUser(user);
            return CreatedAtRoute(_cmGetByIdName, new { id = user.Id }, user);
        }

        /// <summary>
        /// Updates an existing user
        /// </summary>
        /// <param name="user"> The updated user model </param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserModel user)
        {
            _rmUserRepository.UpdateUser(user);
            return NoContent();
        }

        /// <summary>
        /// Deletes an existion user
        /// </summary>
        /// <param name="id"> The user id </param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            _rmUserRepository .DeleteUser(id);
            return NoContent();
        }

        #endregion Methods
    }
}
