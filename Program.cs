using BookingHotel.Helpers;
using BookingHotel.Models;
using BookingHotel.Repository;
using BookingHotel.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddIdentity<Guest, IdentityRole>().AddDefaultTokenProviders().AddEntityFrameworkStores<ApplicationContext>();
builder.Services.AddDbContext<ApplicationContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("CS"));
});
builder.Services.AddAutoMapper(typeof(Program));
//Inject
builder.Services.AddScoped<IRepositoryRoom, RoomRepository>();
builder.Services.AddScoped<IRepositoryRoomType,RoomTypeRepository>();
builder.Services.AddScoped<IRepositoryReservation,ReservationRepository>();
builder.Services.AddScoped<IRepositoryReservationRoom,ReservationRoomRepository>();
builder.Services.AddScoped<IRepositoryBranch,BranchRepository>();
builder.Services.AddScoped<IRepositoryRoom, RoomRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
//End Inject
builder.Services.AddControllers().AddNewtonsoftJson(options=>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter You Auth Key"
    });
    options.AddSecurityRequirement(securityRequirement: new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Name = "Bearer",
                In =ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

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
