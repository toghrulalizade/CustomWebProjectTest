namespace Core.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string AuthenticationToken { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
