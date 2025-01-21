using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs;

public record DepartmentPutDTO
{
    public int Id { get; set; }

    public string Name { get; set; }
}

public class DepartmentPutDTOValidations : AbstractValidator<DepartmentPutDTO>

{
    public DepartmentPutDTOValidations()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Name can not be empty")
            .MaximumLength(50).WithMessage("Name is long").MinimumLength(4).WithMessage("Name is short");
    }
}
