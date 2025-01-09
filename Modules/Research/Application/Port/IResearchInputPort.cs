using AttendanceEpiisBk.Model.Dtos.User;
using AttendanceEpiisBk.Modules.User.Domain.Entity;

namespace AttendanceEpiisBk.Modules.Research.Application.Port;

public interface IResearchInputPort
{
    Task GetAllResearchProject();
    Task GetAllScientificArticle();
}