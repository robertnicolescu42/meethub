namespace MeetHub.API.Models
{
    /// <summary>
    /// The currency model class
    /// </summary>
    public class CurrencyModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Id field of the currency class
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the currency code field of the currency class
        /// </summary>
        public string Code
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the title field of the currency class
        /// </summary>
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
