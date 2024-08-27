using AutoMapper;
using MeetHub.API.Entities;
using MeetHub.API.Models;

namespace MeetHub.API.Mappers
{
    /// <summary>
    /// The mapper between generated invite entity and model
    /// </summary>
    public class GeneratedInviteMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// The constructor of the mapper class
        /// </summary>
        public GeneratedInviteMapper()
        {
            CreateMap<GeneratedInvite, GeneratedInviteModel>().ReverseMap();
        }

        #endregion Constructors

    }
}
