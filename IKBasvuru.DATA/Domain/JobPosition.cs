using IKBasvuru.COMMON.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKBasvuru.DATA.Domain
{
    public class JobPosition : BaseEntity , IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<JobApplication>? JobApplication { get; set; }
    }
}
