using Core.Model;
using Core.Services;
using KantinenAPI.Repository;
using MongoDB.Driver;






var builder = WebApplication.CreateBuilder(args);

// Configure MongoDB
var mongoDbConnectionString =
    "mongodb+srv://sanaa:9xRHv28k5gLVqjL5@cluster0.9rqsi.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
var mongoClient = new MongoClient(mongoDbConnectionString);
var database = mongoClient.GetDatabase("kantinedb");

// Register MongoDB Services
//builder.Services.AddSingleton<IMongoClient>(mongoClient);
//builder.Services.AddSingleton(database);


builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

