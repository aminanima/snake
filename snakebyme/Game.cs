using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snakebyme
{
    class Game
    {
        public static bool isActive;
        public static Snake snakebyme;
        public static Food food;
        public static Wall wall;

        public static void Init()
        {
            isActive = true;
            snakebyme = new Snake();
            food = new Food();
            wall = new Wall();


            snakebyme.body.Add(new Point { x = 20, y = 20 });
            food.body.Add(new Point { x = 10, y = 20 });

            food.color = ConsoleColor.Green;
            wall.color = ConsoleColor.White;
            snakebyme.color = ConsoleColor.Yellow;

            Console.SetWindowSize(48, 51);
        }

        public static void LoadlLevel(int level)
        {
            FileStream fs = new FileStream(string.Format(@"levels\level{0}.txt", level), FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);//reads the file level

            string line;
            int row = -1;
            int col = -1;

            while ((line = sr.ReadLine()) != null)
            {
                row++;
                col = -1;
                foreach (char c in line)
                {
                    col++;
                    if (c == '#')
                    {
                        wall.body.Add(new Point { x = col, y = row });
                    }
                }
            }

            sr.Close();
            fs.Close();
        }

        public static void Save()
        {
            wall.Save();
            snakebyme.Save();
            food.Save();
        }

        public static void Resume()
        {
            wall.Resume();
            snakebyme.Resume();
            food.Resume();
        }

        public static void Draw()
        {
            Console.Clear();
            snakebyme.Draw();
            food.Draw();
            wall.Draw();
            Console.SetCursorPosition(2, 5);
            Console.WriteLine("Level: " + Program.level);
            Console.SetCursorPosition(2, 3);
            Console.WriteLine("Eaten food: " + Program.score);
            Console.SetCursorPosition(1, 48);
            Console.WriteLine("Press F3 " );
            Console.SetCursorPosition(1, 49);
            Console.WriteLine("Press F2 " );
            Console.SetCursorPosition(1, 50);
            Console.WriteLine("Press Escape ");

        }

        public static void RandomSnake()
        {
            snakebyme.body[0].x = new Random().Next(0, 40);
            snakebyme.body[0].y = new Random().Next(0, 40);

            for (int i = 0; i < wall.body.Count; ++i)
            {
                if (snakebyme.body[0].x == wall.body[i].x && snakebyme.body[0].y == wall.body[i].y)
                {
                    RandomSnake();
                }
                else
                {
                    continue;
                }
            }
        }
    }
}

