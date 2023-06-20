global using Data;
global using Microsoft.EntityFrameworkCore;
using Domain.Contracts;
using Services;
using Services.Services;
using Services.Services.Services.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IAtracaoTuristicaService, AtracaoTuristicaService>();
builder.Services.AddScoped<ILocalService, LocalService>();
builder.Services.AddScoped<IDestinoService, DestinoService>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IParteViagemService, ParteViagemService>();
builder.Services.AddScoped<IRestauranteService, RestauranteService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IViagemService, ViagemService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
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
