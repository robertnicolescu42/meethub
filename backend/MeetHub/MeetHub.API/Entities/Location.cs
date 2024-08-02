using System.ComponentModel.DataAnnotations;

namespace MeetHub.API.Entities
{
    /// <summary>
    /// The location entity class
    /// </summary>
    public class Location
    {

        #region Fields

        private const string cmRequiredErrorMessage = "This field is a required field";

        #endregion Fields

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
        [Required(ErrorMessage = cmRequiredErrorMessage)]
        public string Latitude
        {
            get;
            set;
        }

        /// <summary>
        /// The longitude field of the location class
        /// </summary>
        [Required(ErrorMessage = cmRequiredErrorMessage)]
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
