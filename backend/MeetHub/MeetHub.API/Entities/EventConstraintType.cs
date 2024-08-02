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
        /// Gets or sets the Id field of the event constraint type class
        /// </summary>
        [Key]
        public int Id 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// Gets or sets the title field of the event constraint type class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the description field of the event constraint type class
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the events navigation property for the event constraint type class
        /// </summary>
        public List<Event> Events
        {
            get;
            set;
        }

        #endregion Properties
    }
}
