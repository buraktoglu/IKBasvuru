using IKBasvuru.COMMON.Enums;
using IKBasvuru.DATA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKBasvuru.DATA.ViewModels
{
    public class ApplicationListVM
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Note { get; set; }
        public string? JobPosition { get; set; }
        public ApplicationStatus? ApplicationStatus { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }

        public OutputMessages OutputMessage { get; set; }

    }
}
