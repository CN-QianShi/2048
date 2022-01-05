using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    class GameCore
    {
        private int[,] data;
        public int[,] Data
        {
            get { return data; }
        }

        private int[] linearArray;

        public GameCore()
        {
            data = new int[4, 4];
            linearArray = new int[4];

            GenerateRandom.Generate(data);
        }
        public bool IsFail()
        {
            if (Tools.CheckArrayFull(data)) // 数列全满时才进行判断 减少性能开销
            {
                for (int i = 0; i < data.GetLength(1); i++) // 一列中任意两个相邻元素相同 则游戏没有失败
                {
                    Tools.ExtractLinearArray(data, linearArray, Direction.Down, 0, i);
                    for (int j = 0; j < linearArray.Length - 1; j++)
                        if (linearArray[j] == linearArray[j + 1]) return false;
                }
                for (int i = 0; i < data.GetLength(0); i++) // 一行中任意两个相邻元素相同 则游戏没有失败
                {
                    Tools.ExtractLinearArray(data, linearArray, Direction.Right, i, 0);
                    for (int j = 0; j < linearArray.Length - 1; j++)
                        if (linearArray[j] == linearArray[j + 1]) return false;
                }

                return true;
            }
            else return false;
        }

        public void Generate() // 在随机位置生成数
        {
            if(!Tools.CheckArrayFull(data))
                GenerateRandom.Generate(data);
        }

        #region 四种移动方法
        private void MoveUp()
        {
            for (int i = 0; i < data.GetLength(1); i++)
            {
                Tools.ExtractLinearArray(data, linearArray, Direction.Down, 0, i);
                CheckLinearArray();
                Tools.ReplaceLinearArray(data, linearArray, Direction.Down, 0, i);
            }
        }
        private void MoveDown()
        {
            for (int i = 0; i < data.GetLength(1); i++)
            {
                Tools.ExtractLinearArray(data, linearArray, Direction.Up, data.GetLength(0) - 1, i);
                CheckLinearArray();
                Tools.ReplaceLinearArray(data, linearArray, Direction.Up, data.GetLength(0) - 1, i);
            }
        }
        private void MoveLeft()
        {
            for (int i = 0; i < data.GetLength(0); i++)
            {
                Tools.ExtractLinearArray(data, linearArray, Direction.Right, i, 0);
                CheckLinearArray();
                Tools.ReplaceLinearArray(data, linearArray, Direction.Right, i, 0);
            }
        }
        private void MoveRight()
        {
            for (int i = 0; i < data.GetLength(0); i++)
            {
                Tools.ExtractLinearArray(data, linearArray, Direction.Left, i, data.GetLength(1) - 1);
                CheckLinearArray();
                Tools.ReplaceLinearArray(data, linearArray, Direction.Left, i, data.GetLength(1) - 1);
            }
        }
        #endregion      
        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    MoveUp();
                    break;
                case Direction.Down:
                    MoveDown();
                    break;
                case Direction.Left:
                    MoveLeft();
                    break;
                case Direction.Right:
                    MoveRight();
                    break;
            }
        }

        #region 处理一维数组
        private void CheckLinearArray() // 一维数组的检查与合并
        {
            if (Tools.CheckArrayEmpty(linearArray)) return;
            RemoveZero();
            MergeSameNumber();
            RemoveZero();
        }
        private void RemoveZero()  // 除去元素中间的空项（值为0）
        {
            if (Tools.CheckArrayFull(linearArray)) return;
            for (int index = 0; index < linearArray.Length - 1;)
            {
                index = Array.IndexOf<int>(linearArray, 0);
                for (int j = index + 1; j < linearArray.Length; j++)
                {
                    if (linearArray[j] != 0)
                    {
                        Tools.Swap(linearArray, index, j);
                        break;
                    }
                    if (j == linearArray.Length - 1) return; // 若数组后部元素都为0 退出函数 没有必要再比较了
                }
            }
        }
        private void MergeSameNumber() // 相邻相同元素合并
        {
            for (int i = 0; i < linearArray.Length - 1; i++)
                if (linearArray[i] == linearArray[i + 1])
                {
                    linearArray[i] *= 2;
                    linearArray[i + 1] = 0;
                }
        }
        #endregion

    }
}
