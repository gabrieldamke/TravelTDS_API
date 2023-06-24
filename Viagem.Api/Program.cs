global using Data;
global using Microsoft.EntityFrameworkCore;
using Domain.Contracts;
using AspNetCore.Authentication.Basic;
using Microsoft.AspNetCore.Authentication;
using idunno.Authentication.Basic;
using Services.Services;
using Services.Services.Services.Services;
using System.Security.Claims;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

#region Configura��es do Swagger  

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TDS VIAJA API", Version = "v1" });
    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "basic",
        In = ParameterLocation.Header,
        Description = "Autentica��o basica usando o esquema Bearer."
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "basic"
                                }
                            },
                            new string[] {}
                    }
                });
});


#endregion

#region Configura��es da autentica��o
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null)
    .AddBasic(options =>
    {
        options.Realm = "NomeDoRealm"; // Substitua pelo nome desejado para o Realm
        options.Events = new BasicAuthenticationEvents
        {
            OnValidateCredentials = async context =>
            {
                // Obtenha a inst�ncia do servi�o de usu�rio
                var usuarioService = context.HttpContext.RequestServices.GetRequiredService<IUsuarioService>();

                // Verifique as credenciais do usu�rio
                var usuario = await usuarioService.ObterUsuarioPorEmail(context.Username);

                if (usuario == null || usuario.Senha != context.Password)
                {
                    context.Fail("Credenciais inv�lidas");
                    return;
                }

                // Defina as informa��es de identidade do usu�rio autenticado
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.TipoPermissao)
                };

                context.Principal = new ClaimsPrincipal(
                    new ClaimsIdentity(claims, context.Scheme.Name));

                context.Success();
            }
        };
    });
#endregion

#region Configura��o do Banco de dados
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
#endregion

#region Configura��o dos servi�os
builder.Services.AddScoped<IAtracaoTuristicaService, AtracaoTuristicaService>();
builder.Services.AddScoped<ILocalService, LocalService>();
builder.Services.AddScoped<IDestinoService, DestinoService>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IParteViagemService, ParteViagemService>();
builder.Services.AddScoped<IRestauranteService, RestauranteService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IViagemService, ViagemService>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthorization();

#endregion

#region configura��o do builder
var app = builder.Build();
app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion
