using MeetHub.API.Helpers;
using System.ComponentModel.DataAnnotations;

namespace MeetHub.API.Entities
{
    /// <summary>
    /// The user entity class
    /// </summary>
    public class User
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Id field of the user class
        /// </summary>
        [Key]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the username field of the user class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public string Username
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the email field of the user class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the phone number field of the user class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public string PhoneNumber
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the first name field of the user class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public string FirstName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the last name field of the user class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public string LastName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the birth date field of the user class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public DateTime BirthDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user access level id field of the user class
        /// </summary>
        public int UserAccessLevelId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user access level property of the user class
        /// </summary>
        public UserAccessLevel UserAccessLevel
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user to event relations navigation property for user class
        /// </summary>
        public List<UserEventRelation> Relations
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the events navigation properties for user class
        /// </summary>
        public List<Event> Events
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the generated invites navigation property for user class
        /// </summary>
        public List<GeneratedInvite> GeneratedInvites
        {
            get;
            set;
        }

        #endregion Properties
    }
}
