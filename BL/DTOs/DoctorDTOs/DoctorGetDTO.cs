using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs;

public record DoctorGetDTO
{
    public int Id { get; set; }
    public string ImagePath { get; set; }

    public required string Name { get; set; }

    public int DepartmentId { get; set; }
}


public class DoctorGetDTOValidations : AbstractValidator<DoctorGetDTO>
{
    public DoctorGetDTOValidations()
    {
        RuleFor(x => x.Id).NotEmpty().GreaterThan(0).WithMessage("");
        RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Name can not be empty")
            .MaximumLength(50).WithMessage("Name is long").MinimumLength(4).WithMessage("Name is short");
        RuleFor(x => x.ImagePath)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Image cannot be null!");
        RuleFor(e => e.DepartmentId)
            .NotEmpty().WithMessage("Department title cannot be empty!");
            
    }
}
