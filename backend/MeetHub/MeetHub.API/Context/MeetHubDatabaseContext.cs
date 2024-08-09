using MeetHub.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeetHub.API.Context
{
    public class MeetHubDatabaseContext : DbContext
    {
        #region Constructor

        public MeetHubDatabaseContext(DbContextOptions<MeetHubDatabaseContext> options) : base(options)
        {
            
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets the users table definition
        /// </summary>
        public DbSet<User> Users
        {
            get;
            set;
        }

        /// <summary>
        /// The user acccess levels table definition
        /// </summary>
        public DbSet<UserAccessLevel> UserAccessLevels
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user-event relations table definition
        /// </summary>
        public DbSet<UserEventRelation> UserEventRelations
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the events table definition
        /// </summary>
        public DbSet<Event> Events
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the event types table definition
        /// </summary>
        public DbSet<EventType> EventTypes
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the event thumbnails table definition
        /// </summary>
        public DbSet<EventThumbnail> EventThumbnails
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user contraint types table defintion
        /// </summary>
        public DbSet<EventConstraintType> EventConstraintTypes
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the comments table definition
        /// </summary>
        public DbSet<Comment> Comments
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the comment replies table definition
        /// </summary>
        public DbSet<CommentReply> CommentReplies
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the locations table definition
        /// </summary>
        public DbSet<Location> Locations
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the generated invites table definition
        /// </summary>
        public DbSet<GeneratedInvite> GeneratedInvites
        {
            get; 
            set;
        }

        /// <summary>
        /// Gets or sets the currencies table definition
        /// </summary>
        public DbSet<Currency> Currencies
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Creates many to many relations for database tables
        /// </summary>
        /// <param name="modelBuilder"> The model builder that will create the database structure </param>
        private void CreateManyToManyTableRelations(ref ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEventRelation>()
                .HasKey(relation => new { relation.UserId, relation.EventId });

            modelBuilder.Entity<UserEventRelation>()
                .HasOne(relation => relation.User)
                .WithMany(user => user.Relations)
                .HasForeignKey(relation => relation.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserEventRelation>()
                .HasOne(relation => relation.Event)
                .WithMany(ev => ev.Relations)
                .HasForeignKey(relation => relation.EventId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        /// <summary>
        /// Adds the test data to the database
        /// </summary>
        /// <param name="modelBuilder">  The model builder that will create the database structure </param>
        private void AddDumpData(ref ModelBuilder modelBuilder)
        {
            // TODO: Add json with dump data and populate the table for first migration
        }

        #endregion Methods

        #region Override

        /// <summary>
        /// Creates the structural model for the database
        /// </summary>
        /// <param name="modelBuilder"> The model builder that will create the database structure </param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateManyToManyTableRelations(ref modelBuilder);
            AddDumpData(ref modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        #endregion Override

    }
}
