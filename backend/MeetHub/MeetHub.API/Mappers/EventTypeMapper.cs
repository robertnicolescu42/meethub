using AutoMapper;
using MeetHub.API.Entities;
using MeetHub.API.Models;

namespace MeetHub.API.Mappers
{
    /// <summary>
    /// The mapper between event type entity and model
    /// </summary>
    public class EventTypeMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// The constructor of the mapper class
        /// </summary>
        public EventTypeMapper()
        {
            CreateMap<EventType, EventTypeModel>().ReverseMap();
        }

        #endregion Constructors

    }
}
