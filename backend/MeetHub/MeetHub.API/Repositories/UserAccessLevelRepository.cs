using AutoMapper;
using MeetHub.API.Context;
using MeetHub.API.Entities;
using MeetHub.API.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MeetHub.API.Repositories
{
    /// <summary>
    /// The user access level repository interface
    /// </summary>
    public interface IUserAccessLevelRepository
    {
        #region Methods

        /// <summary>
        /// Gets all user access levels from database asyncronous
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<UserAccessLevelModel>> GetAllUserAccessLevelsAsync();

        /// <summary>
        /// Gets user access level from database asyncronous
        /// </summary>
        /// <param name="user access levelId"> The user access level id </param>
        /// <returns></returns>
        Task<UserAccessLevelModel> GetUserAccessLevelByIdAsync(int userAccessLevelId);

        /// <summary>
        /// Adds user access level to database
        /// </summary>
        /// <param name="user access level"> The user access level model </param>
        void AddUserAccessLevel(UserAccessLevelModel userAccessLevel);

        /// <summary>
        /// Updates the user access level from dataabase
        /// </summary>
        /// <param name="user access level"> The updated user access level model</param>
        void UpdateUserAccessLevel(UserAccessLevelModel userAccessLevel);

        /// <summary>
        /// Removes user access level from database
        /// </summary>
        /// <param name="user access levelId"> The user access level id </param>
        void DeleteUserAccessLevel(int userAccessLevelId);

        #endregion Methods

    }

    /// <summary>
    /// The user access level repository implementation class
    /// </summary>
    public class UserAccessLevelRepository : IUserAccessLevelRepository
    {
        #region Fields

        private readonly MeetHubDatabaseContext _rmDatabaseContext;
        private readonly IMapper _rmMapper;

        #endregion Fields

        #region Constructor

        public UserAccessLevelRepository(MeetHubDatabaseContext databaseContext, IMapper mapper)
        {
            _rmDatabaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
            _rmMapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Gets all user access levels from database asyncronous
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserAccessLevelModel>> GetAllUserAccessLevelsAsync()
        {
            var user_access_levels = await _rmDatabaseContext.UserAccessLevels.ToListAsync();
            return _rmMapper.Map<IEnumerable<UserAccessLevelModel>>(user_access_levels);
        }

        /// <summary>
        /// Gets user access level from database asyncronous
        /// </summary>
        /// <param name="user access levelId"> The user access level id </param>
        /// <returns></returns>
        public async Task<UserAccessLevelModel> GetUserAccessLevelByIdAsync(int userAccessLevelId)
        {
            var user_access_level = await _rmDatabaseContext.UserAccessLevels.FirstOrDefaultAsync(userAccessLevel => userAccessLevel.Id == userAccessLevelId);
            return _rmMapper.Map<UserAccessLevelModel>(user_access_level);
        }

        /// <summary>
        /// Adds user access level to database
        /// </summary>
        /// <param name="user access level"> The user access level model </param>
        public async void AddUserAccessLevel(UserAccessLevelModel userAccessLevel)
        {
            try
            {
                var inserting_user_access_level = _rmMapper.Map<UserAccessLevel>(userAccessLevel);
                await _rmDatabaseContext.UserAccessLevels.AddAsync(inserting_user_access_level);
                await _rmDatabaseContext.SaveChangesAsync();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("There was an issue with the inserting operation: \n" + ex.Message);
            }
        }

        /// <summary>
        /// Update the user access level from dataabase
        /// </summary>
        /// <param name="userAccessLevel"> The updated user access level model</param>
        public async void UpdateUserAccessLevel(UserAccessLevelModel userAccessLevel)
        {
            try
            {
                var updating_user_access_level = _rmMapper.Map<UserAccessLevel>(userAccessLevel);
                _rmDatabaseContext.UserAccessLevels.Update(updating_user_access_level);
                await _rmDatabaseContext.SaveChangesAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("There was an issue with the updating operation: \n" + ex.Message);
            }
        }

        /// <summary>
        /// Removes user access level from database
        /// </summary>
        /// <param name="userAccessLevelId"> The user access level id </param>
        public async void DeleteUserAccessLevel(int userAccessLevelId)
        {
            try
            {
                var user_access_level = await _rmDatabaseContext.UserAccessLevels.FirstOrDefaultAsync(ual => ual.Id == userAccessLevelId);
                _rmDatabaseContext.UserAccessLevels.Remove(user_access_level);
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
