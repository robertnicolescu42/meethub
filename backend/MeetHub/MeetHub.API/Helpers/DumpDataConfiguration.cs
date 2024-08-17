using MeetHub.API.Entities;

namespace MeetHub.API.Helpers
{
    /// <summary>
    /// Dump data retriever class
    /// </summary>
    public class DumpDataConfiguration
    {
        #region Fields

        private const string cmDumpDataFileName = "Resources\\DumpData.json";
        private const string cmCurrencyKey = "Currency";
        private const string cmEventTypeKey = "EventType";
        private const string cmEventConstraintTypeKey = "EventConstraintType";
        private const string cmLocationKey = "Location";
        private const string cmEventThumbnailsKey = "EventThumbnail";
        private const string cmUserAccessLevelKey = "UserAccessLevel";
        private const string cmUserKey = "User";
        private const string cmEventKey = "Event";
        private const string cmGeneratedInviteKey = "GeneratedInvite";
        private const string cmCommentKey = "Comment";
        private const string cmCommentReplyKey = "CommentReply";
        private const string cmUserEventRelationKey = "UserEventRelation";

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the currency dump data
        /// </summary>
        public static List<Currency> Currencies => JsonFileRetriever.GetConfigurationObjectValue<Currency>(cmCurrencyKey, cmDumpDataFileName);

        /// <summary>
        /// Gets the event type dump data
        /// </summary>
        public static List<EventType> EventTypes => JsonFileRetriever.GetConfigurationObjectValue<EventType>(cmEventTypeKey, cmDumpDataFileName);

        /// <summary>
        /// Gets the event constraint type dump data
        /// </summary>
        public static List<EventConstraintType> EventConstraintTypes => JsonFileRetriever.GetConfigurationObjectValue<EventConstraintType>(cmEventConstraintTypeKey, cmDumpDataFileName);

        /// <summary>
        /// Gets the location dump data
        /// </summary>
        public static List<Location> Locations => JsonFileRetriever.GetConfigurationObjectValue<Location>(cmLocationKey, cmDumpDataFileName);

        /// <summary>
        /// Gets the event thumbnail dump data
        /// </summary>
        public static List<EventThumbnail> EventThumbnails => JsonFileRetriever.GetConfigurationObjectValue<EventThumbnail>(cmEventThumbnailsKey, cmDumpDataFileName);

        /// <summary>
        /// Gets the user access level dump data
        /// </summary>
        public static List<UserAccessLevel> UserAccessLevels => JsonFileRetriever.GetConfigurationObjectValue<UserAccessLevel>(cmUserAccessLevelKey, cmDumpDataFileName);

        /// <summary>
        /// Gets the user dump data
        /// </summary>
        public static List<User> Users => JsonFileRetriever.GetConfigurationObjectValue<User>(cmUserKey, cmDumpDataFileName);

        /// <summary>
        /// Gets the event dump data
        /// </summary>
        public static List<Event> Events => JsonFileRetriever.GetConfigurationObjectValue<Event>(cmEventKey, cmDumpDataFileName);

        /// <summary>
        /// Gets the generated invite dump data
        /// </summary>
        public static List<GeneratedInvite> GeneratedInvites => JsonFileRetriever.GetConfigurationObjectValue<GeneratedInvite>(cmGeneratedInviteKey, cmDumpDataFileName);

        /// <summary>
        /// Gets the comment dump data
        /// </summary>
        public static List<Comment> Comments => JsonFileRetriever.GetConfigurationObjectValue<Comment>(cmCommentKey, cmDumpDataFileName);

        /// <summary>
        /// Gets the comment reply dump data
        /// </summary>
        public static List<CommentReply> CommentReplies => JsonFileRetriever.GetConfigurationObjectValue<CommentReply>(cmCommentReplyKey, cmDumpDataFileName);

        /// <summary>
        /// Gets the user-event relation dump data
        /// </summary>
        public static List<UserEventRelation> UserEventRelations => JsonFileRetriever.GetConfigurationObjectValue<UserEventRelation>(cmUserEventRelationKey, cmDumpDataFileName);

        #endregion Properties
    }
}
