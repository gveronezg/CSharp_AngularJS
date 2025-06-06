using Microsoft.OpenApi.Models; // Esta linha importa as classes necessárias para trabalhar com o Swagger (documentação da API)
using MeuPrimeiroProjetoCSharp.Data; // Importa o contexto do banco de dados que criamos anteriormente
using Microsoft.EntityFrameworkCore; // Importa o Entity Framework Core, que é usado para interagir com o banco de dados
using MeuPrimeiroProjetoCSharp.Services; // Importa os serviços que criamos para manipular usuários
using Microsoft.AspNetCore.Authentication.JwtBearer; // Importa classes necessárias para autenticação JWT (JSON Web Tokens)
using Microsoft.IdentityModel.Tokens; // Também para TokenValidationParameters
using Microsoft.Extensions.FileProviders;
using System.IO;

// URL do JWKS do Supabase
string supabaseJWKS = "uefXCXju5c2iyInR10MjbtuoUX4+pc3HU+A2HD3SG+8VAOPLfO9LXMDJm8uFStNECPkyDJGw1RcAgZ5PP7xtZQ==";

/*
    var: Palavra-chave que deixa o C# adivinhar o tipo da variável
    WebApplication.CreateBuilder: Cria um construtor para nossa aplicação web
    args: São argumentos passados para a aplicação quando ela inicia
*/
var builder = WebApplication.CreateBuilder(args);

// -------------------- CONFIGURAÇÕES DE BANCO DE DADOS --------------------
builder.Services.AddDbContext<MeuDbContext>(options => // Configura o DbContext para usar PostgreSQL
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); // Adiciona o DbContext

// -------------------- CONFIGURAÇÃO DE AUTENTICAÇÃO JWT via Supabase --------------------
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://jhqlfzrqcbhjguzabfna.supabase.co";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "https://jhqlfzrqcbhjguzabfna.supabase.co",
            ValidateAudience = true,
            ValidAudience = "authenticated",  // ou "anon", se quiser
            ValidateLifetime = true,  // Garantir que token não esteja expirado
            ValidateIssuerSigningKey = true // Valida a chave pública do JWKS
        };
        options.RequireHttpsMetadata = true; // O Supabase exige HTTPS
    });

// -------------------- REGISTRO DE SERVIÇOS E DEPENDÊNCIAS --------------------
builder.Services.AddControllers(); // Adiciona suporte a Controllers
builder.Services.AddCors(); // Adiciona suporte a CORS
builder.Services.AddScoped<IUsuarioService, UsuarioService>(); // Registra o serviço de usuários para injeção de dependência
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // Configura o AutoMapper para mapear objetos entre DTOs e modelos
builder.Services.AddEndpointsApiExplorer(); // Adiciona suporte a explorar endpoints (usado pelo Swagger)
builder.Services.AddSwaggerGen(); // Configura o Swagger para gerar documentação da API

// -------------------- CONSTRÓI A APLICAÇÃO --------------------
var app = builder.Build(); // Cria a aplicação web com todas as configurações que definimos

// -------------------- CONFIGURAÇÃO DE MIDDLEWARE --------------------

// Middleware de CORS (libera acesso de qualquer origem, pode restringir se quiser)
app.UseCors(policy => policy
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication(); // Middleware de autenticação
app.UseAuthorization(); // Middleware de autorização

/*
    IsDevelopment(): Verifica se estamos em ambiente de desenvolvimento
    UseSwagger: Ativa o Swagger
    UseSwaggerUI: Ativa a interface do Swagger no navegador
*/
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Redireciona todas as requisições HTTP para HTTPS (mais seguro)

app.MapGet("/", () => Results.Redirect("/index.html")); // Esse código redireciona qualquer requisição para a raiz do servidor para a página index.html.

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "Templates")),
    RequestPath = ""
});

app.MapControllers(); // Mapeia todos os endpoints de Controllers automaticamente

var summaries = new[] // Cria um array com descrições de temperaturas de exemplo
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

/*
    MapGet: Cria um endpoint que responde a requisições GET
    /weatherforecast: O caminho do endpoint
    () =>: Função anônima que será executada quando o endpoint for acessado
    Enumerable.Range(1, 5): Cria uma sequência de 5 números
    Select: Transforma cada número em uma previsão do tempo
    DateOnly.FromDateTime: Converte a data atual
    Random.Shared.Next: Gera números aleatórios
    WithName: Dá um nome ao endpoint
*/
app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

// Inicia o navegador automaticamente com a URL do Swagger
System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("cmd", $"/c start http://localhost:5292") { CreateNoWindow = true });

app.Run(); // Inicia a aplicação fezendo-a começar a escutar por requisições

/*
    record: Tipo especial de classe para dados imutáveis
    DateOnly Date: Data da previsão
    int TemperatureC: Temperatura em Celsius
    string? Summary: Descrição do tempo (pode ser nulo)
    TemperatureF: Propriedade calculada que converte Celsius para Fahrenheit
*/
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}