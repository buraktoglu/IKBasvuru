using IKBasvuru.COMMON.Enums;
using IKBasvuru.DATA.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKBasvuru.DATA.ViewModels
{
    public class ApplicationVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]
        [MinLength(2, ErrorMessage = "En az 2 karakter girilmesi zorunludur.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]
        [MinLength(2, ErrorMessage = "En az 2 karakter girilmesi zorunludur.")]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Bu alanın seçilmesi zorunludur.")]
        public Gender? Gender { get; set; }

        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Bu alanın seçilmesi zorunludur.")]
        public MaritalStatus? MaritalStatus { get; set; }

        public bool MilitaryStatus { get; set; }

        [Required]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Devam edebilmek için Kişisel veri aydınlatma metnini onaylamalısınız.")]
        public bool KVKKCheck { get; set; }

        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]
        [RegularExpression(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}", ErrorMessage = "10 haneli telefon numaranızı giriniz.")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]
        [MinLength(2, ErrorMessage = "En az 2 karakter girilmesi zorunludur.")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Bu alanın seçilmesi zorunludur.")]
        public int JobPositionId { get; set; }
        public string? FilePath { get; set; }
        public IFormFile? FormFile { get; set; }

        public OutputMessages OutputMessage { get; set; }

        public string? Text { get; set; }

        public List<JobPosition>? JobPositions { get; set; }
    }
}
