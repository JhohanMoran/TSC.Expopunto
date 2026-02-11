namespace TSC.Expopunto.Application.Security
{
    public class PasswordService : IPasswordService
    {
        public string HashPassword(string password)
          => BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);

        public bool VerifyPassword(string password, string hashedPassword)
            => BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
