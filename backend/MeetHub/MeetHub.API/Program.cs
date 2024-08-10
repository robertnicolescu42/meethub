using MeetHub.API.Context;
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

builder.Services.AddDbContext<MeetHubDatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

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

#region Database action

builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();

#endregion Database action

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
