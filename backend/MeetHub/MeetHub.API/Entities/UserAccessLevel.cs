using MeetHub.API.Helpers;
using System.ComponentModel.DataAnnotations;

namespace MeetHub.API.Entities
{
    /// <summary>
    /// The user access level entity class
    /// </summary>
    public class UserAccessLevel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Id field of the user access level class
        /// </summary>
        [Key]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the title field of the user access level class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the description field of the user access level class
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the users navigation property for user access level class
        /// </summary>
        public List<User> Users
        {
            get;
            set;
        }

        #endregion Properties
    }
}
