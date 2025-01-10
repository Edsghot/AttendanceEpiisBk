using AttendanceEpiisBk.Configuration.Shared;
using AttendanceEpiisBk.Model.Dtos.Event;
using AttendanceEpiisBk.Model.Dtos.Participant;
using AttendanceEpiisBk.Model.Dtos.Teacher;
using AttendanceEpiisBk.Modules.Teacher.Application.Port;

namespace AttendanceEpiisBk.Modules.Teacher.Infraestructure.Presenter;

public class TeacherPresenter : BasePresenter<object>, ITeacherOutPort
{
    public void GetAllAsync(IEnumerable<TeacherDto> data)
    {
        Success(data, "Teacher successfully retrieved.");
    }

    public void GetById(TeacherDto data)
    {
        Success(data, "Teacher data");
    }
    public void ParticipantGetByDni(ParticipantDataDto data){
        Success(data);
    }
}