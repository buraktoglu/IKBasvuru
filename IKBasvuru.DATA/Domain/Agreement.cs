using IKBasvuru.COMMON.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKBasvuru.DATA.Domain
{
    public class Agreement : BaseEntity, IEntity
    {
        public int Id { get; set; }

        public string? Text { get; set; }

    }
}
