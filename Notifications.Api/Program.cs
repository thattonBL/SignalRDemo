using Microsoft.AspNetCore.Authentication.JwtBearer;
using Notifications.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddSignalR();

builder.Services.AddCors();

builder.Services.AddAuthorization();
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var signalRClientUrl = builder.Configuration["ClientUrls:GlobalIntegrationUI"] ?? throw new Exception();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins(signalRClientUrl).AllowCredentials());

app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

app.MapHub<NotificationsHub>("notifications");

app.Run();
