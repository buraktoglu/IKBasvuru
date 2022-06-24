using IKBasvuru.COMMON.Abstract;
using IKBasvuru.COMMON.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKBasvuru.DATA.Domain
{
    public class JobApplication : BaseEntity, IEntity 
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

        public DateTime BirthDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Bu alanın seçilmesi zorunludur.")]
        public MaritalStatus? MaritalStatus { get; set; }
        public bool KVKKCheck { get; set; }

        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]
        [MinLength(2, ErrorMessage = "En az 2 karakter girilmesi zorunludur.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]
        [MinLength(2, ErrorMessage = "En az 2 karakter girilmesi zorunludur.")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]
        [MinLength(2, ErrorMessage = "En az 2 karakter girilmesi zorunludur.")]
        public string? Address { get; set; }

        public int? JobPositionId { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }

        public virtual JobPosition? JobPosition { get; set; }
    }
}
