using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    static class Tools
    {
        /// <summary>
        /// 检查数组是否已满（所有元素都不为0）
        /// </summary>
        public static bool CheckArrayFull(int[] Data)
        {
            foreach (var item in Data)
                if (item == 0) return false;
            return true;
        }
        public static bool CheckArrayFull(int[,] Data)
        {
            for (int i = 0; i < Data.GetLength(0); i++)
                for (int j = 0; j < Data.GetLength(1); j++)
                    if (Data[i, j] == 0) return false;
            return true;
        }

        /// <summary>
        /// 检查是否为空数组（所有元素都为0）
        /// </summary>
        public static bool CheckArrayEmpty(int[] Data)
        {
            foreach (var item in Data)
                if (item != 0) return false;
            return true;
        }

        /// <summary>
        /// 交换数组中两个元素的位置
        /// </summary>
        public static void Swap(int[] array, int index1, int index2)
        {
            int Temp = array[index1];
            array[index1] = array[index2];
            array[index2] = Temp;
        }

        /// <summary>
        /// 从指定元素沿指定方向连续取元素至一维数组
        /// </summary>
        public static void ExtractLinearArray(int[,] SourceArray,int[] TargetArray,Direction direction,int index1,int index2)
        {
            int Count = 0;
            switch (direction)
            {
                case Direction.Up:
                    while (index1 >= 0 && Count < TargetArray.Length)
                        TargetArray[Count++] = SourceArray[index1--, index2];
                    return;
                case Direction.Down:
                    while (index1 < SourceArray.GetLength(0) && Count < TargetArray.Length)
                        TargetArray[Count++] = SourceArray[index1++, index2];
                    return;
                case Direction.Left:
                    while (index2 >= 0 && Count < TargetArray.Length)
                        TargetArray[Count++] = SourceArray[index1, index2--];
                    return;
                case Direction.Right:
                    while (index2 < SourceArray.GetLength(1) && Count < TargetArray.Length)
                        TargetArray[Count++] = SourceArray[index1, index2++];
                    return;
            }
        }

        /// <summary>
        /// 从指定元素沿指定方向连续替换成一维数组
        /// </summary>
        public static void ReplaceLinearArray(int[,] SourceArray, int[] TargetArray, Direction direction, int index1, int index2)
        {
            int Count = 0;
            switch (direction)
            {
                case Direction.Up:
                    while (index1 >= 0 && Count < TargetArray.Length)
                        SourceArray[index1--, index2] = TargetArray[Count++];                   
                    return;
                case Direction.Down:
                    while (index1 < SourceArray.GetLength(0) && Count < TargetArray.Length)
                        SourceArray[index1++, index2] = TargetArray[Count++];
                    return;
                case Direction.Left:
                    while (index2 >= 0 && Count < TargetArray.Length)
                        SourceArray[index1, index2--] = TargetArray[Count++];
                    return;
                case Direction.Right:
                    while (index2 < SourceArray.GetLength(1) && Count < TargetArray.Length)
                        SourceArray[index1, index2++] = TargetArray[Count++];
                    return;
            }
        }
    }
}
