using IKBasvuru.COMMON.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKBasvuru.DATA.ViewModels
{
    public class ListApplicationsVM
    {
        public List<ApplicationListVM>? Applications { get; set; }
        public OutputMessages OutputMessage { get; set; }
    }
}
