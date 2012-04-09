namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Runtime.CompilerServices;
    using System.Security.Cryptography;
    using System.Text;

    public class RSASecurityHelper
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Validate(string originalString, string encrytedString)
        {
            bool flag = false;
            RSACryptoServiceProvider key = new RSACryptoServiceProvider();
            try
            {
                key.FromXmlString(UIConstants.PublicKey);
                RSAPKCS1SignatureDeformatter deformatter = new RSAPKCS1SignatureDeformatter(key);
                deformatter.SetHashAlgorithm(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x58ee));
                byte[] rgbSignature = Convert.FromBase64String(encrytedString);
                byte[] rgbHash = new SHA1Managed().ComputeHash(Encoding.ASCII.GetBytes(originalString));
                if (deformatter.VerifySignature(rgbHash, rgbSignature))
                {
                    flag = true;
                }
            }
            catch
            {
            }
            finally
            {
                if (key != null)
                {
                    key.Dispose();
                }
            }
            return flag;
        }
    }
}

