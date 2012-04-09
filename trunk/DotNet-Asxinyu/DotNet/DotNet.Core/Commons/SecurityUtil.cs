namespace DotNet.Core
{
    using System;

    public class SecurityUtil
    {
        private const string CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVXZWYabcdefghijklmnopqrstuvxzwy0123456789";

        private SecurityUtil()
        {
        }

        public static string GeneratePassword(int length)
        {
            return GeneratePassword(length, length, "ABCDEFGHIJKLMNOPQRSTUVXZWYabcdefghijklmnopqrstuvxzwy0123456789");
        }

        public static string GeneratePassword(int minLength, int maxLength, string validCharacters)
        {
            Random random = new Random();
            string str2 = string.Empty;
            int length = validCharacters.Length;
            int num2 = random.Next(minLength, maxLength + 1);
            int num4 = num2;
            for (int i = 1; i <= num4; i++)
            {
                str2 = str2 + validCharacters.Substring(random.Next(0, length), 1);
            }
            return str2;
        }
    }
}
