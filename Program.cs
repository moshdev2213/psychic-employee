using Api_2;
using Api_2._0;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// swagger configs
builder.Services.AddSwaggerGen(options=>{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo(){
        Title="Employee Management",
        Version= "v1"
    });
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Please Enter a Token",
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement(){
        {
            new OpenApiSecurityScheme{
                Reference = new OpenApiReference{
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            []
        }
    });
});

// db context
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnections"))
);

// adding authz
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<AppDbContext>();

// builder.Services.AddAll
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(Options =>
Options.WithOrigins("*").AllowAnyHeader().AllowAnyMethod()
);

app.UseHttpsRedirection();

// mapping controllers
app.MapIdentityApi<User>();
app.MapControllers();

app.Run();

