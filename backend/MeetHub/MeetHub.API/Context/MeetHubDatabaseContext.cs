using MeetHub.API.Entities;
using MeetHub.API.Helpers.ConfigurationHelpers;
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
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserEventRelation>()
                .HasOne(relation => relation.Event)
                .WithMany(ev => ev.Relations)
                .HasForeignKey(relation => relation.EventId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        /// <summary>
        /// Creates the constraints for circular table relations
        /// </summary>
        /// <param name="modelBuilder"> The model builder that will create the database structure </param>
        private void CreateSpecialCasesConstraints(ref ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .HasOne(com => com.User)
                .WithMany(user => user.Comments)
                .HasForeignKey(com => com.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(com => com.Event)
                .WithMany(user => user.Comments)
                .HasForeignKey(com => com.EventId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GeneratedInvite>()
                .HasOne(gi => gi.User)
                .WithMany(user => user.GeneratedInvites)
                .HasForeignKey(gi => gi.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GeneratedInvite>()
                .HasOne(gi => gi.Event)
                .WithMany(ev => ev.GeneratedInvites)
                .HasForeignKey(gi => gi.EventId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        /// <summary>
        /// Adds the test data to the database
        /// </summary>
        /// <param name="modelBuilder">  The model builder that will create the database structure </param>
        private void AddDumpData(ref ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .HasData(DumpDataConfiguration.Locations.ToArray());

            modelBuilder.Entity<EventType>()
                .HasData(DumpDataConfiguration.EventTypes.ToArray());

            modelBuilder.Entity<EventThumbnail>()
                .HasData(DumpDataConfiguration.EventThumbnails.ToArray());

            modelBuilder.Entity<EventConstraintType>()
                .HasData(DumpDataConfiguration.EventConstraintTypes.ToArray());

            modelBuilder.Entity<Currency>()
                .HasData(DumpDataConfiguration.Currencies.ToArray());

            modelBuilder.Entity<UserAccessLevel>()
                .HasData(DumpDataConfiguration.UserAccessLevels.ToArray());

            modelBuilder.Entity<User>()
                .HasData(DumpDataConfiguration.Users.ToArray());

            modelBuilder.Entity<Event>()
                .HasData(DumpDataConfiguration.Events.ToArray());

            modelBuilder.Entity<Comment>()
                .HasData(DumpDataConfiguration.Comments.ToArray());

            modelBuilder.Entity<CommentReply>()
                .HasData(DumpDataConfiguration.CommentReplies.ToArray());

            modelBuilder.Entity<GeneratedInvite>()
                .HasData(DumpDataConfiguration.GeneratedInvites.ToArray());

            modelBuilder.Entity<UserEventRelation>()
                .HasData(DumpDataConfiguration.UserEventRelations.ToArray());
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
            CreateSpecialCasesConstraints(ref modelBuilder);
            AddDumpData(ref modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        #endregion Override

    }
}
