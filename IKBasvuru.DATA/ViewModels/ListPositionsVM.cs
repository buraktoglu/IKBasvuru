using IKBasvuru.COMMON.Enums;
using IKBasvuru.DATA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKBasvuru.DATA.ViewModels
{
    public class ListPositionsVM
    {
        public List<JobPosition>? JobPositions { get; set; }
        public OutputMessages OutputMessage { get; set; }
    }
}
