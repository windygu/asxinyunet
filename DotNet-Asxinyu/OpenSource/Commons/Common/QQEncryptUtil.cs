namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Runtime.CompilerServices;
    using System.Security.Cryptography;
    using System.Text;

    public class QQEncryptUtil
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string EncodePasswordWithVerifyCode(string password, string verifyCode)
        {
            return QM3fY09LE(t00qRSolC(password) + verifyCode.ToUpper());
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string QM3fY09LE(string text1)
        {
            MD5 md = MD5.Create();
            byte[] bytes = Encoding.ASCII.GetBytes(text1);
            return BitConverter.ToString(md.ComputeHash(bytes)).Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x578e), "").ToUpper();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string t00qRSolC(string text1)
        {
            MD5 md = MD5.Create();
            byte[] bytes = Encoding.ASCII.GetBytes(text1);
            bytes = md.ComputeHash(bytes);
            bytes = md.ComputeHash(bytes);
            return BitConverter.ToString(md.ComputeHash(bytes)).Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5788), "").ToUpper();
        }
    }
}

