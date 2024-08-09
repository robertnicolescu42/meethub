using MeetHub.API.Entities;

namespace MeetHub.API.Models.ComplexModels
{
    /// <summary>
    /// The user schema model class
    /// </summary>
    public class UserSchemaModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Id field of the user schema model class
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the username field of the user schema model class
        /// </summary>
        public string Username
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the email field of the user schema model class
        /// </summary>
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the phone number field of the user schema model class
        /// </summary>
        public string PhoneNumber
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the first name field of the user schema model class
        /// </summary>
        public string FirstName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the last name field of the user schema model class
        /// </summary>
        public string LastName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the birth date field of the user schema model class
        /// </summary>
        public DateTime BirthDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user access level id field of the user schema model class
        /// </summary>
        public int UserAccessLevelId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user access level property of the user schema model class
        /// </summary>
        public UserAccessLevelModel UserAccessLevel
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the generated invites property for user schema model class
        /// </summary>
        public List<GeneratedInviteModel> GeneratedInvites
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the events properties for user schema model class
        /// </summary>
        public List<EventModel> Events
        {
            get;
            set;
        }

        #endregion Properties

    }
}
