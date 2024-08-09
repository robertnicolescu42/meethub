using AutoMapper;
using MeetHub.API.Entities;
using MeetHub.API.Models;

namespace MeetHub.API.Mappers
{
    /// <summary>
    /// The mapper between event entity and model
    /// </summary>
    public class EventMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// The constructor of the mapper class
        /// </summary>
        public EventMapper()
        {
            CreateMap<Event, EventModel>().ReverseMap();
        }

        #endregion Constructors
    }
}
