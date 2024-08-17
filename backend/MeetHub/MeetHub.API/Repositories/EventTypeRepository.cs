using AutoMapper;
using MeetHub.API.Context;
using MeetHub.API.Entities;
using MeetHub.API.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MeetHub.API.Repositories
{
    /// <summary>
    /// The event type repository interface
    /// </summary>
    public interface IEventTypeRepository
    {
        #region Methods

        /// <summary>
        /// Gets all event types from database asyncrounous
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<EventTypeModel>> GetAllEventTypesAsync();

        /// <summary>
        /// Gets event type from database asyncronous
        /// </summary>
        /// <param name="eventTypeId"> The event type id</param>
        /// <returns></returns>
        Task<EventTypeModel> GetEventTypeByIdAsync(int eventTypeId);

        /// <summary>
        /// Add nevent type to database
        /// </summary>
        /// <param name="eventType"> The event type model</param>
        void AddEventType(EventTypeModel eventType);

        /// <summary>
        /// Update the evenet type from database
        /// </summary>
        /// <param name="eventType"></param>
        void UpdateEventType(EventTypeModel eventType);

        /// <summary>
        /// Removes the event type from database
        /// </summary>
        /// <param name="eventTypeId"></param>
        void DeleteEventType(int eventTypeId);

        #endregion Methods
    }

    /// <summary>
    /// The event type repository implementation class
    /// </summary>
    public class EventTypeRepository : IEventTypeRepository
    {
        #region Fields

        private readonly MeetHubDatabaseContext _rmDatabaseContext;
        private readonly IMapper _rmMapper;

        #endregion Fields

        #region Constructor

        public EventTypeRepository(MeetHubDatabaseContext databaseContext, IMapper mapper)
        {
            _rmDatabaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
            _rmMapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Gets all event types from database asyncrounous
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EventTypeModel>> GetAllEventTypesAsync()
        {
            var event_types = await _rmDatabaseContext.EventTypes.ToListAsync();
            return _rmMapper.Map<IEnumerable<EventTypeModel>>(event_types);
        }

        /// <summary>
        /// Gets event type from database asyncronous
        /// </summary>
        /// <param name="eventTypeId"> The event type id</param>
        /// <returns></returns>
        public async Task<EventTypeModel> GetEventTypeByIdAsync(int eventTypeId)
        {
            var event_type = await _rmDatabaseContext.EventTypes.FirstOrDefaultAsync(type => type.Id == eventTypeId);
            return _rmMapper.Map<EventTypeModel>(event_type);
        }

        /// <summary>
        /// Add nevent type to database
        /// </summary>
        /// <param name="eventType"> The event type model</param>
        public void AddEventType(EventTypeModel eventType)
        {
            try
            {
                var inserting_event_type = _rmMapper.Map<EventType>(eventType);
                _rmDatabaseContext.EventTypes.Add(inserting_event_type);
                _rmDatabaseContext.SaveChanges();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("There was an issue with the inserting operation: \n" + ex.Message);
            }
        }

        /// <summary>
        /// Update the evenet type from database
        /// </summary>
        /// <param name="eventType"></param>
        public void UpdateEventType(EventTypeModel eventType)
        {
            try
            {
                var updating_event_type = _rmMapper.Map<EventType>(eventType);
                _rmDatabaseContext.EventTypes.Update(updating_event_type);
                _rmDatabaseContext.SaveChanges();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("There was an issue with the updating operation: \n" + ex.Message);
            }
        }

        /// <summary>
        /// Removes the event type from database
        /// </summary>
        /// <param name="eventTypeId"></param>
        public async void DeleteEventType(int eventTypeId)
        {
            try
            {
                var event_type = await _rmDatabaseContext.EventTypes.FirstOrDefaultAsync(type => type.Id == eventTypeId);
                _rmDatabaseContext.EventTypes.Remove(event_type);
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
