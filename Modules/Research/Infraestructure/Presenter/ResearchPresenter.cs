using AttendanceEpiisBk.Configuration.Shared;
using AttendanceEpiisBk.Model.Dtos.Research;
using AttendanceEpiisBk.Model.Dtos.Teacher;
using AttendanceEpiisBk.Modules.Research.Application.Port;
using AttendanceEpiisBk.Modules.Teacher.Application.Port;

namespace AttendanceEpiisBk.Modules.Research.Infraestructure.Presenter;

public class ResearchPresenter : BasePresenter<object>, IResearchOutPort
{
    public void GetAllResearchProject(IEnumerable<ResearchProjectDto> data)
    {
        Success(data, "Data encontrada");
    }

    public void GetAllScientificArticle(IEnumerable<ScientificArticleDto> data)
    {
        Success(data, "data encontrada");
    }
}