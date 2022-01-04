using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    class Program
    {
        static int[,] Data = new int[4, 4] { {0,0,2,4 },
                                        {2,8,4,4 },
                                        {2,8,2,16 },
                                        {4,0,2,4 }};
        static void Main(string[] args)
        {
            Data = Right(Data);
            for (int i = 0; i < Data.GetLength(0); i++)
            {
                for (int j = 0; j < Data.GetLength(1); j++)
                    Console.Write(Data[i, j] + "\t");
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        private static int[,] Up(int[,] Data)
        {
            int[] Temp = new int[Data.GetLength(0)];
            for(int i=0;i<Data.GetLength(1);i++)
            {
                for (int j = 0; j < Data.GetLength(0); j++) 
                    Temp[j] = Data[j, i];                   
                Temp = CheckLinearArray(Temp);
                for (int j = 0; j < Data.GetLength(0); j++)
                    Data[j, i] = Temp[j];
            }
            return Data;
        }

        private static int[,] Down(int[,] Data)
        {
            int[] Temp = new int[Data.GetLength(0)];
            for (int i = 0; i < Data.GetLength(1); i++)
            {
                for (int j = 0; j < Data.GetLength(0); j++)
                    Temp[j] = Data[j, i];
                Array.Reverse(Temp); // 倒序读取
                Temp = CheckLinearArray(Temp);
                Array.Reverse(Temp); // 倒序写入
                for (int j = 0; j < Data.GetLength(0); j++)
                    Data[j, i] = Temp[j];
            }
            return Data;
        }

        private static int[,] Left(int[,] Data)
        {
            int[] Temp = new int[Data.GetLength(1)];
            for (int i = 0; i < Data.GetLength(0); i++)
            {
                for (int j = 0; j < Data.GetLength(1); j++)
                    Temp[j] = Data[i, j];
                Temp = CheckLinearArray(Temp);
                for (int j = 0; j < Data.GetLength(1); j++)
                    Data[i, j] = Temp[j];
            }
            return Data;
        }

        private static int[,] Right(int[,] Data)
        {
            int[] Temp = new int[Data.GetLength(1)];
            for (int i = 0; i < Data.GetLength(0); i++)
            {
                for (int j = 0; j < Data.GetLength(1); j++)
                    Temp[j] = Data[i, j];
                Array.Reverse(Temp);
                Temp = CheckLinearArray(Temp);
                Array.Reverse(Temp);
                for (int j = 0; j < Data.GetLength(1); j++)
                    Data[i, j] = Temp[j];
            }
            return Data;
        }

        /// <summary>
        /// 一维数组的检查与合并
        /// </summary>
        private static int[] CheckLinearArray(int[] Data)
        {
            if (CheckArrayEmpty(Data)) return Data;
            for (int i = 0; i < Data.Length - 1; i++) 
            {
                if (Data[i] == 0) // 将非0元素移项数组头部
                    for (int j = i + 1; j < Data.Length; j++)
                    {
                        if (Data[j] != 0)
                        {
                            Data = Swap(Data, i, j);
                            break;
                        }
                        if (j == Data.Length) return Data; // 若数组后部元素都为0 退出函数 没有必要再比较了
                    }
                for (int j = i + 1; j < Data.Length; j++)
                {
                    if (Data[j] == 0) continue; // 寻找第一个不是0的元素

                    if (Data[i] == Data[j])
                    {
                        Data[i] *= 2;
                        Data[j] = 0;
                        break;
                    }
                    else break;
                }
            }
            return Data;
        }

        /// <summary>
        /// 检查是否为空数组（所有元素都为0）
        /// </summary>
        private static bool CheckArrayEmpty(int[] Data)
        {
            foreach (var item in Data)
                if (item != 0) return false;
            return true;
        }

        private static int[] Swap(int[] array,int A,int B)
        {
            int Temp = array[A];
            array[A] = array[B];
            array[B] = Temp;

            return array;
        }
    }
}
