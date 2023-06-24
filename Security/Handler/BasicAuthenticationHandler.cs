using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text;
using AspNetCore.Authentication.Basic;
using Domain.Contracts;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;

public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IUsuarioService _usuarioService;

    public BasicAuthenticationHandler(
        IUsuarioService usuarioService,
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock)
        : base(options, logger, encoder, clock)
    {
        _usuarioService = usuarioService;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.ContainsKey("Authorization"))
        {
            return AuthenticateResult.Fail("Cabeçalho 'Authorization' não encontrado");
        }

        try
        {
            var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var decodedCredentials = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationHeaderValue.Parameter));
            var credentials = decodedCredentials.Split(':', 2);
            var username = credentials[0];
            var password = credentials[1];

            // Verifique as credenciais do usuário
            var usuario = await _usuarioService.ObterUsuarioPorEmail(username);

            if (usuario == null || usuario.Senha != password)
            {
                return AuthenticateResult.Fail("Credenciais inválidas");
            }

            var claims = new[] { new Claim(ClaimTypes.Name, usuario.Email), new Claim(ClaimTypes.Role, usuario.TipoPermissao) };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
        catch
        {
            return AuthenticateResult.Fail("Erro ao processar as credenciais");
        }
    }
}