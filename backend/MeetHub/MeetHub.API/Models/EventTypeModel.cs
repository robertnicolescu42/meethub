namespace MeetHub.API.Models
{
    /// <summary>
    /// The event type model class
    /// </summary>
    public class EventTypeModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Id field of the event type class
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the title field of the eevent type class
        /// </summary>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the description field of the event type class
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        #endregion Properties
    }
}
