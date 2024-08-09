using AutoMapper;
using MeetHub.API.Entities;
using MeetHub.API.Models;

namespace MeetHub.API.Mappers
{
    /// <summary>
    /// The mapper between event constraint type entity and model
    /// </summary>
    public class EventConstraintTypeMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// The constructor of the mapper class
        /// </summary>
        public EventConstraintTypeMapper()
        {
            CreateMap<EventConstraintType, EventConstraintTypeModel>().ReverseMap();
        }

        #endregion Constructors

    }
}
