using IKBasvuru.COMMON.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKBasvuru.DATA.Domain
{
    public class JobPosition : BaseEntity, IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]
        [MinLength(2, ErrorMessage = "En az 2 karakter girilmesi zorunludur.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur.")]
        [MinLength(2, ErrorMessage = "En az 2 karakter girilmesi zorunludur.")]
        public string? Description { get; set; }

        public virtual ICollection<JobApplication>? JobApplication { get; set; }
    }
}
