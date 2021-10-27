using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities.Dto
{
    public class RecoveryMailDto
    {

        public RecoveryMailDto()
        {
            UserEmail = string.Empty;
        }

        [Required(ErrorMessage = "Elektron-Poct Bolmesi Bos Buraxila Bilmez")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email duzgun deyil! zehmet olmasa duzgen email daxil edin.")]
        public string UserEmail { get; set; }
    }
}
