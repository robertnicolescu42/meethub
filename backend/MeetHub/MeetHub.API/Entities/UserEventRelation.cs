using MeetHub.API.Helpers;
using System.ComponentModel.DataAnnotations;

namespace MeetHub.API.Entities
{
    /// <summary>
    /// The user-event relation entity class
    /// </summary>
    public class UserEventRelation
    {
        #region Properties

        /// <summary>
        /// Gets or sets the user Id field of user-event relation class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public int UserId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the event Id of the user-event relation class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public int EventId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user navigation property of the user-event relation class
        /// </summary>
        public User User
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the event navigation property of the user-event relation class
        /// </summary>
        public Event Event
        {
            get;
            set;
        }

        #endregion Properties
    }
}
