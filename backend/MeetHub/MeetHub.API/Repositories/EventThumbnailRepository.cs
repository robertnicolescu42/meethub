using AutoMapper;
using MeetHub.API.Context;
using MeetHub.API.Entities;
using MeetHub.API.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MeetHub.API.Repositories
{
    /// <summary>
    /// The event thumbnail repository interface
    /// </summary>
    public interface IEventThumbnailRepository
    {
        #region Methods

        /// <summary>
        /// Gets all event thumbnails from database asyncronous
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<EventThumbnailModel>> GetAllEventTHumbnailsAsync();

        /// <summary>
        /// Gets event thumbnail from database asyncronous
        /// </summary>
        /// <param name="eventThumbnailId"> The event thumbnail id </param>
        /// <returns></returns>
        Task<EventThumbnailModel> GetEventThumbnailByIdAsync(int eventThumbnailId);

        /// <summary>
        /// Adds event thumbnail to database
        /// </summary>
        /// <param name="thumbnail"> The event thumbnail model </param>
        void AddEventThumbnail(EventThumbnailModel thumbnail);

        /// <summary>
        /// Updates the event thumbnail from dataabase
        /// </summary>
        /// <param name="thumbnail"> The updated event thumbnail model</param>
        void UpdateEventThumbnail(EventThumbnailModel thumbnail);

        /// <summary>
        /// Removes event thumbnail from database
        /// </summary>
        /// <param name="eventThumbnailId"> The event thumbnail id </param>
        void DeleteEventThumbnail(int eventThumbnailId);

        #endregion Methods
    }

    /// <summary>
    /// The event thumbnail repository implementation class
    /// </summary>
    public class EventThumbnailRepository : IEventThumbnailRepository
    {
        #region Fields

        private readonly MeetHubDatabaseContext _rmDatabaseContext;
        private readonly IMapper _rmMapper;

        #endregion Fields

        #region Constructor

        public EventThumbnailRepository(MeetHubDatabaseContext databaseContext, IMapper mapper)
        {
            _rmDatabaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
            _rmMapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Gets all event thumbnails from database asyncronous
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EventThumbnailModel>> GetAllEventTHumbnailsAsync()
        {
            var thumbnails = await _rmDatabaseContext.EventThumbnails.ToListAsync();
            return _rmMapper.Map<IEnumerable<EventThumbnailModel>>(thumbnails);
        }

        /// <summary>
        /// Gets event thumbnail from database asyncronous
        /// </summary>
        /// <param name="eventThumbnailId"> The event thumbnail id </param>
        /// <returns></returns>
        public async Task<EventThumbnailModel> GetEventThumbnailByIdAsync(int eventThumbnailId)
        {
            var thumbnail = await _rmDatabaseContext.EventThumbnails.FirstOrDefaultAsync(t => t.Id == eventThumbnailId);
            return _rmMapper.Map<EventThumbnailModel>(thumbnail);
        }

        /// <summary>
        /// Adds event thumbnail to database
        /// </summary>
        /// <param name="thumbnail"> The event thumbnail model </param>
        public void AddEventThumbnail(EventThumbnailModel thumbnail)
        {
            try
            {
                var inserting_thumbnail = _rmMapper.Map<EventThumbnail>(thumbnail);
                _rmDatabaseContext.EventThumbnails.Add(inserting_thumbnail);
                _rmDatabaseContext.SaveChanges();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("There was an issue with the inserting operation: \n" + ex.Message);
            }
        }

        /// <summary>
        /// Updates the event thumbnail from dataabase
        /// </summary>
        /// <param name="thumbnail"> The updated event thumbnail model</param>
        public void UpdateEventThumbnail(EventThumbnailModel thumbnail)
        {
            try
            {
                var updating_thumbnail = _rmMapper.Map<EventThumbnail>(thumbnail);
                _rmDatabaseContext.EventThumbnails.Update(updating_thumbnail);
                _rmDatabaseContext.SaveChanges();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("There was an issue with the updating operation: \n" + ex.Message);
            }
        }

        /// <summary>
        /// Removes event thumbnail from database
        /// </summary>
        /// <param name="eventThumbnailId"> The event thumbnail id </param>
        public async void DeleteEventThumbnail(int eventThumbnailId)
        {
            try
            {
                var event_thumbnail = await _rmDatabaseContext.EventThumbnails.FirstOrDefaultAsync(t => t.Id == eventThumbnailId);
                _rmDatabaseContext.EventThumbnails.Remove(event_thumbnail);
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
