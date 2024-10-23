using Microsoft.EntityFrameworkCore;
using MarcasAutosAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar la conexi�n a PostgreSQL usando Entity Framework
builder.Services.AddDbContext<MarcasAutosContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

// Agregar servicios al contenedor
builder.Services.AddControllers();  // A�ade los controladores

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<MarcasAutosContext>();
    context.Database.Migrate();  // Aplica las migraciones pendientes autom�ticamente al iniciar la aplicaci�n
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization(); 

app.MapControllers();  // Mapea los controladores de la API

app.Run();

