namespace AttendanceEpiisBk.Model.Dtos.Teacher;

using FluentValidation;

public class TeacherDtoValidator : AbstractValidator<TeacherDto>
{
    public TeacherDtoValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.");
        RuleFor(x => x.Mail).NotEmpty().EmailAddress().WithMessage("Valid email is required.");
        RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone number is required.");
        RuleFor(x => x.Dni).NotEmpty().WithMessage("DNI is required.");
    }
}