using System;

namespace SoftUniBootcampSecuritySystem.BL.Users
{
    public class PasswordHandler : IPasswordHandler
    {
        public (string password, string salt) GeneratorPassword(string salt,string password)
        {
            int saltSubstringLength = (int)Math.Ceiling(1.0 * salt.Length / 2);
            int passwordSubstringLength = (int)Math.Ceiling(1.0 * password.Length / 2);
            
            string passwordHashed = salt.Substring(0, saltSubstringLength)
                                   + password.Substring(0, passwordSubstringLength)
                                   + salt.Substring(saltSubstringLength)
                                   + password.Substring(passwordSubstringLength);
            return (passwordHashed, salt);
        }

        public string PasswordChecker(string hashedPassword, string salt)
        {
            int saltSubstringLengthLeft = (int)Math.Ceiling(1.0 * salt.Length / 2);
            int saltSubstringLengthRight = salt.Length - saltSubstringLengthLeft;
            int passwordLength = hashedPassword.Length - saltSubstringLengthRight - saltSubstringLengthLeft;
            int passwordSubstringLengthLeft = (int)Math.Ceiling(1.0 * passwordLength / 2);
            int passwordSubstringLengthRight = passwordLength - passwordSubstringLengthLeft;

            string password = hashedPassword.Substring(saltSubstringLengthLeft, passwordSubstringLengthLeft)
                            + hashedPassword.Substring(hashedPassword.Length - passwordSubstringLengthRight);
            return password;
        }
    }
}