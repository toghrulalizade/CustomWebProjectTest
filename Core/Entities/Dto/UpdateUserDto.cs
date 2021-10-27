using Core.Entities.Dto.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dto
{
    public class UpdateUserDto : BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string AuthenticationToken { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
