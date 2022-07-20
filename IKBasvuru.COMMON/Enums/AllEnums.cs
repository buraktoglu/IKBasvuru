using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKBasvuru.COMMON.Enums
{
    public enum Gender
    {
        [Display(Name = "Kadın")]
        Female = 0,
        [Display(Name = "Erkek")]
        Male = 1,
        [Display(Name = "Belirtmek istemiyorum")]
        Unknown = 2,
    }

    public enum MaritalStatus
    {
        [Display(Name = "Bekar")]
        Single = 0,
        [Display(Name = "Evli")]
        Married = 1,
        [Display(Name = "Dul")]
        Widow = 2,
        [Display(Name = "Boşanmış")]
        Divorced = 3,
    }

    public enum ApplicationStatus
    {
        [Display(Name = "Reddedildi")]
        Declined = 0,
        [Display(Name = "Onaylandı")]
        Approved = 1,
        [Display(Name = "Başvuru Alındı")]
        Accepted = 2,
        [Display(Name = "Değerlendirildi")]
        Evaluated = 3,
        [Display(Name = "Değerlendirme Sürecinde")]
        OnEvaluation = 4,
    }
}
