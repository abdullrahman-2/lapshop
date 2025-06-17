using System.ComponentModel.DataAnnotations;

namespace lapshop.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "الاسم الأول مطلوب ولا يمكن أن يكون فارغاً.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "يجب أن يتراوح طول الاسم الأول بين حرفين و 50 حرفاً.")]
        [Display(Name = "الاسم الأول")] 
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "الاسم الأخير مطلوب ولا يمكن أن يكون فارغاً.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "يجب أن يتراوح طول الاسم الأخير بين حرفين و 50 حرفاً.")]
        [Display(Name = "الاسم الأخير")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "البريد الإلكتروني مطلوب ولا يمكن أن يكون فارغاً.")]
        [EmailAddress(ErrorMessage = "الرجاء إدخال بريد إلكتروني بصيغة صحيحة (مثال: user@example.com).")]
        [Display(Name = "البريد الإلكتروني")]
        public string EmailAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "كلمة المرور مطلوبة ولا يمكن أن تكون فارغة.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "يجب أن تكون كلمة المرور 6 أحرف على الأقل.")]
        [Display(Name = "كلمة المرور")]
        public string Password { get; set; } = string.Empty;

        public string ReturnUrl { get; set; } = string.Empty;
    }
}
