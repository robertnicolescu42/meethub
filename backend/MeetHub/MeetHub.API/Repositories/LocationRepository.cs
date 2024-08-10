using AutoMapper;
using MeetHub.API.Context;
using MeetHub.API.Entities;
using MeetHub.API.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MeetHub.API.Repositories
{
    /// <summary>
    /// The location repository interface
    /// </summary>
    public interface ILocationRepository
    {
        #region Methods

        /// <summary>
        /// Gets all locations from database asyncronous
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<LocationModel>> GetAllLocationsAsync();

        /// <summary>
        /// Gets location from database asyncronous
        /// </summary>
        /// <param name="locationId"> The location id </param>
        /// <returns></returns>
        Task<LocationModel> GetLocationByIdAsync(int locationId);

        /// <summary>
        /// Adds location to database asyncronous
        /// </summary>
        /// <param name="location"> The location model </param>
        /// <returns></returns>
        Task<LocationModel> AddLocationAsync(LocationModel location);

        /// <summary>
        /// Update the location from dataabase
        /// </summary>
        /// <param name="location"> The updated location model</param>
        void UpdateLocation(LocationModel location);

        /// <summary>
        /// Removes location from database
        /// </summary>
        /// <param name="locationId"> The location id </param>
        void DeleteLocation(int locationId);

        #endregion Methods
    }


    /// <summary>
    /// The location repository implementation class
    /// </summary>
    public class LocationRepository : ILocationRepository
    {
        #region Fields

        private readonly MeetHubDatabaseContext _rmDatabaseContext;
        private readonly IMapper _rmMapper;

        #endregion Fields

        #region Constructor

        public LocationRepository( MeetHubDatabaseContext databaseContext, IMapper mapper)
        {
            _rmDatabaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
            _rmMapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Gets all locations from database asyncronous
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<LocationModel>> GetAllLocationsAsync()
        {
            var locations = await _rmDatabaseContext.Locations.ToListAsync();
            return _rmMapper.Map<IEnumerable<LocationModel>>(locations);
        }

        /// <summary>
        /// Gets location from database asyncronous
        /// </summary>
        /// <param name="locationId"> The location id </param>
        /// <returns></returns>
        public async Task<LocationModel> GetLocationByIdAsync(int locationId)
        {
            var location = await _rmDatabaseContext.Locations.FirstOrDefaultAsync(location => location.Id == locationId);
            return _rmMapper.Map<LocationModel>(location);
        }

        /// <summary>
        /// Adds location to database asyncronous
        /// </summary>
        /// <param name="location"> The location model </param>
        /// <returns></returns>
        public async Task<LocationModel> AddLocationAsync(LocationModel location)
        {
            try
            {
                var inserting_location = _rmMapper.Map<Location>(location);
                await _rmDatabaseContext.Locations.AddAsync(inserting_location);
                await _rmDatabaseContext.SaveChangesAsync();
                return location;

            }
            catch (SqlException ex)
            {
                Console.WriteLine("There was an issue with the inserting operation: \n" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Update the location from dataabase
        /// </summary>
        /// <param name="location"> The updated location model</param>
        public async void UpdateLocation(LocationModel location)
        {
            try
            {
                var updating_location = _rmMapper.Map<Location>(location);
                _rmDatabaseContext.Locations.Update(updating_location);
                await _rmDatabaseContext.SaveChangesAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("There was an issue with the updating operation: \n" + ex.Message);
            }
        }

        /// <summary>
        /// Removes location from database
        /// </summary>
        /// <param name="locationId"> The location id </param>
        public async void DeleteLocation(int locationId)
        {
            try
            {
                var location = await _rmDatabaseContext.Locations.FirstOrDefaultAsync(loc => loc.Id == locationId);
                _rmDatabaseContext.Locations.Remove(location);
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
