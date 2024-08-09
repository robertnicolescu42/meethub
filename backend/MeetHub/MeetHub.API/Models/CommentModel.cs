namespace MeetHub.API.Models
{
    /// <summary>
    /// The comment model class
    /// </summary>
    public class CommentModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Id field of the comment class
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the event id field of the comment class
        /// </summary>
        public int EventId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user id field of the comment class
        /// </summary>
        public int UserId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the content field of the comment class
        /// </summary>
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

        #endregion Properties
    }
}
