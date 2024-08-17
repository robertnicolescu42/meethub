using AutoMapper;
using MeetHub.API.Context;
using MeetHub.API.Entities;
using MeetHub.API.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MeetHub.API.Repositories
{
    /// <summary>
    /// The event repository interface
    /// </summary>
    public interface IEventRepository
    {
        #region Methods

        /// <summary>
        /// Gets all events from database asyncronous
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<EventModel>> GetAllEventsAsync();

        /// <summary>
        /// Gets event from database asyncronous
        /// </summary>
        /// <param name="eventId"> The event id </param>
        /// <returns></returns>
        Task<EventModel> GetEventByIdAsync(int eventId);

        /// <summary>
        /// Adds event to database
        /// </summary>
        /// <param name="eventModel"> The event model </param>
        void AddEvent(EventModel eventModel);

        /// <summary>
        /// Updates the event from dataabase
        /// </summary>
        /// <param name="eventModel"> The updated event model</param>
        void UpdateEvent(EventModel eventModel);

        /// <summary>
        /// Removes event from database
        /// </summary>
        /// <param name="eventId"> The event id </param>
        void DeleteEvent(int eventId);

        #endregion Methods

    }

    /// <summary>
    /// The event repository implementation class
    /// </summary>
    public class EventRepository : IEventRepository
    {
        #region Fields

        private readonly MeetHubDatabaseContext _rmDatabaseContext;
        private readonly IMapper _rmMapper;

        #endregion Fields

        #region Constructor

        public EventRepository(MeetHubDatabaseContext databaseContext, IMapper mapper)
        {
            _rmDatabaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
            _rmMapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Gets all events from database asyncronous
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EventModel>> GetAllEventsAsync()
        {
            var events = await _rmDatabaseContext.Events.ToListAsync();
            return _rmMapper.Map<IEnumerable<EventModel>>(events);
        }

        /// <summary>
        /// Gets event from database asyncronous
        /// </summary>
        /// <param name="eventId"> The event id </param>
        /// <returns></returns>
        public async Task<EventModel> GetEventByIdAsync(int eventId)
        {
            var event_entry = await _rmDatabaseContext.Events.FirstOrDefaultAsync(e => e.Id == eventId);
            return _rmMapper.Map<EventModel>(event_entry);
        }

        /// <summary>
        /// Adds event to database
        /// </summary>
        /// <param name="eventModel"> The event model </param>
        public async void AddEvent(EventModel eventModel)
        {
            try
            {
                var inserting_event = _rmMapper.Map<Event>(eventModel);
                _rmDatabaseContext.Events.Add(inserting_event);
                _rmDatabaseContext.SaveChanges();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("There was an issue with the inserting operation: \n" + ex.Message);
            }
        }

        /// <summary>
        /// Update the event from dataabase
        /// </summary>
        /// <param name="eventModel"> The updated event model</param>
        public void UpdateEvent(EventModel eventModel)
        {
            try
            {
                var updating_event = _rmMapper.Map<Event>(eventModel);
                _rmDatabaseContext.Events.Update(updating_event);
                _rmDatabaseContext.SaveChanges();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("There was an issue with the updating operation: \n" + ex.Message);
            }
        }

        /// <summary>
        /// Removes event from database
        /// </summary>
        /// <param name="eventId"> The event id </param>
        public async void DeleteEvent(int eventId)
        {
            try
            {
                Event? event_entry = await _rmDatabaseContext.Events.FirstOrDefaultAsync(e => e.Id == eventId);
                _rmDatabaseContext.Events.Remove(event_entry);
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
