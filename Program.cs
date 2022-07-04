using BookingHotel.Models;
using BookingHotel.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddIdentity<Guest, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
builder.Services.AddDbContext<ApplicationContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("CS"));
});
//Inject
builder.Services.AddScoped<IRepositoryRoom, RoomRepository>();
builder.Services.AddScoped<IRepositoryRoomType,RoomTypeRepository>();
builder.Services.AddScoped<IRepositoryReservation,ReservationRepository>();
builder.Services.AddScoped<IRepositoryBranch,BranchRepository>();
builder.Services.AddScoped<IRepositoryRoom, RoomRepository>();
//End Inject
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
