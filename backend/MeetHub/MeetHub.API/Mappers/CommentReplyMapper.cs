using AutoMapper;
using MeetHub.API.Entities;
using MeetHub.API.Models;

namespace MeetHub.API.Mappers
{
    /// <summary>
    /// The mapper between comment reply entity and model
    /// </summary>
    public class CommentReplyMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// The constructor of the mapper class
        /// </summary>
        public CommentReplyMapper()
        {
            CreateMap<CommentReply, CommentReplyModel>().ReverseMap();
        }

        #endregion Constructors

    }
}
