using AutoMapper;
using MeetHub.API.Context;
using MeetHub.API.Entities;
using MeetHub.API.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MeetHub.API.Repositories
{
    /// <summary>
    /// The generated invite repository interface
    /// </summary>
    public interface IGeneratedInvitesRepository
    {
        #region Methods

        /// <summary>
        /// Gets all generated invite from database asyncronous
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<GeneratedInviteModel>> GetAllGeneratedInvitesAsync();

        /// <summary>
        /// Gets generated invite from database asyncronous
        /// </summary>
        /// <param name="generatedInviteId"> The generated invite id </param>
        /// <returns></returns>
        Task<GeneratedInviteModel> GetGeneratedInviteByIdAsync(int generatedInviteId);

        /// <summary>
        /// Adds generated invite to database
        /// </summary>
        /// <param name="generatedInvite"> The generated invite model </param>
        void AddGeneratedInvite(GeneratedInviteModel generatedInvite);

        /// <summary>
        /// Updates the generated invite from dataabase
        /// </summary>
        /// <param name="generatedInvite"> The updated generated invite model</param>
        void UpdateGeneratedInvite(GeneratedInviteModel generatedInvite);

        /// <summary>
        /// Removes generated invite from database
        /// </summary>
        /// <param name="generatedInviteId"> The generated invite id </param>
        void DeleteGeneratedInvite(int generatedInviteId);

        #endregion Methods
    }

    /// <summary>
    /// The generated invite repository implementation class
    /// </summary>
    public class GeneratedInvitesRepository : IGeneratedInvitesRepository
    {
        #region Fields

        private readonly MeetHubDatabaseContext _rmDatabaseContext;
        private readonly IMapper _rmMapper;

        #endregion Fields

        #region Constructor

        public GeneratedInvitesRepository(MeetHubDatabaseContext databaseContext, IMapper mapper)
        {
            _rmDatabaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
            _rmMapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Gets all generated invites from database asyncronous
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<GeneratedInviteModel>> GetAllGeneratedInvitesAsync()
        {
            var generated_invites = await _rmDatabaseContext.GeneratedInvites.ToListAsync();
            return _rmMapper.Map<IEnumerable<GeneratedInviteModel>>(generated_invites);
        }

        /// <summary>
        /// Gets generated invite from database asyncronous
        /// </summary>
        /// <param name="generatedInviteId"> The generated invite id </param>
        /// <returns></returns>
        public async Task<GeneratedInviteModel> GetGeneratedInviteByIdAsync(int generatedInviteId)
        {
            var generated_invite = await _rmDatabaseContext.GeneratedInvites.FirstOrDefaultAsync(generatedInvite => generatedInvite.Id == generatedInviteId);
            return _rmMapper.Map<GeneratedInviteModel>(generated_invite);
        }

        /// <summary>
        /// Adds generated invite to database
        /// </summary>
        /// <param name="generatedInvite"> The generated invite model </param>
        public async void AddGeneratedInvite(GeneratedInviteModel generatedInvite)
        {
            try
            {
                var inserting_generated_invite = _rmMapper.Map<GeneratedInvite>(generatedInvite);
                await _rmDatabaseContext.GeneratedInvites.AddAsync(inserting_generated_invite);
                await _rmDatabaseContext.SaveChangesAsync();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("There was an issue with the inserting operation: \n" + ex.Message);
            }
        }

        /// <summary>
        /// Update the generated invite from dataabase
        /// </summary>
        /// <param name="generatedInvite"> The updated generated invite model</param>
        public async void UpdateGeneratedInvite(GeneratedInviteModel generatedInvite)
        {
            try
            {
                var updating_generated_invite = _rmMapper.Map<GeneratedInvite>(generatedInvite);
                _rmDatabaseContext.GeneratedInvites.Update(updating_generated_invite);
                await _rmDatabaseContext.SaveChangesAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("There was an issue with the updating operation: \n" + ex.Message);
            }
        }

        /// <summary>
        /// Removes generated invite from database
        /// </summary>
        /// <param name="generatedInviteId"> The generated invite id </param>
        public async void DeleteGeneratedInvite(int generatedInviteId)
        {
            try
            {
                var generated_invite = await _rmDatabaseContext.GeneratedInvites.FirstOrDefaultAsync(gi => gi.Id == generatedInviteId);
                _rmDatabaseContext.GeneratedInvites.Remove(generated_invite);
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
