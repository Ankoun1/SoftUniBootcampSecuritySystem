namespace SoftUniBootcampSecuritySystem.BL.Users
{
    public interface IPasswordHandler
    {
        (string password, string salt) GeneratorPassword(string salt,string password);

        string PasswordChecker(string hashedPassword, string salt);
    }
}