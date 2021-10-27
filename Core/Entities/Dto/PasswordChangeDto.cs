using Core.Entities.Dto.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities.Dto
{
    public class PasswordChangeDto : BaseDto
    {
        public PasswordChangeDto()
        {
            Password = string.Empty;
            PasswordRepeat = string.Empty;
        }

        public int Id { get; set; }

        [Required(ErrorMessage ="Sifre Bolmesi Bos Buraxila Bilmez")]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Sifre Tekrar Bolmesi Bos Buraxila Bilmez")]
        [Compare("Password", ErrorMessage ="Sifre ve Sifre Tekrar Bolmesi Bir-Biri Ile Eyni Olmalidir!")]
        public string PasswordRepeat { get; set; }
    }
}
