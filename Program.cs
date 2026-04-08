using DotNetEnv;
using GerenciamentoPatrimonio.Aplications;
using GerenciamentoPatrimonio.Aplications.Service;
using GerenciamentoPatrimonio.Contexts;
using GerenciamentoPatrimonio.Interfaces;
using GerenciamentoPatrimonio.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// carregando o env
Env.Load();
// Add services to the container.

//pegando a connection string
string connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

//Conexão com o banco
builder.Services.AddDbContext<GerenciamentoPatrimoniosContext>(option => option.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Áreas
builder.Services.AddScoped<IAreaRepository, AreaRepository>();
builder.Services.AddScoped<AreaService>();

// Locais
builder.Services.AddScoped<ILocalRepository, LocalRepository>();
builder.Services.AddScoped<LocalService>();

// Cidades
builder.Services.AddScoped<ICidadeRepository, CidadeRepository>();
builder.Services.AddScoped<CidadeService>();

// Bairros
builder.Services.AddScoped<IBairroRepository, BairroRepository>();
builder.Services.AddScoped<BairroService>();

// Usuarios
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<UsuarioService>();


// Enderecos
builder.Services.AddScoped<lEnderecoRepository, EnderecoRepository>();
builder.Services.AddScoped<EnderecoService>();

// Cargos
builder.Services.AddScoped<ICargoRepository, CargoRepository>();
builder.Services.AddScoped<CargoService>();

//Solicitação Transferência
builder.Services.AddScoped<ISolicitacaoTransferenciaRepository, SolicitacaoTransferenciaRepository>();
builder.Services.AddScoped<SolicitacaoTransferenciaService>();

//trocar o builder e colocar a autenticação e logtransferencia


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
