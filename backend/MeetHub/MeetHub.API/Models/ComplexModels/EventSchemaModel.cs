using MeetHub.API.Entities;

namespace MeetHub.API.Models.ComplexModels
{
    /// <summary>
    /// The event schema model class
    /// </summary>
    public class EventSchemaModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Id field of the event schema model class class
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the title field for the event schema model class class
        /// </summary>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the description field if the event schema model class class
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the start date field for the event schema model class class
        /// </summary>
        public DateTime StartDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the end date field for the event schema model class class
        /// </summary>
        public DateTime EndDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the location Id field for the event schema model class class
        /// </summary>
        public int LocationId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the creator Id field for the event schema model class class
        /// </summary>
        public int CreatorId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the event type Id field for the event schema model class class
        /// </summary>
        public int EventTypeId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the event constraint type Id field for the event schema model class class
        /// </summary>
        public int EventConstraintTypeId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the is age restricted field for the event schema model class class
        /// </summary>
        public bool MaximumAgeAllowed
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the minimum age allowed field for the event schema model class class
        /// </summary>
        public int MinimumAgeAllowd
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the maximum age allowed field for the event schema model class class
        /// </summary>
        public bool IsAgeRestricted
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the enter fee field for event schema model class class
        /// </summary>
        public int EnterFee
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the currency Id field for event schema model class class
        /// </summary>
        public int CurrencyId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the event thumbnail Id field for event schema model class class
        /// </summary>
        public int EventThumbnailId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the minimum number of participants field for event schema model class class
        /// </summary>
        public int MinimumNumberOfParticipants
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the maximum number of participants field for event schema model class class
        /// </summary>
        public int MaximumNumberOfParticipants
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the event type property for event schema model class
        /// </summary>
        public EventTypeModel EventType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the event constraint type property for event schema model class
        /// </summary>
        public EventConstraintTypeModel EventConstraintType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the currency property for event schema model class
        /// </summary>
        public CurrencyModel Currency
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the event thumbnail property for event schema model class
        /// </summary>
        public EventThumbnailModel EventThumbnail
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the event users property for event schema model class
        /// </summary>
        public List<UserModel> Users
        {
            get;
            set;
        }

        #endregion Properties

    }
}
