﻿
using AttendanceEpiisBk.Model.Dtos.Guest;
using AttendanceEpiisBk.Model.Dtos.Teacher;

namespace AttendanceEpiisBk.Modules.Teacher.Application.Port;

public interface ITeacherInputPort
{
    Task GetAllAsync();
    Task GetById(int id);
    Task ParticipantGetByDni(string dni);
    Task CreateTeacher(TeacherDto teacherDto);
    Task UpdateTeacher(TeacherDto teacherDto);
    Task DeleteTeacher(int id);

}