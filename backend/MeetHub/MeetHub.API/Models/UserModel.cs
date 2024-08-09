namespace MeetHub.API.Models
{
    /// <summary>
    /// The user model class
    /// </summary>
    public class UserModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Id field of the user model class
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the username field of the user model class
        /// </summary>
        public string Username
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the email field of the user model class
        /// </summary>
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the phone number field of the user model class
        /// </summary>
        public string PhoneNumber
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the first name field of the user model class
        /// </summary>
        public string FirstName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the last name field of the user model class
        /// </summary>
        public string LastName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the birth date field of the user model class
        /// </summary>
        public DateTime BirthDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user access level id field of the user model class
        /// </summary>
        public int UserAccessLevelId
        {
            get;
            set;
        }

        #endregion Properties
    }
}
