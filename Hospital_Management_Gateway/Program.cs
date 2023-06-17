using Hospital_Management_Gateway;
using Hospital_Management_Gateway.Repository.IRepository;
using Hospital_Management_Gateway.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient<IAnalystRepository, AnalystRepository>();
SD.Hospital_ServiceBase = builder.Configuration["ServiceUrls:Hospital_Service"];
SD.Appointment_ServiceBase = builder.Configuration["ServiceUrls:Appointment_Service"];
SD.Clinic_ServiceBase = builder.Configuration["ServiceUrls:Clinic_Service"];

builder.Services.AddScoped<IAnalystRepository, AnalystRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
