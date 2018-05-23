using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FashionShop.Models
{
    public class RegisterModel
    {
        [Key]
        public long ID { get; set; }

        [Display(Name = "Tên Tài Khoản")]
        [Required(ErrorMessage = "Yêu Cầu Nhập Tài Khoản")]
        public string UserName { set; get; }

        [Display(Name = "Mật Khẩu")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ Dài Password Phải Trên 6 Kí Tự.")]
        [Required(ErrorMessage = "Yêu Cầu Nhập Mật Khẩu")]
        public string Password { set; get; }

        [Display(Name = "Xác Nhận Mật Khẩu")]
        [Compare("Password", ErrorMessage = "Xác Nhận Mật Khẩu Không Đúng.")]
        [Required(ErrorMessage = "Yêu Cầu Xác Nhận Mật Khẩu")]
        public string ConfirmPassword { set; get; }

        [Display(Name = "Họ Tên")]
        [Required(ErrorMessage = "Yêu Cầu Nhập Họ Tên")]
        public string Name { set; get; }

        [Display(Name = "Địa Chỉ")]
        [Required(ErrorMessage = "Yêu Cầu Nhập Địa Chỉ")]
        public string Address { set; get; }

        [Display(Name = "Địa Chỉ Email")]
        [Required(ErrorMessage = "Yêu Cầu Nhập Email")]
        public string Email { set; get; }

        [Display(Name = "Số Điện Thoại")]
        [Required(ErrorMessage = "Yêu Cầu Nhập Số Điện Thoại")]
        public string Phone { set; get; }
    }
}