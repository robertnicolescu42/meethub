using MeetHub.API.Helpers;
using System.ComponentModel.DataAnnotations;

namespace MeetHub.API.Entities
{
    /// <summary>
    /// The currency entity class
    /// </summary>
    public class Currency
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Id field of the currency class
        /// </summary>
        [Key]
        public int Id 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// Gets or sets the currency code field of the currency class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public string Code
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the title field of the currency class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Description field of the currency class
        /// </summary>
        public string Description
        {
            get; 
            set;
        }

        #endregion Properties
    }
}
