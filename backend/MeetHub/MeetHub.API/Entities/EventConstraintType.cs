using MeetHub.API.Helpers;
using System.ComponentModel.DataAnnotations;

namespace MeetHub.API.Entities
{
    /// <summary>
    /// The event constraint type entity class
    /// </summary>
    public class EventConstraintType
    {
        #region Properties

        /// <summary>
        /// The Id field of the event constraint type class
        /// </summary>
        [Key]
        public int Id 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// The title field of the event constraint type class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// The description field of the event constraint type class
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        #endregion Properties
    }
}
