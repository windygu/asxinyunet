using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoungRunLab
{
    public class LabHelper
    {
        #region 函数
        public static int CalcuteVI(double V40, double V100)
        {
            double L, H;
            int res = -1;
            if (V100 < 2)
                return res;
            if (V100 >= 2 && V100 < 4)
            {
                L = 1.1364 * Math.Pow(V100, 2) + 1.814 * V100 - 0.181;
                H = 0.827 * Math.Pow(V100, 2) + 1.632 * V100 - 0.181;
            }
            else if (V100 >= 4 && V100 < 6.1)
            {
                L = -9.8713 * Math.Pow(V100, 2) + 338.663 * V100 - 995.142 * Math.Pow(V100, 0.5) + 818.905;
                H = -2.6758 * Math.Pow(V100, 2) + 96.671 * V100 - 269.664 * Math.Pow(V100, 0.5) + 215.025;
            }
            else if (V100 >= 6.1 && V100 < 7.2)
            {
                L = 2.838 * Math.Pow(V100, 2) + 2.32 * Math.Pow(V100, 1.5626) - 27.35 * V100 + 81.83;
                H = 2.32 * Math.Pow(V100, 1.5626);
            }
            else if (V100 >= 7.2 && V100 < 12.4)
            {
                L = 0.7385 * Math.Pow(V100, 2) + 10.692 * V100 - 32.888;
                H = 0.1922 * Math.Pow(V100, 2) + 8.25 * V100 - 18.728;
            }
            else if (V100 >= 12.4 && V100 < 70)
            {
                L = 1795.2 * Math.Pow(V100, -2) + 0.8813 * Math.Pow(V100, 2) + 9.167 * V100 - 46.947;
                H = 1795.2 * Math.Pow(V100, -2) + 0.1818 * Math.Pow(V100, 2) + 10.357 * V100 - 54.547;
            }
            else
            {
                L = 0.8353 * Math.Pow(V100, 2) + 14.67 * V100 - 216;
                H = 0.1684 * Math.Pow(V100, 2) + 11.85 * V100 - 97;
            }
            res = (int)Math.Round(((L - V40) * 100 / (L - H)), 0);
            if (res >= 100)
            {
                if (V100 > 70)
                {
                    H = 0.1684 * Math.Pow(V100, 2) + 11.85 * V100 - 97;
                }
                double N = (Math.Log10(H) - Math.Log10(V40)) / Math.Log10(V100);
                double t = ((Math.Pow(10, N) - 1) / 0.00715 + 100);
                res = (int)(Math.Round(t, 0));
            }
            return res;
        }
        public static double CalcuateMixV(double KV1, double KV2, double percent, int i)
        {
            int[] Kvalue = new int[] { 4, 2 };   //40度和100度的k值
            int K = Kvalue[i];
            double x1 = percent / 100;
            return Math.Round(100 * (Math.Exp(Math.Log(KV2 + K) * Math.Exp(x1 * Math.Log(Math.Log(KV1 + K) / Math.Log(KV2 + K)))) - K)) / 100;
        }

        public static double CalcuateMixVs(double KV1, double KV2, double KV, int i)
        {
            int[] Kvalue = new int[] { 4, 2 };   //40度和100度的k值
            int K = Kvalue[i];
            double a = Math.Log(KV + K);
            double b = Math.Log(KV1 + K);
            double c = Math.Log(KV2 + K);
            return Math.Round(10000 * (Math.Log(a / c) / Math.Log(b / c))) / 100;
        }
        #endregion
    }
}
