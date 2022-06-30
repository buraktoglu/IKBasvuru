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

        public string? Name { get; set; }

        public string? Surname { get; set; }
        
        public Gender? Gender { get; set; }

        public DateTime BirthDate { get; set; } = DateTime.Now;

        public MaritalStatus? MaritalStatus { get; set; }

        public bool KVKKCheck { get; set; }

        public bool MilitaryService { get; set; } = false;

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }

        public ApplicationStatus? ApplicationStatus { get; set; } = COMMON.Enums.ApplicationStatus.Accepted;

        public string? Note { get; set; } = "Henüz yorum eklenmemiştir.";

        public int JobPositionId { get; set; }

        public string? FileName { get; set; }

        public string? FilePath { get; set; }

        public virtual JobPosition? JobPosition { get; set; }
    }
}
