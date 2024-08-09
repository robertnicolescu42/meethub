using AutoMapper;
using MeetHub.API.Entities;
using MeetHub.API.Models;

namespace MeetHub.API.Mappers
{
    /// <summary>
    /// The mapper between user entity and model
    /// </summary>
    public class UserMapper : Profile
    {
        #region Constructors
        
        /// <summary>
        /// The constructor of the mapper class
        /// </summary>
        public UserMapper()
        {
            CreateMap<User, UserModel>().ReverseMap();
        }

        #endregion Constructors
    }
}
