using System.ComponentModel.DataAnnotations;

namespace lapshop.Models
{
    public class TbSetting
    {
        [Key]
      
        public int SettingId { get; set; }
        [Required(ErrorMessage = ("this field is required"))]

        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = ("this field is required"))]

        public string Description { get; set; } = string.Empty ;
        [Required(ErrorMessage = ("this field is required"))]

        public string PhoneNumber { get; set; } = string.Empty;
        [Required(ErrorMessage = ("this field is required"))]
        [EmailAddress(ErrorMessage =("please Enter a Valid Email"))]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = ("this field is required"))]
        public string Adress { get; set; } = string.Empty;
        [Required(ErrorMessage = ("this field is required"))]
        public string FaceBook { get; set; } = string.Empty;
    }
}
