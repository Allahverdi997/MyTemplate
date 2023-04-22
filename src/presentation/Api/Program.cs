using Api.Filters;
using Application.Validation.Base;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Infrastructure.DependencyInjection;
using Infrastructure.DependencyInjection.AspNet;
using Infrastructure.DependencyInjection.Autofac;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(option =>
{
    option.Filters.Add(typeof(AuthenticationFilter), 1);
    option.Filters.Add(typeof(ModelStateFilterAttribute), 2);
    option.Filters.Add(typeof(UnhandledExceptionFilter), 3);
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SimaWebsite.WebAPI",
        Version = "v1"
    });
    c.OperationFilter<SwaggerAddAuthenticationHeaderFilter>();
});

builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
} 
).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<GeneralValidator>()); ;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacModule()));
builder.Services.RegisterServicesFromPersistance(builder.Configuration);
builder.Services.RegisterServicesFromInfrastructure(builder.Configuration);
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
