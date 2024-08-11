using Newtonsoft.Json.Linq;

namespace MeetHub.API.Helpers
{
    /// <summary>
    /// The application configuration class
    /// </summary>
    public static class AppConfiguration
    {
        #region Fields

        private const string cmSettingsFileName = "appsettings.json";

        private const string cmEventTableKey = "EventEntity";
        private const string cmUserTableKey = "UserEntityKey";
        private const string cmLocationTableKey = "LocationEntity";
        private const string cmEventTypeKey = "EventTypeEntity";
        private const string cmEventConstraintTypeKey = "EventConstraintTypeEntity";
        private const string cmCurrencyTypeKey = "CurrencyTypeEntity";
        private const string cmEventThumbnailKey = "EventThumbnailEntity";
        private const string cmCommentKey = "CommentEntity";
        private const string cmCommentReplyKey = "CommentReplyEntity";
        private const string cmUserAccessLevelKey = "UserAccessLevelEntity";
        private const string cmUserEventRelationKey = "UserEventRelationEntity";
        private const string cmGeneratedInviteKey = "GeneratedInviteEntity";

        #endregion Fields

        #region Properties

        #region Table names

        /// <summary>
        /// Gets the event table name
        /// </summary>
        public static string EventTableName => JsonFileRetriever.GetConfigurationValue(cmEventTableKey, cmSettingsFileName);

        /// <summary>
        /// Gets the user table name
        /// </summary>
        public static string UserTableName => JsonFileRetriever.GetConfigurationValue(cmUserTableKey, cmSettingsFileName);

        /// <summary>
        /// Gets the location table name
        /// </summary>
        public static string LocationTableName => JsonFileRetriever.GetConfigurationValue(cmLocationTableKey, cmSettingsFileName);

        /// <summary>
        /// Gets the event type name
        /// </summary>
        public static string EventTypeTableName => JsonFileRetriever.GetConfigurationValue(cmEventTypeKey, cmSettingsFileName);

        /// <summary>
        /// Gets the event constraint table name
        /// </summary>
        public static string EventConstraintTableName => JsonFileRetriever.GetConfigurationValue(cmEventConstraintTypeKey, cmSettingsFileName);

        /// <summary>
        /// Gets the currency type table name
        /// </summary>
        public static string CurrencyTypeTableName => JsonFileRetriever.GetConfigurationValue(cmCurrencyTypeKey, cmSettingsFileName);

        /// <summary>
        /// Gets the event thumbnail table name
        /// </summary>
        public static string EventThumbnailTableName => JsonFileRetriever.GetConfigurationValue(cmEventThumbnailKey, cmSettingsFileName);

        /// <summary>
        /// Gets the comment table name
        /// </summary>
        public static string CommentTableName => JsonFileRetriever.GetConfigurationValue(cmCommentKey, cmSettingsFileName);

        /// <summary>
        /// Gets the comment reply table name
        /// </summary>
        public static string CommentReplyTableName => JsonFileRetriever.GetConfigurationValue(cmCommentReplyKey, cmSettingsFileName);

        /// <summary>
        /// Gets the user access level table name
        /// </summary>
        public static string UserAccessLevelTableName => JsonFileRetriever.GetConfigurationValue(cmUserAccessLevelKey, cmSettingsFileName);

        /// <summary>
        /// Gets the user-event relation table name
        /// </summary>
        public static string UserEventRelationTableName => JsonFileRetriever.GetConfigurationValue(cmUserEventRelationKey, cmSettingsFileName);

        /// <summary>
        /// Gets the generated invites table name
        /// </summary>
        public static string GeneratedInvitesTableName => JsonFileRetriever.GetConfigurationValue(cmGeneratedInviteKey, cmSettingsFileName);

        #endregion Table names

        #region Controller names



        #endregion Controller names

        #endregion Properties
    }
}
