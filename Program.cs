using AttendanceEpiisBk.Configuration.Context;
using AttendanceEpiisBk.Modules.Teacher.Application.Adapter;
using AttendanceEpiisBk.Modules.Teacher.Application.Port;
using AttendanceEpiisBk.Modules.Teacher.Domain.IRepository;
using AttendanceEpiisBk.Modules.Teacher.Infraestructure.Presenter;
using AttendanceEpiisBk.Modules.Teacher.Infraestructure.Repository;
using AttendanceEpiisBk.Modules.User.Application.Adapter;
using AttendanceEpiisBk.Modules.User.Application.Port;
using AttendanceEpiisBk.Modules.User.Domain.IRepository;
using AttendanceEpiisBk.Modules.User.Infraestructure.Presenter;
using AttendanceEpiisBk.Modules.User.Infraestructure.Repository;
using AutoMapper;
using Mapster;
using Microsoft.EntityFrameworkCore;
using AttendanceEpiisBk.Mapping;
using AttendanceEpiisBk.Modules.Research.Application.Adapter;
using AttendanceEpiisBk.Modules.Research.Application.Port;
using AttendanceEpiisBk.Modules.Research.Domain.IRepository;
using AttendanceEpiisBk.Modules.Research.Infraestructure.Presenter;
using
    AttendanceEpiisBk.Modules.Research.Infraestructure.Repository; // Asegúrate de incluir el espacio de nombres de AutoMapper

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MySqlContext>();
builder.Services.AddMapster();
MappingConfig.RegisterMappings();

builder.Services.AddScoped<IUserInputPort, UserAdapter>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserOutPort, UserPresenter>();

builder.Services.AddScoped<ITeacherInputPort, TeacherAdapter>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<ITeacherOutPort, TeacherPresenter>();

builder.Services.AddScoped<IResearchInputPort, ResearchAdapter>();
builder.Services.AddScoped<IResearchRepository, ResearchRepository>();
builder.Services.AddScoped<IResearchOutPort, ResearchPresenter>();


// Configuración de CORS para permitir cualquier origen
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Apply migrations and update database automatically
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MySqlContext>();
    if (dbContext.Database.GetPendingMigrations().Any())
    {
        dbContext.Database.Migrate();
        Console.WriteLine("Migraciones aplicadas correctamente.");
    }
    else
    {
        dbContext.Database.EnsureCreated();
        Console.WriteLine("Base de datos ya estaba actualizada.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Habilitar CORS para todos los orígenes
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();