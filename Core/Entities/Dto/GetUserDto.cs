using Core.Entities.Dto.Base;

namespace Core.Entities.Dto
{
    public class GetUserDto : BaseDto
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
