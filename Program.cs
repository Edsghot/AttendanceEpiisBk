using AttendanceEpiisBk.Configuration.Context;
using AttendanceEpiisBk.Modules.Teacher.Application.Adapter;
using AttendanceEpiisBk.Modules.Teacher.Application.Port;
using AttendanceEpiisBk.Modules.Teacher.Domain.IRepository;
using AttendanceEpiisBk.Modules.Teacher.Infraestructure.Presenter;
using AttendanceEpiisBk.Modules.Teacher.Infraestructure.Repository;
using Mapster;
using AttendanceEpiisBk.Mapping;
using AttendanceEpiisBk.Model.Dtos.Teacher;
using AttendanceEpiisBk.Modules.Attendance.Application.Adapter;
using AttendanceEpiisBk.Modules.Attendance.Application.Port;
using AttendanceEpiisBk.Modules.Attendance.Infraestructure.Presenter;
using AttendanceEpiisBk.Modules.Attendance.Infraestructure.Repository;
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
using AttendanceEpiisBk.Modules.User.Application.Adapter;
using AttendanceEpiisBk.Modules.user.Application.Port;
using AttendanceEpiisBk.Modules.User.Application.Port;
using AttendanceEpiisBk.Modules.User.Domain.IRepository;
using AttendanceEpiisBk.Modules.User.Infraestructure.Presenter;
using AttendanceEpiisBk.Modules.User.Infraestructure.Repository;
using FluentValidation;

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

builder.Services.AddScoped<IAttendanceInputPort, AttendanceAdapter>();
builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
builder.Services.AddScoped<IAttendanceOutPort, AttendancePresenter>();


builder.Services.AddScoped<IUserInputPort, UserAdapter>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserOutPort, UserPresenter>();


builder.Services.AddScoped<IValidator<TeacherDto>, TeacherDtoValidator>();



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