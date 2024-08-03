using MeetHub.API.Helpers;
using System.ComponentModel.DataAnnotations;

namespace MeetHub.API.Entities
{
    /// <summary>
    /// The generated invite entity class
    /// </summary>
    public class GeneratedInvite
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Id field of the generated invite class
        /// </summary>
        [Key]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user Id field of the generated invite class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public int UserId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the event Id field of the generated invite class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public int NumberOfUses
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the invite code field of the generated invide class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public string InviteCode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the number of uses field of the generated invite class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public int EventId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the crreated at field of the generated invite class
        /// </summary>
        public DateTime CreatedAt
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the expire on field of the generated invite class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public DateTime ExpireOn
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user navigation property of the generated invite class
        /// </summary>
        public User User
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the event navigation property of the generated invite class
        /// </summary>
        public Event Event
        {
            get;
            set;
        }

        #endregion Properties
    }
}
