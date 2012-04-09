namespace Devv.Core.Utils
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.IO;
    using System.Net;

    public class GeoIPUtil
    {
        private static long CountryBegin = 0xffff00L;
        private static string[] CountryCode = new string[] { 
            "", "AP", "EU", "AD", "AE", "AF", "AG", "AI", "AL", "AM", "AN", "AO", "AQ", "AR", "AS", "AT", 
            "AU", "AW", "AZ", "BA", "BB", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BM", "BN", "BO", "BR", 
            "BS", "BT", "BV", "BW", "BY", "BZ", "CA", "CC", "CD", "CF", "CG", "CH", "CI", "CK", "CL", "CM", 
            "CN", "CO", "CR", "CU", "CV", "CX", "CY", "CZ", "DE", "DJ", "DK", "DM", "DO", "DZ", "EC", "EE", 
            "EG", "EH", "ER", "ES", "ET", "FI", "FJ", "FK", "FM", "FO", "FR", "FX", "GA", "GB", "GD", "GE", 
            "GF", "GH", "GI", "GL", "GM", "GN", "GP", "GQ", "GR", "GS", "GT", "GU", "GW", "GY", "HK", "HM", 
            "HN", "HR", "HT", "HU", "ID", "IE", "IL", "IN", "IO", "IQ", "IR", "IS", "IT", "JM", "JO", "JP", 
            "KE", "KG", "KH", "KI", "KM", "KN", "KP", "KR", "KW", "KY", "KZ", "LA", "LB", "LC", "LI", "LK", 
            "LR", "LS", "LT", "LU", "LV", "LY", "MA", "MC", "MD", "MG", "MH", "MK", "ML", "MM", "MN", "MO", 
            "MP", "MQ", "MR", "MS", "MT", "MU", "MV", "MW", "MX", "MY", "MZ", "NA", "NC", "NE", "NF", "NG", 
            "NI", "NL", "NO", "NP", "NR", "NU", "NZ", "OM", "PA", "PE", "PF", "PG", "PH", "PK", "PL", "PM", 
            "PN", "PR", "PS", "PT", "PW", "PY", "QA", "RE", "RO", "RU", "RW", "SA", "SB", "SC", "SD", "SE", 
            "SG", "SH", "SI", "SJ", "SK", "SL", "SM", "SN", "SO", "SR", "ST", "SV", "SY", "SZ", "TC", "TD", 
            "TF", "TG", "TH", "TJ", "TK", "TM", "TN", "TO", "TL", "TR", "TT", "TV", "TW", "TZ", "UA", "UG", 
            "UM", "US", "UY", "UZ", "VA", "VC", "VE", "VG", "VI", "VN", "VU", "WF", "WS", "YE", "YT", "RS", 
            "ZA", "ZM", "ME", "ZW", "A1", "A2", "O1", "AX", "GG", "IM", "JE", "BL", "MF"
         };
        public static MemoryStream CountryDatabase;
        private static string[] CountryName = new string[] { 
            "", "Asia/Pacific Region", "Europe", "Andorra", "United Arab Emirates", "Afghanistan", "Antigua and Barbuda", "Anguilla", "Albania", "Armenia", "Netherlands Antilles", "Angola", "Antarctica", "Argentina", "American Samoa", "Austria", 
            "Australia", "Aruba", "Azerbaijan", "Bosnia and Herzegovina", "Barbados", "Bangladesh", "Belgium", "Burkina Faso", "Bulgaria", "Bahrain", "Burundi", "Benin", "Bermuda", "Brunei Darussalam", "Bolivia", "Brazil", 
            "Bahamas", "Bhutan", "Bouvet Island", "Botswana", "Belarus", "Belize", "Canada", "Cocos (Keeling) Islands", "Congo, The Democratic Republic of the", "Central African Republic", "Congo", "Switzerland", "Cote D'Ivoire", "Cook Islands", "Chile", "Cameroon", 
            "China", "Colombia", "Costa Rica", "Cuba", "Cape Verde", "Christmas Island", "Cyprus", "Czech Republic", "Germany", "Djibouti", "Denmark", "Dominica", "Dominican Republic", "Algeria", "Ecuador", "Estonia", 
            "Egypt", "Western Sahara", "Eritrea", "Spain", "Ethiopia", "Finland", "Fiji", "Falkland Islands (Malvinas)", "Micronesia, Federated States of", "Faroe Islands", "France", "France, Metropolitan", "Gabon", "United Kingdom", "Grenada", "Georgia", 
            "French Guiana", "Ghana", "Gibraltar", "Greenland", "Gambia", "Guinea", "Guadeloupe", "Equatorial Guinea", "Greece", "South Georgia and the South Sandwich Islands", "Guatemala", "Guam", "Guinea-Bissau", "Guyana", "Hong Kong", "Heard Island and McDonald Islands", 
            "Honduras", "Croatia", "Haiti", "Hungary", "Indonesia", "Ireland", "Israel", "India", "British Indian Ocean Territory", "Iraq", "Iran, Islamic Republic of", "Iceland", "Italy", "Jamaica", "Jordan", "Japan", 
            "Kenya", "Kyrgyzstan", "Cambodia", "Kiribati", "Comoros", "Saint Kitts and Nevis", "Korea, Democratic People's Republic of", "Korea, Republic of", "Kuwait", "Cayman Islands", "Kazakstan", "Lao People's Democratic Republic", "Lebanon", "Saint Lucia", "Liechtenstein", "Sri Lanka", 
            "Liberia", "Lesotho", "Lithuania", "Luxembourg", "Latvia", "Libyan Arab Jamahiriya", "Morocco", "Monaco", "Moldova, Republic of", "Madagascar", "Marshall Islands", "Macedonia, the Former Yugoslav Republic of", "Mali", "Myanmar", "Mongolia", "Macao", 
            "Northern Mariana Islands", "Martinique", "Mauritania", "Montserrat", "Malta", "Mauritius", "Maldives", "Malawi", "Mexico", "Malaysia", "Mozambique", "Namibia", "New Caledonia", "Niger", "Norfolk Island", "Nigeria", 
            "Nicaragua", "Netherlands", "Norway", "Nepal", "Nauru", "Niue", "New Zealand", "Oman", "Panama", "Peru", "French Polynesia", "Papua New Guinea", "Philippines", "Pakistan", "Poland", "Saint Pierre and Miquelon", 
            "Pitcairn", "Puerto Rico", "Palestinian Territory, Occupied", "Portugal", "Palau", "Paraguay", "Qatar", "Reunion", "Romania", "Russian Federation", "Rwanda", "Saudi Arabia", "Solomon Islands", "Seychelles", "Sudan", "Sweden", 
            "Singapore", "Saint Helena", "Slovenia", "Svalbard and Jan Mayen", "Slovakia", "Sierra Leone", "San Marino", "Senegal", "Somalia", "Suriname", "Sao Tome and Principe", "El Salvador", "Syrian Arab Republic", "Swaziland", "Turks and Caicos Islands", "Chad", 
            "French Southern Territories", "Togo", "Thailand", "Tajikistan", "Tokelau", "Turkmenistan", "Tunisia", "Tonga", "Timor-Leste", "Turkey", "Trinidad and Tobago", "Tuvalu", "Taiwan, Province of China", "Tanzania, United Republic of", "Ukraine", "Uganda", 
            "United States Minor Outlying Islands", "United States", "Uruguay", "Uzbekistan", "Holy See (Vatican City State)", "Saint Vincent and the Grenadines", "Venezuela", "Virgin Islands, British", "Virgin Islands, U.S.", "Vietnam", "Vanuatu", "Wallis and Futuna", "Samoa", "Yemen", "Mayotte", "Yugoslavia", 
            "South Africa", "Zambia", "Montenegro", "Zimbabwe", "Anonymous Proxy", "Satellite Provider", "Other", "Aland Islands", "Guernsey", "Isle of Man", "Jersey", "Saint Barthelemy", "Saint Martin"
         };

        private GeoIPUtil()
        {
        }

        private static long ConvertIPAddressToNumber(IPAddress ip)
        {
            string[] strArray = ip.ToString().Split(".".ToCharArray());
            if (strArray.Length == 4)
            {
                return Convert.ToInt64((long) ((((0x1000000L * Convert.ToInt64(strArray[0])) + (0x10000L * Convert.ToInt64(strArray[1]))) + (0x100L * Convert.ToInt64(strArray[2]))) + Convert.ToInt64(strArray[3])));
            }
            return 0L;
        }

        private static string ConvertIPNumberToAddress(long ip)
        {
            string str2 = (Convert.ToInt32((double) (((double) ip) / 16777216.0)) % 0x100).ToString();
            string str3 = (Convert.ToInt32((double) (((double) ip) / 65536.0)) % 0x100).ToString();
            string str4 = (Convert.ToInt32((double) (((double) ip) / 256.0)) % 0x100).ToString();
            string str5 = (Convert.ToInt32(ip) % 0x100).ToString();
            return (str2 + "." + str3 + "." + str4 + "." + str5);
        }

        public static MemoryStream FileToMemory(string path)
        {
            FileStream stream2 = new FileStream(path, FileMode.Open, FileAccess.Read);
            MemoryStream stream3 = new MemoryStream();
            byte[] array = new byte[0x101];
            while (stream2.Read(array, 0, array.Length) != 0)
            {
                stream3.Write(array, 0, array.Length);
            }
            stream2.Dispose();
            return stream3;
        }

        public static void LoadCountryDatabase(string path)
        {
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] array = new byte[0x101];
            CountryDatabase = new MemoryStream();
            while (stream.Read(array, 0, array.Length) != 0)
            {
                CountryDatabase.Write(array, 0, array.Length);
            }
            stream.Dispose();
        }

        public static string LookupCountryCode(IPAddress ip)
        {
            return CountryCode[(int) SeekCountry(0L, ConvertIPAddressToNumber(ip), 0x1f)];
        }

        public static string LookupCountryCode(string ip)
        {
            IPAddress address;
            try
            {
                address = IPAddress.Parse(ip);
            }
            catch (FormatException exception1)
            {
                ProjectData.SetProjectError(exception1);
                FormatException exception = exception1;
                string str = string.Empty;
                ProjectData.ClearProjectError();
                return str;
            }
            return LookupCountryCode(address);
        }

        public static string LookupCountryName(IPAddress ip)
        {
            return CountryName[(int) SeekCountry(0L, ConvertIPAddressToNumber(ip), 0x1f)];
        }

        public static string LookupCountryName(string ip)
        {
            IPAddress address;
            try
            {
                address = IPAddress.Parse(ip);
            }
            catch (FormatException exception1)
            {
                ProjectData.SetProjectError(exception1);
                FormatException exception = exception1;
                string str = string.Empty;
                ProjectData.ClearProjectError();
                return str;
            }
            return LookupCountryName(address);
        }

        private static long SeekCountry(long StartOffset, long IPNumber, int SearchDepth)
        {
            byte[] buffer = new byte[7];
            long[] numArray = new long[3];
            if (SearchDepth == 0)
            {
                return 0L;
            }
            try
            {
                CountryDatabase.Seek(6L * StartOffset, SeekOrigin.Begin);
                CountryDatabase.Read(buffer, 0, 6);
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                ProjectData.ClearProjectError();
            }
            int index = 0;
            do
            {
                numArray[index] = 0L;
                int num3 = 0;
                do
                {
                    int num4 = buffer[(index * 3) + num3];
                    if (num4 < 0)
                    {
                        num4 += 0x100;
                    }
                    long[] numArray2 = numArray;
                    int num5 = index;
                    numArray2[num5] += vbShiftLeft((long) num4, num3 * 8);
                    num3++;
                }
                while (num3 <= 2);
                index++;
            }
            while (index <= 1);
            if ((IPNumber & vbShiftLeft(1L, SearchDepth)) > 0L)
            {
                if (numArray[1] >= CountryBegin)
                {
                    return (numArray[1] - CountryBegin);
                }
                return SeekCountry(numArray[1], IPNumber, SearchDepth - 1);
            }
            if (numArray[0] >= CountryBegin)
            {
                return (numArray[0] - CountryBegin);
            }
            return SeekCountry(numArray[0], IPNumber, SearchDepth - 1);
        }

        private static long vbShiftLeft(long Value, int Count)
        {
            long num2 = Value;
            int num4 = Count;
            for (int i = 1; i <= num4; i++)
            {
                num2 *= 2L;
            }
            return num2;
        }

        private static long vbShiftRight(long Value, int Count)
        {
            long num2 = Value;
            int num4 = Count;
            for (int i = 1; i <= num4; i++)
            {
                num2 /= 2L;
            }
            return num2;
        }
    }
}
