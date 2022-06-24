using FluentValidation;
using IKBasvuru.DATA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKBasvuru.CORE.Validations
{
    public class JobPositionValidator : AbstractValidator<JobPosition>
    {
        public JobPositionValidator()
        {
            RuleFor(e => e.Name).NotNull().WithMessage("Adı alanı boş bırakılamaz.");
            RuleFor(e => e.Name).MinimumLength(2).WithMessage("2 karakterden az olamaz.");

            RuleFor(e => e.Description).NotNull().WithMessage("Açıklama alanı boş bırakılamaz.");
            RuleFor(e => e.Description).MinimumLength(2).WithMessage("2 karakterden az olamaz.");
        }
    }
}
