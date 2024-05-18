using DataStoreWebAPI.Entities;
using DataStoreWebAPI.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
 
using Microsoft.AspNetCore.Authentication.Cookies;
using DataStoreWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//// Singleton funciona como se fosse um banco de dados inteiramente na memoria
//builder.Services.AddSingleton<CommonDBContext>();

// ------------------ Configuracao para banco apenas na memoria ---------
// para usar o banco em memoria, descomente essa linha
//builder.Services.AddDbContext<DbNodeHunterContext>(s => s.UseInMemoryDatabase("DbNodeHunter"));
// ----------------------------------------------------------------------

// ------------------ Configuracao de Acesso ao SQL Server ---------------
// coletando a string de conexao
var connectionString = builder.Configuration.GetConnectionString("NodeHunter");
builder.Services.AddDbContext<DbDataStoreContext>(s => s.UseSqlServer(connectionString));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<DbDataStoreContext>();
/* quando tinha dois contextos isso era necessario
builder.Services.AddDbContext<IdentityDataContext>(s => s.UseSqlServer(connectionString));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IdentityDataContext>();
*/
// --------------------Configuracao do sistema de login -----------------------------------------------------
/*
builder.Services.AddDbContext<DbDataStoreContext>(
    options => options.UseInMemoryDatabase("AppDb"));


builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<TabUsuario>()
    .AddEntityFrameworkStores<DbDataStoreContext>();
*/


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// configurando as opcoes nos cookies de login
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option => 
    {
        option.Cookie.Name = "DataStoreWebApiLoginCookie";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(10);
        option.SlidingExpiration = true; // emite novo cookie quando mais de 10/2 minutos tiver sido transcorrido
    });

// configurando a complexidade da senha de login
builder.Services.Configure<IdentityOptions>(option => {
    option.Password.RequiredLength = 5;
    option.Password.RequireNonAlphanumeric = false; 
});

builder.Services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

await CriarPerfisUsuariosAsync(app);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

async Task CriarPerfisUsuariosAsync(WebApplication app)
{
    var scoppedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scoppedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<ISeedUserRoleInitial>();
        await service.SeedRoleAsync();
        await service.SeedUserAsync();
    }
}