using IKBasvuru.COMMON.Enums;
using IKBasvuru.DATA.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKBasvuru.DATA.ViewModels
{
    public class ApplicationDetailsVM
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public Gender? Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public MaritalStatus? MaritalStatus { get; set; }

        public bool MilitaryStatus { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }

        public string? JobPosition { get; set; }

        public string? FilePath { get; set; }

        public string? FileName { get; set; }

        public string? Note { get; set; }

        public ApplicationStatus? ApplicationStatus { get; set; }

    }
}
