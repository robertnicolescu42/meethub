using MeetHub.API.Helpers;
using System.ComponentModel.DataAnnotations;

namespace MeetHub.API.Entities
{
    /// <summary>
    /// The event thumbnail entity class
    /// </summary>
    public class EventThumbnail
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Id field of the event thumbnail class
        /// </summary>
        [Key]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the source field of the event thumbnail class 
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public string Source 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// Gets or sets the events navigation property for the event  thumbnail class
        /// </summary>
        public List<Event> Events
        {
            get;
            set;
        }

        #endregion Properties
    }
}
