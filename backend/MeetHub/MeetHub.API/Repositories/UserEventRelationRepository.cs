using AutoMapper;
using MeetHub.API.Context;
using MeetHub.API.Entities;
using MeetHub.API.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MeetHub.API.Repositories
{
    /// <summary>
    /// The user-event relation repository interface
    /// </summary>
    public interface IUserEventRelationRepository
    {
        #region Methods

        /// <summary>
        /// Gets all user-event relations from database asyncronous
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<UserEventRelationModel>> GetAllUserEventRelationsAsync();

        /// <summary>
        /// Gets all user-event relations by user id from database asyncronous
        /// </summary>
        /// <param name="userId"> The user id</param>
        /// <returns></returns>
        Task<IEnumerable<UserEventRelationModel>> GetAllUserEventRelationByUserIdAsync(int userId);

        /// <summary>
        /// Gets all user-event relations by event id from database asyncronous
        /// </summary>
        /// <param name="eventId"> The event id</param>
        /// <returns></returns>
        Task<IEnumerable<UserEventRelationModel>> GetAllUserEventRelationByEventIdAsync(int eventId);

        /// <summary>
        /// Gets user-event specific relation from database asyncronous
        /// </summary>
        /// <param name="userId"> The user id </param>
        /// <param name="eventId"> The event id </param>
        /// <returns></returns>
        Task<UserEventRelationModel> GetUserEventRelationByIdAsync(int userId, int eventId);

        /// <summary>
        /// Adds user-event relation to database
        /// </summary>
        /// <param name="userEventRelation"> The user-event relation model </param>
        void AddUserEventRelation(UserEventRelationModel userEventRelation);

        /// <summary>
        /// Removes user-event relation from database
        /// </summary>
        /// <param name="userId"> The user id </param>
        /// <param name="eventId"> The event id </param>
        void DeleteUserEventRelation(int userId, int eventId);

        #endregion Methods

    }

    /// <summary>
    /// The user-event relation repository implementation class
    /// </summary>
    public class UserEventRelationRepository : IUserEventRelationRepository
    {
        #region Fields

        private readonly MeetHubDatabaseContext _rmDatabaseContext;
        private readonly IMapper _rmMapper;


        #endregion Fields

        #region Constructor

        public UserEventRelationRepository(MeetHubDatabaseContext databaseContext, IMapper mapper)
        {
            _rmDatabaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
            _rmMapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Gets all user-event relations from database asyncronous
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserEventRelationModel>> GetAllUserEventRelationsAsync()
        {
            var relations = await _rmDatabaseContext.UserEventRelations.ToListAsync();
            return _rmMapper.Map<IEnumerable<UserEventRelationModel>>(relations);
        }

        /// <summary>
        /// Gets all user-event relations by user id from database asyncronous
        /// </summary>
        /// <param name="userId"> The user id</param>
        /// <returns></returns>
        public async Task<IEnumerable<UserEventRelationModel>> GetAllUserEventRelationByUserIdAsync(int userId)
        {
            var relations = await _rmDatabaseContext.UserEventRelations.Where(rel => rel.UserId == userId).ToListAsync();
            return _rmMapper.Map<IEnumerable<UserEventRelationModel>>(relations);
        }

        /// <summary>
        /// Gets all user-event relations by user id from database asyncronous
        /// </summary>
        /// <param name="eventId"> The user id</param>
        /// <returns></returns>
        public async Task<IEnumerable<UserEventRelationModel>> GetAllUserEventRelationByEventIdAsync(int eventId)
        {
            var relations = await _rmDatabaseContext.UserEventRelations.Where(rel => rel.EventId == eventId).ToListAsync();
            return _rmMapper.Map<IEnumerable<UserEventRelationModel>>(relations);
        }

        /// <summary>
        /// Gets user-event specific relation from database asyncronous
        /// </summary>
        /// <param name="userId"> The user id </param>
        /// <param name="eventId"> The event id </param>
        /// <returns></returns>
        public async Task<UserEventRelationModel> GetUserEventRelationByIdAsync(int userId, int eventId)
        {
            var relation = await _rmDatabaseContext.UserEventRelations.FirstOrDefaultAsync(rel => rel.UserId == userId && rel.EventId == eventId);
            return _rmMapper.Map<UserEventRelationModel>(relation);
        }

        /// <summary>
        /// Adds user-event relation to database
        /// </summary>
        /// <param name="userEventRelation"> The user-event relation model </param>
        public void AddUserEventRelation(UserEventRelationModel userEventRelation)
        {
            try
            {
                var inserting_relation = _rmMapper.Map<UserEventRelation>(userEventRelation);
                _rmDatabaseContext.UserEventRelations.Add(inserting_relation);
                _rmDatabaseContext.SaveChanges();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("There was an issue with the inserting operation: \n" + ex.Message);
            }
        }

        /// <summary>
        /// Removes user-event relation from database
        /// </summary>
        /// <param name="userId"> The user id </param>
        /// <param name="eventId"> The event id </param>
        public void DeleteUserEventRelation(int userId, int eventId)
        {
            try
            {
                var relation = _rmDatabaseContext.UserEventRelations.FirstOrDefault(rel => rel.UserId == userId && rel.EventId == eventId);
                _rmDatabaseContext.UserEventRelations.Remove(relation);
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
