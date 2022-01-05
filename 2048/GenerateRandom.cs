using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    static class GenerateRandom
    {
        static List<BlankSpace> list;
        static Random random;
        static GenerateRandom()
        {
            list = new List<BlankSpace>(16);
            random = new Random();
        }

        public static void Generate(int[,] Data)
        {
            list.Clear();
            for (int i = 0; i < Data.GetLength(0); i++)
                for (int j = 0; j < Data.GetLength(1); j++)
                    if (Data[i, j] == 0) list.Add(new BlankSpace(i, j)); // 遍历数组，寻找空白位置，记录其位置的索引
            BlankSpace Temp = list[random.Next(0, list.Count - 1)];
            Data[Temp.Index1, Temp.Index2] = random.Next(0, 9) == 0 ? 4 : 2; // 10%的几率生成4，90%的几率生成2
        }
    }
}
