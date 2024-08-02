using MeetHub.API.Helpers;
using System.ComponentModel.DataAnnotations;

namespace MeetHub.API.Entities
{
    /// <summary>
    /// The location entity class
    /// </summary>
    public class Location
    {
        #region Properties

        /// <summary>
        /// The Id field of the location class
        /// </summary>
        [Key]
        public int Id 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// The latitude field of the location class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public string Latitude
        {
            get;
            set;
        }

        /// <summary>
        /// The longitude field of the location class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public string Longitude
        {
            get;
            set;
        }

        /// <summary>
        /// The location name of the location class
        /// </summary>
        public string LocationName
        {
            get;
            set;
        }

        #endregion Properties
    }
}
