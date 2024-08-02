using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MeetHub.API.Helpers
{
    /// <summary>
    /// The application configuration class
    /// </summary>
    public static class AppConfiguration
    {
        #region Fields

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
        public static string EventTableName => GetConfigurationValue(cmEventTableKey);

        /// <summary>
        /// Gets the user table name
        /// </summary>
        public static string UserTableName => GetConfigurationValue(cmUserTableKey);

        /// <summary>
        /// Gets the location table name
        /// </summary>
        public static string LocationTableName => GetConfigurationValue(cmLocationTableKey);

        /// <summary>
        /// Gets the event type name
        /// </summary>
        public static string EventTypeTableName => GetConfigurationValue(cmEventTypeKey);

        /// <summary>
        /// Gets the event constraint table name
        /// </summary>
        public static string EventConstraintTableName => GetConfigurationValue(cmEventConstraintTypeKey);

        /// <summary>
        /// Gets the currency type table name
        /// </summary>
        public static string CurrencyTypeTableName => GetConfigurationValue(cmCurrencyTypeKey);

        /// <summary>
        /// Gets the event thumbnail table name
        /// </summary>
        public static string EventThumbnailTableName => GetConfigurationValue(cmEventThumbnailKey);

        /// <summary>
        /// Gets the comment table name
        /// </summary>
        public static string CommentTableName => GetConfigurationValue(cmCommentKey);

        /// <summary>
        /// Gets the comment reply table name
        /// </summary>
        public static string CommentReplyTableName => GetConfigurationValue(cmCommentReplyKey);

        /// <summary>
        /// Gets the user access level table name
        /// </summary>
        public static string UserAccessLevelTableName => GetConfigurationValue(cmUserAccessLevelKey);

        /// <summary>
        /// Gets the user-event relation table name
        /// </summary>
        public static string UserEventRelationTableName => GetConfigurationValue(cmUserEventRelationKey);

        /// <summary>
        /// Gets the generated invites table name
        /// </summary>
        public static string GeneratedInvitesTableName => GetConfigurationValue(cmGeneratedInviteKey);

        #endregion Table names

        #region Controller names



        #endregion Controller names

        #endregion Properties

        #region Methods

        /// <summary>
        /// Get the configured fields from the config file 'appsettings.json'
        /// </summary>
        /// <returns></returns>
        private static JObject GetConfiguration()
        {
            JObject config = new JObject();
            try
            {
                using (StreamReader r = new StreamReader("appsettings.json"))
                {
                    string json = r.ReadToEnd();
                    config = (JObject)JsonConvert.DeserializeObject(json);
                }
            }
            catch (JsonException)
            {
                // Not implemented. Use logger service to add log
                throw;
            }
            catch (Exception)
            {

                throw;
            }

            return config;
        }

        /// <summary>
        /// Gets the property value from json config
        /// </summary>
        /// <param name="fieldKey"> The key of the field </param>
        /// <returns></returns>
        private static string GetConfigurationValue(string fieldKey)
        {
            var config = GetConfiguration();
            return config[fieldKey].Value<string>();
        }

        #endregion Methods
    }
}
