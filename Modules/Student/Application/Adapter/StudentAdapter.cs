using AttendanceEpiisBk.Model.Dtos.Student;
using Mapster;
using Microsoft.EntityFrameworkCore;
using AttendanceEpiisBk.Model.Dtos.Teacher;
using AttendanceEpiisBk.Modules.Event.Application.Port;
using AttendanceEpiisBk.Modules.Event.Domain.Entity;
using AttendanceEpiisBk.Modules.Event.Domain.IRepository;
using AttendanceEpiisBk.Modules.Student.Application.Port;
using AttendanceEpiisBk.Modules.Student.Domain.Entity;
using AttendanceEpiisBk.Modules.Student.Domain.IRepository;
using AttendanceEpiisBk.Modules.Teacher.Domain.Entity;

namespace AttendanceEpiisBk.Modules.Student.Application.Adapter;

public class StudentAdapter : IStudentInputPort
{
    private readonly IStudentOutPort _studentOutPort;
    private readonly IStudentRepository _studentRepository;

    public StudentAdapter(IStudentRepository repository, IStudentOutPort studentOutPort)
    {
        _studentRepository = repository;
        _studentOutPort = studentOutPort;
    }

    public async Task GetById(int id)
    {
        var students = await _studentRepository.GetAsync<StudentEntity>(
            x => x.IdStudent == id);
        if (students == null)
        {
            _studentOutPort.NotFound("No student found.");
            return;
        }

        var studentDtos = students.Adapt<StudentDto>();
        _studentOutPort.GetById(studentDtos);
    }

    public async Task GetAllAsync()
    {
        var students = await _studentRepository.GetAllAsync<StudentEntity>( );

        var studentEntities = students.ToList();
        if (!studentEntities.Any())
        {
            _studentOutPort.NotFound("No student found.");
            return;
        }

        var studentDtos = students.Adapt<List<StudentDto>>();

        _studentOutPort.GetAllAsync(studentDtos);
    }

  public async Task CreateStudent(StudentDto data)
{
    var existingStudent = await _studentRepository.GetAsync<StudentEntity>(x => x.Dni == data.Dni);
    if (existingStudent != null)
    {
        _studentOutPort.Error("El estudiante ya esta registrado");
        return;
    }

    var studentEntity = data.Adapt<StudentEntity>();
    await _studentRepository.AddAsync(studentEntity);
    await _studentRepository.SaveChangesAsync();
    _studentOutPort.Success(studentEntity, "Estudiante creado correctamente");
}
}