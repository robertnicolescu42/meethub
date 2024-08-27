using MeetHub.API.Helpers;
using System.ComponentModel.DataAnnotations;

namespace MeetHub.API.Entities
{
    /// <summary>
    /// The comment entity class
    /// </summary>
    public class Comment
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Id field of the comment class
        /// </summary>
        [Key]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the event id field of the comment class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public int EventId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user id field of the comment class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public int UserId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the content field of the comment class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public string Content
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the date added field of the comment class
        /// </summary>
        public DateTime DateAdded
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user navigation property of the comment class
        /// </summary>
        public User User
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the event navigation property of the comment class
        /// </summary>
        public Event Event
        {
            get;
            set;
        }

        #endregion Properties
    }
}
