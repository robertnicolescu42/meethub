using MeetHub.API.Helpers;
using System.ComponentModel.DataAnnotations;

namespace MeetHub.API.Entities
{
    /// <summary>
    /// The comment reply entity class
    /// </summary>
    public class CommentReply
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Id field of the comment reply class
        /// </summary>
        [Key]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the comment id field of the comment reply class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public int CommentId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user id field of the comment reply class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public int UserId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the content field of the comment reply class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
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

        /// <summary>
        /// Gets or sets the user navigation property of the comment reply class
        /// </summary>
        public User User
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the comment navigation property of the comment reply class
        /// </summary>
        public Comment Comment
        {
            get;
            set;
        }

        #endregion Properties
    }
}
