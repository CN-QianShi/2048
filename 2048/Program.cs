using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    class Program
    {
        static void Main(string[] args)
        {
            GameCore game = new GameCore();
            DrawBoard(game.Data);

            do
            {
                game.Move(ReadKey());
                game.Generate();
                DrawBoard(game.Data);
            } while (!game.IsFail());

            Console.WriteLine("您失败了");
            Console.ReadLine();
        }

        static void DrawBoard(int[,] Data)
        {
            for (int i = 0; i < Data.GetLength(0); i++)
            {
                for (int j = 0; j < Data.GetLength(1); j++)
                    Console.Write(Data[i, j] + "\t");
                Console.WriteLine();
            }
        }

        static Direction ReadKey()
        {
            switch (char.Parse(Console.ReadLine()))
            {
                case 'w':
                    return Direction.Up;
                case 'a':
                    return Direction.Left;
                case 's':
                    return Direction.Down;
                case 'd':
                    return Direction.Right;
                default:
                    return Direction.Blank;
            }
        }
    }
}
