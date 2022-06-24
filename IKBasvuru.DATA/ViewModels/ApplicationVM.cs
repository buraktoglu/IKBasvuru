using IKBasvuru.COMMON.Enums;
using IKBasvuru.DATA.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKBasvuru.DATA.ViewModels
{
    public class ApplicationVM
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public bool KVKKCheck { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public int? JobPositionId { get; set; }
        public string? FilePath { get; set; }
        public IFormFile? FormFile { get; set; }

        public List<JobPosition>? JobPositions { get; set; }
        public List<Gender>? Genders { get; set; }
        public List<MaritalStatus>? MaritalStatuses { get; set; }
    }
}
