using Core.Entities.Dto.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities.Dto
{
    public class InsertUserDto : BaseDto
    {
        public InsertUserDto()
        {
            Name = string.Empty;
            Surname = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
            PasswordRepeat = string.Empty;
            Email = string.Empty;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Ad Bolmesi Bos Buraxila Bilmez")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad Bolmesi Bos Buraxila Bilmez")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Soyad Bolmesi Bos Buraxila Bilmez")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Sifre Bolmesi Bos Buraxila Bilmez")]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Sifre Tekrar Bolmesi Bos Buraxila Bilmez")]
        [Compare("Password", ErrorMessage = "Sifre ve Sifre Tekrar Bolmesi Bir-Biri Ile Eyni Olmalidir!")]
        public string PasswordRepeat { get; set; }
        public string AuthenticationToken { get; set; }

        [Required(ErrorMessage = "Elektron-Poct Bolmesi Bos Buraxila Bilmez")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email duzgun deyil! zehmet olmasa duzgen email daxil edin.")]
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
