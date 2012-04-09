namespace WHC.OrderWater.Commons
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using WCbbmZBBn9vfvwmNV9;

    public class Camera
    {
        private IntPtr 3RGFtDsi0;
        private int iPnC2QyUu;
        private eRTMAk2M3FdSf44ROG.XuEGGndIpJbRWWv3Ot J33Gvmr8S;
        private IntPtr qqOZd2BSd;
        private int S4k2CWq1J;

        public event RecievedFrameEventHandler RecievedFrame;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public Camera(IntPtr handle, int width, int height)
        {
            this.3RGFtDsi0 = handle;
            this.iPnC2QyUu = width;
            this.S4k2CWq1J = height;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private bool 37jAJ3Bnt(IntPtr ptr1, ref eRTMAk2M3FdSf44ROG.Fw8hcgSSYOqKZH1j06 qkzhjRef1, int num1)
        {
            return eRTMAk2M3FdSf44ROG.37jAJ3Bnt(ptr1, 0x42d, num1, ref qkzhjRef1);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private bool 408MSTia8(IntPtr ptr1, bool flag1)
        {
            return eRTMAk2M3FdSf44ROG.408MSTia8(ptr1, 0x432, flag1, 0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private bool A3kPEVyyt(IntPtr ptr1, bool flag1)
        {
            return eRTMAk2M3FdSf44ROG.408MSTia8(ptr1, 0x433, flag1, 0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void CloseWebcam()
        {
            this.XPOfx7u7N(this.qqOZd2BSd);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private bool GPY6Re0PF(IntPtr ptr1, short num1)
        {
            return eRTMAk2M3FdSf44ROG.GPY6Re0PF(ptr1, 0x434, num1, 0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void GrabImage(string path)
        {
            eRTMAk2M3FdSf44ROG.GPY6Re0PF(this.qqOZd2BSd, 0x419, 0, Marshal.StringToHGlobalAnsi(path).ToInt32());
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool GrabImageToClipBoard()
        {
            return eRTMAk2M3FdSf44ROG.GPY6Re0PF(this.qqOZd2BSd, 0x41e, 0, 0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private bool JiYUNJcCW(IntPtr ptr1, eRTMAk2M3FdSf44ROG.XuEGGndIpJbRWWv3Ot ot1)
        {
            return eRTMAk2M3FdSf44ROG.JiYUNJcCW(ptr1, 0x405, 0, ot1);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private bool mUvqAX6rk(IntPtr ptr1, short num1)
        {
            return eRTMAk2M3FdSf44ROG.GPY6Re0PF(ptr1, 0x40a, num1, 0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void PQMwwy6pB(IntPtr, IntPtr ptr1)
        {
            eRTMAk2M3FdSf44ROG.v5xBALCYlwJdpwwDkG kg = new eRTMAk2M3FdSf44ROG.v5xBALCYlwJdpwwDkG();
            kg = (eRTMAk2M3FdSf44ROG.v5xBALCYlwJdpwwDkG) eRTMAk2M3FdSf44ROG.3RGFtDsi0(ptr1, kg);
            byte[] data = new byte[kg.408MSTia8];
            eRTMAk2M3FdSf44ROG.5gYn6JLpM(kg.mUvqAX6rk, data);
            if (this.5gYn6JLpM != null)
            {
                this.5gYn6JLpM(data);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void SetCaptureFormat()
        {
            eRTMAk2M3FdSf44ROG.BIxYw46OSbLW5E66eU eu = new eRTMAk2M3FdSf44ROG.BIxYw46OSbLW5E66eU();
            eRTMAk2M3FdSf44ROG.PQMwwy6pB(this.qqOZd2BSd, 0x40e, eRTMAk2M3FdSf44ROG.J33Gvmr8S(eu), ref eu);
            if (eu.408MSTia8)
            {
                eRTMAk2M3FdSf44ROG.GPY6Re0PF(this.qqOZd2BSd, 0x429, 0, 0);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void SetCaptureSource()
        {
            eRTMAk2M3FdSf44ROG.BIxYw46OSbLW5E66eU eu = new eRTMAk2M3FdSf44ROG.BIxYw46OSbLW5E66eU();
            eRTMAk2M3FdSf44ROG.PQMwwy6pB(this.qqOZd2BSd, 0x40e, eRTMAk2M3FdSf44ROG.J33Gvmr8S(eu), ref eu);
            if (eu.408MSTia8)
            {
                eRTMAk2M3FdSf44ROG.GPY6Re0PF(this.qqOZd2BSd, 0x42a, 0, 0);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void StartWebCam()
        {
            byte[] buffer = new byte[100];
            byte[] buffer2 = new byte[100];
            eRTMAk2M3FdSf44ROG.XPOfx7u7N(1, buffer, 100, buffer2, 100);
            this.qqOZd2BSd = eRTMAk2M3FdSf44ROG.mUvqAX6rk(buffer, 0x50000000, 0, 0, this.iPnC2QyUu, this.S4k2CWq1J, this.3RGFtDsi0, 0);
            if (this.mUvqAX6rk(this.qqOZd2BSd, 0))
            {
                this.GPY6Re0PF(this.qqOZd2BSd, 0x42);
                this.408MSTia8(this.qqOZd2BSd, true);
                this.A3kPEVyyt(this.qqOZd2BSd, true);
                eRTMAk2M3FdSf44ROG.Fw8hcgSSYOqKZH1j06 qkzhj = new eRTMAk2M3FdSf44ROG.Fw8hcgSSYOqKZH1j06();
                qkzhj.mUvqAX6rk.mUvqAX6rk = eRTMAk2M3FdSf44ROG.J33Gvmr8S(qkzhj.mUvqAX6rk);
                qkzhj.mUvqAX6rk.XPOfx7u7N = this.iPnC2QyUu;
                qkzhj.mUvqAX6rk.408MSTia8 = this.S4k2CWq1J;
                qkzhj.mUvqAX6rk.GPY6Re0PF = 1;
                qkzhj.mUvqAX6rk.JiYUNJcCW = 0x18;
                this.37jAJ3Bnt(this.qqOZd2BSd, ref qkzhj, eRTMAk2M3FdSf44ROG.J33Gvmr8S(qkzhj));
                this.J33Gvmr8S = new eRTMAk2M3FdSf44ROG.XuEGGndIpJbRWWv3Ot(this.PQMwwy6pB);
                this.JiYUNJcCW(this.qqOZd2BSd, this.J33Gvmr8S);
                eRTMAk2M3FdSf44ROG.A3kPEVyyt(this.qqOZd2BSd, 0, 0, 0, this.iPnC2QyUu, this.S4k2CWq1J, 6);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private bool XPOfx7u7N(IntPtr ptr1)
        {
            return eRTMAk2M3FdSf44ROG.GPY6Re0PF(ptr1, 0x40b, 0, 0);
        }

        public delegate void RecievedFrameEventHandler(byte[] data);
    }
}

