using System.ComponentModel.DataAnnotations;

namespace CampShoping.Domiain.ViewModel.Account
{
    public class LoginUserViewModel
    {
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "ایمیل اجباری میباشد")]
        [MaxLength(150, ErrorMessage = "نام وارد شده نمیتواند بیشتر از 150 کاراکتر باشد")]
        [EmailAddress(ErrorMessage = "ایمیل مورد نظر معتبر نمیباشد")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "کلمه عبور ")]
        [Required(ErrorMessage = "لطفا {0}را وارد نمایید ")]
        [MaxLength(150, ErrorMessage = "  بیشتر از {1} کاراکتر داشته باشد {0}نمیتواند ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememmbMe { get; set; } //مرا بخاطر بسپار 
    }

    public enum LoginUserResult
    {
        Success,
        NotActive,  // کاربر اکتیو نیست 
        WrongData, // اعطلاعات یافت نشد 
        IsBan  // یوزر اگر قفل باشد 
    }

}