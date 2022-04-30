using System.ComponentModel.DataAnnotations;

namespace CampShoping.Domiain.ViewModel.Account
{
    public class ForgotPasswordViewModel
    {
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "ایمیل اجباری میباشد")]
        [MaxLength(150, ErrorMessage = "نام وارد شده نمیتواند بیشتر از 150 کاراکتر باشد")]
        [EmailAddress(ErrorMessage = "ایمیل مورد نظر معتبر نمیباشد")]
        public string Email { get; set; }
       
    }

    public enum ForgotPasswordResult
    {
        Success,
         NotFoundUser,


    }




}