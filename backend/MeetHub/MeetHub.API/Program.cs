using MeetHub.API.Context;
using MeetHub.API.Helpers.ConfigurationHelpers.Routes;
using MeetHub.API.Mappers;
using MeetHub.API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Database conenction

builder.Services.AddDbContext<MeetHubDatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnectionString")));

#endregion Database connection

#region AutoMapper Profiles

builder.Services.AddAutoMapper(typeof(UserMapper));
builder.Services.AddAutoMapper(typeof(UserEventRelationMapper));
builder.Services.AddAutoMapper(typeof(UserAccessLevelMapper));
builder.Services.AddAutoMapper(typeof(EventMapper));
builder.Services.AddAutoMapper(typeof(EventTypeMapper));
builder.Services.AddAutoMapper(typeof(EventThumbnailMapper));
builder.Services.AddAutoMapper(typeof(EventConstraintTypeMapper));
builder.Services.AddAutoMapper(typeof(CommentMapper));
builder.Services.AddAutoMapper(typeof(CommentReplyMapper));
builder.Services.AddAutoMapper(typeof(LocationMapper));
builder.Services.AddAutoMapper(typeof(GeneratedInviteMapper));
builder.Services.AddAutoMapper(typeof(CurrencyMapper));

#endregion AutoMapper Profiles

#region Repositories

builder.Services.AddScoped<ICommentReplyRepository, CommentReplyRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddScoped<IEventConstraintTypeRepository, EventConstraintTypeRepository>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventThumbnailRepository, EventThumbnailRepository>();
builder.Services.AddScoped<IEventTypeRepository, EventTypeRepository>();
builder.Services.AddScoped<IGeneratedInviteRepository, GeneratedInviteRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IUserAccessLevelRepository, UserAccessLevelRepository>();
builder.Services.AddScoped<IUserEventRelationRepository, UserEventRelationRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

#endregion Repositories

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

#region Routes mapping

var routeConfigs = RouteConfigRetriever.GetFileRoutes();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    foreach (var routeConfig in routeConfigs)
    {
        endpoints.MapControllerRoute(
            name: $"{routeConfig.Controller}_{routeConfig.Action}",
            pattern: routeConfig.Template,
            defaults: new { controller = routeConfig.Controller, action = routeConfig.Action }
        );
    }
});

app.MapControllers();

#endregion Routes mapping

app.Run();
