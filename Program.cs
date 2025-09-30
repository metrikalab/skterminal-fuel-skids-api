using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using skterminal_fuel_skids_api.Configurations.Controllers;
using skterminal_fuel_skids_api.Configurations.CustomHttpResponses;
using skterminal_fuel_skids_api.Configurations.Databases;
using skterminal_fuel_skids_api.Repositories.GenericContract;
using skterminal_fuel_skids_api.Repositories.SkidContract;
using skterminal_fuel_skids_api.Services.SkidServices;
using skterminal_fuel_skids_api.Validators.SkidValidators;

var builder = WebApplication.CreateBuilder(args);

#region AddServices
builder.Services.AddControllers(options =>
{
  options.Filters.Add(new ValidateModelAttribute());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

#region CorsConfiguration
builder.Services.AddCors((options) =>
{
  options.AddPolicy("DevCors", (corsBuilder) =>
  {
    corsBuilder.AllowAnyOrigin()
      // WithOrigins("http://localhost:8000","http://localhost:5173")
      .AllowAnyMethod()
      .AllowAnyHeader();
    // .AllowCredentials();
  });

  options.AddPolicy("ProdCors", (corsBuilder) =>
  {
    corsBuilder.AllowAnyOrigin()
      // WithOrigins("http://localhost:8000","http://localhost:5173")
      .AllowAnyMethod()
      .AllowAnyHeader();
    // .AllowCredentials();
  });
});
#endregion

#region DatabaseConfiguration
var connectionStringSecret = builder.Configuration["CONNECTION_STRING"];
builder.Services.AddDbContext<DataContextEntityFramework>(options =>
{
  options.UseNpgsql(connectionStringSecret);
});
#endregion

#region SwaggerConfiguration
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "skView_Backend_API", Version = "v1" });

  c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
  {
    Description = "JWT Authorization header using the Bearer scheme",
    Name = "Authorization",
    In = ParameterLocation.Header,
    Type = SecuritySchemeType.ApiKey,
    Scheme = "Bearer",
    BearerFormat = "JWT"
  });

  c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
              Scheme = "oauth2",
              Name = "Bearer",
              In = ParameterLocation.Header,
            },
            Array.Empty<string>()
        }
    });
});
#endregion

builder.Services.AddHttpClient();

builder.Services.AddScoped<ISkidRepository, SkidRepository>();
builder.Services.AddScoped<ISkidValidator, SkidValidator>();
builder.Services.AddScoped<ISkidService, SkidService>();

#region Allows to Inject as dependency
#region Generic
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
#endregion
#endregion

var app = builder.Build();

#region MiddlewaresConfiguration
app.UseMiddleware<ExceptionsMiddleware>();
#endregion

#region Configure the HTTP request pipeline.
#region Development
if (app.Environment.IsDevelopment())
{
  app.UseCors("DevCors");
  // app.UseHttpsRedirection();
  app.UseSwagger();
  app.UseSwaggerUI(c =>
  {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "skterminal-operationsandcatalogues-api");

    c.InjectJavascript("/swagger/swagger.js");
  });
}
#endregion

#region Staging
if (app.Environment.IsStaging())
{
  app.UseCors("DevCors");
  // app.UseHttpsRedirection();
  app.UseSwagger();
  app.UseSwaggerUI(c =>
  {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "skView_Backend_API");

    c.InjectJavascript("/swagger/swagger.js");
  });
}
#endregion

#region Production
//At the moment allows swagger on production
if (app.Environment.IsProduction())
{
  app.UseCors("DevCors");
  // app.UseHttpsRedirection();
  app.UseSwagger();
  app.UseSwaggerUI(c =>
  {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "skterminal-operationsandcatalogues-api");

    c.InjectJavascript("/swagger/swagger.js");
  });
}
#endregion
#endregion

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();