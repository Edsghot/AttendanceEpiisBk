using System.ComponentModel.DataAnnotations;
using AttendanceEpiisBk.Model.Dtos.Event;
using AttendanceEpiisBk.Model.Dtos.Guest;
using AttendanceEpiisBk.Model.Dtos.Participant;
using Mapster;
using Microsoft.EntityFrameworkCore;
using AttendanceEpiisBk.Model.Dtos.Teacher;
using AttendanceEpiisBk.Modules.Event.Domain.Entity;
using AttendanceEpiisBk.Modules.Student.Domain.Entity;
using AttendanceEpiisBk.Modules.Teacher.Application.Port;
using AttendanceEpiisBk.Modules.Teacher.Domain.Entity;
using AttendanceEpiisBk.Modules.Teacher.Domain.IRepository;
using FluentValidation;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace AttendanceEpiisBk.Modules.Teacher.Application.Adapter;

public class TeacherAdapter : ITeacherInputPort
{
    private readonly ITeacherOutPort _teacherOutPort;
    private readonly ITeacherRepository _teacherRepository;
    private readonly IValidator<TeacherDto> _validator;

    public TeacherAdapter(ITeacherRepository repository, ITeacherOutPort teacherOutPort,IValidator<TeacherDto> validator)
    {
        _teacherRepository = repository;
        _teacherOutPort = teacherOutPort;
        _validator = validator;
    }

    public async Task GetById(int id)
    {
        var teachers = await _teacherRepository.GetAsync<TeacherEntity>(
            x => x.IdTeacher == id);
        if (teachers == null)
        {
            _teacherOutPort.NotFound("No teacher found.");
            return;
        }

        var teacherDtos = teachers.Adapt<TeacherDto>();
        _teacherOutPort.GetById(teacherDtos);
    }

    public async Task GetAllAsync()
    {
        var teachers = await _teacherRepository.GetAllAsync<TeacherEntity>( );

        var teacherEntities = teachers.ToList();
        if (!teacherEntities.Any())
        {
            _teacherOutPort.NotFound("No teacher found.");
            return;
        }

        var teacherDtos = teachers.Adapt<List<TeacherDto>>();

        _teacherOutPort.GetAllAsync(teacherDtos);
    }

  public async Task ParticipantGetByDni(string dni)
{
    var teachers = await _teacherRepository.GetAsync<TeacherEntity>(x => x.Dni.Equals(dni));
    
    if (teachers == null)
    {
        var students = await _teacherRepository.GetAsync<StudentEntity>(e => e.Dni.Equals(dni));
        
        if (students == null)
        {
            var guests = await _teacherRepository.GetAsync<GuestEntity>(g => g.Dni.Equals(dni));
            
            if (guests == null)
            {
                _teacherOutPort.NotFound("No participant found.");
                return;
            }
            
            var guestResponse = guests.Adapt<ParticipantDataDto>();
            guestResponse.Role = 2;
            _teacherOutPort.ParticipantGetByDni(guestResponse);
            return;
        }
        
        var studentResponse = students.Adapt<ParticipantDataDto>();
        studentResponse.Role = 1;
        _teacherOutPort.ParticipantGetByDni(studentResponse);
        return;
    }
    
    var teacherResponse = teachers.Adapt<ParticipantDataDto>();
    teacherResponse.Role = 0;
    _teacherOutPort.ParticipantGetByDni(teacherResponse);
}
    
    public async Task CreateTeacher(TeacherDto teacherDto)
    {
        var existingTeacher = await _teacherRepository.GetAsync<TeacherEntity>(x => x.Dni == teacherDto.Dni);
        if (existingTeacher != null)
        {
            _teacherOutPort.Error("El docente ya fue registrado!");
            return;
        }

        var result = await _validator.ValidateAsync(teacherDto);
        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
            var serializedErrors = System.Text.Json.JsonSerializer.Serialize(errorMessages);
            _teacherOutPort.Error(serializedErrors);
            return;
        }

        var teacherEntity = teacherDto.Adapt<TeacherEntity>();
        await _teacherRepository.AddAsync(teacherEntity);
        await _teacherRepository.SaveChangesAsync();
        _teacherOutPort.Success(teacherEntity, "Teacher created successfully.");
    }
    
    public async Task UpdateTeacher(TeacherDto teacherDto)
    {
        var existingTeacher = await _teacherRepository.GetAsync<TeacherEntity>(x => x.IdTeacher == teacherDto.IdTeacher);
        if (existingTeacher == null)
        {
            _teacherOutPort.Error("No se encontró el profesor que quieres actualizar.");
            return;
        }

        existingTeacher.FirstName = teacherDto.FirstName;
        existingTeacher.LastName = teacherDto.LastName;
        existingTeacher.Mail = teacherDto.Mail;
        existingTeacher.Phone = teacherDto.Phone;
        existingTeacher.Gender = teacherDto.Gender;
        existingTeacher.Dni = teacherDto.Dni;
        existingTeacher.BirthDate = teacherDto.BirthDate;

        await _teacherRepository.UpdateAsync(existingTeacher);
        await _teacherRepository.SaveChangesAsync();
        _teacherOutPort.Success(existingTeacher, "Profesor actualizado satisfactoriamente.");
    }

    public async Task DeleteTeacher(int id)
    {
        var existingTeacher = await _teacherRepository.GetAsync<TeacherEntity>(x => x.IdTeacher == id);
        if (existingTeacher == null)
        {
            _teacherOutPort.Error("No se encontró el docente que quieres eliminar.");
            return;
        }

        await _teacherRepository.DeleteAsync(existingTeacher);
        await _teacherRepository.SaveChangesAsync();
        _teacherOutPort.SuccessMessage("Docente eliminado exitosamente.");
    }
  
    
}
        
