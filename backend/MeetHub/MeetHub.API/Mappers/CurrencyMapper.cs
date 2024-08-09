using AutoMapper;
using MeetHub.API.Entities;
using MeetHub.API.Models;

namespace MeetHub.API.Mappers
{
    /// <summary>
    /// The mapper between currency entity and model
    /// </summary>
    public class CurrencyMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// The constructor of the mapper class
        /// </summary>
        public CurrencyMapper()
        {
            CreateMap<Currency, CurrencyModel>().ReverseMap();
        }

        #endregion Constructors

    }
}
