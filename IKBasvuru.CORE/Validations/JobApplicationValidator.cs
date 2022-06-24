using FluentValidation;
using IKBasvuru.DATA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKBasvuru.CORE.Validations
{
    public class JobApplicationValidator : AbstractValidator<JobApplication>
    {
        public JobApplicationValidator()
        {
            RuleFor(e => e.Name).NotNull().WithMessage("İsim alanı boş bırakılamaz.");
            RuleFor(e => e.Name).MinimumLength(2).WithMessage("2 karakterden az olamaz.");            
            
            RuleFor(e => e.Surname).NotNull().WithMessage("Soyisim alanı boş bırakılamaz.");
            RuleFor(e => e.Surname).MinimumLength(2).WithMessage("2 karakterden az olamaz.");

            RuleFor(e => e.Gender).NotNull().WithMessage("Cinsiyet alanı boş bırakılamaz.");
            RuleFor(e => e.MaritalStatus).NotNull().WithMessage("Medeni Hal alanı boş bırakılamaz.");

            RuleFor(e => e.BirthDate).NotNull().WithMessage("Doğum tarihi alanı boş bırakılamaz.");
            RuleFor(e => e.BirthDate).LessThanOrEqualTo(DateTime.Now).WithMessage("Doğum tarihi ileri bir tarih olarak girilemez.");

            RuleFor(e => e.Email).NotNull().WithMessage("Email alanı boş bırakılamaz");
            RuleFor(e => e.Email).EmailAddress().WithMessage("Email adresi doğru formatta girilmelidir.");

            RuleFor(e => e.PhoneNumber).NotNull().WithMessage("Telefon numarası alanı boş bırakılamaz.");

            RuleFor(e => e.Address).NotNull().WithMessage("Adres alanı boş bırakılamaz.");

            RuleFor(e => e.FileName).NotNull().WithMessage("Dosya adı alanı boş bırakılamaz.");

            RuleFor(e => e.FilePath).NotNull().WithMessage("Dosya dizini alanı boş bırakılamaz.");
        }
    }
}
