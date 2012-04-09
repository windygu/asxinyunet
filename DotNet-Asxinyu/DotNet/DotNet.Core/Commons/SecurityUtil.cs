namespace DotNet.Core.Commons
{
    using System;

    /// <summary>
    /// 安全工具类：随机密码生成，加解密等
    /// </summary>
    public class SecurityUtil
    {
        #region 生成随机密码
        //字符元素集合
        private const string CHARACTERS = "A0BCD1EF3GHI2JKL4M5NOP6QR7ST8UV9XZWYa-bcd=efgh@ijklm#nopqrs&tuvx*zwy";
        /// <summary>
        /// 得到制定长度的随机密码
        /// </summary>
        /// <param name="length">密码长度</param>
        /// <returns>随机密码</returns>
        public static string GeneratePassword(int length)
        {
            return GeneratePassword(length, length, CHARACTERS );
        }
        /// <summary>
        /// 根据给定的字符串序列来生成指定长度的密码
        /// </summary>
        /// <param name="minLength">最小长度</param>
        /// <param name="maxLength">最大长度</param>
        /// <param name="validCharacters">字符元素</param>
        /// <returns>随机密码</returns>
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
        #endregion
    }
}
