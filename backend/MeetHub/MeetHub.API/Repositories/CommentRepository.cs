using AutoMapper;
using MeetHub.API.Context;
using MeetHub.API.Entities;
using MeetHub.API.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MeetHub.API.Repositories
{
    /// <summary>
    /// The comment repository interface
    /// </summary>
    public interface ICommentRepository
    {
        #region Methods

        /// <summary>
        /// Gets all comments from database asyncronous
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CommentModel>> GetAllCommentsAsync();

        /// <summary>
        /// Gets comment from database asyncronous
        /// </summary>
        /// <param name="commentId"> The comment id </param>
        /// <returns></returns>
        Task<CommentModel> GetCommentByIdAsync(int commentId);

        /// <summary>
        /// Adds comment to database
        /// </summary>
        /// <param name="comment"> The comment model </param>
        void AddComment(CommentModel comment);

        /// <summary>
        /// Updates the comment from dataabase
        /// </summary>
        /// <param name="comment"> The updated comment model</param>
        void UpdateComment(CommentModel comment);

        /// <summary>
        /// Removes comment from database
        /// </summary>
        /// <param name="commentId"> The comment id </param>
        void DeleteComment(int commentId);

        #endregion Methods
    }

    /// <summary>
    /// The comment repository implementation class
    /// </summary>
    public class CommentRepository : ICommentRepository
    {
        #region Fields

        private readonly MeetHubDatabaseContext _rmDatabaseContext;
        private readonly IMapper _rmMapper;

        #endregion Fields

        #region Constructor

        public CommentRepository(MeetHubDatabaseContext databaseContext, IMapper mapper)
        {
            _rmDatabaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
            _rmMapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Gets all comments from database asyncronous
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CommentModel>> GetAllCommentsAsync()
        {
            var comments = await _rmDatabaseContext.Comments.ToListAsync();
            return _rmMapper.Map<IEnumerable<CommentModel>>(comments);
        }

        /// <summary>
        /// Gets comment from database asyncronous
        /// </summary>
        /// <param name="commentId"> The comment id </param>
        /// <returns></returns>
        public async Task<CommentModel> GetCommentByIdAsync(int commentId)
        {
            var comment = await _rmDatabaseContext.Comments.FirstOrDefaultAsync(c => c.Id == commentId);
            return _rmMapper.Map<CommentModel>(comment);
        }

        /// <summary>
        /// Adds comment to database
        /// </summary>
        /// <param name="comment"> The comment model </param>
        public void AddComment(CommentModel comment)
        {
            try
            {
                var inserting_comment = _rmMapper.Map<Comment>(comment);
                _rmDatabaseContext.Comments.Add(inserting_comment);
                _rmDatabaseContext.SaveChanges();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("There was an issue with the inserting operation: \n" + ex.Message);
            }
        }

        /// <summary>
        /// Updates the comment from dataabase
        /// </summary>
        /// <param name="comment"> The updated comment model</param>
        public void UpdateComment(CommentModel comment)
        {
            try
            {
                var updating_comment = _rmMapper.Map<Comment>(comment);
                _rmDatabaseContext.Comments.Update(updating_comment);
                _rmDatabaseContext.SaveChanges();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("There was an issue with the updating operation: \n" + ex.Message);
            }
        }

        /// <summary>
        /// Removes comment from database
        /// </summary>
        /// <param name="commentId"> The comment id </param>
        public void DeleteComment(int commentId)
        {
            try
            {
                var comment = _rmDatabaseContext.Comments.FirstOrDefault(c => c.Id == commentId);
                _rmDatabaseContext.Comments.Remove(comment);
                _rmDatabaseContext.SaveChanges();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("There was an issue with the removing operation: \n" + ex.Message);
            }
        }

        #endregion Methods
    }
}
