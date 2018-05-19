using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FashionShop.Areas.Admin.Models
{
    public class UserInfoModel
    {
        [Key]
        public long ID { get; set; }


        public string UserName { set; get; }

    
        public string Password { set; get; }

   
        public string ConfirmPassword { set; get; }
        
        public string Name { set; get; }

   
        public string Address { set; get; }

        public string Email { set; get; }

 
        public string Phone { set; get; }

    }
}