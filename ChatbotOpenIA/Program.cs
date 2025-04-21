using DataAccess.DataModel.DracarysModel;
using Entities.Commons;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

 

// Configure Basic Authentication Scheme
builder.Services.AddAuthentication("BasicAuthentication") // Add authentication scheme named "BasicAuthentication"
    .AddScheme<AuthenticationSchemeOptions, BusinessLogic.Security.BasicAuthenticationHandler>("BasicAuthentication", null);
 

// Register the custom authentication handler (BasicAuthenticationHandler) for Basic Authentication.
// Add services to the container.
builder.Services.AddControllers();

 

// Configure Swagger for API documentation with Basic Authentication
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
     
    
    // Define Basic Authentication for Swagger
    c.AddSecurityDefinition("Basic", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization", // Name of the HTTP header
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http, // Type of security scheme
        Scheme = "basic", // Use "basic" authentication scheme
        In = Microsoft.OpenApi.Models.ParameterLocation.Header, // Authorization info will be sent in HTTP headers
        Description = "Enter your username and password in the `Basic` format." // Swagger prompt for credentials
    });
     
    
    // Require Basic Authentication for all Swagger endpoints
    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme, // Link to the Basic Authentication scheme
                    Id = "Basic" // Match the ID defined in AddSecurityDefinition
                }
            },
            new string[] {} // No specific scopes required
        }
    });
});


// Database configuration and service registration


// Register the DataBaseDTO as a singleton service to ensure a single instance is shared across the application.
builder.Services.AddSingleton<DataBaseDTO>();

// Configure the DracarysContext to use the connection string provided by the DataBaseDTO.
builder.Services.AddScoped<DracarysContext>(provider =>
{
    var dbDTO = provider.GetRequiredService<DataBaseDTO>();
    var options = new DbContextOptionsBuilder<DracarysContext>()
        .UseSqlServer(dbDTO.DefaultConnection)
        .Options;

    return new DracarysContext(options);
});




var app = builder.Build();
 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Enable Swagger in development mode
    app.UseSwaggerUI(); // Configure Swagger UI
}

app.UseAuthentication(); // Enable the middleware for authentication
app.UseAuthorization(); // Enable the middleware for authorization

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
