namespace DotNet.Core.Commons
{
    using System;

    /// <summary>
    /// ��ȫ�����ࣺ����������ɣ��ӽ��ܵ�
    /// </summary>
    public class SecurityUtil
    {
        #region �����������
        //�ַ�Ԫ�ؼ���
        private const string CHARACTERS = "A0BCD1EF3GHI2JKL4M5NOP6QR7ST8UV9XZWYa-bcd=efgh@ijklm#nopqrs&tuvx*zwy";
        /// <summary>
        /// �õ��ƶ����ȵ��������
        /// </summary>
        /// <param name="length">���볤��</param>
        /// <returns>�������</returns>
        public static string GeneratePassword(int length)
        {
            return GeneratePassword(length, length, CHARACTERS );
        }
        /// <summary>
        /// ���ݸ������ַ�������������ָ�����ȵ�����
        /// </summary>
        /// <param name="minLength">��С����</param>
        /// <param name="maxLength">��󳤶�</param>
        /// <param name="validCharacters">�ַ�Ԫ��</param>
        /// <returns>�������</returns>
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
