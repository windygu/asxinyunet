namespace WHC.OrderWater.Commons
{
    using System;
    using System.IO;
    using System.Net;
    using System.Runtime.CompilerServices;

    public class IdentifyEncoding
    {
        internal static string[] fcNUBE6Y4 = new string[] { kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x840c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x841c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8426), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x842e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x843a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8450), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8468), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8476), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8488), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8496) };
        internal static int[][] jSdinGKD3 = new int[0x5e][];
        internal static int[][] lWvfFeZUE = new int[0x7e][];
        internal static int[][] mi5qIK3te = new int[0x5e][];
        internal static int[][] OBHMaLtRG = new int[0x5e][];

        [MethodImpl(MethodImplOptions.NoInlining)]
        public IdentifyEncoding()
        {
            this.bSBfwBcaaq();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal virtual int 0ZHfmuDUeA(sbyte[] rawtext)
        {
            int num = 70;
            int length = rawtext.Length;
            for (int i = 0; i < length; i++)
            {
                if (rawtext[i] < 0)
                {
                    num -= 5;
                }
                else if (rawtext[i] == 0x1b)
                {
                    num -= 5;
                }
            }
            return num;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal virtual int 36ufN2M432(sbyte[] rawtext)
        {
            int length = 0;
            int num3 = 1;
            int num4 = 1;
            long num5 = 0L;
            long num6 = 1L;
            float num7 = 0f;
            float num8 = 0f;
            length = rawtext.Length;
            for (int i = 0; i < (length - 1); i++)
            {
                if ((rawtext[i] == 0x1b) && ((i + 3) < length))
                {
                    int num9;
                    int num10;
                    if (((rawtext[i + 1] == 0x24) && (rawtext[i + 2] == 0x29)) && (rawtext[i + 3] == 0x41))
                    {
                        i += 4;
                        while (rawtext[i] != 0x1b)
                        {
                            num3++;
                            if (((0x21 <= rawtext[i]) && (rawtext[i] <= 0x77)) && ((0x21 <= rawtext[i + 1]) && (rawtext[i + 1] <= 0x77)))
                            {
                                num4++;
                                num9 = rawtext[i] - 0x21;
                                num10 = rawtext[i + 1] - 0x21;
                                num6 += 500L;
                                if (mi5qIK3te[num9][num10] != 0)
                                {
                                    num5 += mi5qIK3te[num9][num10];
                                }
                                else if ((15 <= num9) && (num9 < 0x37))
                                {
                                    num5 += 200L;
                                }
                                i++;
                            }
                            i++;
                        }
                    }
                    else if (((((i + 3) < length) && (rawtext[i + 1] == 0x24)) && (rawtext[i + 2] == 0x29)) && (rawtext[i + 3] == 0x47))
                    {
                        i += 4;
                        while (rawtext[i] != 0x1b)
                        {
                            num3++;
                            if ((((0x21 <= rawtext[i]) && (rawtext[i] <= 0x7e)) && (0x21 <= rawtext[i + 1])) && (rawtext[i + 1] <= 0x7e))
                            {
                                num4++;
                                num6 += 500L;
                                num9 = rawtext[i] - 0x21;
                                num10 = rawtext[i + 1] - 0x21;
                                if (jSdinGKD3[num9][num10] != 0)
                                {
                                    num5 += jSdinGKD3[num9][num10];
                                }
                                else if ((0x23 <= num9) && (num9 <= 0x5c))
                                {
                                    num5 += 150L;
                                }
                                i++;
                            }
                            i++;
                        }
                    }
                    if ((((rawtext[i] == 0x1b) && ((i + 2) < length)) && (rawtext[i + 1] == 40)) && (rawtext[i + 2] == 0x42))
                    {
                        i += 2;
                    }
                }
            }
            num7 = 50f * (((float) num4) / ((float) num3));
            num8 = 50f * (((float) num5) / ((float) num6));
            return (int) (num7 + num8);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal virtual int bGofPXwZAx(sbyte[] rawtext)
        {
            int num = 0;
            int length = 0;
            int num4 = 0;
            int num5 = 0;
            length = rawtext.Length;
            for (int i = 0; i < length; i++)
            {
                if ((rawtext[i] & 0x7f) == rawtext[i])
                {
                    num5++;
                }
                else if ((((-64 <= rawtext[i]) && (rawtext[i] <= -33)) && (((i + 1) < length) && (-128 <= rawtext[i + 1]))) && (rawtext[i + 1] <= -65))
                {
                    num4 += 2;
                    i++;
                }
                else if (((((-32 <= rawtext[i]) && (rawtext[i] <= -17)) && (((i + 2) < length) && (-128 <= rawtext[i + 1]))) && ((rawtext[i + 1] <= -65) && (-128 <= rawtext[i + 2]))) && (rawtext[i + 2] <= -65))
                {
                    num4 += 3;
                    i += 2;
                }
            }
            if (num5 != length)
            {
                num = (int) (100f * (((float) num4) / ((float) (length - num5))));
                if (num > 0x62)
                {
                    return num;
                }
                if ((num > 0x5f) && (num4 > 30))
                {
                    return num;
                }
            }
            return 0;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal virtual void bSBfwBcaaq()
        {
            int num;
            if (mi5qIK3te[0] == null)
            {
                for (num = 0; num < 0x5e; num++)
                {
                    mi5qIK3te[num] = new int[0x5e];
                }
                mi5qIK3te[0x31][0x1a] = 0x256;
                mi5qIK3te[0x29][0x26] = 0x255;
                mi5qIK3te[0x11][0x1a] = 0x254;
                mi5qIK3te[0x20][0x2a] = 0x253;
                mi5qIK3te[0x27][0x2a] = 0x252;
                mi5qIK3te[0x2d][0x31] = 0x251;
                mi5qIK3te[0x33][0x39] = 0x250;
                mi5qIK3te[50][0x2f] = 0x24f;
                mi5qIK3te[0x2a][90] = 590;
                mi5qIK3te[0x34][0x41] = 0x24d;
                mi5qIK3te[0x35][0x2f] = 0x24c;
                mi5qIK3te[0x13][0x52] = 0x24b;
                mi5qIK3te[0x1f][0x13] = 0x24a;
                mi5qIK3te[40][0x2e] = 0x249;
                mi5qIK3te[0x18][0x59] = 0x248;
                mi5qIK3te[0x17][0x55] = 0x247;
                mi5qIK3te[20][0x1c] = 0x246;
                mi5qIK3te[0x2a][20] = 0x245;
                mi5qIK3te[0x22][0x26] = 580;
                mi5qIK3te[0x2d][9] = 0x243;
                mi5qIK3te[0x36][50] = 0x242;
                mi5qIK3te[0x19][0x2c] = 0x241;
                mi5qIK3te[0x23][0x42] = 0x240;
                mi5qIK3te[20][0x37] = 0x23f;
                mi5qIK3te[0x12][0x55] = 0x23e;
                mi5qIK3te[20][0x1f] = 0x23d;
                mi5qIK3te[0x31][0x11] = 0x23c;
                mi5qIK3te[0x29][0x10] = 0x23b;
                mi5qIK3te[0x23][0x49] = 570;
                mi5qIK3te[20][0x22] = 0x239;
                mi5qIK3te[0x1d][0x2c] = 0x238;
                mi5qIK3te[0x23][0x26] = 0x237;
                mi5qIK3te[0x31][9] = 0x236;
                mi5qIK3te[0x2e][0x21] = 0x235;
                mi5qIK3te[0x31][0x33] = 0x234;
                mi5qIK3te[40][0x59] = 0x233;
                mi5qIK3te[0x1a][0x40] = 0x232;
                mi5qIK3te[0x36][0x33] = 0x231;
                mi5qIK3te[0x36][0x24] = 560;
                mi5qIK3te[0x27][4] = 0x22f;
                mi5qIK3te[0x35][13] = 0x22e;
                mi5qIK3te[0x18][0x5c] = 0x22d;
                mi5qIK3te[0x1b][0x31] = 0x22c;
                mi5qIK3te[0x30][6] = 0x22b;
                mi5qIK3te[0x15][0x33] = 0x22a;
                mi5qIK3te[30][40] = 0x229;
                mi5qIK3te[0x2a][0x5c] = 0x228;
                mi5qIK3te[0x1f][0x4e] = 0x227;
                mi5qIK3te[0x19][0x52] = 550;
                mi5qIK3te[0x2f][0] = 0x225;
                mi5qIK3te[0x22][0x13] = 0x224;
                mi5qIK3te[0x2f][0x23] = 0x223;
                mi5qIK3te[0x15][0x3f] = 0x222;
                mi5qIK3te[0x2b][0x4b] = 0x221;
                mi5qIK3te[0x15][0x57] = 0x220;
                mi5qIK3te[0x23][0x3b] = 0x21f;
                mi5qIK3te[0x19][0x22] = 0x21e;
                mi5qIK3te[0x15][0x1b] = 0x21d;
                mi5qIK3te[0x27][0x1a] = 540;
                mi5qIK3te[0x22][0x1a] = 0x21b;
                mi5qIK3te[0x27][0x34] = 0x21a;
                mi5qIK3te[50][0x39] = 0x219;
                mi5qIK3te[0x25][0x4f] = 0x218;
                mi5qIK3te[0x1a][0x18] = 0x217;
                mi5qIK3te[0x16][1] = 0x216;
                mi5qIK3te[0x12][40] = 0x215;
                mi5qIK3te[0x29][0x21] = 0x214;
                mi5qIK3te[0x35][0x1a] = 0x213;
                mi5qIK3te[0x36][0x56] = 530;
                mi5qIK3te[20][0x10] = 0x211;
                mi5qIK3te[0x2e][0x4a] = 0x210;
                mi5qIK3te[30][0x13] = 0x20f;
                mi5qIK3te[0x2d][0x23] = 0x20e;
                mi5qIK3te[0x2d][0x3d] = 0x20d;
                mi5qIK3te[30][9] = 0x20c;
                mi5qIK3te[0x29][0x35] = 0x20b;
                mi5qIK3te[0x29][13] = 0x20a;
                mi5qIK3te[50][0x22] = 0x209;
                mi5qIK3te[0x35][0x56] = 520;
                mi5qIK3te[0x2f][0x2f] = 0x207;
                mi5qIK3te[0x16][0x1c] = 0x206;
                mi5qIK3te[50][0x35] = 0x205;
                mi5qIK3te[0x27][70] = 0x204;
                mi5qIK3te[0x26][15] = 0x203;
                mi5qIK3te[0x2a][0x58] = 0x202;
                mi5qIK3te[0x10][0x1d] = 0x201;
                mi5qIK3te[0x1b][90] = 0x200;
                mi5qIK3te[0x1d][12] = 0x1ff;
                mi5qIK3te[0x2c][0x16] = 510;
                mi5qIK3te[0x22][0x45] = 0x1fd;
                mi5qIK3te[0x18][10] = 0x1fc;
                mi5qIK3te[0x2c][11] = 0x1fb;
                mi5qIK3te[0x27][0x5c] = 0x1fa;
                mi5qIK3te[0x31][0x30] = 0x1f9;
                mi5qIK3te[0x1f][0x2e] = 0x1f8;
                mi5qIK3te[0x13][50] = 0x1f7;
                mi5qIK3te[0x15][14] = 0x1f6;
                mi5qIK3te[0x20][0x1c] = 0x1f5;
                mi5qIK3te[0x12][3] = 500;
                mi5qIK3te[0x35][9] = 0x1f3;
                mi5qIK3te[0x22][80] = 0x1f2;
                mi5qIK3te[0x30][0x58] = 0x1f1;
                mi5qIK3te[0x2e][0x35] = 0x1f0;
                mi5qIK3te[0x16][0x35] = 0x1ef;
                mi5qIK3te[0x1c][10] = 0x1ee;
                mi5qIK3te[0x2c][0x41] = 0x1ed;
                mi5qIK3te[20][10] = 0x1ec;
                mi5qIK3te[40][0x4c] = 0x1eb;
                mi5qIK3te[0x2f][8] = 490;
                mi5qIK3te[50][0x4a] = 0x1e9;
                mi5qIK3te[0x17][0x3e] = 0x1e8;
                mi5qIK3te[0x31][0x41] = 0x1e7;
                mi5qIK3te[0x1c][0x57] = 0x1e6;
                mi5qIK3te[15][0x30] = 0x1e5;
                mi5qIK3te[0x16][7] = 0x1e4;
                mi5qIK3te[0x13][0x2a] = 0x1e3;
                mi5qIK3te[0x29][20] = 0x1e2;
                mi5qIK3te[0x1a][0x37] = 0x1e1;
                mi5qIK3te[0x15][0x5d] = 480;
                mi5qIK3te[0x1f][0x4c] = 0x1df;
                mi5qIK3te[0x22][0x1f] = 0x1de;
                mi5qIK3te[20][0x42] = 0x1dd;
                mi5qIK3te[0x33][0x21] = 0x1dc;
                mi5qIK3te[0x22][0x56] = 0x1db;
                mi5qIK3te[0x25][0x43] = 0x1da;
                mi5qIK3te[0x35][0x35] = 0x1d9;
                mi5qIK3te[40][0x58] = 0x1d8;
                mi5qIK3te[0x27][10] = 0x1d7;
                mi5qIK3te[0x18][3] = 470;
                mi5qIK3te[0x1b][0x19] = 0x1d5;
                mi5qIK3te[0x1a][15] = 0x1d4;
                mi5qIK3te[0x15][0x58] = 0x1d3;
                mi5qIK3te[0x34][0x3e] = 0x1d2;
                mi5qIK3te[0x2e][0x51] = 0x1d1;
                mi5qIK3te[0x26][0x48] = 0x1d0;
                mi5qIK3te[0x11][30] = 0x1cf;
                mi5qIK3te[0x34][0x5c] = 0x1ce;
                mi5qIK3te[0x22][90] = 0x1cd;
                mi5qIK3te[0x15][7] = 460;
                mi5qIK3te[0x24][13] = 0x1cb;
                mi5qIK3te[0x2d][0x29] = 0x1ca;
                mi5qIK3te[0x20][5] = 0x1c9;
                mi5qIK3te[0x1a][0x59] = 0x1c8;
                mi5qIK3te[0x17][0x57] = 0x1c7;
                mi5qIK3te[20][0x27] = 0x1c6;
                mi5qIK3te[0x1b][0x17] = 0x1c5;
                mi5qIK3te[0x19][0x3b] = 0x1c4;
                mi5qIK3te[0x31][20] = 0x1c3;
                mi5qIK3te[0x36][0x4d] = 450;
                mi5qIK3te[0x1b][0x43] = 0x1c1;
                mi5qIK3te[0x2f][0x21] = 0x1c0;
                mi5qIK3te[0x29][0x11] = 0x1bf;
                mi5qIK3te[0x13][0x51] = 0x1be;
                mi5qIK3te[0x10][0x42] = 0x1bd;
                mi5qIK3te[0x2d][0x1a] = 0x1bc;
                mi5qIK3te[0x31][0x51] = 0x1bb;
                mi5qIK3te[0x35][0x37] = 0x1ba;
                mi5qIK3te[0x10][0x1a] = 0x1b9;
                mi5qIK3te[0x36][0x3e] = 440;
                mi5qIK3te[20][70] = 0x1b7;
                mi5qIK3te[0x2a][0x23] = 0x1b6;
                mi5qIK3te[20][0x39] = 0x1b5;
                mi5qIK3te[0x22][0x24] = 0x1b4;
                mi5qIK3te[0x2e][0x3f] = 0x1b3;
                mi5qIK3te[0x13][0x2d] = 0x1b2;
                mi5qIK3te[0x15][10] = 0x1b1;
                mi5qIK3te[0x34][0x5d] = 0x1b0;
                mi5qIK3te[0x19][2] = 0x1af;
                mi5qIK3te[30][0x39] = 430;
                mi5qIK3te[0x29][0x18] = 0x1ad;
                mi5qIK3te[0x1c][0x2b] = 0x1ac;
                mi5qIK3te[0x2d][0x56] = 0x1ab;
                mi5qIK3te[0x33][0x38] = 0x1aa;
                mi5qIK3te[0x25][0x1c] = 0x1a9;
                mi5qIK3te[0x34][0x45] = 0x1a8;
                mi5qIK3te[0x2b][0x5c] = 0x1a7;
                mi5qIK3te[0x29][0x1f] = 0x1a6;
                mi5qIK3te[0x25][0x57] = 0x1a5;
                mi5qIK3te[0x2f][0x24] = 420;
                mi5qIK3te[0x10][0x10] = 0x1a3;
                mi5qIK3te[40][0x38] = 0x1a2;
                mi5qIK3te[0x18][0x37] = 0x1a1;
                mi5qIK3te[0x11][1] = 0x1a0;
                mi5qIK3te[0x23][0x39] = 0x19f;
                mi5qIK3te[0x1b][50] = 0x19e;
                mi5qIK3te[0x1a][14] = 0x19d;
                mi5qIK3te[50][40] = 0x19c;
                mi5qIK3te[0x27][0x13] = 0x19b;
                mi5qIK3te[0x13][0x59] = 410;
                mi5qIK3te[0x1d][0x5b] = 0x199;
                mi5qIK3te[0x11][0x59] = 0x198;
                mi5qIK3te[0x27][0x4a] = 0x197;
                mi5qIK3te[0x2e][0x27] = 0x196;
                mi5qIK3te[40][0x1c] = 0x195;
                mi5qIK3te[0x2d][0x44] = 0x194;
                mi5qIK3te[0x2b][10] = 0x193;
                mi5qIK3te[0x2a][13] = 0x192;
                mi5qIK3te[0x2c][0x51] = 0x191;
                mi5qIK3te[0x29][0x2f] = 400;
                mi5qIK3te[0x30][0x3a] = 0x18f;
                mi5qIK3te[0x2b][0x44] = 0x18e;
                mi5qIK3te[0x10][0x4f] = 0x18d;
                mi5qIK3te[0x13][5] = 0x18c;
                mi5qIK3te[0x36][0x3b] = 0x18b;
                mi5qIK3te[0x11][0x24] = 0x18a;
                mi5qIK3te[0x12][0] = 0x189;
                mi5qIK3te[0x29][5] = 0x188;
                mi5qIK3te[0x29][0x48] = 0x187;
                mi5qIK3te[0x10][0x27] = 390;
                mi5qIK3te[0x36][0] = 0x185;
                mi5qIK3te[0x33][0x10] = 0x184;
                mi5qIK3te[0x1d][0x24] = 0x183;
                mi5qIK3te[0x2f][5] = 0x182;
                mi5qIK3te[0x2f][0x33] = 0x181;
                mi5qIK3te[0x2c][7] = 0x180;
                mi5qIK3te[0x23][30] = 0x17f;
                mi5qIK3te[0x1a][9] = 0x17e;
                mi5qIK3te[0x10][7] = 0x17d;
                mi5qIK3te[0x20][1] = 380;
                mi5qIK3te[0x21][0x4c] = 0x17b;
                mi5qIK3te[0x22][0x5b] = 0x17a;
                mi5qIK3te[0x34][0x24] = 0x179;
                mi5qIK3te[0x1a][0x4d] = 0x178;
                mi5qIK3te[0x23][0x30] = 0x177;
                mi5qIK3te[40][80] = 0x176;
                mi5qIK3te[0x29][0x5c] = 0x175;
                mi5qIK3te[0x1b][0x5d] = 0x174;
                mi5qIK3te[15][0x11] = 0x173;
                mi5qIK3te[0x10][0x4c] = 370;
                mi5qIK3te[0x33][12] = 0x171;
                mi5qIK3te[0x12][20] = 0x170;
                mi5qIK3te[15][0x36] = 0x16f;
                mi5qIK3te[50][5] = 0x16e;
                mi5qIK3te[0x21][0x16] = 0x16d;
                mi5qIK3te[0x25][0x39] = 0x16c;
                mi5qIK3te[0x1c][0x2f] = 0x16b;
                mi5qIK3te[0x2a][0x1f] = 0x16a;
                mi5qIK3te[0x12][2] = 0x169;
                mi5qIK3te[0x2b][0x40] = 360;
                mi5qIK3te[0x17][0x2f] = 0x167;
                mi5qIK3te[0x1c][0x4f] = 0x166;
                mi5qIK3te[0x19][0x2d] = 0x165;
                mi5qIK3te[0x17][0x5b] = 0x164;
                mi5qIK3te[0x16][0x13] = 0x163;
                mi5qIK3te[0x19][0x2e] = 0x162;
                mi5qIK3te[0x16][0x24] = 0x161;
                mi5qIK3te[0x36][0x55] = 0x160;
                mi5qIK3te[0x2e][20] = 0x15f;
                mi5qIK3te[0x1b][0x25] = 350;
                mi5qIK3te[0x1a][0x51] = 0x15d;
                mi5qIK3te[0x2a][0x1d] = 0x15c;
                mi5qIK3te[0x1f][90] = 0x15b;
                mi5qIK3te[0x29][0x3b] = 0x15a;
                mi5qIK3te[0x18][0x41] = 0x159;
                mi5qIK3te[0x2c][0x54] = 0x158;
                mi5qIK3te[0x18][90] = 0x157;
                mi5qIK3te[0x26][0x36] = 0x156;
                mi5qIK3te[0x1c][70] = 0x155;
                mi5qIK3te[0x1b][15] = 340;
                mi5qIK3te[0x1c][80] = 0x153;
                mi5qIK3te[0x1d][8] = 0x152;
                mi5qIK3te[0x2d][80] = 0x151;
                mi5qIK3te[0x35][0x25] = 0x150;
                mi5qIK3te[0x1c][0x41] = 0x14f;
                mi5qIK3te[0x17][0x56] = 0x14e;
                mi5qIK3te[0x27][0x2d] = 0x14d;
                mi5qIK3te[0x35][0x20] = 0x14c;
                mi5qIK3te[0x26][0x44] = 0x14b;
                mi5qIK3te[0x2d][0x4e] = 330;
                mi5qIK3te[0x2b][7] = 0x149;
                mi5qIK3te[0x2e][0x52] = 0x148;
                mi5qIK3te[0x1b][0x26] = 0x147;
                mi5qIK3te[0x10][0x3e] = 0x146;
                mi5qIK3te[0x18][0x11] = 0x145;
                mi5qIK3te[0x16][70] = 0x144;
                mi5qIK3te[0x34][0x1c] = 0x143;
                mi5qIK3te[0x17][40] = 0x142;
                mi5qIK3te[0x1c][50] = 0x141;
                mi5qIK3te[0x2a][0x5b] = 320;
                mi5qIK3te[0x2f][0x4c] = 0x13f;
                mi5qIK3te[15][0x2a] = 0x13e;
                mi5qIK3te[0x2b][0x37] = 0x13d;
                mi5qIK3te[0x1d][0x54] = 0x13c;
                mi5qIK3te[0x2c][90] = 0x13b;
                mi5qIK3te[0x35][0x10] = 0x13a;
                mi5qIK3te[0x16][0x5d] = 0x139;
                mi5qIK3te[0x22][10] = 0x138;
                mi5qIK3te[0x20][0x35] = 0x137;
                mi5qIK3te[0x2b][0x41] = 310;
                mi5qIK3te[0x1c][7] = 0x135;
                mi5qIK3te[0x23][0x2e] = 0x134;
                mi5qIK3te[0x15][0x27] = 0x133;
                mi5qIK3te[0x2c][0x12] = 0x132;
                mi5qIK3te[40][10] = 0x131;
                mi5qIK3te[0x36][0x35] = 0x130;
                mi5qIK3te[0x26][0x4a] = 0x12f;
                mi5qIK3te[0x1c][0x1a] = 0x12e;
                mi5qIK3te[15][13] = 0x12d;
                mi5qIK3te[0x27][0x22] = 300;
                mi5qIK3te[0x27][0x2e] = 0x12b;
                mi5qIK3te[0x2a][0x42] = 0x12a;
                mi5qIK3te[0x21][0x3a] = 0x129;
                mi5qIK3te[15][0x38] = 0x128;
                mi5qIK3te[0x12][0x33] = 0x127;
                mi5qIK3te[0x31][0x44] = 0x126;
                mi5qIK3te[30][0x25] = 0x125;
                mi5qIK3te[0x33][0x54] = 0x124;
                mi5qIK3te[0x33][9] = 0x123;
                mi5qIK3te[40][70] = 290;
                mi5qIK3te[0x29][0x54] = 0x121;
                mi5qIK3te[0x1c][0x40] = 0x120;
                mi5qIK3te[0x20][0x58] = 0x11f;
                mi5qIK3te[0x18][5] = 0x11e;
                mi5qIK3te[0x35][0x17] = 0x11d;
                mi5qIK3te[0x2a][0x1b] = 0x11c;
                mi5qIK3te[0x16][0x26] = 0x11b;
                mi5qIK3te[0x20][0x56] = 0x11a;
                mi5qIK3te[0x22][30] = 0x119;
                mi5qIK3te[0x26][0x3f] = 280;
                mi5qIK3te[0x18][0x3b] = 0x117;
                mi5qIK3te[0x16][0x51] = 0x116;
                mi5qIK3te[0x20][11] = 0x115;
                mi5qIK3te[0x33][0x15] = 0x114;
                mi5qIK3te[0x36][0x29] = 0x113;
                mi5qIK3te[0x15][50] = 0x112;
                mi5qIK3te[0x17][0x59] = 0x111;
                mi5qIK3te[0x13][0x57] = 0x110;
                mi5qIK3te[0x1a][7] = 0x10f;
                mi5qIK3te[30][0x4b] = 270;
                mi5qIK3te[0x2b][0x54] = 0x10d;
                mi5qIK3te[0x33][0x19] = 0x10c;
                mi5qIK3te[0x10][0x43] = 0x10b;
                mi5qIK3te[0x20][9] = 0x10a;
                mi5qIK3te[0x30][0x33] = 0x109;
                mi5qIK3te[0x27][7] = 0x108;
                mi5qIK3te[0x2c][0x58] = 0x107;
                mi5qIK3te[0x34][0x18] = 0x106;
                mi5qIK3te[0x17][0x22] = 0x105;
                mi5qIK3te[0x20][0x4b] = 260;
                mi5qIK3te[0x13][10] = 0x103;
                mi5qIK3te[0x1c][0x5b] = 0x102;
                mi5qIK3te[0x20][0x53] = 0x101;
                mi5qIK3te[0x19][0x4b] = 0x100;
                mi5qIK3te[0x35][0x2d] = 0xff;
                mi5qIK3te[0x1d][0x55] = 0xfe;
                mi5qIK3te[0x35][0x3b] = 0xfd;
                mi5qIK3te[0x10][2] = 0xfc;
                mi5qIK3te[0x13][0x4e] = 0xfb;
                mi5qIK3te[15][0x4b] = 250;
                mi5qIK3te[0x33][0x2a] = 0xf9;
                mi5qIK3te[0x2d][0x43] = 0xf8;
                mi5qIK3te[15][0x4a] = 0xf7;
                mi5qIK3te[0x19][0x51] = 0xf6;
                mi5qIK3te[0x25][0x3e] = 0xf5;
                mi5qIK3te[0x10][0x37] = 0xf4;
                mi5qIK3te[0x12][0x26] = 0xf3;
                mi5qIK3te[0x17][0x17] = 0xf2;
                mi5qIK3te[0x26][30] = 0xf1;
                mi5qIK3te[0x11][0x1c] = 240;
                mi5qIK3te[0x2c][0x49] = 0xef;
                mi5qIK3te[0x17][0x4e] = 0xee;
                mi5qIK3te[40][0x4d] = 0xed;
                mi5qIK3te[0x26][0x57] = 0xec;
                mi5qIK3te[0x1b][0x13] = 0xeb;
                mi5qIK3te[0x26][0x52] = 0xea;
                mi5qIK3te[0x25][0x16] = 0xe9;
                mi5qIK3te[0x29][30] = 0xe8;
                mi5qIK3te[0x36][9] = 0xe7;
                mi5qIK3te[0x20][30] = 230;
                mi5qIK3te[30][0x34] = 0xe5;
                mi5qIK3te[40][0x54] = 0xe4;
                mi5qIK3te[0x35][0x39] = 0xe3;
                mi5qIK3te[0x1b][0x1b] = 0xe2;
                mi5qIK3te[0x26][0x40] = 0xe1;
                mi5qIK3te[0x12][0x2b] = 0xe0;
                mi5qIK3te[0x17][0x45] = 0xdf;
                mi5qIK3te[0x1c][12] = 0xde;
                mi5qIK3te[50][0x4e] = 0xdd;
                mi5qIK3te[50][1] = 220;
                mi5qIK3te[0x1a][0x58] = 0xdb;
                mi5qIK3te[0x24][40] = 0xda;
                mi5qIK3te[0x21][0x59] = 0xd9;
                mi5qIK3te[0x29][0x1c] = 0xd8;
                mi5qIK3te[0x1f][0x4d] = 0xd7;
                mi5qIK3te[0x2e][1] = 0xd6;
                mi5qIK3te[0x2f][0x13] = 0xd5;
                mi5qIK3te[0x23][0x37] = 0xd4;
                mi5qIK3te[0x29][0x15] = 0xd3;
                mi5qIK3te[0x1b][10] = 210;
                mi5qIK3te[0x20][0x4d] = 0xd1;
                mi5qIK3te[0x1a][0x25] = 0xd0;
                mi5qIK3te[20][0x21] = 0xcf;
                mi5qIK3te[0x29][0x34] = 0xce;
                mi5qIK3te[0x20][0x12] = 0xcd;
                mi5qIK3te[0x26][13] = 0xcc;
                mi5qIK3te[20][0x12] = 0xcb;
                mi5qIK3te[20][0x18] = 0xca;
                mi5qIK3te[0x2d][0x13] = 0xc9;
                mi5qIK3te[0x12][0x35] = 200;
            }
            if (lWvfFeZUE[0] == null)
            {
                for (num = 0; num < 0x7e; num++)
                {
                    lWvfFeZUE[num] = new int[0xbf];
                }
                lWvfFeZUE[0x49][0x87] = 0x257;
                lWvfFeZUE[0x31][0x7b] = 0x256;
                lWvfFeZUE[0x4d][0x92] = 0x255;
                lWvfFeZUE[0x51][0x7b] = 0x254;
                lWvfFeZUE[0x52][0x90] = 0x253;
                lWvfFeZUE[0x33][0xb3] = 0x252;
                lWvfFeZUE[0x53][0x9a] = 0x251;
                lWvfFeZUE[0x47][0x8b] = 0x250;
                lWvfFeZUE[0x40][0x8b] = 0x24f;
                lWvfFeZUE[0x55][0x90] = 590;
                lWvfFeZUE[0x34][0x7d] = 0x24d;
                lWvfFeZUE[0x58][0x19] = 0x24c;
                lWvfFeZUE[0x51][0x6a] = 0x24b;
                lWvfFeZUE[0x51][0x94] = 0x24a;
                lWvfFeZUE[0x3e][0x89] = 0x249;
                lWvfFeZUE[0x5e][0] = 0x248;
                lWvfFeZUE[1][0x40] = 0x247;
                lWvfFeZUE[0x43][0xa3] = 0x246;
                lWvfFeZUE[20][190] = 0x245;
                lWvfFeZUE[0x39][0x83] = 580;
                lWvfFeZUE[0x1d][0xa9] = 0x243;
                lWvfFeZUE[0x48][0x8f] = 0x242;
                lWvfFeZUE[0][0xad] = 0x241;
                lWvfFeZUE[11][0x17] = 0x240;
                lWvfFeZUE[0x3d][0x8d] = 0x23f;
                lWvfFeZUE[60][0x7b] = 0x23e;
                lWvfFeZUE[0x51][0x72] = 0x23d;
                lWvfFeZUE[0x52][0x83] = 0x23c;
                lWvfFeZUE[0x43][0x9c] = 0x23b;
                lWvfFeZUE[0x47][0xa7] = 570;
                lWvfFeZUE[20][50] = 0x239;
                lWvfFeZUE[0x4d][0x84] = 0x238;
                lWvfFeZUE[0x54][0x26] = 0x237;
                lWvfFeZUE[0x1a][0x1d] = 0x236;
                lWvfFeZUE[0x4a][0xbb] = 0x235;
                lWvfFeZUE[0x3e][0x74] = 0x234;
                lWvfFeZUE[0x43][0x87] = 0x233;
                lWvfFeZUE[5][0x56] = 0x232;
                lWvfFeZUE[0x48][0xba] = 0x231;
                lWvfFeZUE[0x4b][0xa1] = 560;
                lWvfFeZUE[0x4e][130] = 0x22f;
                lWvfFeZUE[0x5e][30] = 0x22e;
                lWvfFeZUE[0x54][0x48] = 0x22d;
                lWvfFeZUE[1][0x43] = 0x22c;
                lWvfFeZUE[0x4b][0xac] = 0x22b;
                lWvfFeZUE[0x4a][0xb9] = 0x22a;
                lWvfFeZUE[0x35][160] = 0x229;
                lWvfFeZUE[0x7b][14] = 0x228;
                lWvfFeZUE[0x4f][0x61] = 0x227;
                lWvfFeZUE[0x55][110] = 550;
                lWvfFeZUE[0x4e][0xab] = 0x225;
                lWvfFeZUE[0x34][0x83] = 0x224;
                lWvfFeZUE[0x38][100] = 0x223;
                lWvfFeZUE[50][0xb6] = 0x222;
                lWvfFeZUE[0x5e][0x40] = 0x221;
                lWvfFeZUE[0x6a][0x4a] = 0x220;
                lWvfFeZUE[11][0x66] = 0x21f;
                lWvfFeZUE[0x35][0x7c] = 0x21e;
                lWvfFeZUE[0x18][3] = 0x21d;
                lWvfFeZUE[0x56][0x94] = 540;
                lWvfFeZUE[0x35][0xb8] = 0x21b;
                lWvfFeZUE[0x56][0x93] = 0x21a;
                lWvfFeZUE[0x60][0xa1] = 0x219;
                lWvfFeZUE[0x52][0x4d] = 0x218;
                lWvfFeZUE[0x3b][0x92] = 0x217;
                lWvfFeZUE[0x54][0x7e] = 0x216;
                lWvfFeZUE[0x4f][0x84] = 0x215;
                lWvfFeZUE[0x55][0x7b] = 0x214;
                lWvfFeZUE[0x47][0x65] = 0x213;
                lWvfFeZUE[0x55][0x6a] = 530;
                lWvfFeZUE[6][0xb8] = 0x211;
                lWvfFeZUE[0x39][0x9c] = 0x210;
                lWvfFeZUE[0x4b][0x68] = 0x20f;
                lWvfFeZUE[50][0x89] = 0x20e;
                lWvfFeZUE[0x4f][0x85] = 0x20d;
                lWvfFeZUE[0x4c][0x6c] = 0x20c;
                lWvfFeZUE[0x39][0x8e] = 0x20b;
                lWvfFeZUE[0x54][130] = 0x20a;
                lWvfFeZUE[0x34][0x80] = 0x209;
                lWvfFeZUE[0x2f][0x2c] = 520;
                lWvfFeZUE[0x34][0x98] = 0x207;
                lWvfFeZUE[0x36][0x68] = 0x206;
                lWvfFeZUE[30][0x2f] = 0x205;
                lWvfFeZUE[0x47][0x7b] = 0x204;
                lWvfFeZUE[0x34][0x6b] = 0x203;
                lWvfFeZUE[0x2d][0x54] = 0x202;
                lWvfFeZUE[0x6b][0x76] = 0x201;
                lWvfFeZUE[5][0xa1] = 0x200;
                lWvfFeZUE[0x30][0x7e] = 0x1ff;
                lWvfFeZUE[0x43][170] = 510;
                lWvfFeZUE[0x2b][6] = 0x1fd;
                lWvfFeZUE[70][0x70] = 0x1fc;
                lWvfFeZUE[0x56][0xae] = 0x1fb;
                lWvfFeZUE[0x54][0xa6] = 0x1fa;
                lWvfFeZUE[0x4f][130] = 0x1f9;
                lWvfFeZUE[0x39][0x8d] = 0x1f8;
                lWvfFeZUE[0x51][0xb2] = 0x1f7;
                lWvfFeZUE[0x38][0xbb] = 0x1f6;
                lWvfFeZUE[0x51][0xa2] = 0x1f5;
                lWvfFeZUE[0x35][0x68] = 500;
                lWvfFeZUE[0x7b][0x23] = 0x1f3;
                lWvfFeZUE[70][0xa9] = 0x1f2;
                lWvfFeZUE[0x45][0xa4] = 0x1f1;
                lWvfFeZUE[0x6d][0x3d] = 0x1f0;
                lWvfFeZUE[0x49][130] = 0x1ef;
                lWvfFeZUE[0x3e][0x86] = 0x1ee;
                lWvfFeZUE[0x36][0x7d] = 0x1ed;
                lWvfFeZUE[0x4f][0x69] = 0x1ec;
                lWvfFeZUE[70][0xa5] = 0x1eb;
                lWvfFeZUE[0x47][0xbd] = 490;
                lWvfFeZUE[0x17][0x93] = 0x1e9;
                lWvfFeZUE[0x33][0x8b] = 0x1e8;
                lWvfFeZUE[0x2f][0x89] = 0x1e7;
                lWvfFeZUE[0x4d][0x7b] = 0x1e6;
                lWvfFeZUE[0x56][0xb7] = 0x1e5;
                lWvfFeZUE[0x3f][0xad] = 0x1e4;
                lWvfFeZUE[0x4f][0x90] = 0x1e3;
                lWvfFeZUE[0x54][0x9f] = 0x1e2;
                lWvfFeZUE[60][0x5b] = 0x1e1;
                lWvfFeZUE[0x42][0xbb] = 480;
                lWvfFeZUE[0x49][0x72] = 0x1df;
                lWvfFeZUE[0x55][0x38] = 0x1de;
                lWvfFeZUE[0x47][0x95] = 0x1dd;
                lWvfFeZUE[0x54][0xbd] = 0x1dc;
                lWvfFeZUE[0x68][0x1f] = 0x1db;
                lWvfFeZUE[0x53][0x52] = 0x1da;
                lWvfFeZUE[0x44][0x23] = 0x1d9;
                lWvfFeZUE[11][0x4d] = 0x1d8;
                lWvfFeZUE[15][0x9b] = 0x1d7;
                lWvfFeZUE[0x53][0x99] = 470;
                lWvfFeZUE[0x47][1] = 0x1d5;
                lWvfFeZUE[0x35][190] = 0x1d4;
                lWvfFeZUE[50][0x87] = 0x1d3;
                lWvfFeZUE[3][0x93] = 0x1d2;
                lWvfFeZUE[0x30][0x88] = 0x1d1;
                lWvfFeZUE[0x42][0xa6] = 0x1d0;
                lWvfFeZUE[0x37][0x9f] = 0x1cf;
                lWvfFeZUE[0x52][150] = 0x1ce;
                lWvfFeZUE[0x3a][0xb2] = 0x1cd;
                lWvfFeZUE[0x40][0x66] = 460;
                lWvfFeZUE[0x10][0x6a] = 0x1cb;
                lWvfFeZUE[0x44][110] = 0x1ca;
                lWvfFeZUE[0x36][14] = 0x1c9;
                lWvfFeZUE[60][140] = 0x1c8;
                lWvfFeZUE[0x5b][0x47] = 0x1c7;
                lWvfFeZUE[0x36][150] = 0x1c6;
                lWvfFeZUE[0x4e][0xb1] = 0x1c5;
                lWvfFeZUE[0x4e][0x75] = 0x1c4;
                lWvfFeZUE[0x68][12] = 0x1c3;
                lWvfFeZUE[0x49][150] = 450;
                lWvfFeZUE[0x33][0x8e] = 0x1c1;
                lWvfFeZUE[0x51][0x91] = 0x1c0;
                lWvfFeZUE[0x42][0xb7] = 0x1bf;
                lWvfFeZUE[0x33][0xb2] = 0x1be;
                lWvfFeZUE[0x4b][0x6b] = 0x1bd;
                lWvfFeZUE[0x41][0x77] = 0x1bc;
                lWvfFeZUE[0x45][0xb0] = 0x1bb;
                lWvfFeZUE[0x3b][0x7a] = 0x1ba;
                lWvfFeZUE[0x4e][160] = 0x1b9;
                lWvfFeZUE[0x55][0xb7] = 440;
                lWvfFeZUE[0x69][0x10] = 0x1b7;
                lWvfFeZUE[0x49][110] = 0x1b6;
                lWvfFeZUE[0x68][0x27] = 0x1b5;
                lWvfFeZUE[0x77][0x10] = 0x1b4;
                lWvfFeZUE[0x4c][0xa2] = 0x1b3;
                lWvfFeZUE[0x43][0x98] = 0x1b2;
                lWvfFeZUE[0x52][0x18] = 0x1b1;
                lWvfFeZUE[0x49][0x79] = 0x1b0;
                lWvfFeZUE[0x53][0x53] = 0x1af;
                lWvfFeZUE[0x52][0x91] = 430;
                lWvfFeZUE[0x31][0x85] = 0x1ad;
                lWvfFeZUE[0x5e][13] = 0x1ac;
                lWvfFeZUE[0x3a][0x8b] = 0x1ab;
                lWvfFeZUE[0x4a][0xbd] = 0x1aa;
                lWvfFeZUE[0x42][0xb1] = 0x1a9;
                lWvfFeZUE[0x55][0xb8] = 0x1a8;
                lWvfFeZUE[0x37][0xb7] = 0x1a7;
                lWvfFeZUE[0x47][0x6b] = 0x1a6;
                lWvfFeZUE[11][0x62] = 0x1a5;
                lWvfFeZUE[0x48][0x99] = 420;
                lWvfFeZUE[2][0x89] = 0x1a3;
                lWvfFeZUE[0x3b][0x93] = 0x1a2;
                lWvfFeZUE[0x3a][0x98] = 0x1a1;
                lWvfFeZUE[0x37][0x90] = 0x1a0;
                lWvfFeZUE[0x49][0x7d] = 0x19f;
                lWvfFeZUE[0x34][0x9a] = 0x19e;
                lWvfFeZUE[70][0xb2] = 0x19d;
                lWvfFeZUE[0x4f][0x94] = 0x19c;
                lWvfFeZUE[0x3f][0x8f] = 0x19b;
                lWvfFeZUE[50][140] = 410;
                lWvfFeZUE[0x2f][0x91] = 0x199;
                lWvfFeZUE[0x30][0x7b] = 0x198;
                lWvfFeZUE[0x38][0x6b] = 0x197;
                lWvfFeZUE[0x54][0x53] = 0x196;
                lWvfFeZUE[0x3b][0x70] = 0x195;
                lWvfFeZUE[0x7c][0x48] = 0x194;
                lWvfFeZUE[0x4f][0x63] = 0x193;
                lWvfFeZUE[3][0x25] = 0x192;
                lWvfFeZUE[0x72][0x37] = 0x191;
                lWvfFeZUE[0x55][0x98] = 400;
                lWvfFeZUE[60][0x2f] = 0x18f;
                lWvfFeZUE[0x41][0x60] = 0x18e;
                lWvfFeZUE[0x4a][110] = 0x18d;
                lWvfFeZUE[0x56][0xb6] = 0x18c;
                lWvfFeZUE[50][0x63] = 0x18b;
                lWvfFeZUE[0x43][0xba] = 0x18a;
                lWvfFeZUE[0x51][0x4a] = 0x189;
                lWvfFeZUE[80][0x25] = 0x188;
                lWvfFeZUE[0x15][60] = 0x187;
                lWvfFeZUE[110][12] = 390;
                lWvfFeZUE[60][0xa2] = 0x185;
                lWvfFeZUE[0x1d][0x73] = 0x184;
                lWvfFeZUE[0x53][130] = 0x183;
                lWvfFeZUE[0x34][0x88] = 0x182;
                lWvfFeZUE[0x3f][0x72] = 0x181;
                lWvfFeZUE[0x31][0x7f] = 0x180;
                lWvfFeZUE[0x53][0x6d] = 0x17f;
                lWvfFeZUE[0x42][0x80] = 0x17e;
                lWvfFeZUE[0x4e][0x88] = 0x17d;
                lWvfFeZUE[0x51][180] = 380;
                lWvfFeZUE[0x4c][0x68] = 0x17b;
                lWvfFeZUE[0x38][0x9c] = 0x17a;
                lWvfFeZUE[0x3d][0x17] = 0x179;
                lWvfFeZUE[4][30] = 0x178;
                lWvfFeZUE[0x45][0x9a] = 0x177;
                lWvfFeZUE[100][0x25] = 0x176;
                lWvfFeZUE[0x36][0xb1] = 0x175;
                lWvfFeZUE[0x17][0x77] = 0x174;
                lWvfFeZUE[0x47][0xab] = 0x173;
                lWvfFeZUE[0x54][0x92] = 370;
                lWvfFeZUE[20][0xb8] = 0x171;
                lWvfFeZUE[0x56][0x4c] = 0x170;
                lWvfFeZUE[0x4a][0x84] = 0x16f;
                lWvfFeZUE[0x2f][0x61] = 0x16e;
                lWvfFeZUE[0x52][0x89] = 0x16d;
                lWvfFeZUE[0x5e][0x38] = 0x16c;
                lWvfFeZUE[0x5c][30] = 0x16b;
                lWvfFeZUE[0x13][0x75] = 0x16a;
                lWvfFeZUE[0x30][0xad] = 0x169;
                lWvfFeZUE[2][0x88] = 360;
                lWvfFeZUE[7][0xb6] = 0x167;
                lWvfFeZUE[0x4a][0xbc] = 0x166;
                lWvfFeZUE[14][0x84] = 0x165;
                lWvfFeZUE[0x3e][0xac] = 0x164;
                lWvfFeZUE[0x19][0x27] = 0x163;
                lWvfFeZUE[0x55][0x81] = 0x162;
                lWvfFeZUE[0x40][0x62] = 0x161;
                lWvfFeZUE[0x43][0x7f] = 0x160;
                lWvfFeZUE[0x48][0xa7] = 0x15f;
                lWvfFeZUE[0x39][0x8f] = 350;
                lWvfFeZUE[0x4c][0xbb] = 0x15d;
                lWvfFeZUE[0x53][0xb5] = 0x15c;
                lWvfFeZUE[0x54][10] = 0x15b;
                lWvfFeZUE[0x37][0xa6] = 0x15a;
                lWvfFeZUE[0x37][0xbc] = 0x159;
                lWvfFeZUE[13][0x97] = 0x158;
                lWvfFeZUE[0x3e][0x7c] = 0x157;
                lWvfFeZUE[0x35][0x88] = 0x156;
                lWvfFeZUE[0x6a][0x39] = 0x155;
                lWvfFeZUE[0x2f][0xa6] = 340;
                lWvfFeZUE[0x6d][30] = 0x153;
                lWvfFeZUE[0x4e][0x72] = 0x152;
                lWvfFeZUE[0x53][0x13] = 0x151;
                lWvfFeZUE[0x38][0xa2] = 0x150;
                lWvfFeZUE[60][0xb1] = 0x14f;
                lWvfFeZUE[0x58][9] = 0x14e;
                lWvfFeZUE[0x4a][0xa3] = 0x14d;
                lWvfFeZUE[0x34][0x9c] = 0x14c;
                lWvfFeZUE[0x47][180] = 0x14b;
                lWvfFeZUE[60][0x39] = 330;
                lWvfFeZUE[0x48][0xad] = 0x149;
                lWvfFeZUE[0x52][0x5b] = 0x148;
                lWvfFeZUE[0x33][0xba] = 0x147;
                lWvfFeZUE[0x4b][0x56] = 0x146;
                lWvfFeZUE[0x4b][0x4e] = 0x145;
                lWvfFeZUE[0x4c][170] = 0x144;
                lWvfFeZUE[60][0x93] = 0x143;
                lWvfFeZUE[0x52][0x4b] = 0x142;
                lWvfFeZUE[80][0x94] = 0x141;
                lWvfFeZUE[0x56][150] = 320;
                lWvfFeZUE[13][0x5f] = 0x13f;
                lWvfFeZUE[0][11] = 0x13e;
                lWvfFeZUE[0x54][190] = 0x13d;
                lWvfFeZUE[0x4c][0xa6] = 0x13c;
                lWvfFeZUE[14][0x48] = 0x13b;
                lWvfFeZUE[0x43][0x90] = 0x13a;
                lWvfFeZUE[0x54][0x2c] = 0x139;
                lWvfFeZUE[0x48][0x7d] = 0x138;
                lWvfFeZUE[0x42][0x7f] = 0x137;
                lWvfFeZUE[60][0x19] = 310;
                lWvfFeZUE[70][0x92] = 0x135;
                lWvfFeZUE[0x4f][0x87] = 0x134;
                lWvfFeZUE[0x36][0x87] = 0x133;
                lWvfFeZUE[60][0x68] = 0x132;
                lWvfFeZUE[0x37][0x84] = 0x131;
                lWvfFeZUE[0x5e][2] = 0x130;
                lWvfFeZUE[0x36][0x85] = 0x12f;
                lWvfFeZUE[0x38][190] = 0x12e;
                lWvfFeZUE[0x3a][0xae] = 0x12d;
                lWvfFeZUE[80][0x90] = 300;
                lWvfFeZUE[0x55][0x71] = 0x12b;
            }
            if (OBHMaLtRG[0] == null)
            {
                for (num = 0; num < 0x5e; num++)
                {
                    OBHMaLtRG[num] = new int[0x9e];
                }
                OBHMaLtRG[11][15] = 0x257;
                OBHMaLtRG[3][0x42] = 0x256;
                OBHMaLtRG[6][0x79] = 0x255;
                OBHMaLtRG[3][0] = 0x254;
                OBHMaLtRG[5][0x52] = 0x253;
                OBHMaLtRG[3][0x2a] = 0x252;
                OBHMaLtRG[5][0x22] = 0x251;
                OBHMaLtRG[3][8] = 0x250;
                OBHMaLtRG[3][6] = 0x24f;
                OBHMaLtRG[3][0x43] = 590;
                OBHMaLtRG[7][0x8b] = 0x24d;
                OBHMaLtRG[0x17][0x89] = 0x24c;
                OBHMaLtRG[12][0x2e] = 0x24b;
                OBHMaLtRG[4][8] = 0x24a;
                OBHMaLtRG[4][0x29] = 0x249;
                OBHMaLtRG[0x12][0x2f] = 0x248;
                OBHMaLtRG[12][0x72] = 0x247;
                OBHMaLtRG[6][1] = 0x246;
                OBHMaLtRG[0x16][60] = 0x245;
                OBHMaLtRG[5][0x2e] = 580;
                OBHMaLtRG[11][0x4f] = 0x243;
                OBHMaLtRG[3][0x17] = 0x242;
                OBHMaLtRG[7][0x72] = 0x241;
                OBHMaLtRG[0x1d][0x66] = 0x240;
                OBHMaLtRG[0x13][14] = 0x23f;
                OBHMaLtRG[4][0x85] = 0x23e;
                OBHMaLtRG[3][0x1d] = 0x23d;
                OBHMaLtRG[4][0x6d] = 0x23c;
                OBHMaLtRG[14][0x7f] = 0x23b;
                OBHMaLtRG[5][0x30] = 570;
                OBHMaLtRG[13][0x68] = 0x239;
                OBHMaLtRG[3][0x84] = 0x238;
                OBHMaLtRG[0x1a][0x40] = 0x237;
                OBHMaLtRG[7][0x13] = 0x236;
                OBHMaLtRG[4][12] = 0x235;
                OBHMaLtRG[11][0x7c] = 0x234;
                OBHMaLtRG[7][0x59] = 0x233;
                OBHMaLtRG[15][0x7c] = 0x232;
                OBHMaLtRG[4][0x6c] = 0x231;
                OBHMaLtRG[0x13][0x42] = 560;
                OBHMaLtRG[3][0x15] = 0x22f;
                OBHMaLtRG[0x18][12] = 0x22e;
                OBHMaLtRG[0x1c][0x6f] = 0x22d;
                OBHMaLtRG[12][0x6b] = 0x22c;
                OBHMaLtRG[3][0x70] = 0x22b;
                OBHMaLtRG[8][0x71] = 0x22a;
                OBHMaLtRG[5][40] = 0x229;
                OBHMaLtRG[0x1a][0x91] = 0x228;
                OBHMaLtRG[3][0x30] = 0x227;
                OBHMaLtRG[3][70] = 550;
                OBHMaLtRG[0x16][0x11] = 0x225;
                OBHMaLtRG[0x10][0x2f] = 0x224;
                OBHMaLtRG[3][0x35] = 0x223;
                OBHMaLtRG[4][0x18] = 0x222;
                OBHMaLtRG[0x20][120] = 0x221;
                OBHMaLtRG[0x18][0x31] = 0x220;
                OBHMaLtRG[0x18][0x8e] = 0x21f;
                OBHMaLtRG[0x12][0x42] = 0x21e;
                OBHMaLtRG[0x1d][150] = 0x21d;
                OBHMaLtRG[5][0x7a] = 540;
                OBHMaLtRG[5][0x72] = 0x21b;
                OBHMaLtRG[3][0x2c] = 0x21a;
                OBHMaLtRG[10][0x80] = 0x219;
                OBHMaLtRG[15][20] = 0x218;
                OBHMaLtRG[13][0x21] = 0x217;
                OBHMaLtRG[14][0x57] = 0x216;
                OBHMaLtRG[3][0x7e] = 0x215;
                OBHMaLtRG[4][0x35] = 0x214;
                OBHMaLtRG[4][40] = 0x213;
                OBHMaLtRG[9][0x5d] = 530;
                OBHMaLtRG[15][0x89] = 0x211;
                OBHMaLtRG[10][0x7b] = 0x210;
                OBHMaLtRG[4][0x38] = 0x20f;
                OBHMaLtRG[5][0x47] = 0x20e;
                OBHMaLtRG[10][8] = 0x20d;
                OBHMaLtRG[5][0x10] = 0x20c;
                OBHMaLtRG[5][0x92] = 0x20b;
                OBHMaLtRG[0x12][0x58] = 0x20a;
                OBHMaLtRG[0x18][4] = 0x209;
                OBHMaLtRG[20][0x2f] = 520;
                OBHMaLtRG[5][0x21] = 0x207;
                OBHMaLtRG[9][0x2b] = 0x206;
                OBHMaLtRG[20][12] = 0x205;
                OBHMaLtRG[20][13] = 0x204;
                OBHMaLtRG[5][0x9c] = 0x203;
                OBHMaLtRG[0x16][140] = 0x202;
                OBHMaLtRG[8][0x92] = 0x201;
                OBHMaLtRG[0x15][0x7b] = 0x200;
                OBHMaLtRG[4][90] = 0x1ff;
                OBHMaLtRG[5][0x3e] = 510;
                OBHMaLtRG[0x11][0x3b] = 0x1fd;
                OBHMaLtRG[10][0x25] = 0x1fc;
                OBHMaLtRG[0x12][0x6b] = 0x1fb;
                OBHMaLtRG[14][0x35] = 0x1fa;
                OBHMaLtRG[0x16][0x33] = 0x1f9;
                OBHMaLtRG[8][13] = 0x1f8;
                OBHMaLtRG[5][0x1d] = 0x1f7;
                OBHMaLtRG[9][7] = 0x1f6;
                OBHMaLtRG[0x16][14] = 0x1f5;
                OBHMaLtRG[8][0x37] = 500;
                OBHMaLtRG[0x21][9] = 0x1f3;
                OBHMaLtRG[0x10][0x40] = 0x1f2;
                OBHMaLtRG[7][0x83] = 0x1f1;
                OBHMaLtRG[0x22][4] = 0x1f0;
                OBHMaLtRG[7][0x65] = 0x1ef;
                OBHMaLtRG[11][0x8b] = 0x1ee;
                OBHMaLtRG[3][0x87] = 0x1ed;
                OBHMaLtRG[7][0x66] = 0x1ec;
                OBHMaLtRG[0x11][13] = 0x1eb;
                OBHMaLtRG[3][20] = 490;
                OBHMaLtRG[0x1b][0x6a] = 0x1e9;
                OBHMaLtRG[5][0x58] = 0x1e8;
                OBHMaLtRG[6][0x21] = 0x1e7;
                OBHMaLtRG[5][0x8b] = 0x1e6;
                OBHMaLtRG[6][0] = 0x1e5;
                OBHMaLtRG[0x11][0x3a] = 0x1e4;
                OBHMaLtRG[5][0x85] = 0x1e3;
                OBHMaLtRG[9][0x6b] = 0x1e2;
                OBHMaLtRG[0x17][0x27] = 0x1e1;
                OBHMaLtRG[5][0x17] = 480;
                OBHMaLtRG[3][0x4f] = 0x1df;
                OBHMaLtRG[0x20][0x61] = 0x1de;
                OBHMaLtRG[3][0x88] = 0x1dd;
                OBHMaLtRG[4][0x5e] = 0x1dc;
                OBHMaLtRG[0x15][0x3d] = 0x1db;
                OBHMaLtRG[0x17][0x7b] = 0x1da;
                OBHMaLtRG[0x1a][0x10] = 0x1d9;
                OBHMaLtRG[0x18][0x89] = 0x1d8;
                OBHMaLtRG[0x16][0x12] = 0x1d7;
                OBHMaLtRG[5][1] = 470;
                OBHMaLtRG[20][0x77] = 0x1d5;
                OBHMaLtRG[3][7] = 0x1d4;
                OBHMaLtRG[10][0x4f] = 0x1d3;
                OBHMaLtRG[15][0x69] = 0x1d2;
                OBHMaLtRG[3][0x90] = 0x1d1;
                OBHMaLtRG[12][80] = 0x1d0;
                OBHMaLtRG[15][0x49] = 0x1cf;
                OBHMaLtRG[3][0x13] = 0x1ce;
                OBHMaLtRG[8][0x6d] = 0x1cd;
                OBHMaLtRG[3][15] = 460;
                OBHMaLtRG[0x1f][0x52] = 0x1cb;
                OBHMaLtRG[3][0x2b] = 0x1ca;
                OBHMaLtRG[0x19][0x77] = 0x1c9;
                OBHMaLtRG[0x10][0x6f] = 0x1c8;
                OBHMaLtRG[7][0x4d] = 0x1c7;
                OBHMaLtRG[3][0x5f] = 0x1c6;
                OBHMaLtRG[0x18][0x52] = 0x1c5;
                OBHMaLtRG[7][0x34] = 0x1c4;
                OBHMaLtRG[9][0x97] = 0x1c3;
                OBHMaLtRG[3][0x81] = 450;
                OBHMaLtRG[5][0x57] = 0x1c1;
                OBHMaLtRG[3][0x37] = 0x1c0;
                OBHMaLtRG[8][0x99] = 0x1bf;
                OBHMaLtRG[4][0x53] = 0x1be;
                OBHMaLtRG[3][0x72] = 0x1bd;
                OBHMaLtRG[0x17][0x93] = 0x1bc;
                OBHMaLtRG[15][0x1f] = 0x1bb;
                OBHMaLtRG[3][0x36] = 0x1ba;
                OBHMaLtRG[11][0x7a] = 0x1b9;
                OBHMaLtRG[4][4] = 440;
                OBHMaLtRG[0x22][0x95] = 0x1b7;
                OBHMaLtRG[3][0x11] = 0x1b6;
                OBHMaLtRG[0x15][0x40] = 0x1b5;
                OBHMaLtRG[0x1a][0x90] = 0x1b4;
                OBHMaLtRG[4][0x3e] = 0x1b3;
                OBHMaLtRG[8][15] = 0x1b2;
                OBHMaLtRG[0x23][80] = 0x1b1;
                OBHMaLtRG[7][110] = 0x1b0;
                OBHMaLtRG[0x17][0x72] = 0x1af;
                OBHMaLtRG[3][0x6c] = 430;
                OBHMaLtRG[3][0x3e] = 0x1ad;
                OBHMaLtRG[0x15][0x29] = 0x1ac;
                OBHMaLtRG[15][0x63] = 0x1ab;
                OBHMaLtRG[5][0x2f] = 0x1aa;
                OBHMaLtRG[4][0x60] = 0x1a9;
                OBHMaLtRG[20][0x7a] = 0x1a8;
                OBHMaLtRG[5][0x15] = 0x1a7;
                OBHMaLtRG[4][0x9d] = 0x1a6;
                OBHMaLtRG[0x10][14] = 0x1a5;
                OBHMaLtRG[3][0x75] = 420;
                OBHMaLtRG[7][0x81] = 0x1a3;
                OBHMaLtRG[4][0x1b] = 0x1a2;
                OBHMaLtRG[5][30] = 0x1a1;
                OBHMaLtRG[0x16][0x10] = 0x1a0;
                OBHMaLtRG[5][0x40] = 0x19f;
                OBHMaLtRG[0x11][0x63] = 0x19e;
                OBHMaLtRG[0x11][0x39] = 0x19d;
                OBHMaLtRG[8][0x69] = 0x19c;
                OBHMaLtRG[5][0x70] = 0x19b;
                OBHMaLtRG[20][0x3b] = 410;
                OBHMaLtRG[6][0x81] = 0x199;
                OBHMaLtRG[0x12][0x11] = 0x198;
                OBHMaLtRG[3][0x5c] = 0x197;
                OBHMaLtRG[0x1c][0x76] = 0x196;
                OBHMaLtRG[3][0x6d] = 0x195;
                OBHMaLtRG[0x1f][0x33] = 0x194;
                OBHMaLtRG[13][0x74] = 0x193;
                OBHMaLtRG[6][15] = 0x192;
                OBHMaLtRG[0x24][0x88] = 0x191;
                OBHMaLtRG[12][0x4a] = 400;
                OBHMaLtRG[20][0x58] = 0x18f;
                OBHMaLtRG[0x24][0x44] = 0x18e;
                OBHMaLtRG[3][0x93] = 0x18d;
                OBHMaLtRG[15][0x54] = 0x18c;
                OBHMaLtRG[0x10][0x20] = 0x18b;
                OBHMaLtRG[0x10][0x3a] = 0x18a;
                OBHMaLtRG[7][0x42] = 0x189;
                OBHMaLtRG[0x17][0x6b] = 0x188;
                OBHMaLtRG[9][6] = 0x187;
                OBHMaLtRG[12][0x56] = 390;
                OBHMaLtRG[0x17][0x70] = 0x185;
                OBHMaLtRG[0x25][0x17] = 0x184;
                OBHMaLtRG[3][0x8a] = 0x183;
                OBHMaLtRG[20][0x44] = 0x182;
                OBHMaLtRG[15][0x74] = 0x181;
                OBHMaLtRG[0x12][0x40] = 0x180;
                OBHMaLtRG[12][0x8b] = 0x17f;
                OBHMaLtRG[11][0x9b] = 0x17e;
                OBHMaLtRG[4][0x9c] = 0x17d;
                OBHMaLtRG[12][0x54] = 380;
                OBHMaLtRG[0x12][0x31] = 0x17b;
                OBHMaLtRG[0x19][0x7d] = 0x17a;
                OBHMaLtRG[0x19][0x93] = 0x179;
                OBHMaLtRG[15][110] = 0x178;
                OBHMaLtRG[0x13][0x60] = 0x177;
                OBHMaLtRG[30][0x98] = 0x176;
                OBHMaLtRG[6][0x1f] = 0x175;
                OBHMaLtRG[0x1b][0x75] = 0x174;
                OBHMaLtRG[3][10] = 0x173;
                OBHMaLtRG[6][0x83] = 370;
                OBHMaLtRG[13][0x70] = 0x171;
                OBHMaLtRG[0x24][0x9c] = 0x170;
                OBHMaLtRG[4][60] = 0x16f;
                OBHMaLtRG[15][0x79] = 0x16e;
                OBHMaLtRG[4][0x70] = 0x16d;
                OBHMaLtRG[30][0x8e] = 0x16c;
                OBHMaLtRG[0x17][0x9a] = 0x16b;
                OBHMaLtRG[0x1b][0x65] = 0x16a;
                OBHMaLtRG[9][140] = 0x169;
                OBHMaLtRG[3][0x59] = 360;
                OBHMaLtRG[0x12][0x94] = 0x167;
                OBHMaLtRG[4][0x45] = 0x166;
                OBHMaLtRG[0x10][0x31] = 0x165;
                OBHMaLtRG[6][0x75] = 0x164;
                OBHMaLtRG[0x24][0x37] = 0x163;
                OBHMaLtRG[5][0x7b] = 0x162;
                OBHMaLtRG[4][0x7e] = 0x161;
                OBHMaLtRG[4][0x77] = 0x160;
                OBHMaLtRG[9][0x5f] = 0x15f;
                OBHMaLtRG[5][0x18] = 350;
                OBHMaLtRG[0x10][0x85] = 0x15d;
                OBHMaLtRG[10][0x86] = 0x15c;
                OBHMaLtRG[0x1a][0x3b] = 0x15b;
                OBHMaLtRG[6][0x29] = 0x15a;
                OBHMaLtRG[6][0x92] = 0x159;
                OBHMaLtRG[0x13][0x18] = 0x158;
                OBHMaLtRG[5][0x71] = 0x157;
                OBHMaLtRG[10][0x76] = 0x156;
                OBHMaLtRG[0x22][0x97] = 0x155;
                OBHMaLtRG[9][0x48] = 340;
                OBHMaLtRG[0x1f][0x19] = 0x153;
                OBHMaLtRG[0x12][0x7e] = 0x152;
                OBHMaLtRG[0x12][0x1c] = 0x151;
                OBHMaLtRG[4][0x99] = 0x150;
                OBHMaLtRG[3][0x54] = 0x14f;
                OBHMaLtRG[0x15][0x12] = 0x14e;
                OBHMaLtRG[0x19][0x81] = 0x14d;
                OBHMaLtRG[6][0x6b] = 0x14c;
                OBHMaLtRG[12][0x19] = 0x14b;
                OBHMaLtRG[0x11][0x6d] = 330;
                OBHMaLtRG[7][0x4c] = 0x149;
                OBHMaLtRG[15][15] = 0x148;
                OBHMaLtRG[4][14] = 0x147;
                OBHMaLtRG[0x17][0x58] = 0x146;
                OBHMaLtRG[0x12][2] = 0x145;
                OBHMaLtRG[6][0x58] = 0x144;
                OBHMaLtRG[0x10][0x54] = 0x143;
                OBHMaLtRG[12][0x30] = 0x142;
                OBHMaLtRG[7][0x44] = 0x141;
                OBHMaLtRG[5][50] = 320;
                OBHMaLtRG[13][0x36] = 0x13f;
                OBHMaLtRG[7][0x62] = 0x13e;
                OBHMaLtRG[11][6] = 0x13d;
                OBHMaLtRG[9][80] = 0x13c;
                OBHMaLtRG[0x10][0x29] = 0x13b;
                OBHMaLtRG[7][0x2b] = 0x13a;
                OBHMaLtRG[0x1c][0x75] = 0x139;
                OBHMaLtRG[3][0x33] = 0x138;
                OBHMaLtRG[7][3] = 0x137;
                OBHMaLtRG[20][0x51] = 310;
                OBHMaLtRG[4][2] = 0x135;
                OBHMaLtRG[11][0x10] = 0x134;
                OBHMaLtRG[10][4] = 0x133;
                OBHMaLtRG[10][0x77] = 0x132;
                OBHMaLtRG[6][0x8e] = 0x131;
                OBHMaLtRG[0x12][0x33] = 0x130;
                OBHMaLtRG[8][0x90] = 0x12f;
                OBHMaLtRG[10][0x41] = 0x12e;
                OBHMaLtRG[11][0x40] = 0x12d;
                OBHMaLtRG[11][130] = 300;
                OBHMaLtRG[9][0x5c] = 0x12b;
                OBHMaLtRG[0x12][0x1d] = 0x12a;
                OBHMaLtRG[0x12][0x4e] = 0x129;
                OBHMaLtRG[0x12][0x97] = 0x128;
                OBHMaLtRG[0x21][0x7f] = 0x127;
                OBHMaLtRG[0x23][0x71] = 0x126;
                OBHMaLtRG[10][0x9b] = 0x125;
                OBHMaLtRG[3][0x4c] = 0x124;
                OBHMaLtRG[0x24][0x7b] = 0x123;
                OBHMaLtRG[13][0x8f] = 290;
                OBHMaLtRG[5][0x87] = 0x121;
                OBHMaLtRG[0x17][0x74] = 0x120;
                OBHMaLtRG[6][0x65] = 0x11f;
                OBHMaLtRG[14][0x4a] = 0x11e;
                OBHMaLtRG[7][0x99] = 0x11d;
                OBHMaLtRG[3][0x65] = 0x11c;
                OBHMaLtRG[9][0x4a] = 0x11b;
                OBHMaLtRG[3][0x9c] = 0x11a;
                OBHMaLtRG[4][0x93] = 0x119;
                OBHMaLtRG[9][12] = 280;
                OBHMaLtRG[0x12][0x85] = 0x117;
                OBHMaLtRG[4][0] = 0x116;
                OBHMaLtRG[7][0x9b] = 0x115;
                OBHMaLtRG[9][0x90] = 0x114;
                OBHMaLtRG[0x17][0x31] = 0x113;
                OBHMaLtRG[5][0x59] = 0x112;
                OBHMaLtRG[10][11] = 0x111;
                OBHMaLtRG[3][110] = 0x110;
                OBHMaLtRG[3][40] = 0x10f;
                OBHMaLtRG[0x1d][0x73] = 270;
                OBHMaLtRG[9][100] = 0x10d;
                OBHMaLtRG[0x15][0x43] = 0x10c;
                OBHMaLtRG[0x17][0x91] = 0x10b;
                OBHMaLtRG[10][0x2f] = 0x10a;
                OBHMaLtRG[4][0x1f] = 0x109;
                OBHMaLtRG[4][0x51] = 0x108;
                OBHMaLtRG[0x16][0x3e] = 0x107;
                OBHMaLtRG[4][0x1c] = 0x106;
                OBHMaLtRG[0x1b][0x27] = 0x105;
                OBHMaLtRG[0x1b][0x36] = 260;
                OBHMaLtRG[0x20][0x2e] = 0x103;
                OBHMaLtRG[4][0x4c] = 0x102;
                OBHMaLtRG[0x1a][15] = 0x101;
                OBHMaLtRG[12][0x9a] = 0x100;
                OBHMaLtRG[9][150] = 0xff;
                OBHMaLtRG[15][0x11] = 0xfe;
                OBHMaLtRG[5][0x81] = 0xfd;
                OBHMaLtRG[10][40] = 0xfc;
                OBHMaLtRG[13][0x25] = 0xfb;
                OBHMaLtRG[0x1f][0x68] = 250;
                OBHMaLtRG[3][0x98] = 0xf9;
                OBHMaLtRG[5][0x16] = 0xf8;
                OBHMaLtRG[8][0x30] = 0xf7;
                OBHMaLtRG[4][0x4a] = 0xf6;
                OBHMaLtRG[6][0x11] = 0xf5;
                OBHMaLtRG[30][0x52] = 0xf4;
                OBHMaLtRG[4][0x74] = 0xf3;
                OBHMaLtRG[0x10][0x2a] = 0xf2;
                OBHMaLtRG[5][0x37] = 0xf1;
                OBHMaLtRG[4][0x40] = 240;
                OBHMaLtRG[14][0x13] = 0xef;
                OBHMaLtRG[0x23][0x52] = 0xee;
                OBHMaLtRG[30][0x8b] = 0xed;
                OBHMaLtRG[0x1a][0x98] = 0xec;
                OBHMaLtRG[0x20][0x20] = 0xeb;
                OBHMaLtRG[0x15][0x66] = 0xea;
                OBHMaLtRG[10][0x83] = 0xe9;
                OBHMaLtRG[9][0x80] = 0xe8;
                OBHMaLtRG[3][0x57] = 0xe7;
                OBHMaLtRG[4][0x33] = 230;
                OBHMaLtRG[10][15] = 0xe5;
                OBHMaLtRG[4][150] = 0xe4;
                OBHMaLtRG[7][4] = 0xe3;
                OBHMaLtRG[7][0x33] = 0xe2;
                OBHMaLtRG[7][0x9d] = 0xe1;
                OBHMaLtRG[4][0x92] = 0xe0;
                OBHMaLtRG[4][0x5b] = 0xdf;
                OBHMaLtRG[7][13] = 0xde;
                OBHMaLtRG[0x11][0x74] = 0xdd;
                OBHMaLtRG[0x17][0x15] = 220;
                OBHMaLtRG[5][0x6a] = 0xdb;
                OBHMaLtRG[14][100] = 0xda;
                OBHMaLtRG[10][0x98] = 0xd9;
                OBHMaLtRG[14][0x59] = 0xd8;
                OBHMaLtRG[6][0x8a] = 0xd7;
                OBHMaLtRG[12][0x9d] = 0xd6;
                OBHMaLtRG[10][0x66] = 0xd5;
                OBHMaLtRG[0x13][0x5e] = 0xd4;
                OBHMaLtRG[7][0x4a] = 0xd3;
                OBHMaLtRG[0x12][0x80] = 210;
                OBHMaLtRG[0x1b][0x6f] = 0xd1;
                OBHMaLtRG[11][0x39] = 0xd0;
                OBHMaLtRG[3][0x83] = 0xcf;
                OBHMaLtRG[30][0x17] = 0xce;
                OBHMaLtRG[30][0x7e] = 0xcd;
                OBHMaLtRG[4][0x24] = 0xcc;
                OBHMaLtRG[0x1a][0x7c] = 0xcb;
                OBHMaLtRG[4][0x13] = 0xca;
                OBHMaLtRG[9][0x98] = 0xc9;
            }
            if (jSdinGKD3[0] == null)
            {
                for (num = 0; num < 0x5e; num++)
                {
                    jSdinGKD3[num] = new int[0x5e];
                }
                jSdinGKD3[0x23][0x41] = 0x256;
                jSdinGKD3[0x29][0x1b] = 0x255;
                jSdinGKD3[0x23][0] = 0x254;
                jSdinGKD3[0x27][0x13] = 0x253;
                jSdinGKD3[0x23][0x2a] = 0x252;
                jSdinGKD3[0x26][0x42] = 0x251;
                jSdinGKD3[0x23][8] = 0x250;
                jSdinGKD3[0x23][6] = 0x24f;
                jSdinGKD3[0x23][0x42] = 590;
                jSdinGKD3[0x2b][14] = 0x24d;
                jSdinGKD3[0x45][80] = 0x24c;
                jSdinGKD3[50][0x30] = 0x24b;
                jSdinGKD3[0x24][0x47] = 0x24a;
                jSdinGKD3[0x25][10] = 0x249;
                jSdinGKD3[60][0x34] = 0x248;
                jSdinGKD3[0x33][0x15] = 0x247;
                jSdinGKD3[40][2] = 0x246;
                jSdinGKD3[0x43][0x23] = 0x245;
                jSdinGKD3[0x26][0x4e] = 580;
                jSdinGKD3[0x31][0x12] = 0x243;
                jSdinGKD3[0x23][0x17] = 0x242;
                jSdinGKD3[0x2a][0x53] = 0x241;
                jSdinGKD3[0x4f][0x2f] = 0x240;
                jSdinGKD3[0x3d][0x52] = 0x23f;
                jSdinGKD3[0x26][7] = 0x23e;
                jSdinGKD3[0x23][0x1d] = 0x23d;
                jSdinGKD3[0x25][0x4d] = 0x23c;
                jSdinGKD3[0x36][0x43] = 0x23b;
                jSdinGKD3[0x26][80] = 570;
                jSdinGKD3[0x34][0x4a] = 0x239;
                jSdinGKD3[0x24][0x25] = 0x238;
                jSdinGKD3[0x4a][8] = 0x237;
                jSdinGKD3[0x29][0x53] = 0x236;
                jSdinGKD3[0x24][0x4b] = 0x235;
                jSdinGKD3[0x31][0x3f] = 0x234;
                jSdinGKD3[0x2a][0x3a] = 0x233;
                jSdinGKD3[0x38][0x21] = 0x232;
                jSdinGKD3[0x25][0x4c] = 0x231;
                jSdinGKD3[0x3e][0x27] = 560;
                jSdinGKD3[0x23][0x15] = 0x22f;
                jSdinGKD3[70][0x13] = 0x22e;
                jSdinGKD3[0x4d][0x58] = 0x22d;
                jSdinGKD3[0x33][14] = 0x22c;
                jSdinGKD3[0x24][0x11] = 0x22b;
                jSdinGKD3[0x2c][0x33] = 0x22a;
                jSdinGKD3[0x26][0x48] = 0x229;
                jSdinGKD3[0x4a][90] = 0x228;
                jSdinGKD3[0x23][0x30] = 0x227;
                jSdinGKD3[0x23][0x45] = 550;
                jSdinGKD3[0x42][0x56] = 0x225;
                jSdinGKD3[0x39][20] = 0x224;
                jSdinGKD3[0x23][0x35] = 0x223;
                jSdinGKD3[0x24][0x57] = 0x222;
                jSdinGKD3[0x54][0x43] = 0x221;
                jSdinGKD3[70][0x38] = 0x220;
                jSdinGKD3[0x47][0x36] = 0x21f;
                jSdinGKD3[60][70] = 0x21e;
                jSdinGKD3[80][1] = 0x21d;
                jSdinGKD3[0x27][0x3b] = 540;
                jSdinGKD3[0x27][0x33] = 0x21b;
                jSdinGKD3[0x23][0x2c] = 0x21a;
                jSdinGKD3[0x30][4] = 0x219;
                jSdinGKD3[0x37][0x18] = 0x218;
                jSdinGKD3[0x34][4] = 0x217;
                jSdinGKD3[0x36][0x1a] = 0x216;
                jSdinGKD3[0x24][0x1f] = 0x215;
                jSdinGKD3[0x25][0x16] = 0x214;
                jSdinGKD3[0x25][9] = 0x213;
                jSdinGKD3[0x2e][0] = 530;
                jSdinGKD3[0x38][0x2e] = 0x211;
                jSdinGKD3[0x2f][0x5d] = 0x210;
                jSdinGKD3[0x25][0x19] = 0x20f;
                jSdinGKD3[0x27][8] = 0x20e;
                jSdinGKD3[0x2e][0x49] = 0x20d;
                jSdinGKD3[0x26][0x30] = 0x20c;
                jSdinGKD3[0x27][0x53] = 0x20b;
                jSdinGKD3[60][0x5c] = 0x20a;
                jSdinGKD3[70][11] = 0x209;
                jSdinGKD3[0x3f][0x54] = 520;
                jSdinGKD3[0x26][0x41] = 0x207;
                jSdinGKD3[0x2d][0x2d] = 0x206;
                jSdinGKD3[0x3f][0x31] = 0x205;
                jSdinGKD3[0x3f][50] = 0x204;
                jSdinGKD3[0x27][0x5d] = 0x203;
                jSdinGKD3[0x44][20] = 0x202;
                jSdinGKD3[0x2c][0x54] = 0x201;
                jSdinGKD3[0x42][0x22] = 0x200;
                jSdinGKD3[0x25][0x3a] = 0x1ff;
                jSdinGKD3[0x27][0] = 510;
                jSdinGKD3[0x3b][1] = 0x1fd;
                jSdinGKD3[0x2f][8] = 0x1fc;
                jSdinGKD3[0x3d][0x11] = 0x1fb;
                jSdinGKD3[0x35][0x57] = 0x1fa;
                jSdinGKD3[0x43][0x1a] = 0x1f9;
                jSdinGKD3[0x2b][0x2e] = 0x1f8;
                jSdinGKD3[0x26][0x3d] = 0x1f7;
                jSdinGKD3[0x2d][9] = 0x1f6;
                jSdinGKD3[0x42][0x53] = 0x1f5;
                jSdinGKD3[0x2b][0x58] = 500;
                jSdinGKD3[0x55][20] = 0x1f3;
                jSdinGKD3[0x39][0x24] = 0x1f2;
                jSdinGKD3[0x2b][6] = 0x1f1;
                jSdinGKD3[0x56][0x4d] = 0x1f0;
                jSdinGKD3[0x2a][70] = 0x1ef;
                jSdinGKD3[0x31][0x4e] = 0x1ee;
                jSdinGKD3[0x24][40] = 0x1ed;
                jSdinGKD3[0x2a][0x47] = 0x1ec;
                jSdinGKD3[0x3a][0x31] = 0x1eb;
                jSdinGKD3[0x23][20] = 490;
                jSdinGKD3[0x4c][20] = 0x1e9;
                jSdinGKD3[0x27][0x19] = 0x1e8;
                jSdinGKD3[40][0x22] = 0x1e7;
                jSdinGKD3[0x27][0x4c] = 0x1e6;
                jSdinGKD3[40][1] = 0x1e5;
                jSdinGKD3[0x3b][0] = 0x1e4;
                jSdinGKD3[0x27][70] = 0x1e3;
                jSdinGKD3[0x2e][14] = 0x1e2;
                jSdinGKD3[0x44][0x4d] = 0x1e1;
                jSdinGKD3[0x26][0x37] = 480;
                jSdinGKD3[0x23][0x4e] = 0x1df;
                jSdinGKD3[0x54][0x2c] = 0x1de;
                jSdinGKD3[0x24][0x29] = 0x1dd;
                jSdinGKD3[0x25][0x3e] = 0x1dc;
                jSdinGKD3[0x41][0x43] = 0x1db;
                jSdinGKD3[0x45][0x42] = 0x1da;
                jSdinGKD3[0x49][0x37] = 0x1d9;
                jSdinGKD3[0x47][0x31] = 0x1d8;
                jSdinGKD3[0x42][0x57] = 0x1d7;
                jSdinGKD3[0x26][0x21] = 470;
                jSdinGKD3[0x40][0x3d] = 0x1d5;
                jSdinGKD3[0x23][7] = 0x1d4;
                jSdinGKD3[0x2f][0x31] = 0x1d3;
                jSdinGKD3[0x38][14] = 0x1d2;
                jSdinGKD3[0x24][0x31] = 0x1d1;
                jSdinGKD3[50][0x51] = 0x1d0;
                jSdinGKD3[0x37][0x4c] = 0x1cf;
                jSdinGKD3[0x23][0x13] = 0x1ce;
                jSdinGKD3[0x2c][0x2f] = 0x1cd;
                jSdinGKD3[0x23][15] = 460;
                jSdinGKD3[0x52][0x3b] = 0x1cb;
                jSdinGKD3[0x23][0x2b] = 0x1ca;
                jSdinGKD3[0x49][0] = 0x1c9;
                jSdinGKD3[0x39][0x53] = 0x1c8;
                jSdinGKD3[0x2a][0x2e] = 0x1c7;
                jSdinGKD3[0x24][0] = 0x1c6;
                jSdinGKD3[70][0x58] = 0x1c5;
                jSdinGKD3[0x2a][0x16] = 0x1c4;
                jSdinGKD3[0x2e][0x3a] = 0x1c3;
                jSdinGKD3[0x24][0x22] = 450;
                jSdinGKD3[0x27][0x18] = 0x1c1;
                jSdinGKD3[0x23][0x37] = 0x1c0;
                jSdinGKD3[0x2c][0x5b] = 0x1bf;
                jSdinGKD3[0x25][0x33] = 0x1be;
                jSdinGKD3[0x24][0x13] = 0x1bd;
                jSdinGKD3[0x45][90] = 0x1bc;
                jSdinGKD3[0x37][0x23] = 0x1bb;
                jSdinGKD3[0x23][0x36] = 0x1ba;
                jSdinGKD3[0x31][0x3d] = 0x1b9;
                jSdinGKD3[0x24][0x43] = 440;
                jSdinGKD3[0x58][0x22] = 0x1b7;
                jSdinGKD3[0x23][0x11] = 0x1b6;
                jSdinGKD3[0x41][0x45] = 0x1b5;
                jSdinGKD3[0x4a][0x59] = 0x1b4;
                jSdinGKD3[0x25][0x1f] = 0x1b3;
                jSdinGKD3[0x2b][0x30] = 0x1b2;
                jSdinGKD3[0x59][0x1b] = 0x1b1;
                jSdinGKD3[0x2a][0x4f] = 0x1b0;
                jSdinGKD3[0x45][0x39] = 0x1af;
                jSdinGKD3[0x24][13] = 430;
                jSdinGKD3[0x23][0x3e] = 0x1ad;
                jSdinGKD3[0x41][0x2f] = 0x1ac;
                jSdinGKD3[0x38][8] = 0x1ab;
                jSdinGKD3[0x26][0x4f] = 0x1aa;
                jSdinGKD3[0x25][0x40] = 0x1a9;
                jSdinGKD3[0x40][0x40] = 0x1a8;
                jSdinGKD3[0x26][0x35] = 0x1a7;
                jSdinGKD3[0x26][0x1f] = 0x1a6;
                jSdinGKD3[0x38][0x51] = 0x1a5;
                jSdinGKD3[0x24][0x16] = 420;
                jSdinGKD3[0x2b][4] = 0x1a3;
                jSdinGKD3[0x24][90] = 0x1a2;
                jSdinGKD3[0x26][0x3e] = 0x1a1;
                jSdinGKD3[0x42][0x55] = 0x1a0;
                jSdinGKD3[0x27][1] = 0x19f;
                jSdinGKD3[0x3b][40] = 0x19e;
                jSdinGKD3[0x3a][0x5d] = 0x19d;
                jSdinGKD3[0x2c][0x2b] = 0x19c;
                jSdinGKD3[0x27][0x31] = 0x19b;
                jSdinGKD3[0x40][2] = 410;
                jSdinGKD3[0x29][0x23] = 0x199;
                jSdinGKD3[60][0x16] = 0x198;
                jSdinGKD3[0x23][0x5b] = 0x197;
                jSdinGKD3[0x4e][1] = 0x196;
                jSdinGKD3[0x24][14] = 0x195;
                jSdinGKD3[0x52][0x1d] = 0x194;
                jSdinGKD3[0x34][0x56] = 0x193;
                jSdinGKD3[40][0x10] = 0x192;
                jSdinGKD3[0x5b][0x34] = 0x191;
                jSdinGKD3[50][0x4b] = 400;
                jSdinGKD3[0x40][30] = 0x18f;
                jSdinGKD3[90][0x4e] = 0x18e;
                jSdinGKD3[0x24][0x34] = 0x18d;
                jSdinGKD3[0x37][0x57] = 0x18c;
                jSdinGKD3[0x39][5] = 0x18b;
                jSdinGKD3[0x39][0x1f] = 0x18a;
                jSdinGKD3[0x2a][0x23] = 0x189;
                jSdinGKD3[0x45][50] = 0x188;
                jSdinGKD3[0x2d][8] = 0x187;
                jSdinGKD3[50][0x57] = 390;
                jSdinGKD3[0x45][0x37] = 0x185;
                jSdinGKD3[0x5c][3] = 0x184;
                jSdinGKD3[0x24][0x2b] = 0x183;
                jSdinGKD3[0x40][10] = 0x182;
                jSdinGKD3[0x38][0x19] = 0x181;
                jSdinGKD3[60][0x44] = 0x180;
                jSdinGKD3[0x33][0x2e] = 0x17f;
                jSdinGKD3[50][0] = 0x17e;
                jSdinGKD3[0x26][30] = 0x17d;
                jSdinGKD3[50][0x55] = 380;
                jSdinGKD3[60][0x36] = 0x17b;
                jSdinGKD3[0x49][6] = 0x17a;
                jSdinGKD3[0x49][0x1c] = 0x179;
                jSdinGKD3[0x38][0x13] = 0x178;
                jSdinGKD3[0x3e][0x45] = 0x177;
                jSdinGKD3[0x51][0x42] = 0x176;
                jSdinGKD3[40][0x20] = 0x175;
                jSdinGKD3[0x4c][0x1f] = 0x174;
                jSdinGKD3[0x23][10] = 0x173;
                jSdinGKD3[0x29][0x25] = 370;
                jSdinGKD3[0x34][0x52] = 0x171;
                jSdinGKD3[0x5b][0x48] = 0x170;
                jSdinGKD3[0x25][0x1d] = 0x16f;
                jSdinGKD3[0x38][30] = 0x16e;
                jSdinGKD3[0x25][80] = 0x16d;
                jSdinGKD3[0x51][0x38] = 0x16c;
                jSdinGKD3[70][3] = 0x16b;
                jSdinGKD3[0x4c][15] = 0x16a;
                jSdinGKD3[0x2e][0x2f] = 0x169;
                jSdinGKD3[0x23][0x58] = 360;
                jSdinGKD3[0x3d][0x3a] = 0x167;
                jSdinGKD3[0x25][0x25] = 0x166;
                jSdinGKD3[0x39][0x16] = 0x165;
                jSdinGKD3[0x29][0x17] = 0x164;
                jSdinGKD3[90][0x42] = 0x163;
                jSdinGKD3[0x27][60] = 0x162;
                jSdinGKD3[0x26][0] = 0x161;
                jSdinGKD3[0x25][0x57] = 0x160;
                jSdinGKD3[0x2e][2] = 0x15f;
                jSdinGKD3[0x26][0x38] = 350;
                jSdinGKD3[0x3a][11] = 0x15d;
                jSdinGKD3[0x30][10] = 0x15c;
                jSdinGKD3[0x4a][4] = 0x15b;
                jSdinGKD3[40][0x2a] = 0x15a;
                jSdinGKD3[0x29][0x34] = 0x159;
                jSdinGKD3[0x3d][0x5c] = 0x158;
                jSdinGKD3[0x27][50] = 0x157;
                jSdinGKD3[0x2f][0x58] = 0x156;
                jSdinGKD3[0x58][0x24] = 0x155;
                jSdinGKD3[0x2d][0x49] = 340;
                jSdinGKD3[0x52][3] = 0x153;
                jSdinGKD3[0x3d][0x24] = 0x152;
                jSdinGKD3[60][0x21] = 0x151;
                jSdinGKD3[0x26][0x1b] = 0x150;
                jSdinGKD3[0x23][0x53] = 0x14f;
                jSdinGKD3[0x41][0x18] = 0x14e;
                jSdinGKD3[0x49][10] = 0x14d;
                jSdinGKD3[0x29][13] = 0x14c;
                jSdinGKD3[50][0x1b] = 0x14b;
                jSdinGKD3[0x3b][50] = 330;
                jSdinGKD3[0x2a][0x2d] = 0x149;
                jSdinGKD3[0x37][0x13] = 0x148;
                jSdinGKD3[0x24][0x4d] = 0x147;
                jSdinGKD3[0x45][0x1f] = 0x146;
                jSdinGKD3[60][7] = 0x145;
                jSdinGKD3[40][0x58] = 0x144;
                jSdinGKD3[0x39][0x38] = 0x143;
                jSdinGKD3[50][50] = 0x142;
                jSdinGKD3[0x2a][0x25] = 0x141;
                jSdinGKD3[0x26][0x52] = 320;
                jSdinGKD3[0x34][0x19] = 0x13f;
                jSdinGKD3[0x2a][0x43] = 0x13e;
                jSdinGKD3[0x30][40] = 0x13d;
                jSdinGKD3[0x2d][0x51] = 0x13c;
                jSdinGKD3[0x39][14] = 0x13b;
                jSdinGKD3[0x2a][13] = 0x13a;
                jSdinGKD3[0x4e][0] = 0x139;
                jSdinGKD3[0x23][0x33] = 0x138;
                jSdinGKD3[0x29][0x43] = 0x137;
                jSdinGKD3[0x40][0x17] = 310;
                jSdinGKD3[0x24][0x41] = 0x135;
                jSdinGKD3[0x30][50] = 0x134;
                jSdinGKD3[0x2e][0x45] = 0x133;
                jSdinGKD3[0x2f][0x59] = 0x132;
                jSdinGKD3[0x29][0x30] = 0x131;
                jSdinGKD3[60][0x38] = 0x130;
                jSdinGKD3[0x2c][0x52] = 0x12f;
                jSdinGKD3[0x2f][0x23] = 0x12e;
                jSdinGKD3[0x31][3] = 0x12d;
                jSdinGKD3[0x31][0x45] = 300;
                jSdinGKD3[0x2d][0x5d] = 0x12b;
                jSdinGKD3[60][0x22] = 0x12a;
                jSdinGKD3[60][0x52] = 0x129;
                jSdinGKD3[0x3d][0x3d] = 0x128;
                jSdinGKD3[0x56][0x2a] = 0x127;
                jSdinGKD3[0x59][60] = 0x126;
                jSdinGKD3[0x30][0x1f] = 0x125;
                jSdinGKD3[0x23][0x4b] = 0x124;
                jSdinGKD3[0x5b][0x27] = 0x123;
                jSdinGKD3[0x35][0x13] = 290;
                jSdinGKD3[0x27][0x48] = 0x121;
                jSdinGKD3[0x45][0x3b] = 0x120;
                jSdinGKD3[0x29][7] = 0x11f;
                jSdinGKD3[0x36][13] = 0x11e;
                jSdinGKD3[0x2b][0x1c] = 0x11d;
                jSdinGKD3[0x24][6] = 0x11c;
                jSdinGKD3[0x2d][0x4b] = 0x11b;
                jSdinGKD3[0x24][0x3d] = 0x11a;
                jSdinGKD3[0x26][0x15] = 0x119;
                jSdinGKD3[0x2d][14] = 280;
                jSdinGKD3[0x3d][0x2b] = 0x117;
                jSdinGKD3[0x24][0x3f] = 0x116;
                jSdinGKD3[0x2b][30] = 0x115;
                jSdinGKD3[0x2e][0x33] = 0x114;
                jSdinGKD3[0x44][0x57] = 0x113;
                jSdinGKD3[0x27][0x1a] = 0x112;
                jSdinGKD3[0x2e][0x4c] = 0x111;
                jSdinGKD3[0x24][15] = 0x110;
                jSdinGKD3[0x23][40] = 0x10f;
                jSdinGKD3[0x4f][60] = 270;
                jSdinGKD3[0x2e][7] = 0x10d;
                jSdinGKD3[0x41][0x48] = 0x10c;
                jSdinGKD3[0x45][0x58] = 0x10b;
                jSdinGKD3[0x2f][0x12] = 0x10a;
                jSdinGKD3[0x25][0] = 0x109;
                jSdinGKD3[0x25][0x31] = 0x108;
                jSdinGKD3[0x43][0x25] = 0x107;
                jSdinGKD3[0x24][0x5b] = 0x106;
                jSdinGKD3[0x4b][0x30] = 0x105;
                jSdinGKD3[0x4b][0x3f] = 260;
                jSdinGKD3[0x53][0x57] = 0x103;
                jSdinGKD3[0x25][0x2c] = 0x102;
                jSdinGKD3[0x49][0x36] = 0x101;
                jSdinGKD3[0x33][0x3d] = 0x100;
                jSdinGKD3[0x2e][0x39] = 0xff;
                jSdinGKD3[0x37][0x15] = 0xfe;
                jSdinGKD3[0x27][0x42] = 0xfd;
                jSdinGKD3[0x2f][11] = 0xfc;
                jSdinGKD3[0x34][8] = 0xfb;
                jSdinGKD3[0x52][0x51] = 250;
                jSdinGKD3[0x24][0x39] = 0xf9;
                jSdinGKD3[0x26][0x36] = 0xf8;
                jSdinGKD3[0x2b][0x51] = 0xf7;
                jSdinGKD3[0x25][0x2a] = 0xf6;
                jSdinGKD3[40][0x12] = 0xf5;
                jSdinGKD3[80][90] = 0xf4;
                jSdinGKD3[0x25][0x54] = 0xf3;
                jSdinGKD3[0x39][15] = 0xf2;
                jSdinGKD3[0x26][0x57] = 0xf1;
                jSdinGKD3[0x25][0x20] = 240;
                jSdinGKD3[0x35][0x35] = 0xef;
                jSdinGKD3[0x59][0x1d] = 0xee;
                jSdinGKD3[0x51][0x35] = 0xed;
                jSdinGKD3[0x4b][3] = 0xec;
                jSdinGKD3[0x53][0x49] = 0xeb;
                jSdinGKD3[0x42][13] = 0xea;
                jSdinGKD3[0x30][7] = 0xe9;
                jSdinGKD3[0x2e][0x23] = 0xe8;
                jSdinGKD3[0x23][0x56] = 0xe7;
                jSdinGKD3[0x25][20] = 230;
                jSdinGKD3[0x2e][80] = 0xe5;
                jSdinGKD3[0x26][0x18] = 0xe4;
                jSdinGKD3[0x29][0x44] = 0xe3;
                jSdinGKD3[0x2a][0x15] = 0xe2;
                jSdinGKD3[0x2b][0x20] = 0xe1;
                jSdinGKD3[0x26][20] = 0xe0;
                jSdinGKD3[0x25][0x3b] = 0xdf;
                jSdinGKD3[0x29][0x4d] = 0xde;
                jSdinGKD3[0x3b][0x39] = 0xdd;
                jSdinGKD3[0x44][0x3b] = 220;
                jSdinGKD3[0x27][0x2b] = 0xdb;
                jSdinGKD3[0x36][0x27] = 0xda;
                jSdinGKD3[0x30][0x1c] = 0xd9;
                jSdinGKD3[0x36][0x1c] = 0xd8;
                jSdinGKD3[0x29][0x2c] = 0xd7;
                jSdinGKD3[0x33][0x40] = 0xd6;
                jSdinGKD3[0x2f][0x48] = 0xd5;
                jSdinGKD3[0x3e][0x43] = 0xd4;
                jSdinGKD3[0x2a][0x2b] = 0xd3;
                jSdinGKD3[0x3d][0x26] = 210;
                jSdinGKD3[0x4c][0x19] = 0xd1;
                jSdinGKD3[0x30][0x5b] = 0xd0;
                jSdinGKD3[0x24][0x24] = 0xcf;
                jSdinGKD3[80][0x20] = 0xce;
                jSdinGKD3[0x51][40] = 0xcd;
                jSdinGKD3[0x25][5] = 0xcc;
                jSdinGKD3[0x4a][0x45] = 0xcb;
                jSdinGKD3[0x24][0x52] = 0xca;
                jSdinGKD3[0x2e][0x3b] = 0xc9;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static long FileLength(FileInfo file)
        {
            if (Directory.Exists(file.FullName))
            {
                return 0L;
            }
            return file.Length;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual string GetEncodingName(sbyte[] rawtext)
        {
            int num2 = 0;
            int index = 0;
            int[] numArray = new int[] { this.shYqQnYSdY(rawtext), this.Z0KqzOrDab(rawtext), this.vHVfy06piH(rawtext), this.V81fqrVEdm(rawtext), this.LI2ffmW764(rawtext), this.36ufN2M432(rawtext), this.bGofPXwZAx(rawtext), this.UdAfVk2gVw(rawtext), this.0ZHfmuDUeA(rawtext), 0 };
            for (int i = 0; i < 10; i++)
            {
                if (numArray[i] > num2)
                {
                    index = i;
                    num2 = numArray[i];
                }
            }
            if (num2 <= 50)
            {
                index = 9;
            }
            return fcNUBE6Y4[index];
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual string GetEncodingName(FileInfo testfile)
        {
            FileStream sourceStream = null;
            sbyte[] target = new sbyte[(int) FileLength(testfile)];
            try
            {
                sourceStream = new FileStream(testfile.FullName, FileMode.Open, FileAccess.Read);
                ReadInput(sourceStream, ref target, 0, target.Length);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (null != sourceStream)
                {
                    sourceStream.Close();
                }
            }
            return this.GetEncodingName(target);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual string GetEncodingName(Uri testurl)
        {
            sbyte[] target = new sbyte[0x400];
            int num = 0;
            int start = 0;
            try
            {
                Stream responseStream = WebRequest.Create(testurl.AbsoluteUri).GetResponse().GetResponseStream();
                while ((num = ReadInput(responseStream, ref target, start, target.Length - start)) > 0)
                {
                    start += num;
                }
                responseStream.Close();
            }
            catch
            {
                throw;
            }
            return this.GetEncodingName(target);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static double Identity(double literal)
        {
            return literal;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static long Identity(long literal)
        {
            return literal;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static float Identity(float literal)
        {
            return literal;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ulong Identity(ulong literal)
        {
            return literal;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal virtual int LI2ffmW764(sbyte[] rawtext)
        {
            int length = 0;
            int num3 = 1;
            int num4 = 1;
            long num5 = 0L;
            long num6 = 1L;
            float num7 = 0f;
            float num8 = 0f;
            length = rawtext.Length;
            for (int i = 0; i < (length - 1); i++)
            {
                if (rawtext[i] < 0)
                {
                    num3++;
                    if ((((((i + 3) < length) && (((sbyte) Identity((long) 0x8eL)) == rawtext[i])) && ((((sbyte) Identity((long) 0xa1L)) <= rawtext[i + 1]) && (rawtext[i + 1] <= ((sbyte) Identity((long) 0xb0L))))) && (((((sbyte) Identity((long) 0xa1L)) <= rawtext[i + 2]) && (rawtext[i + 2] <= ((sbyte) Identity((long) 0xfeL)))) && (((sbyte) Identity((long) 0xa1L)) <= rawtext[i + 3]))) && (rawtext[i + 3] <= ((sbyte) Identity((long) 0xfeL))))
                    {
                        num4++;
                        i += 3;
                    }
                    else if ((((((sbyte) Identity((long) 0xa1L)) <= rawtext[i]) && (rawtext[i] <= ((sbyte) Identity((long) 0xfeL)))) && (((sbyte) Identity((long) 0xa1L)) <= rawtext[i + 1])) && (rawtext[i + 1] <= ((sbyte) Identity((long) 0xfeL))))
                    {
                        num4++;
                        num6 += 500L;
                        int index = (rawtext[i] + 0x100) - 0xa1;
                        int num10 = (rawtext[i + 1] + 0x100) - 0xa1;
                        if (jSdinGKD3[index][num10] != 0)
                        {
                            num5 += jSdinGKD3[index][num10];
                        }
                        else if ((0x23 <= index) && (index <= 0x5c))
                        {
                            num5 += 150L;
                        }
                        i++;
                    }
                }
            }
            num7 = 50f * (((float) num4) / ((float) num3));
            num8 = 50f * (((float) num5) / ((float) num6));
            return (int) (num7 + num8);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int ReadInput(Stream sourceStream, ref sbyte[] target, int start, int count)
        {
            if (target.Length == 0)
            {
                return 0;
            }
            byte[] buffer = new byte[target.Length];
            int num = sourceStream.Read(buffer, start, count);
            if (num == 0)
            {
                return -1;
            }
            for (int i = start; i < (start + num); i++)
            {
                target[i] = (sbyte) buffer[i];
            }
            return num;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int ReadInput(TextReader sourceTextReader, ref sbyte[] target, int start, int count)
        {
            if (target.Length == 0)
            {
                return 0;
            }
            char[] buffer = new char[target.Length];
            int num = sourceTextReader.Read(buffer, start, count);
            if (num == 0)
            {
                return -1;
            }
            for (int i = start; i < (start + num); i++)
            {
                target[i] = (sbyte) buffer[i];
            }
            return num;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal virtual int shYqQnYSdY(sbyte[] rawtext)
        {
            int length = 0;
            int num3 = 1;
            int num4 = 1;
            long num5 = 0L;
            long num6 = 1L;
            float num7 = 0f;
            float num8 = 0f;
            length = rawtext.Length;
            for (int i = 0; i < (length - 1); i++)
            {
                if (rawtext[i] < 0)
                {
                    num3++;
                    if ((((((sbyte) Identity((long) 0xa1L)) <= rawtext[i]) && (rawtext[i] <= ((sbyte) Identity((long) 0xf7L)))) && (((sbyte) Identity((long) 0xa1L)) <= rawtext[i + 1])) && (rawtext[i + 1] <= ((sbyte) Identity((long) 0xfeL))))
                    {
                        num4++;
                        num6 += 500L;
                        int index = (rawtext[i] + 0x100) - 0xa1;
                        int num10 = (rawtext[i + 1] + 0x100) - 0xa1;
                        if (mi5qIK3te[index][num10] != 0)
                        {
                            num5 += mi5qIK3te[index][num10];
                        }
                        else if ((15 <= index) && (index < 0x37))
                        {
                            num5 += 200L;
                        }
                    }
                    i++;
                }
            }
            num7 = 50f * (((float) num4) / ((float) num3));
            num8 = 50f * (((float) num5) / ((float) num6));
            return (int) (num7 + num8);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static byte[] ToByteArray(object[] tempObjectArray)
        {
            byte[] buffer = new byte[tempObjectArray.Length];
            for (int i = 0; i < tempObjectArray.Length; i++)
            {
                buffer[i] = (byte) tempObjectArray[i];
            }
            return buffer;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static byte[] ToByteArray(string sourceString)
        {
            byte[] buffer = new byte[sourceString.Length];
            for (int i = 0; i < sourceString.Length; i++)
            {
                buffer[i] = (byte) sourceString[i];
            }
            return buffer;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static byte[] ToByteArray(sbyte[] sbyteArray)
        {
            byte[] buffer = new byte[sbyteArray.Length];
            for (int i = 0; i < sbyteArray.Length; i++)
            {
                buffer[i] = (byte) sbyteArray[i];
            }
            return buffer;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static sbyte[] ToSByteArray(byte[] byteArray)
        {
            sbyte[] numArray = new sbyte[byteArray.Length];
            for (int i = 0; i < byteArray.Length; i++)
            {
                numArray[i] = (sbyte) byteArray[i];
            }
            return numArray;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal virtual int UdAfVk2gVw(sbyte[] rawtext)
        {
            if (((((sbyte) Identity((long) 0xfeL)) == rawtext[0]) && (((sbyte) Identity((long) 0xffL)) == rawtext[1])) || ((((sbyte) Identity((long) 0xffL)) == rawtext[0]) && (((sbyte) Identity((long) 0xfeL)) == rawtext[1])))
            {
                return 100;
            }
            return 0;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal virtual int V81fqrVEdm(sbyte[] rawtext)
        {
            int length = 0;
            int num3 = 1;
            int num4 = 1;
            float num5 = 0f;
            float num6 = 0f;
            long num7 = 0L;
            long num8 = 1L;
            length = rawtext.Length;
            for (int i = 0; i < (length - 1); i++)
            {
                if (rawtext[i] < 0)
                {
                    num3++;
                    if (((((sbyte) Identity((long) 0xa1L)) <= rawtext[i]) && (rawtext[i] <= ((sbyte) Identity((long) 0xf9L)))) && (((0x40 <= rawtext[i + 1]) && (rawtext[i + 1] <= 0x7e)) || ((((sbyte) Identity((long) 0xa1L)) <= rawtext[i + 1]) && (rawtext[i + 1] <= ((sbyte) Identity((long) 0xfeL))))))
                    {
                        int num10;
                        num4++;
                        num8 += 500L;
                        int index = (rawtext[i] + 0x100) - 0xa1;
                        if ((0x40 <= rawtext[i + 1]) && (rawtext[i + 1] <= 0x7e))
                        {
                            num10 = rawtext[i + 1] - 0x40;
                        }
                        else
                        {
                            num10 = (rawtext[i + 1] + 0x100) - 0x61;
                        }
                        if (OBHMaLtRG[index][num10] != 0)
                        {
                            num7 += OBHMaLtRG[index][num10];
                        }
                        else if ((3 <= index) && (index <= 0x25))
                        {
                            num7 += 200L;
                        }
                    }
                    i++;
                }
            }
            num5 = 50f * (((float) num4) / ((float) num3));
            num6 = 50f * (((float) num7) / ((float) num8));
            return (int) (num5 + num6);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal virtual int vHVfy06piH(sbyte[] rawtext)
        {
            int num3 = 0;
            int num4 = 1;
            long num5 = 0L;
            long num6 = 1L;
            float num7 = 0f;
            float num8 = 0f;
            int num9 = 0;
            int num10 = 0;
            int length = rawtext.Length;
            for (int i = 0; i < length; i++)
            {
                if (rawtext[i] == 0x7e)
                {
                    if (rawtext[i + 1] == 0x7b)
                    {
                        num9++;
                        i += 2;
                        while (i < (length - 1))
                        {
                            int num11;
                            int num12;
                            if ((rawtext[i] == 10) || (rawtext[i] == 13))
                            {
                                break;
                            }
                            if ((rawtext[i] == 0x7e) && (rawtext[i + 1] == 0x7d))
                            {
                                num10++;
                                i++;
                                break;
                            }
                            if (((0x21 <= rawtext[i]) && (rawtext[i] <= 0x77)) && ((0x21 <= rawtext[i + 1]) && (rawtext[i + 1] <= 0x77)))
                            {
                                num3 += 2;
                                num11 = rawtext[i] - 0x21;
                                num12 = rawtext[i + 1] - 0x21;
                                num6 += 500L;
                                if (mi5qIK3te[num11][num12] != 0)
                                {
                                    num5 += mi5qIK3te[num11][num12];
                                }
                                else if ((15 <= num11) && (num11 < 0x37))
                                {
                                    num5 += 200L;
                                }
                            }
                            else if (((0xa1 <= rawtext[i]) && (rawtext[i] <= 0xf7)) && ((0xa1 <= rawtext[i + 1]) && (rawtext[i + 1] <= 0xf7)))
                            {
                                num3 += 2;
                                num11 = (rawtext[i] + 0x100) - 0xa1;
                                num12 = (rawtext[i + 1] + 0x100) - 0xa1;
                                num6 += 500L;
                                if (mi5qIK3te[num11][num12] != 0)
                                {
                                    num5 += mi5qIK3te[num11][num12];
                                }
                                else if ((15 <= num11) && (num11 < 0x37))
                                {
                                    num5 += 200L;
                                }
                            }
                            num4 += 2;
                            i += 2;
                        }
                    }
                    else if (rawtext[i + 1] == 0x7d)
                    {
                        num10++;
                        i++;
                    }
                    else if (rawtext[i + 1] == 0x7e)
                    {
                        i++;
                    }
                }
            }
            if (num9 > 4)
            {
                num7 = 50f;
            }
            else if (num9 > 1)
            {
                num7 = 41f;
            }
            else if (num9 > 0)
            {
                num7 = 39f;
            }
            else
            {
                num7 = 0f;
            }
            num8 = 50f * (((float) num5) / ((float) num6));
            return (int) (num7 + num8);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal virtual int Z0KqzOrDab(sbyte[] rawtext)
        {
            int length = 0;
            int num3 = 1;
            int num4 = 1;
            long num5 = 0L;
            long num6 = 1L;
            float num7 = 0f;
            float num8 = 0f;
            length = rawtext.Length;
            for (int i = 0; i < (length - 1); i++)
            {
                if (rawtext[i] < 0)
                {
                    int num9;
                    int num10;
                    num3++;
                    if ((((((sbyte) Identity((long) 0xa1L)) <= rawtext[i]) && (rawtext[i] <= ((sbyte) Identity((long) 0xf7L)))) && (((sbyte) Identity((long) 0xa1L)) <= rawtext[i + 1])) && (rawtext[i + 1] <= ((sbyte) Identity((long) 0xfeL))))
                    {
                        num4++;
                        num6 += 500L;
                        num9 = (rawtext[i] + 0x100) - 0xa1;
                        num10 = (rawtext[i + 1] + 0x100) - 0xa1;
                        if (mi5qIK3te[num9][num10] != 0)
                        {
                            num5 += mi5qIK3te[num9][num10];
                        }
                        else if ((15 <= num9) && (num9 < 0x37))
                        {
                            num5 += 200L;
                        }
                    }
                    else if (((((sbyte) Identity((long) 0x81L)) <= rawtext[i]) && (rawtext[i] <= ((sbyte) Identity((long) 0xfeL)))) && (((((sbyte) Identity((long) 0x80L)) <= rawtext[i + 1]) && (rawtext[i + 1] <= ((sbyte) Identity((long) 0xfeL)))) || ((0x40 <= rawtext[i + 1]) && (rawtext[i + 1] <= 0x7e))))
                    {
                        num4++;
                        num6 += 500L;
                        num9 = (rawtext[i] + 0x100) - 0x81;
                        if ((0x40 <= rawtext[i + 1]) && (rawtext[i + 1] <= 0x7e))
                        {
                            num10 = rawtext[i + 1] - 0x40;
                        }
                        else
                        {
                            num10 = (rawtext[i + 1] + 0x100) - 0x80;
                        }
                        if (lWvfFeZUE[num9][num10] != 0)
                        {
                            num5 += lWvfFeZUE[num9][num10];
                        }
                    }
                    i++;
                }
            }
            num7 = 50f * (((float) num4) / ((float) num3));
            num8 = 50f * (((float) num5) / ((float) num6));
            return (((int) (num7 + num8)) - 1);
        }
    }
}

