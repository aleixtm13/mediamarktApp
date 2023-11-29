using Application;
using Infrastructure;
using Web.API;
using Web.API.Extensions;
using Web.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation()
    .AddInfrastructure(builder.Configuration)
    .AddApplication();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseCors("corsapp");
app.UseAuthorization();


app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
