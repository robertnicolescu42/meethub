using AutoMapper;
using MeetHub.API.Entities;
using MeetHub.API.Models;

namespace MeetHub.API.Mappers
{
    /// <summary>
    /// The mapper between comment entity and model
    /// </summary>
    public class CommentMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// The constructor of the mapper class
        /// </summary>
        public CommentMapper()
        {
            CreateMap<Comment, CommentModel>().ReverseMap();
        }

        #endregion Constructors

    }
}
