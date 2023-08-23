using NodeHunterWebAPI.Persistence;
using Microsoft.EntityFrameworkCore;

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
builder.Services.AddDbContext<DbNodeHunterContext>(s => s.UseSqlServer(connectionString));

// -------------------------------------------------------------------------


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
