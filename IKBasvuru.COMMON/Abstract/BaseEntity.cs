using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKBasvuru.COMMON.Abstract
{
    public class BaseEntity
    {
        public bool IsActive { get; set; } = true;

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string ModifiedBy { get; set; } = "Kullanici Ilk Giris";

        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}
