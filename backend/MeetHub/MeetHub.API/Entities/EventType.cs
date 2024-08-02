using MeetHub.API.Helpers;
using System.ComponentModel.DataAnnotations;

namespace MeetHub.API.Entities
{
    /// <summary>
    /// The event type entity class
    /// </summary>
    public class EventType
    {
        #region Properties

        /// <summary>
        /// The Id field of the event type class
        /// </summary>
        [Key]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// The title field of the eevent type class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// The description field of the event type class
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        #endregion Properties
    }
}
