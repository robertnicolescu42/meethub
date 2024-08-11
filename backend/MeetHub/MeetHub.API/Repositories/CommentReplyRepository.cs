using AutoMapper;
using MeetHub.API.Context;
using MeetHub.API.Entities;
using MeetHub.API.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MeetHub.API.Repositories
{
    /// <summary>
    /// The comment reply repository interface
    /// </summary>
    public interface ICommentReplyRepository
    {
        #region Methods

        /// <summary>
        /// Gets all comment replies from database asyncronous
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CommentReplyModel>> GetAllCommentRepliesAsync();

        /// <summary>
        /// Gets comment reply from database asyncronous
        /// </summary>
        /// <param name="commentReplyId"> The commentReply id </param>
        /// <returns></returns>
        Task<CommentReplyModel> GetCommentReplyByIdAsync(int commentReplyId);

        /// <summary>
        /// Adds commentReply to database
        /// </summary>
        /// <param name="commentReply"> The commentReply model </param>
        void AddCommentReply(CommentReplyModel commentReply);

        /// <summary>
        /// Updates the comment reply from dataabase
        /// </summary>
        /// <param name="commentReply"> The updated commentReply model</param>
        void UpdateCommentReply(CommentReplyModel commentReply);

        /// <summary>
        /// Removes comment reply from database
        /// </summary>
        /// <param name="commentReplyId"> The commentReply id </param>
        void DeleteCommentReply(int commentReplyId);

        #endregion Methods
    }

    /// <summary>
    /// The comment reply repository implementation class
    /// </summary>
    public class CommentReplyRepository : ICommentReplyRepository
    {
        #region Fields

        private readonly MeetHubDatabaseContext _rmDatabaseContext;
        private readonly IMapper _rmMapper;

        #endregion Fields

        #region Constructor

        public CommentReplyRepository(MeetHubDatabaseContext databaseContext, IMapper mapper)
        {
            _rmDatabaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
            _rmMapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Gets all comment replys from database asyncronous
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CommentReplyModel>> GetAllCommentRepliesAsync()
        {
            var comment_replys = await _rmDatabaseContext.CommentReplies.ToListAsync();
            return _rmMapper.Map<IEnumerable<CommentReplyModel>>(comment_replys);
        }

        /// <summary>
        /// Gets comment reply from database asyncronous
        /// </summary>
        /// <param name="commentReplyId"> The comment reply id </param>
        /// <returns></returns>
        public async Task<CommentReplyModel> GetCommentReplyByIdAsync(int commentReplyId)
        {
            var comment_reply = await _rmDatabaseContext.CommentReplies.FirstOrDefaultAsync(commentReply => commentReply.Id == commentReplyId);
            return _rmMapper.Map<CommentReplyModel>(comment_reply);
        }

        /// <summary>
        /// Adds commentReply to database
        /// </summary>
        /// <param name="commentReply"> The comment reply model </param>
        public async void AddCommentReply(CommentReplyModel commentReply)
        {
            try
            {
                var inserting_comment_reply = _rmMapper.Map<CommentReply>(commentReply);
                await _rmDatabaseContext.CommentReplies.AddAsync(inserting_comment_reply);
                await _rmDatabaseContext.SaveChangesAsync();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("There was an issue with the inserting operation: \n" + ex.Message);
            }
        }

        /// <summary>
        /// Update the comment reply from dataabase
        /// </summary>
        /// <param name="commentReply"> The updated comment reply model</param>
        public async void UpdateCommentReply(CommentReplyModel commentReply)
        {
            try
            {
                var updating_comment_reply = _rmMapper.Map<CommentReply>(commentReply);
                _rmDatabaseContext.CommentReplies.Update(updating_comment_reply);
                await _rmDatabaseContext.SaveChangesAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("There was an issue with the updating operation: \n" + ex.Message);
            }
        }

        /// <summary>
        /// Removes comment reply from database
        /// </summary>
        /// <param name="commentReplyId"> The comment reply id </param>
        public async void DeleteCommentReply(int commentReplyId)
        {
            try
            {
                var comment_reply = await _rmDatabaseContext.CommentReplies.FirstOrDefaultAsync(cr => cr.Id == commentReplyId);
                _rmDatabaseContext.CommentReplies.Remove(comment_reply);
                await _rmDatabaseContext.SaveChangesAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("There was an issue with the removing operation: \n" + ex.Message);
            }
        }


        #endregion Methods
    }
}
