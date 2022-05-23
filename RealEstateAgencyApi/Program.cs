using Newtonsoft.Json;
using RealEstateAgencyApi.Data.Interfaces;
using RealEstateAgencyApi.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IRepository, AgencyRepository>();
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
builder.Services.AddCors(options => options.AddPolicy(name:"local", policyBuilder => 
    policyBuilder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));


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
app.UseCors();
app.UseAuthorization();
app.MapControllers();

app.Run();

/*
 * sudo docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=StefanTumi.7" \
   -p 1433:1433 --name Agencies --hostname Agencies \
   -d mcr.microsoft.com/mssql/server:2019-latest


   sudo docker exec -it sql1 /opt/mssql-tools/bin/sqlcmd \
-S localhost -U SA \
 -P "$(read -sp "Enter current SA password: "; echo "${REPLY}")" \
 -Q "ALTER LOGIN SA WITH PASSWORD=\"$(read -sp "Enter new SA password: "; echo "${REPLY}")\""
 */