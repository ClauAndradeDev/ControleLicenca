using ControleLicenca.Api.App.Context;
using ControleLicenca.Api.Mapper;
using ControleLicenca.Api.Repositorios;
using ControleLicenca.Api.Services.Cadastro;
using ControleLicenca.Api.Services.Movimentacao;
using ControleLicenca.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ControleLicencaAPI", Version = "v1" });

});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.EnableSensitiveDataLogging();
});

builder.Services.AddTransient<AppDbContextFactory>();
builder.Services.AddTransient(opt => opt.GetService<AppDbContextFactory>().CreateDbContext());

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true, // Defina como true se desejar validar o emissor (issuer)
//            ValidateAudience = true, // Defina como true se desejar validar a audiência
//            ValidateLifetime = true, // Defina como true se desejar validar a validade do token
//            ValidateIssuerSigningKey = true, // Defina como true se desejar validar a chave de assinatura
//            ValidIssuer = "controlelicenca_issuer",
//            ValidAudience = "controlelicenca_audience",
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("c2157d46fa4cb606e924ab1d1e0e1d5b868adf9a8d690fd41820fa8433e475b4"))
//        };
//    });

/*REPOSITORIOS*/
builder.Services.AddTransient<ClienteRepositorio>();
builder.Services.AddTransient<ContratoRepositorio>();
builder.Services.AddTransient<LicencaRepositorio>();
builder.Services.AddTransient<ProdutoRepositorio>();
builder.Services.AddTransient<UsuarioRepositorio>();

/*SERVIÇOS*/
builder.Services.AddTransient<ClienteService>();
builder.Services.AddTransient<ContratoService>();
builder.Services.AddTransient<LicencaService>();
builder.Services.AddTransient<ProdutoService>();
builder.Services.AddTransient<UsuarioService>();

builder.Services.AddTransient<Mapper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/swagger/v1/swagger.json", "ControleLicencaAPI v1");
        opt.RoutePrefix = String.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
