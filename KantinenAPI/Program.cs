using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using KantinenAPI.Repository;
using MongoDB.Driver;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Text;






var builder = WebApplication.CreateBuilder(args);

// Configure MongoDB
var mongoDbConnectionString =
    "mongodb+srv://sanaa:9xRHv28k5gLVqjL5@cluster0.9rqsi.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
var mongoClient = new MongoClient(mongoDbConnectionString);
var database = mongoClient.GetDatabase("kantinedb");



builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();



builder.Services.AddControllers();


// Configure JWT Authentication
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]))
    };
});
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

builder.Services.AddAuthorization();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthentication(); // Add this
app.UseAuthorization();

app.MapControllers();

app.Run();

