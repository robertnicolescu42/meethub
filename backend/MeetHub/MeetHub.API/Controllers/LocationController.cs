using MeetHub.API.Models;
using MeetHub.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MeetHub.API.Controllers
{
    /// <summary>
    /// The controller for location actions
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        #region Fields

        private const string _cmGetByIdName = "GetLocation";
        private readonly ILocationRepository _rmLocationRepository;

        #endregion Fields

        #region Constructor

        public LocationController(ILocationRepository locationRepository)
        {
            _rmLocationRepository = locationRepository ?? throw new ArgumentNullException(nameof(locationRepository));
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Gets all locations from repository
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpHead]
        public async Task<ActionResult<IEnumerable<LocationModel>>> GetAllLocations()
        {
            var locations = _rmLocationRepository
                .GetAllLocationsAsync()
                .GetAwaiter()
                .GetResult();

            return Ok(locations);
        }

        /// <summary>
        /// Gets a specific location using id
        /// </summary>
        /// <param name="id"> The id of the location </param>
        /// <returns></returns>
        [HttpGet("{id}", Name = _cmGetByIdName)]
        public async Task<ActionResult<LocationModel>> GetLocation(int id)
        {
            var location = _rmLocationRepository
                .GetLocationByIdAsync(id)
                .GetAwaiter()
                .GetResult();

            return Ok(location);
        }

        /// <summary>
        /// Adds new location
        /// </summary>
        /// <param name="location"> The location model </param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddLocation(LocationModel location)
        {
            _rmLocationRepository.AddLocation(location);
            return CreatedAtRoute(_cmGetByIdName, new { id = location.Id }, location);
        }

        /// <summary>
        /// Updates an existing location
        /// </summary>
        /// <param name="location"> The updated location model </param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateLocation(LocationModel location)
        {
            _rmLocationRepository.UpdateLocation(location);
            return NoContent();
        }

        /// <summary>
        /// Deletes an existion location
        /// </summary>
        /// <param name="id"> The location id </param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            _rmLocationRepository.DeleteLocation(id);
            return NoContent();
        }

        #endregion Methods

    }
}
