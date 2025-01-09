using AttendanceEpiisBk.Configuration.Shared;
using AttendanceEpiisBk.Model.Dtos.Research;
using AttendanceEpiisBk.Model.Dtos.Teacher;

namespace AttendanceEpiisBk.Modules.Research.Application.Port;

public interface IResearchOutPort : IBasePresenter<object>
{
    void GetAllResearchProject(IEnumerable<ResearchProjectDto> data);
    void GetAllScientificArticle(IEnumerable<ScientificArticleDto> data);
}