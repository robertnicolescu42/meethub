namespace MeetHub.API.Models
{
    /// <summary>
    /// The user event relation model class
    /// </summary>
    public class UserEventRelationModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the user Id field of user-event relation class
        /// </summary>
        public int UserId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the event Id of the user-event relation class
        /// </summary>
        public int EventId
        {
            get;
            set;
        }

        #endregion Properties
    }
}
