namespace WHC.OrderWater.Commons
{
    using System;
    using System.Runtime.CompilerServices;

    public class SortHelper
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void 01FqmBarm(ref int numRef1, ref int numRef2)
        {
            int num = numRef1;
            numRef1 = numRef2;
            numRef2 = num;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void BubbleSort(int[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                for (int j = i; j < list.Length; j++)
                {
                    if (list[i] < list[j])
                    {
                        int num3 = list[i];
                        list[i] = list[j];
                        list[j] = num3;
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void InsertionSort(int[] list)
        {
            for (int i = 1; i < list.Length; i++)
            {
                int num2 = list[i];
                int index = i;
                while ((index > 0) && (list[index - 1] > num2))
                {
                    list[index] = list[index - 1];
                    index--;
                }
                list[index] = num2;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void QuickSort(int[] list, int low, int high)
        {
            if (high > low)
            {
                if (high == (low + 1))
                {
                    if (list[low] > list[high])
                    {
                        01FqmBarm(ref list[low], ref list[high]);
                    }
                }
                else
                {
                    int index = (low + high) >> 1;
                    int num = list[index];
                    01FqmBarm(ref list[low], ref list[index]);
                    int num2 = low + 1;
                    int num3 = high;
                    do
                    {
                        while ((num2 <= num3) && (list[num2] < num))
                        {
                            num2++;
                        }
                        while (list[num3] >= num)
                        {
                            num3--;
                        }
                        if (num2 < num3)
                        {
                            01FqmBarm(ref list[num2], ref list[num3]);
                        }
                    }
                    while (num2 < num3);
                    list[low] = list[num3];
                    list[num3] = num;
                    if ((low + 1) < num3)
                    {
                        QuickSort(list, low, num3 - 1);
                    }
                    if ((num3 + 1) < high)
                    {
                        QuickSort(list, num3 + 1, high);
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SelectionSort(int[] list)
        {
            for (int i = 0; i < (list.Length - 1); i++)
            {
                int index = i;
                for (int j = i + 1; j < list.Length; j++)
                {
                    if (list[j] < list[index])
                    {
                        index = j;
                    }
                }
                int num4 = list[index];
                list[index] = list[i];
                list[i] = num4;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ShellSort(int[] list)
        {
            int num = 1;
            while (num <= (list.Length / 9))
            {
                num = (3 * num) + 1;
            }
            while (num > 0)
            {
                for (int i = num + 1; i <= list.Length; i += num)
                {
                    int num3 = list[i - 1];
                    int num4 = i;
                    while ((num4 > num) && (list[(num4 - num) - 1] > num3))
                    {
                        list[num4 - 1] = list[(num4 - num) - 1];
                        num4 -= num;
                    }
                    list[num4 - 1] = num3;
                }
                num /= 3;
            }
        }
    }
}

