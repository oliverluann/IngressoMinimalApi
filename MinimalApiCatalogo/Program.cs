using IngressoMinimalApi.ApiEndpoints;
using IngressoMinimalApi.AppServicesExtensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MinimalApiCatalogo.Context;
using MinimalApiCatalogo.Models;
using MinimalApiCatalogo.Services;
using Newtonsoft.Json.Linq;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

//INCLUINDO OS SERVIÇOS NO CONTAINER NATIVO E FAZENDO AS CONFIGURAÇÕES
//TODOS OS MÉTODOS DE EXTENSÃO, DEFINIDOS NA CLASSE *SERVICECOLLECTION.
builder.AddApiSwagger();
builder.AddPersistence();
builder.Services.AddCors();
builder.AddAutenticationJwt();

var app = builder.Build();

//DEFINE OS ENDPOINTS, DEFINIDOS NA PASTA *ENDPOINTS.
app.MapAutenticacaoEndpoints();
app.MapCategoriasEndpoints();
app.MapIngressosEndpoints();

//OBTÉM O CONTEXTO E CONFIGURA OS SERVIÇOS NA CLASSE *APPAPLICATIONBUILDER.
//HABILITAÇÃO DE MIDDLEWARE DO SWAGGER.
//DEFINIÇÃO DA POLITICA CORS.
var envoiroment = app.Environment;
app.UseExceptionHandling(envoiroment)
    .UseSwaggerMiddleware()
    .UseAppCors();

//HABILITAÇÃO DA AUTENTICAÇÃO E AUTORIZAÇÃO.
app.UseAuthentication();
app.UseAuthorization();

app.Run();

