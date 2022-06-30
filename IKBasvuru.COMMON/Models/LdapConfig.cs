using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKBasvuru.COMMON.Models
{
    public class LdapConfig
    {
        public string Url { get; set; }
        public string Domain { get; set; }
        public int Port { get; set; }
        public string BindDn { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string SearchBase { get; set; }
        public string SearchFilter { get; set; }
        public string AuthorizationRole { get; set; }

    }
}
