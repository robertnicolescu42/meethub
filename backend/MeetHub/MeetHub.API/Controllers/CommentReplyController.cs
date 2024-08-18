using MeetHub.API.Models;
using MeetHub.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MeetHub.API.Controllers
{
    /// <summary>
    /// The controller for comment reply actions
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CommentReplyController : ControllerBase
    {
        #region Fields

        private const string _cmGetByIdName = "GetCommentReply";
        private readonly ICommentReplyRepository _rmCommentReplyRepository;

        #endregion Fields

        #region Constructor

        public CommentReplyController(ICommentReplyRepository commentReplyRepository)
        {
            _rmCommentReplyRepository = commentReplyRepository ?? throw new ArgumentNullException(nameof(commentReplyRepository));
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Gets all comment replies from repository
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpHead]
        public async Task<ActionResult<IEnumerable<CommentReplyModel>>> GetAllCommentReplies()
        {
            var comment_replies = _rmCommentReplyRepository
                .GetAllCommentRepliesAsync()
                .GetAwaiter()
                .GetResult();

            return Ok(comment_replies);
        }

        /// <summary>
        /// Gets a specific comment reply using id
        /// </summary>
        /// <param name="id"> The id of the commentReply </param>
        /// <returns></returns>
        [HttpGet("{id}", Name = _cmGetByIdName)]
        public async Task<ActionResult<CommentReplyModel>> GetCommentReply(int id)
        {
            var comment_reply = _rmCommentReplyRepository
                .GetCommentReplyByIdAsync(id)
                .GetAwaiter()
                .GetResult();

            return Ok(comment_reply);
        }

        /// <summary>
        /// Adds new commentReply
        /// </summary>
        /// <param name="commentReply"> The comment reply model </param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddCommentReply(CommentReplyModel commentReply)
        {
            _rmCommentReplyRepository.AddCommentReply(commentReply);
            return CreatedAtRoute(_cmGetByIdName, new { id = commentReply.Id }, commentReply);
        }

        /// <summary>
        /// Updates an existing comment reply
        /// </summary>
        /// <param name="commentReply"> The updated comment reply model </param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateCommentReply(CommentReplyModel commentReply)
        {
            _rmCommentReplyRepository.UpdateCommentReply(commentReply);
            return NoContent();
        }

        /// <summary>
        /// Deletes an existion comment reply
        /// </summary>
        /// <param name="id"> The comment reply id </param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentReply(int id)
        {
            _rmCommentReplyRepository.DeleteCommentReply(id);
            return NoContent();
        }

        #endregion Methods

    }
}
