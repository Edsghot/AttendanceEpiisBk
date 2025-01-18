
using AttendanceEpiisBk.Model.Dtos.Student;

namespace AttendanceEpiisBk.Modules.Student.Application.Port;

public interface IStudentInputPort
{
    Task GetAllAsync();
    Task GetById(int id);
    Task CreateStudent(StudentDto data);
    Task UpdateStudent(StudentDto studentDto);
    Task DeleteStudent(int id);
}