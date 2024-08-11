using AutoMapper;
using MeetHub.API.Context;
using MeetHub.API.Entities;
using MeetHub.API.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MeetHub.API.Repositories
{
    /// <summary>
    /// The event constraint type repository interface
    /// </summary>
    public interface IEventConstraintTypeRepository
    {
        #region Methods

        /// <summary>
        /// Gets event contraint types from database asyncronous
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<EventConstraintTypeModel>> GetAllEventConstrintTypesAsync();

        /// <summary>
        /// Gets event constraint type from database asyncronous
        /// </summary>
        /// <param name="eventConstraintTypeId"> The event constraint type id </param>
        /// <returns></returns>
        Task<EventConstraintTypeModel> GetEventConstrintTypeByIdAsync(int eventConstraintTypeId);

        /// <summary>
        /// Adds event constraint type to database
        /// </summary>
        /// <param name="eventConstraintType"> The event constraint type model </param>
        void AddEventConstraintType(EventConstraintTypeModel eventConstraintType);

        /// <summary>
        /// Updates the event constraint type from dataabase
        /// </summary>
        /// <param name="eventConstraintType"> The event constraint type model </param>
        void UpdateEventConstraintType(EventConstraintTypeModel eventConstraintType);

        /// <summary>
        /// Removes event constraint type from database
        /// </summary>
        /// <param name="eventConstraintTypeId"> The event constraint type id </param>
        void DeleteEventConstraintType(int eventConstraintTypeId);

        #endregion Methods
    }

    /// <summary>
    /// The event constraint type repository implementation class
    /// </summary>
    public class EventConstraintTypeRepository : IEventConstraintTypeRepository
    {
        #region Fields

        private readonly MeetHubDatabaseContext _rmDatabaseContext;
        private readonly IMapper _rmMapper;

        #endregion Fields

        #region Contructor

        public EventConstraintTypeRepository(MeetHubDatabaseContext databaseContext, IMapper mapper)
        {
            _rmDatabaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
            _rmMapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Gets event contraint types from database asyncronous
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EventConstraintTypeModel>> GetAllEventConstrintTypesAsync()
        {
            var event_constraint_types = await _rmDatabaseContext.EventConstraintTypes.ToListAsync();
            return _rmMapper.Map<IEnumerable<EventConstraintTypeModel>>(event_constraint_types);
        }

        /// <summary>
        /// Gets event constraint type from database asyncronous
        /// </summary>
        /// <param name="eventConstraintTypeId"> The event constraint type id </param>
        /// <returns></returns>
        public async Task<EventConstraintTypeModel> GetEventConstrintTypeByIdAsync(int eventConstraintTypeId)
        {
            var event_constrint_type = await _rmDatabaseContext.EventConstraintTypes.FirstOrDefaultAsync(type => type.Id == eventConstraintTypeId);
            return _rmMapper.Map<EventConstraintTypeModel>(event_constrint_type);
        }

        /// <summary>
        /// Adds event constraint type to database
        /// </summary>
        /// <param name="eventConstraintType"> The event constraint type model </param>
        public async void AddEventConstraintType(EventConstraintTypeModel eventConstraintType)
        {
            try
            {
                var inserting_event_constraint_type = _rmMapper.Map<EventConstraintType>(eventConstraintType);
                await _rmDatabaseContext.EventConstraintTypes.AddAsync(inserting_event_constraint_type);
                await _rmDatabaseContext.SaveChangesAsync();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("There was an issue with the inserting operation: \n" + ex.Message);
            }
        }

        /// <summary>
        /// Updates the event constraint type from dataabase
        /// </summary>
        /// <param name="eventConstraintType"> The event constraint type model </param>
        public async void UpdateEventConstraintType(EventConstraintTypeModel eventConstraintType)
        {
            try
            {
                var updating_event_constraint_type = _rmMapper.Map<EventConstraintType>(eventConstraintType);
                _rmDatabaseContext.EventConstraintTypes.Update(updating_event_constraint_type);
                await _rmDatabaseContext.SaveChangesAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("There was an issue with the updating operation: \n" + ex.Message);
            }
        }

        /// <summary>
        /// Removes event constraint type from database
        /// </summary>
        /// <param name="eventConstraintTypeId"> The event constraint type id </param>
        public async void DeleteEventConstraintType(int eventConstraintTypeId)
        {
            try
            {
                var event_constraint_type = await _rmDatabaseContext.EventConstraintTypes.FirstOrDefaultAsync(loc => loc.Id == eventConstraintTypeId);
                _rmDatabaseContext.EventConstraintTypes.Remove(event_constraint_type);
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
