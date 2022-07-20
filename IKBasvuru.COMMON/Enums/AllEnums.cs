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

    public enum OutputMessages
    {
        [Display(Name = "Hoşgeldiniz.")] 
        Welcome = 0, 
        [Display(Name = "İşleminiz Başarılı.")] 
        Success = 1, 
        [Display(Name = "İşleminiz Başarısız.")] 
        Failure = 2,
        [Display(Name = "Dosya Hatası. Yüklenilen dosya bulunamadı. Lütfen dosyanın yüklendiğinden emin olarak tekrar deneyiniz.")]
        FileError = 3,
        [Display(Name = "Dosya Uzantısı Hatası. Yüklediğiniz dosya uzantısı sistem tarafından kabul edilmemektedir. " +
            "Lütfen dosya uzantınızı '.doc - .docx - .pdf - .xls - .xlsx - .rtf - .odt' olduğundan emin olarak tekrar deneyiniz. ")]
        ExtensionError = 4,
        [Display( Name = "Format Hatası. Girdiğiniz bilgilerin formatını kontrol ederek tekrar deneyiniz")]
        FormatError = 5,
    }
}
