using CampShoping.Domiain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace CampShoping.Domiain.Entities.Account
{
    public class User : BaseEntity
    {
        #region Properties

        [MaxLength(150, ErrorMessage = "نام وارد شده نمیتواند بیشتر از 150 کاراکتر باشد")]
        public string Name { get; set; }
        [MaxLength(150, ErrorMessage = "نام خانوادگی وارد شده نمیتواند بیشتر از 150 کاراکتر باشد")]
        public string Family { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "ایمیل اجباری میباشد")]
        [MaxLength(150, ErrorMessage = "نام وارد شده نمیتواند بیشتر از 150 کاراکتر باشد")]
        [EmailAddress(ErrorMessage = "ایمیل مورد نظر معتبر نمیباشد")]
        public string Email { get; set; }
        [Display(Name = "کلمه عبور ")]
        [Required(ErrorMessage = "لطفا {0}را وارد نمایید ")]
        [MaxLength(150, ErrorMessage = "  بیشتر از {1} کاراکتر داشته باشد {0}نمیتواند ")]
        public string Password { get; set; }
        [MaxLength(200)]
        public string Avatar { get; set; }
        [MaxLength(150, ErrorMessage = "  بیشتر از {1} کاراکتر داشته باشد {0}نمیتواند ")]
        public string ActiveCode { get; set; }

        public bool IsActive { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsSuperUser  { get; set; }

        #endregion

        #region Relations



        #endregion
    }
}
