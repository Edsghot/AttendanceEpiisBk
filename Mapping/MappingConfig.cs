using Mapster;
using AttendanceEpiisBk.Model.Dtos.Teacher;
using AttendanceEpiisBk.Modules.Teacher.Domain.Entity;

namespace AttendanceEpiisBk.Mapping;

public class MappingConfig
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<TeacherEntity, TeacherDto>.NewConfig();
        TypeAdapterConfig<WorkExperienceEntity, WorkExperienceDto>.NewConfig();
        TypeAdapterConfig<TeachingExperienceEntity, TeachingExperienceDto>.NewConfig();
        TypeAdapterConfig<ThesisAdvisingExperienceEntity, ThesisAdvisingExperienceDto>.NewConfig();
    }
}