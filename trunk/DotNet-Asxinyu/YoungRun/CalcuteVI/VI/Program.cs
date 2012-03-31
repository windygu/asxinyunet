/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2010-4-29
 * Time: 9:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace VI
{
	class Program
	{
		public static void Main(string[] args)
		{	
			while(true)
			{
				Console.Write("V40 = ") ;
				double v40 =Convert.ToDouble (Console.ReadLine ());
                Console.Write("V100 = ");
                double v100 = Convert.ToDouble(Console.ReadLine());
				Console.Write("T = ") ;
                double T = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("V = " + GetTempVtByV400V100 (v40 ,v100,T ).ToString());
			}	
		}
        public static double GetTempVtByV400V100(double V40, double V100, double T)
        {
            double a =Math.Log(Math.Log(V40 + 0.6,Math.E ),Math.E );            
            double b =Math.Log(Math.Log(V100 + 0.6,Math.E ),Math.E );            
            b = (a - b) / (Math.Log10(100 + 273) - Math.Log10(40 + 273));
            a = a + b * Math.Log10(40 + 273);
            double v3 = a - b * Math.Log10(T + 273);
            v3 = Math.Exp(v3);
            v3 = Math.Exp(v3) - 0.6;
            return v3;
        }
        public static double CalcuteV100ByVIAndV40(double V40, int VI)
        {
            //�ȼ����ʼ������,Ȼ����С�ķ�Χ������ȷ��Ŀ��
            double V100 = Math.Round(100 * (0.989 * Math.Log10(V40) + VI * (-49.04 + 7.16 * V40) / 10000 + 0.135)) / 100;
            int V2 = CalcuteVIFromGB(V40, V100);//�����ʼ��
            while (V2 != VI)
            {
                V100 += ((double)(VI - V2)) / 100;
                V2 = CalcuteVIFromGB(V40, V100);
            }
            return V100;
        }
		public static double CalcuateMixV(double KV1,double KV2,double percent,int i)
		{
			int[] Kvalue = new int[]{4,2} ;   //40�Ⱥ�100�ȵ�kֵ
			int K = Kvalue[i ] ;
			double x1 = percent /100 ;
			return Math.Round(100*(Math.Exp(Math.Log(KV2+K)*Math.Exp(x1*Math.Log (Math.Log (KV1+K)/Math.Log (KV2+K))))-K))/100;
		}
		
		public static double CalcuateMixVs(double KV1,double KV2,double KV,int i)
		{
			int[] Kvalue = new int[]{4,2} ;   //40�Ⱥ�100�ȵ�kֵ
			int K = Kvalue[i ] ;
			double a=Math.Log (KV+K);
			double b=Math.Log (KV1+K);
			double c=Math.Log (KV2+K);
			return Math.Round(10000*(Math.Log(a/c)/Math.Log(b/c)))/100;
		}
		public static int CalcuteVI(double V40,double V100)
		{
			double L,H ;
			int res = -1 ;
			if(V100<2)
				return res ;
			if(V100>=2&&V100<4)
			{
				L=1.1364*Math.Pow (V100,2)+1.814*V100-0.181 ;
				H=0.827*Math.Pow (V100,2)+1.632*V100-0.181 ;
			}
			else if(V100>=4&&V100<6.1)
			{
				L=-9.8713*Math.Pow (V100,2)+338.663*V100-995.142*Math.Pow (V100,0.5)+818.905 ;
				H=-2.6758*Math.Pow (V100,2)+96.671*V100-269.664*Math.Pow (V100,0.5)+215.025 ;
			}
			else if(V100>=6.1&&V100<7.2)
			{
				L=2.838*Math.Pow (V100,2)+2.32*Math.Pow (V100,1.5626)-27.35*V100+81.83 ;
				H=2.32*Math.Pow (V100,1.5626) ;
			}
			else if(V100>=7.2&&V100<12.4)
			{
				L=0.7385*Math.Pow (V100,2)+10.692*V100-32.888 ;
				H=0.1922*Math.Pow (V100,2)+8.25*V100-18.728 ;
			}
			else if(V100>=12.4&&V100<70)
			{
				L=1795.2*Math.Pow (V100,-2)+0.8813*Math.Pow (V100,2)+9.167*V100-46.947 ;
				H=1795.2*Math.Pow (V100,-2)+0.1818*Math.Pow (V100,2)+10.357*V100-54.547;
			}
			else
			{
				L=0.8353*Math.Pow (V100,2)+14.67*V100-216 ;
				H=0.1684*Math.Pow (V100,2)+11.85*V100-97 ;
			}
			res = (int)Math.Round (((L-V40)*100/(L-H)),0) ;
			if(res >=100)
			{
				if(V100>70)
				{
					H=0.1684*Math.Pow (V100,2)+11.85*V100-97 ;
				}
				double N = (Math.Log10 (H)-Math.Log10 (V40))/Math.Log10 (V100) ;
				double t =((Math.Pow (10,N)-1)/0.00715+100) ;
				res = (int)(Math.Round (t,0)) ;
			}
			return res ;
		}

		
		public static int CalcuteVIFromGB(double V40,double V100)
		{
			double L,H ;
            try
            {
                double[] p = GetParams(V100);
                L = p[0] * V100 * V100 +p [1] * V100 + p[2] ;
                H = p[3] * V100 * V100 + p[4] * V100 + p[5] ;
                if (V40 >= H )                
                    return (int )Math.Round ((L - V40) * 100 / (L - H),0);
                else
                {
                    double N = (Math.Log10 (H )-Math.Log10 (V40 ))/Math.Log10 (V100 );
                    return (int)Math.Round(((Math.Pow (10,N )-1)/0.00715+100),0);
                }                   
            }
            catch (Exception err)
            {
                throw err;
            }			
		}
        public static double[] GetParams(double Y)
        {
            if (Y < 2.0)
                throw new Exception("100���϶�ճ��С��2�޷����㣡");
            else if (Y >= 2.0 && Y <= 3.8)
                return new double[] { 1.14673, 1.7576, -0.109, 0.84155, 1.5521, -0.077 };
            else if (Y > 3.8 && Y <= 4.4)
                return new double[] { 3.38095, -15.4952, 33.196, 0.78571, 1.7929, -0.183 };
            else if (Y > 4.4 && Y <= 5.0)
                return new double[] { 2.5, -7.2143, 13.812, 0.82143, 1.5679, 0.119 };
            else if (Y > 5.0 && Y <= 6.4)
                return new double[] { 0.101, 16.6350, -45.469, 0.04985, 9.1613, -18.557 };
            else if (Y > 6.4 && Y <= 7.0)
                return new double[] { 3.35714, -23.5643, 78.466, 0.22619, 7.7369, -16.626 };
            else if (Y > 7.0 && Y <= 7.7)
                return new double[] { 0.01191, 21.4750, -72.870, 0.79762, -0.7321, 14.610 };
            else if (Y > 7.7 && Y <= 9.0)
                return new double[] { 0.41858, 16.1558, -56.040, 0.05794, 10.5156, -28.24 };
            else if (Y > 9.0 && Y <= 12)
                return new double[] { 0.88779, 7.5527, -16.6, 0.26665, 6.7015, -10.81 };
            else if (Y > 12 && Y <= 15)
                return new double[] { 0.7672, 10.7972, -38.18, 0.20073, 8.4658, -22.49 };
            else if (Y > 15 && Y <= 18)
                return new double[] { 0.97305, 5.3135, -2.2, 0.28889, 5.9741, -4.93 };
            else if (Y > 18 && Y <= 22)
                return new double[] { 0.97256, 5.25, -0.98, 0.24504, 7.416, -16.73 };
            else if (Y > 22 && Y <= 28)
                return new double[] { 0.91413, 7.4759, -21.82, 0.20323, 9.1267, -34.23 };
            else if (Y > 28 && Y <= 40)
                return new double[] { 0.87031, 9.7157, -50.77, 0.18411, 10.1015, -46.75 };
            else if (Y > 40 && Y <= 55)
                return new double[] { 0.84703, 12.6752, -133.31, 0.17029, 11.4866, -80.62 };
            else if (Y > 55 && Y <= 70)
                return new double[] { 0.85921, 11.1009, -83.19, 0.1713, 11.368, -76.94 };
            else
                return new double[] { 0.83531, 14.6731, -216.246, 0.16841, 11.8493, -96.947 };
        }
	}
}
