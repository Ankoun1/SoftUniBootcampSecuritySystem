namespace SoftUniBootcampSecuritySystem.Models
{
    public static class DataConstants
    {
        public static class DefaultConstants
        {
            public const byte IdMaxLength = 40;
            public const byte MinLengthPassword = 5;
            public const byte MaxLengthPassword = 50;
            public const byte MaxLengthHashedPassword = 255;
            public const byte MaxLengthSalt = 255;
            public const byte MinCount = 1;
        }

        public static class SkillConstants
        {
            public const byte MinLengthName = 5;
            public const byte MaxLengthName = 25;
        }
        
        public static class RecruiterConstants
        {
            public const byte MinLengthFullName = 6;
            public const byte MaxLengthFullName = 30;
            public const byte MinLengthCountryName = 4;
            public const byte MaxLengthCountryName = 30;
            public const byte RecruiterFreeSeats = 5;
        }

        public static class JobConstants
        {
            public const byte MinLengthDescription = 10;
            public const byte MaxLengthDescription = 140;
            public const byte MinLengthTitle = 5;
            public const byte MaxLengthTitle = 50;
            public const short MinSalary = 1500;
            public const short MaxSalary = 2000;
        }
        public static class UserConst
        {
            public const byte MinLengthFullName = 3;
            public const byte MaxLengthFullName = 30;                  
            public const byte BirthDateMinLength = 10;
            public const byte BirthDateMaxLength = 10;
            public const byte BiographyMinLength = 10;
            public const byte BiographynMaxLength = 140;
            public const string UserIdentificator = "User";
        } 
        public static class AdminRepository
        {
            //password bo123
            public const string AdminName = "bos";
            public const string AdminSalt = "3981e80c-40e0-49c4-a70e-e4c12eb8f0ad";
            public const string AdminPassword = "3981e80c-40e0-49c4bo1-a70e-e4c12eb8f0ad23";
            public const string AdminIdentificator = "Administrator";                            
        }
    }
}
