using MeetHub.API.Models;
using MeetHub.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MeetHub.API.Controllers
{
    /// <summary>
    /// The controller for generated invite actions
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class GeneratedInviteController : ControllerBase
    {
        #region Fields

        private const string _cmGetByIdName = "GetGeneratedInvite";
        private readonly IGeneratedInviteRepository _rmGeneratedInviteRepository;

        #endregion Fields

        #region Constructor

        public GeneratedInviteController(IGeneratedInviteRepository generatedInviteRepository)
        {
            _rmGeneratedInviteRepository = generatedInviteRepository ?? throw new ArgumentNullException(nameof(generatedInviteRepository));
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Gets all generated invites from repository
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpHead]
        public async Task<ActionResult<IEnumerable<GeneratedInviteModel>>> GetAllGeneratedInvites()
        {
            var generated_invites = _rmGeneratedInviteRepository
                .GetAllGeneratedInvitesAsync()
                .GetAwaiter()
                .GetResult();

            return Ok(generated_invites);
        }

        /// <summary>
        /// Gets a specific generated invite using id
        /// </summary>
        /// <param name="id"> The id of the generated invite </param>
        /// <returns></returns>
        [HttpGet("{id}", Name = _cmGetByIdName)]
        public async Task<ActionResult<GeneratedInviteModel>> GetGeneratedInvite(int id)
        {
            var generated_invite = _rmGeneratedInviteRepository
                .GetGeneratedInviteByIdAsync(id)
                .GetAwaiter()
                .GetResult();

            return Ok(generated_invite);
        }

        /// <summary>
        /// Adds new generatedInvite
        /// </summary>
        /// <param name="generatedInvite"> The generated invite model </param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddGeneratedInvite(GeneratedInviteModel generatedInvite)
        {
            _rmGeneratedInviteRepository.AddGeneratedInvite(generatedInvite);
            return CreatedAtRoute(_cmGetByIdName, new { id = generatedInvite.Id }, generatedInvite);
        }

        /// <summary>
        /// Updates an existing generated invite
        /// </summary>
        /// <param name="generatedInvite"> The updated generated invite model </param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateGeneratedInvite(GeneratedInviteModel generatedInvite)
        {
            _rmGeneratedInviteRepository.UpdateGeneratedInvite(generatedInvite);
            return NoContent();
        }

        /// <summary>
        /// Deletes an existion generated invite
        /// </summary>
        /// <param name="id"> The generated invite id </param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeneratedInvite(int id)
        {
            _rmGeneratedInviteRepository.DeleteGeneratedInvite(id);
            return NoContent();
        }

        #endregion Methods

    }
}
