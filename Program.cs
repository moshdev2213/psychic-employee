using Api_2._0;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// the service configs are handled
ServiceConfiguration.Configure(builder.Services, builder.Configuration);

// builder.Services.AddAll
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// the default cors option
app.UseCors();
// defined cors option
// app.UseCors("AllowAll");

app.UseHttpsRedirection();

// mapping controllers
app.MapIdentityApi<User>();
app.MapControllers();

app.Run();

