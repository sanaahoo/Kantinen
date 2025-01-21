using Core.Model;
using Core.Services;
using KantinenAPI.Repository;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();

public void ConfigureServices(IServiceCollection services)
{
    services.Configure<MongoDB>(Configuration.GetSection("MongoDBSettings"));

    services.AddSingleton<IMongoClient, MongoClient>(sp =>
    {
        var settings = sp.GetRequiredService<IOptions<MongoDB>>().Value;
        return new MongoClient(settings.ConnectionString);
    });

    // Add other services
    services.AddRazorPages();
}
