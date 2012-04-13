namespace WHC.Pager.WinControl
{
    using System;

    public class LicenseTool
    {
        public static LicenseCheckResult CheckLicense()
        {
            LicenseCheckResult result = new LicenseCheckResult();
            string license = MyConstants.License;
            if (!string.IsNullOrEmpty(license))
            {
                LicenseCheckResult result2;
                try
                {
                    string[] strArray = Base64Util.Decrypt(MD5Util.RemoveMD5Profix(license)).Split(new char[] { '|' });
                    if (strArray.Length < 4)
                    {
                        return result;
                    }
                    string str3 = strArray[0];
                    if (str3.ToLower() == "whc.pager")
                    {
                        result.IsValided = true;
                    }
                    result.Username = strArray[1];
                    result.CompanyName = strArray[2];
                    try
                    {
                        result.DisplayCopyright = Convert.ToBoolean(strArray[3]);
                    }
                    catch
                    {
                        result.DisplayCopyright = true;
                    }
                    result2 = result;
                }
                catch
                {
                }
                return result2;
            }
            return result;
        }
    }
}

