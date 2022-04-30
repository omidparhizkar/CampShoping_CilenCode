using System.ComponentModel.DataAnnotations;

namespace CampShoping.Domiain.ViewModel.Account
{
    public class RegisterUserViewModel
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
        [Display(Name = "کلمه عبور ")]
        [Required(ErrorMessage = "لطفا {0}را وارد نمایید ")]
        [MaxLength(150, ErrorMessage = "  بیشتر از {1} کاراکتر داشته باشد {0}نمیتواند ")]
        [Compare("Password", ErrorMessage= " کلمه های عبور مغایرت دارند ")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }

    public enum RegisterUserResult
    {
        Success,
        NotSendEmail,
        DuplicateEmail 
    }

}