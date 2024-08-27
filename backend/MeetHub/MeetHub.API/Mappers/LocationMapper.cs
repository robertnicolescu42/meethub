using AutoMapper;
using MeetHub.API.Entities;
using MeetHub.API.Models;

namespace MeetHub.API.Mappers
{
    /// <summary>
    /// The mapper between location entity and model
    /// </summary>
    public class LocationMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// The constructor of the mapper class
        /// </summary>
        public LocationMapper()
        {
            CreateMap<Location, LocationModel>().ReverseMap();
        }

        #endregion Constructors

    }
}
