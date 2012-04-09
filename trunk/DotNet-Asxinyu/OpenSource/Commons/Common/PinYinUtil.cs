namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Collections;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading;

    public class PinYinUtil
    {
        private static string[] EPgfA8o8U = new string[] { 
            kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb96a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb970), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb978), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb980), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb98a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb992), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb99a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb9a4), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb9ae), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb9ba), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb9c4), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb9ce), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb9d8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb9e4), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb9ec), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb9f8), 
            kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xba04), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xba0e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xba18), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xba24), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xba2c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xba34), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xba3c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xba46), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xba50), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xba5c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xba66), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xba6e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xba7a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xba84), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xba90), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xba9c), 
            kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbaaa), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbab6), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbac0), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbacc), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbada), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbae4), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbaf2), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbafe), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbb08), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbb16), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbb24), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbb34), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbb40), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbb4c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbb58), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbb60), 
            kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbb6c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbb76), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbb7e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbb8a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbb94), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbb9e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbba8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbbb0), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbbba), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbbc4), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbbd0), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbbda), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbbe2), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbbee), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbbf6), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbc02), 
            kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbc0e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbc18), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbc24), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbc2e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbc3a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbc44), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbc4c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbc58), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbc62), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbc6c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbc76), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbc7c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbc84), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbc8c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbc94), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbc9e), 
            kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbcaa), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbcb4), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbcbe), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbcca), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbcd2), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbcdc), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbce4), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbcec), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbcf6), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbd00), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbd0c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbd16), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbd1e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbd28), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbd32), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbd3e), 
            kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbd4a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbd54), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbd5c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbd66), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbd72), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbd7e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbd8c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbd96), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbda0), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbdaa), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbdb2), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbdbc), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbdc6), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbdd2), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbddc), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbde4), 
            kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbdee), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbdf8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbe04), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbe10), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbe1a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbe22), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbe2c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbe38), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbe44), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbe52), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbe5c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbe66), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbe70), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbe78), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbe82), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbe8e), 
            kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbe9c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbea8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbeb2), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbebc), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbec8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbed6), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbee0), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbee8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbef4), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbefe), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbf08), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbf10), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbf1a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbf24), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbf30), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbf3a), 
            kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbf42), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbf4c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbf58), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbf64), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbf6e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbf76), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbf80), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbf8c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbf98), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbfa6), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbfb0), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbfba), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbfc4), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbfcc), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbfd6), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbfe0), 
            kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbfec), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbff6), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbffe), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc008), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc014), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc01c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc026), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc032), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc040), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc04c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc056), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc060), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc06c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc076), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc082), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc08c), 
            kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc094), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc09c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc0a8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc0b2), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc0bc), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc0c6), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc0ce), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc0d8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc0e2), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc0ee), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc0f8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc100), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc10a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc114), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc120), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc128), 
            kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc134), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc140), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc14a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc154), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc160), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc16a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc172), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc17c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc184), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc18c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc196), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc1a0), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc1ac), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc1b6), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc1be), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc1c8), 
            kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc1d2), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc1de), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc1e6), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc1f2), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc200), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc20c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc216), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc220), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc22c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc236), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc242), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc24a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc252), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc25e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc268), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc272), 
            kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc278), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc280), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc288), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc292), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc29c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc2a8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc2b2), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc2bc), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc2c6), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc2d2), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc2da), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc2e6), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc2f2), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc2fc), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc306), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc312), 
            kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc31a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc322), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc32a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc334), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc340), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc34e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc35a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc364), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc36e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc37a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc388), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc392), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc39a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc3a6), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc3b0), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc3ba), 
            kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc3c4), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc3d0), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc3da), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc3e2), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc3ec), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc3f8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc400), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc40c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc416), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc41e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc42a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc434), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc43e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc448), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc450), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc45a), 
            kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc464), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc470), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc47a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc482), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc48c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc498), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc4a2), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc4ae), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc4ba), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc4c8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc4d4), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc4de), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc4ea), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc4f8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc502), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc50e), 
            kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc518), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc524), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc532), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc540), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc550), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc55c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc568), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc574), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc57c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc588), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc592), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc59a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc5a6), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc5b0), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc5ba), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc5c4), 
            kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc5cc), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc5d6), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc5e0), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc5ec), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc5f6), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc5fe), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc60a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc612), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc61e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc62a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc634), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc640), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc64c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc656), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc65e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc66a), 
            kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc674), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc67e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc688), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc690), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc69a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc6a4), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc6b0), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc6ba), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc6c4), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc6d0), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc6d8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc6e0), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc6e8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc6f2), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc6fe), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc70c), 
            kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc718), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc722), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc72c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc738), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc746), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc750), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc758), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc764), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc76e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc778), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc780), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc78a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc796), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc7a0), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc7a8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc7b0), 
            kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc7ba), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc7c6), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc7ce), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc7da), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc7e4), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc7ec), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc7f8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc802), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc80c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc814), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc81e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc828), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc834), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc83e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc846), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc850), 
            kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc85a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc866), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc870), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc87c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc888), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc896), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc8a2), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc8ac), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc8b8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc8c6), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc8d0), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc8de), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc8ea), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc8f4), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc900), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc90e), 
            kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc91c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc92c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc938), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc944), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc950), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc958), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc964), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc96e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc976), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc982), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc98c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc996)
         };
        private static Hashtable hudMECjTG;
        private static int[] XxQqQ66mW = new int[] { 
            -20319, -20317, -20304, -20295, -20292, -20283, -20265, -20257, -20242, -20230, -20051, -20036, -20032, -20026, -20002, -19990, 
            -19986, -19982, -19976, -19805, -19784, -19775, -19774, -19763, -19756, -19751, -19746, -19741, -19739, -19728, -19725, -19715, 
            -19540, -19531, -19525, -19515, -19500, -19484, -19479, -19467, -19289, -19288, -19281, -19275, -19270, -19263, -19261, -19249, 
            -19243, -19242, -19238, -19235, -19227, -19224, -19218, -19212, -19038, -19023, -19018, -19006, -19003, -18996, -18977, -18961, 
            -18952, -18783, -18774, -18773, -18763, -18756, -18741, -18735, -18731, -18722, -18710, -18697, -18696, -18526, -18518, -18501, 
            -18490, -18478, -18463, -18448, -18447, -18446, -18239, -18237, -18231, -18220, -18211, -18201, -18184, -18183, -18181, -18012, 
            -17997, -17988, -17970, -17964, -17961, -17950, -17947, -17931, -17928, -17922, -17759, -17752, -17733, -17730, -17721, -17703, 
            -17701, -17697, -17692, -17683, -17676, -17496, -17487, -17482, -17468, -17454, -17433, -17427, -17417, -17202, -17185, -16983, 
            -16970, -16942, -16915, -16733, -16708, -16706, -16689, -16664, -16657, -16647, -16474, -16470, -16465, -16459, -16452, -16448, 
            -16433, -16429, -16427, -16423, -16419, -16412, -16407, -16403, -16401, -16393, -16220, -16216, -16212, -16205, -16202, -16187, 
            -16180, -16171, -16169, -16158, -16155, -15959, -15958, -15944, -15933, -15920, -15915, -15903, -15889, -15878, -15707, -15701, 
            -15681, -15667, -15661, -15659, -15652, -15640, -15631, -15625, -15454, -15448, -15436, -15435, -15419, -15416, -15408, -15394, 
            -15385, -15377, -15375, -15369, -15363, -15362, -15183, -15180, -15165, -15158, -15153, -15150, -15149, -15144, -15143, -15141, 
            -15140, -15139, -15128, -15121, -15119, -15117, -15110, -15109, -14941, -14937, -14933, -14930, -14929, -14928, -14926, -14922, 
            -14921, -14914, -14908, -14902, -14894, -14889, -14882, -14873, -14871, -14857, -14678, -14674, -14670, -14668, -14663, -14654, 
            -14645, -14630, -14594, -14429, -14407, -14399, -14384, -14379, -14368, -14355, -14353, -14345, -14170, -14159, -14151, -14149, 
            -14145, -14140, -14137, -14135, -14125, -14123, -14122, -14112, -14109, -14099, -14097, -14094, -14092, -14090, -14087, -14083, 
            -13917, -13914, -13910, -13907, -13906, -13905, -13896, -13894, -13878, -13870, -13859, -13847, -13831, -13658, -13611, -13601, 
            -13406, -13404, -13400, -13398, -13395, -13391, -13387, -13383, -13367, -13359, -13356, -13343, -13340, -13329, -13326, -13318, 
            -13147, -13138, -13120, -13107, -13096, -13095, -13091, -13076, -13068, -13063, -13060, -12888, -12875, -12871, -12860, -12858, 
            -12852, -12849, -12838, -12831, -12829, -12812, -12802, -12607, -12597, -12594, -12585, -12556, -12359, -12346, -12320, -12300, 
            -12120, -12099, -12089, -12074, -12067, -12058, -12039, -11867, -11861, -11847, -11831, -11798, -11781, -11604, -11589, -11536, 
            -11358, -11340, -11339, -11324, -11303, -11097, -11077, -11067, -11055, -11052, -11045, -11041, -11038, -11024, -11020, -11019, 
            -11018, -11014, -10838, -10832, -10815, -10800, -10790, -10780, -10764, -10587, -10544, -10533, -10519, -10331, -10329, -10328, 
            -10322, -10315, -10309, -10307, -10296, -10281, -10274, -10270, -10262, -10260, -10256, -10254
         };

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string CHSToPinyin(string chs)
        {
            return CHSToPinyin(chs, "");
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string CHSToPinyin(string chs, bool initialCap)
        {
            return CHSToPinyin(chs, "", initialCap);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string CHSToPinyin(string chs, string separator)
        {
            return CHSToPinyin(chs, separator, false);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string CHSToPinyin(string chs, string separator, bool initialCap)
        {
            if ((chs == null) || (chs.Length == 0))
            {
                return "";
            }
            if ((separator == null) || (separator.Length == 0))
            {
                separator = "";
            }
            foreach (DictionaryEntry entry in CHSPhraseSpecial)
            {
                chs = chs.Replace(entry.Key.ToString(), string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb7c6), entry.Value.ToString().Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb7dc), separator)));
            }
            byte[] bytes = new byte[2];
            string str = "";
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            bool flag = false;
            bool flag2 = false;
            char[] chArray = chs.ToCharArray();
            TextInfo textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
            for (int i = 0; i < chArray.Length; i++)
            {
                bytes = Encoding.Default.GetBytes(chArray[i].ToString());
                string str2 = chArray[i].ToString();
                if (bytes.Length == 1)
                {
                    flag = true;
                    str = str + str2;
                    continue;
                }
                num2 = bytes[0];
                num3 = bytes[1];
                num = ((num2 * 0x100) + num3) - 0x10000;
                for (int j = XxQqQ66mW.Length - 1; j >= 0; j--)
                {
                    if (XxQqQ66mW[j] <= num)
                    {
                        flag2 = true;
                        str2 = EPgfA8o8U[j];
                        if (initialCap)
                        {
                            str2 = textInfo.ToTitleCase(str2);
                        }
                        if ((str == "") || flag)
                        {
                            str = str + str2;
                        }
                        else
                        {
                            str = str + separator + str2;
                        }
                        break;
                    }
                    flag2 = false;
                }
                if (!flag2)
                {
                    str = str + str2;
                }
                flag = false;
            }
            return str.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb7e2), separator);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetFirstPY(string chsStr)
        {
            if (chsStr.CompareTo(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb7ec)) < 0)
            {
                string s = chsStr.Substring(0, 1).ToUpper();
                if (char.IsNumber(s, 0))
                {
                    return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb7f2);
                }
                return s;
            }
            if (chsStr.CompareTo(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb7f8)) < 0)
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb7fe);
            }
            if (chsStr.CompareTo(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb804)) < 0)
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb80a);
            }
            if (chsStr.CompareTo(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb810)) < 0)
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb816);
            }
            if (chsStr.CompareTo(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb81c)) < 0)
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb822);
            }
            if (chsStr.CompareTo(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb828)) < 0)
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb82e);
            }
            if (chsStr.CompareTo(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb834)) < 0)
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb83a);
            }
            if (chsStr.CompareTo(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb840)) < 0)
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb846);
            }
            if (chsStr.CompareTo(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb84c)) < 0)
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb852);
            }
            if (chsStr.CompareTo(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb858)) < 0)
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb85e);
            }
            if (chsStr.CompareTo(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb864)) < 0)
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb86a);
            }
            if (chsStr.CompareTo(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb870)) < 0)
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb876);
            }
            if (chsStr.CompareTo(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb87c)) < 0)
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb882);
            }
            if (chsStr.CompareTo(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb888)) < 0)
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb88e);
            }
            if (chsStr.CompareTo(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb894)) < 0)
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb89a);
            }
            if (chsStr.CompareTo(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb8a0)) < 0)
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb8a6);
            }
            if (chsStr.CompareTo(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb8ac)) < 0)
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb8b2);
            }
            if (chsStr.CompareTo(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb8b8)) < 0)
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb8be);
            }
            if (chsStr.CompareTo(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb8c4)) < 0)
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb8ca);
            }
            if (chsStr.CompareTo(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb8d0)) < 0)
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb8d6);
            }
            if (chsStr.CompareTo(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb8dc)) < 0)
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb8e2);
            }
            if (chsStr.CompareTo(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb8e8)) < 0)
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb8ee);
            }
            if (chsStr.CompareTo(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb8f4)) < 0)
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb8fa);
            }
            if (chsStr.CompareTo(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb900)) < 0)
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb906);
            }
            return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb90c);
        }

        public static Hashtable CHSPhraseSpecial
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                if (hudMECjTG == null)
                {
                    hudMECjTG = new Hashtable();
                    hudMECjTG.Add(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb912), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb91a));
                    hudMECjTG.Add(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb932), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb93a));
                    hudMECjTG.Add(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb950), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb958));
                }
                return hudMECjTG;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                hudMECjTG = value;
            }
        }
    }
}

