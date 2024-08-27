using MeetHub.API.Models;
using MeetHub.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MeetHub.API.Controllers
{
    /// <summary>
    /// The controller for comment actions
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        #region Fields

        private const string _cmGetByIdName = "GetComment";
        private readonly ICommentRepository _rmCommentRepository;

        #endregion Fields

        #region Constructor

        public CommentController(ICommentRepository commentRepository)
        {
            _rmCommentRepository = commentRepository ?? throw new ArgumentNullException(nameof(commentRepository));
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Gets all comments from repository
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpHead]
        public async Task<ActionResult<IEnumerable<CommentModel>>> GetAllComments()
        {
            var comments = _rmCommentRepository
                .GetAllCommentsAsync()
                .GetAwaiter()
                .GetResult();

            return Ok(comments);
        }

        /// <summary>
        /// Gets a specific comment using id
        /// </summary>
        /// <param name="id"> The id of the comment </param>
        /// <returns></returns>
        [HttpGet("{id}", Name = _cmGetByIdName)]
        public async Task<ActionResult<CommentModel>> GetComment(int id)
        {
            var comment = _rmCommentRepository
                .GetCommentByIdAsync(id)
                .GetAwaiter()
                .GetResult();

            return Ok(comment);
        }

        /// <summary>
        /// Adds new comment
        /// </summary>
        /// <param name="comment"> The comment model </param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddComment(CommentModel comment)
        {
            _rmCommentRepository.AddComment(comment);
            return CreatedAtRoute(_cmGetByIdName, new { id = comment.Id }, comment);
        }

        /// <summary>
        /// Updates an existing comment
        /// </summary>
        /// <param name="comment"> The updated comment model </param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateComment(CommentModel comment)
        {
            _rmCommentRepository.UpdateComment(comment);
            return NoContent();
        }

        /// <summary>
        /// Deletes an existion comment
        /// </summary>
        /// <param name="id"> The comment id </param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            _rmCommentRepository.DeleteComment(id);
            return NoContent();
        }

        #endregion Methods

    }
}
