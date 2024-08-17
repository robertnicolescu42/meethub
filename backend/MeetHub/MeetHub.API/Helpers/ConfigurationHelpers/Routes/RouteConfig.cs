namespace MeetHub.API.Helpers.ConfigurationHelpers.Routes
{
    /// <summary>
    /// The route configuration class
    /// </summary>
    public class RouteConfig
    {
        #region Properties

        /// <summary>
        /// The template of the route
        /// </summary>
        public string Template 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// The controller name
        /// </summary>
        public string Controller 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// The method name
        /// </summary>
        public string Action 
        { 
            get; 
            set; 
        }

        #endregion Properties
    }
}
