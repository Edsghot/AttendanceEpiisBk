using AttendanceEpiisBk.Configuration.Context;
using AttendanceEpiisBk.Modules.Teacher.Application.Adapter;
using AttendanceEpiisBk.Modules.Teacher.Application.Port;
using AttendanceEpiisBk.Modules.Teacher.Domain.IRepository;
using AttendanceEpiisBk.Modules.Teacher.Infraestructure.Presenter;
using AttendanceEpiisBk.Modules.Teacher.Infraestructure.Repository;
using Mapster;
using Microsoft.EntityFrameworkCore;
using AttendanceEpiisBk.Mapping;
using AttendanceEpiisBk.Modules.Event.Application.Adapter;
using AttendanceEpiisBk.Modules.Event.Application.Port;
using AttendanceEpiisBk.Modules.Event.Domain.IRepository;
using AttendanceEpiisBk.Modules.Event.Infraestructure.Presenter;
using AttendanceEpiisBk.Modules.Event.Infraestructure.Repository;
using AttendanceEpiisBk.Modules.Student.Application.Adapter;
using AttendanceEpiisBk.Modules.Student.Application.Port;
using AttendanceEpiisBk.Modules.Student.Domain.IRepository;
using AttendanceEpiisBk.Modules.Student.Infraestructure.Presenter;
using AttendanceEpiisBk.Modules.Student.Infraestructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MySqlContext>();
builder.Services.AddMapster();
MappingConfig.RegisterMappings();


builder.Services.AddScoped<ITeacherInputPort, TeacherAdapter>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<ITeacherOutPort, TeacherPresenter>();

builder.Services.AddScoped<IStudentInputPort, StudentAdapter>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentOutPort, StudentPresenter>();

builder.Services.AddScoped<IEventInputPort, EventAdapter>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventOutPort, EventPresenter>();






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