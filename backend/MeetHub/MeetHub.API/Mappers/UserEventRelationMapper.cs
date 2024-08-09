using AutoMapper;
using MeetHub.API.Entities;
using MeetHub.API.Models;

namespace MeetHub.API.Mappers
{
    /// <summary>
    /// The mapper between user-event relation entity and model
    /// </summary>
    public class UserEventRelationMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// The constructor of the mapper class
        /// </summary>
        public UserEventRelationMapper()
        {
            CreateMap<UserEventRelation, UserEventRelationModel>().ReverseMap();
        }

        #endregion Constructors

    }
}
