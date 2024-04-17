using Microsoft.EntityFrameworkCore;
using ProEvents.Application.Implementation;
using ProEvents.Application.Interface;
using ProEvents.Persistense;
using ProEvents.Persistense.Data;
using ProEvents.Persistense.Implementation;
using ProEvents.Persistense.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors();
//builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IEventPersist, EventPersist>();
builder.Services.AddScoped<IGeneralPersist, GeneralPersistence>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Validating and receiving the connection string
string SqlLiteConnection =
    builder.Configuration.GetConnectionString("Default")
    ?? throw new Exception("A connection string was not configured correctly");

builder.Services.AddDbContext<ProEventsContext>(options =>
                   options.UseSqlite(SqlLiteConnection));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x => x.AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowAnyOrigin());

app.MapControllers();

app.Run();
