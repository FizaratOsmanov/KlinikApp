using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs;

public  record DoctorPutDTO
{
    public int Id { get; set; }
    public IFormFile Image { get; set; }

    public string Name { get; set; }

    public int DepartmentId { get; set; }
}

public class DoctorPutDTOValidations : AbstractValidator<DoctorPutDTO>
{
    public DoctorPutDTOValidations()
    {
        RuleFor(x => x.Id).NotEmpty().GreaterThan(0).WithMessage("Id can not be 0");
        RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Name can not be empty")
            .MaximumLength(50).WithMessage("Name is long").MinimumLength(4).WithMessage("Name is short");
        RuleFor(x => x.Image)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Image cannot be null!");

        RuleFor(e => e.DepartmentId)
            .NotEmpty().WithMessage("Department id cannot be empty!")
            .GreaterThan(0).WithMessage("Department id must be a natural number!");

    }
}
