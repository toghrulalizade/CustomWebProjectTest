using Core.Entities.Dto.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities.Dto
{
    public class LoginUserDto : BaseDto
    {
        public LoginUserDto()
        {
            Username = string.Empty;
            Password = string.Empty;
        }

        [Required(ErrorMessage ="Istifadeci Adi Bolmesi Bos Ola Bilmez")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Sifre Bolmesi Bos Ola Bilmez")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
