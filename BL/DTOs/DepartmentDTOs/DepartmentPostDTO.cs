using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs;

public record DepartmentPostDTO
{
    public string Name { get; set; }
}

public class DepartmentPostDTOValidations : AbstractValidator<DepartmentPostDTO>

{
    public DepartmentPostDTOValidations()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Name can not be empty")
            .MaximumLength(50).WithMessage("Name is long").MinimumLength(4).WithMessage("Name is short");
    }
}
