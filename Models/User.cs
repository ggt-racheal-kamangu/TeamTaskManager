namespace TeamTaskManager.API.Models
{
    public enum UserRole
    {
        Admin,
        Manager,
        Employee
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public UserRole Role { get; set; }
    }
}
