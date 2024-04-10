namespace APIAirsalon.Models
{
    public class AuthDto
    {


        public string FirstName { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Salt { get; set; } = null!;
        public bool IsDelete { get; set; }
        public int? RoleId { get; set; }

    }
}
