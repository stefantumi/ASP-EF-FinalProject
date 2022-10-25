using Newtonsoft.Json;
using RealEstateAgencyApi.Data.Interfaces;
using RealEstateAgencyApi.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IRepository, AgencyRepository>();
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
const string myAllowedSpecification = "_myAllowedSpecificOrigins";
builder.Services.AddCors(options => 
    options.AddPolicy(name: myAllowedSpecification,
        policy =>
        {
            policy.WithOrigins("*", "127.0.0.1", "https://localhost/", "http://localhost:8080")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
        })
);
/*builder.Services.AddCors(options => options.AddPolicy(name:"local", policyBuilder => 
    policyBuilder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));*/


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(myAllowedSpecification);
app.UseAuthorization();
app.MapControllers();

app.Run();