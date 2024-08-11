using AutoMapper;
using MeetHub.API.Context;
using MeetHub.API.Entities;
using MeetHub.API.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MeetHub.API.Repositories
{
    /// <summary>
    /// The user repository interface
    /// </summary>
    public interface IUserRepository
    {
        #region Methods

        /// <summary>
        /// Gets all users from database asyncronous
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<UserModel>> GetAllUsersAsync();

        /// <summary>
        /// Gets user from database asyncronous
        /// </summary>
        /// <param name="userId"> The user id </param>
        /// <returns></returns>
        Task<UserModel> GetUserByIdAsync(int userId);

        /// <summary>
        /// Adds user to database
        /// </summary>
        /// <param name="user"> The user model </param>
        void AddUser(UserModel user);

        /// <summary>
        /// Updates the user from dataabase
        /// </summary>
        /// <param name="user"> The updated user model</param>
        void UpdateUser(UserModel user);

        /// <summary>
        /// Removes user from database
        /// </summary>
        /// <param name="userId"> The user id </param>
        void DeleteUser(int userId);

        #endregion Methods

    }

    /// <summary>
    /// The user repository implementation class
    /// </summary>
    public class UserRepository : IUserRepository
    {
        #region Fields

        private readonly MeetHubDatabaseContext _rmDatabaseContext;
        private readonly IMapper _rmMapper;

        #endregion Fields

        #region Constructor

        public UserRepository(MeetHubDatabaseContext databaseContext, IMapper mapper)
        {
            _rmDatabaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
            _rmMapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Gets all users from database asyncronous
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            var users = await _rmDatabaseContext.Users.ToListAsync();
            return _rmMapper.Map<IEnumerable<UserModel>>(users);
        }

        /// <summary>
        /// Gets user from database asyncronous
        /// </summary>
        /// <param name="userId"> The user id </param>
        /// <returns></returns>
        public async Task<UserModel> GetUserByIdAsync(int userId)
        {
            var user = await _rmDatabaseContext.Users.FirstOrDefaultAsync(user => user.Id == userId);
            return _rmMapper.Map<UserModel>(user);
        }

        /// <summary>
        /// Adds user to database
        /// </summary>
        /// <param name="user"> The user model </param>
        public async void AddUser(UserModel user)
        {
            try
            {
                var inserting_user = _rmMapper.Map<User>(user);
                await _rmDatabaseContext.Users.AddAsync(inserting_user);
                await _rmDatabaseContext.SaveChangesAsync();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("There was an issue with the inserting operation: \n" + ex.Message);
            }
        }

        /// <summary>
        /// Update the user from dataabase
        /// </summary>
        /// <param name="user"> The updated user model</param>
        public async void UpdateUser(UserModel user)
        {
            try
            {
                var updating_user = _rmMapper.Map<User>(user);
                _rmDatabaseContext.Users.Update(updating_user);
                await _rmDatabaseContext.SaveChangesAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("There was an issue with the updating operation: \n" + ex.Message);
            }
        }

        /// <summary>
        /// Removes user from database
        /// </summary>
        /// <param name="userId"> The user id </param>
        public async void DeleteUser(int userId)
        {
            try
            {
                var user = await _rmDatabaseContext.Users.FirstOrDefaultAsync(loc => loc.Id == userId);
                _rmDatabaseContext.Users.Remove(user);
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
