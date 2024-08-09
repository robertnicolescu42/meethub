using AutoMapper;
using MeetHub.API.Entities;
using MeetHub.API.Models;

namespace MeetHub.API.Mappers
{
    /// <summary>
    /// The mapper between user access level entity and model
    /// </summary>

    public class UserAccessLevelMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// The constructor of the mapper class
        /// </summary>
        public UserAccessLevelMapper()
        {
            CreateMap<UserAccessLevel, UserAccessLevelModel>().ReverseMap();
        }

        #endregion Constructors

    }
}
