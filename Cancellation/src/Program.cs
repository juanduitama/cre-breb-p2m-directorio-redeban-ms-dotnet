using SPI_Cancellation_Service.Proxy.cancellation;
using SPI_Cancellation_Service.Proxy.interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar los servicios
builder.Services.AddSingleton<IRedDeleteAccountService, RedDeleteAccountServiceImpl>();
builder.Services.AddSingleton<IOAuthService, OAuthService>();

// Configurar logging
builder.Services.AddLogging(options =>
{
    options.AddConsole();
    options.AddDebug();
});

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