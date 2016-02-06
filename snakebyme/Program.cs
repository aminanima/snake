
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snakebyme
{
    class Program
    {
        public static int level = 1;
        public static int score = 0;

        static void Main(string[] args)
        {
            while (level <= Directory.GetFiles(@"D:\PT2016\snakebyme\snakebyme\bin\Debug\levels").Length)//gets the files from level until finds the last element
            {
                Game.Init();
                Game.LoadlLevel(level);
                Game.RandomSnake();

                while (Game.isActive)
                {
                    Game.Draw();

                    ConsoleKeyInfo pressedKey = Console.ReadKey();
                    switch (pressedKey.Key)
                    {
                        case ConsoleKey.UpArrow:
                            Game.snakebyme.Move(0, -1);
                            break;
                        case ConsoleKey.DownArrow:
                            Game.snakebyme.Move(0, 1);
                            break;
                        case ConsoleKey.LeftArrow:
                            Game.snakebyme.Move(-1, 0);
                            break;
                        case ConsoleKey.RightArrow:
                            Game.snakebyme.Move(1, 0);
                            break;
                        case ConsoleKey.Escape:
                            Game.isActive = false;
                            break;
                        case ConsoleKey.F2:
                            Game.Save();
                            break;
                        case ConsoleKey.F3:
                            Game.Resume();
                            break;
                    }
                }

                
            }
            Console.Clear();
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("You won the game!");
            Console.WriteLine("Your score is " + score);
            Game.isActive = false;
            Console.ReadKey();
        }
    }
}

