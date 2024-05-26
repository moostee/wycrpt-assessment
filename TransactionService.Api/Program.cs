using TransactionService.Api;
using TransactionService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();

builder.Services.AddControllers();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
   {
       builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
   }));

builder.Services
    .AddSwagger()
    .AddInfrastructure(builder.Configuration.GetConnectionString("DefaultConnection"), builder.Configuration);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsapp");
app.UseHttpsRedirection();

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseInfrastructure();

app.MapControllers();

app.Run();

