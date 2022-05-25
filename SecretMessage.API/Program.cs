using FirebaseAdmin;
using FirebaseAdminAuthentication.DependencyInjection.Extensions;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authorization;
using SecretMessage.API.Responses;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton(FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromJson(builder.Configuration.GetValue<string>("FIREBASE_CONFIG"))
}));
builder.Services.AddFirebaseAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", [Authorize] () =>
{
    return Results.Json(new SecretMessageResponse() { Message = "Firebase is cool." });
});

app.Run();
