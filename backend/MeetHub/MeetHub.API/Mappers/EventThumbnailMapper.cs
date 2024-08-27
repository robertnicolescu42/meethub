using AutoMapper;
using MeetHub.API.Entities;
using MeetHub.API.Models;

namespace MeetHub.API.Mappers
{
    /// <summary>
    /// The mapper between event thumbnail entity and model
    /// </summary>

    public class EventThumbnailMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// The constructor of the mapper class
        /// </summary>
        public EventThumbnailMapper()
        {
            CreateMap<EventThumbnail, EventThumbnailModel>().ReverseMap();
        }

        #endregion Constructors

    }
}
