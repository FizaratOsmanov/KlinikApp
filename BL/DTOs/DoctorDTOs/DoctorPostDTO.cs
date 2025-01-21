using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BL.DTOs;

public record DoctorPostDTO
{
    public IFormFile Image { get; set; }

    public string Name { get; set; }

    public int DepartmentId {  get; set; }
}

public class DoctorPostDTOValidations : AbstractValidator<DoctorPostDTO>

{
    public DoctorPostDTOValidations()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Name can not be empty")
            .MaximumLength(50).WithMessage("Name is long").MinimumLength(4).WithMessage("Name is short");
        RuleFor(x => x.Image)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Image cannot be null!")
            .Must(x => x.Length <= 2 * 1024 * 1024).WithMessage("File size must be less than 2 MB!");            
        RuleFor(e => e.DepartmentId)
            .NotEmpty().WithMessage("Department id cannot be empty!")
            .GreaterThan(0).WithMessage("Department id must be a natural number!");
    }
}
