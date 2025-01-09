using Mapster;
using Microsoft.EntityFrameworkCore;
using AttendanceEpiisBk.Model.Dtos.Research;
using AttendanceEpiisBk.Model.Dtos.Teacher;
using AttendanceEpiisBk.Modules.Research.Application.Port;
using AttendanceEpiisBk.Modules.Research.Domain.Entity;
using AttendanceEpiisBk.Modules.Research.Domain.IRepository;
using AttendanceEpiisBk.Modules.Teacher.Application.Port;
using AttendanceEpiisBk.Modules.Teacher.Domain.Entity;
using AttendanceEpiisBk.Modules.Teacher.Domain.IRepository;

namespace AttendanceEpiisBk.Modules.Research.Application.Adapter;

public class ResearchAdapter : IResearchInputPort
{
    private readonly IResearchOutPort _researchOutPort;
    private readonly IResearchRepository _researchRepository;

    public ResearchAdapter(IResearchRepository repository, IResearchOutPort outPort)
    {
        _researchRepository = repository;
        _researchOutPort = outPort;
    }

    public async Task GetAllResearchProject()
    {
        var research = await _researchRepository.GetAllAsync<ResearchProjectEntity>();

        var researchEntities = research.ToList();
        if (!researchEntities.Any())
        {
            _researchOutPort.NotFound("No se encontraron proyectos de investigacion");
            return;
        }

        var researchDtos = researchEntities.Adapt<List<ResearchProjectDto>>();

        _researchOutPort.GetAllResearchProject(researchDtos);
    }

    public async Task GetAllScientificArticle()
    {
        var research = await _researchRepository.GetAllAsync<ScientificArticleEntity>();

        var researchEntities = research.ToList();
        if (!researchEntities.Any())
        {
            _researchOutPort.NotFound("No se encontro articulos");
            return;
        }

        var researchDtos = researchEntities.Adapt<List<ScientificArticleDto>>();

        _researchOutPort.GetAllScientificArticle(researchDtos);
    }
}