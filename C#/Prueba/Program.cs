using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Prueba.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//SQLITE database
var Config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var cs = Config.GetValue<String>("ConnectionStrings:cs");
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlite(cs));

//SQLITE create database
using (SqliteConnection con = new SqliteConnection(cs))
using (SqliteCommand command = con.CreateCommand())
{
    con.Open();
    command.CommandText = "CREATE TABLE IF NOT EXISTS contacto (id TEXT, nombre TEXT, celular INTEGER);";
    command.ExecuteNonQuery();
    con.Close();
}

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5173")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseCors(MyAllowSpecificOrigins);

app.Run();
