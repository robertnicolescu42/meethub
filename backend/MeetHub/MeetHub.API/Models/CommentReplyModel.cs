namespace MeetHub.API.Models
{
    /// <summary>
    /// The comment reply model class
    /// </summary>
    public class CommentReplyModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Id field of the comment reply class
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the comment id field of the comment reply class
        /// </summary>
        public int CommentId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user id field of the comment reply class
        /// </summary>
        public int UserId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the content field of the comment reply class
        /// </summary>
        public string Content
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the date added field of the comment reply class
        /// </summary>
        public DateTime DateAdded
        {
            get;
            set;
        }

        #endregion Properties
    }
}
