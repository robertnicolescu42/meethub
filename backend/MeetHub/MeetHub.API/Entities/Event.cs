using MeetHub.API.Helpers;
using System.ComponentModel.DataAnnotations;

namespace MeetHub.API.Entities
{
    /// <summary>
    /// The event entity class
    /// </summary>
    public class Event
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Id field of the event class
        /// </summary>
        [Key]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the title field for the event class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the description field if the event class
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the start date field for the event class
        /// </summary>
        public DateTime StartDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the end date field for the event class
        /// </summary>
        public DateTime EndDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the location Id field for the event class
        /// </summary>
        public int LocationId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the creator Id field for the event class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public int CreatorId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the event type Id field for the event class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public int EventTypeId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the event constraint type Id field for the event class
        /// </summary>
        [Required(ErrorMessage = Constants.cmRequiredErrorMessage)]
        public int EventConstraintTypeId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the is age restricted field for the event class
        /// </summary>
        public bool MaximumAgeAllowed
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the minimum age allowed field for the event class
        /// </summary>
        public int MinimumAgeAllowd
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the maximum age allowed field for the event class
        /// </summary>
        public bool IsAgeRestricted
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the enter fee field for event class
        /// </summary>
        public int EnterFee
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the currency Id field for event class
        /// </summary>
        public int CurrencyId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the event thumbnail Id field for event class
        /// </summary>
        public int EventThumbnailId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the minimum number of participants field for event class
        /// </summary>
        public int MinimumNumberOfParticipants
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the maximum number of participants field for event class
        /// </summary>
        public int MaximumNumberOfParticipants
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the location navigation property for event class
        /// </summary>
        public Location Location
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user navigation property for event class
        /// </summary>
        public User User
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the event type navigation property for event class
        /// </summary>
        public EventType EventType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the event constraint type navigation property for event class
        /// </summary>
        public EventConstraintType EventConstraintType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the currency navigation property for event class
        /// </summary>
        public Currency Currency
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the event thumbnail navigation property for event class
        /// </summary>
        public EventThumbnail EventThumbnail
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the event to user relations navigation property for event class
        /// </summary>
        public List<UserEventRelation> Relations
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the generated invites navigation property for event class
        /// </summary>
        public List<GeneratedInvite> GeneratedInvites
        {
            get;
            set;
        }

        #endregion Properties
    }
}
