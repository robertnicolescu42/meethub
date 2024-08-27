namespace MeetHub.API.Models
{
    /// <summary>
    /// The location model class
    /// </summary>
    public class LocationModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Id field of the location class
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the latitude field of the location class
        /// </summary>
        public string Latitude
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the longitude field of the location class
        /// </summary>
        public string Longitude
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the location name of the location class
        /// </summary>
        public string LocationName
        {
            get;
            set;
        }

        #endregion Properties
    }
}
