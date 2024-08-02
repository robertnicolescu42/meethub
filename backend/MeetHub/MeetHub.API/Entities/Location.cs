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
        /// Gets or sets the Id field of the location class
        /// </summary>
        [Key]
        public int Id 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// Gets or sets the latitude field of the location class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public string Latitude
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the longitude field of the location class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public string Longitude
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the location name of the location class
        /// </summary>
        public string LocationName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the events navigation property for the location class
        /// </summary>
        public List<Event> Events
        {
            get;
            set;
        }

        #endregion Properties
    }
}
