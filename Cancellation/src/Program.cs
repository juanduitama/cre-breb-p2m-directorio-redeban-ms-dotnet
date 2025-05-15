using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SPI_Cancellation_Service.Infrastructure.repositories;
using SPI_Cancellation_Service.Proxy.cancellation;
using SPI_Cancellation_Service.Proxy.interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//// Registrar los servicios
//builder.Services.AddSingleton<IRedDeleteAccountService, RedDeleteAccountServiceImpl>();
//builder.Services.AddSingleton<IOAuthService, OAuthService>();

// Configurar logging
builder.Services.AddLogging(options =>
{
    options.AddConsole();
    options.AddDebug();
});

#region Contexto de bases de datos 

var cnxBuilder = new SqlConnectionStringBuilder
{
    DataSource = Environment.GetEnvironmentVariable("SERVER"),
    InitialCatalog = Environment.GetEnvironmentVariable("DATABASE"),
    UserID = Environment.GetEnvironmentVariable("USER_ID"),
    Password = Environment.GetEnvironmentVariable("PASSWORD"),
    IntegratedSecurity = Convert.ToBoolean(Environment.GetEnvironmentVariable("INTEGRATED_SECURITY")),
    TrustServerCertificate = Convert.ToBoolean(Environment.GetEnvironmentVariable("TRUST_SERVER_CERTIFICATE"))
};

builder.Services.AddDbContext<AuroraDbContext>(options =>
    options.UseMySql(cnxBuilder.ConnectionString, ServerVersion.AutoDetect(cnxBuilder.ConnectionString)));

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();