using MeetHub.API.Entities;

namespace MeetHub.API.Helpers.ConfigurationHelpers.Routes
{
    /// <summary>
    /// The route config retriever class
    /// </summary>
    public static class RouteConfigRetriever
    {
        #region Fields

        private const string _cmConfigurationsFolder = "Helpers\\ConfigurationHelpers\\Routes\\Configurations\\";
        private const string _cmRoutesFieldKey = "routes";

        private const string _cmCommentReplyRoutesFilePath = _cmConfigurationsFolder+"CommentReplyControllerRoutes.json";
        private const string _cmCommentRoutesFilePath = _cmConfigurationsFolder + "CommentControllerRoutes.json";
        private const string _cmCurrencyRoutesFilePath = _cmConfigurationsFolder + "CurrencyControllerRoutes.json";
        private const string _cmEventConstraintsRoutesFilePath = _cmConfigurationsFolder + "EventConstraintsControllerRoutes.json";
        private const string _cmEventRoutesFilePath = _cmConfigurationsFolder + "EventControllerRoutes.json";
        private const string _cmEventThumbnailsRoutesFilePath = _cmConfigurationsFolder + "EventThumbnailsControllerRoutes.json";
        private const string _cmEventTypeRoutesFilePath = _cmConfigurationsFolder + "EventTypeControllerRoutes.json";
        private const string _cmGeneratedInvitesRoutesFilePath = _cmConfigurationsFolder + "GeneratedInvitesControllerRoutes.json";
        private const string _cmLocationRoutesFilePath = _cmConfigurationsFolder + "LocationControllerRoutes.json";
        private const string _cmUserAccessLevelRoutesFilePath = _cmConfigurationsFolder + "UserAccessLevelControllerRoutes.json";
        private const string _cmUserRoutesFilePath = _cmConfigurationsFolder + "UserControllerRoutes.json";
        private const string _cmUserEventRelationRoutesFilePath = _cmConfigurationsFolder + "UserEventRelationControllerRoutes.json";

        #endregion Fields

        #region Methods

        /// <summary>
        /// Returns the list of all controller routes
        /// </summary>
        /// <returns></returns>
        public static List<RouteConfig> GetFileRoutes()
        {
            List<RouteConfig> route_configs = new List<RouteConfig>();
            route_configs.AddRange(JsonFileRetriever.GetConfigurationObjectValue<RouteConfig>(_cmRoutesFieldKey, _cmCommentReplyRoutesFilePath));
            route_configs.AddRange(JsonFileRetriever.GetConfigurationObjectValue<RouteConfig>(_cmRoutesFieldKey, _cmCommentRoutesFilePath));
            route_configs.AddRange(JsonFileRetriever.GetConfigurationObjectValue<RouteConfig>(_cmRoutesFieldKey, _cmCurrencyRoutesFilePath));
            route_configs.AddRange(JsonFileRetriever.GetConfigurationObjectValue<RouteConfig>(_cmRoutesFieldKey, _cmEventConstraintsRoutesFilePath));
            route_configs.AddRange(JsonFileRetriever.GetConfigurationObjectValue<RouteConfig>(_cmRoutesFieldKey, _cmEventRoutesFilePath));
            route_configs.AddRange(JsonFileRetriever.GetConfigurationObjectValue<RouteConfig>(_cmRoutesFieldKey, _cmEventThumbnailsRoutesFilePath));
            route_configs.AddRange(JsonFileRetriever.GetConfigurationObjectValue<RouteConfig>(_cmRoutesFieldKey, _cmEventTypeRoutesFilePath));
            route_configs.AddRange(JsonFileRetriever.GetConfigurationObjectValue<RouteConfig>(_cmRoutesFieldKey, _cmGeneratedInvitesRoutesFilePath));
            route_configs.AddRange(JsonFileRetriever.GetConfigurationObjectValue<RouteConfig>(_cmRoutesFieldKey, _cmLocationRoutesFilePath));
            route_configs.AddRange(JsonFileRetriever.GetConfigurationObjectValue<RouteConfig>(_cmRoutesFieldKey, _cmUserAccessLevelRoutesFilePath));
            route_configs.AddRange(JsonFileRetriever.GetConfigurationObjectValue<RouteConfig>(_cmRoutesFieldKey, _cmUserEventRelationRoutesFilePath));
            route_configs.AddRange(JsonFileRetriever.GetConfigurationObjectValue<RouteConfig>(_cmRoutesFieldKey, _cmUserRoutesFilePath));

            return route_configs;
        }

        #endregion Methods
    }
}
