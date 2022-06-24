using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKBasvuru.COMMON.Models
{
    public class CookiesConfig
    {

        public string CookieName { get; set; }

        public string LoginPath { get; set; }

        public string LogoutPath { get; set; }

        public string AccessDeniedPath { get; set; }

        public string ReturnUrlParameter { get; set; }
    }
}
