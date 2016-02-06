using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snakebyme
{
    class Snake : Drawer
    {
        public int MyProperty { get; set; }
        public Snake()
        {
            sign = 'o';
        }

        public void Move(int dx, int dy)
        {
            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            body[0].x = body[0].x + dx;
            body[0].y = body[0].y + dy;

            if (Game.snakebyme.body[0].x == 0 || Game.snakebyme.body[0].x == 47 || Game.snakebyme.body[0].y == 0 || Game.snakebyme.body[0].y == 47)// if snake crosses the border
            {
                Console.Clear();
                Console.SetCursorPosition(20, 10);
                Console.WriteLine("Game over!");
                Game.isActive = false;
            }

            if (Game.snakebyme.body[0].x == Game.food.body[0].x && Game.snakebyme.body[0].y == Game.food.body[0].y)//check for eating the food
            {
                Program.score++;
                Game.snakebyme.body.Add(new Point { x = Game.food.body[0].x, y = Game.food.body[0].y });// increase in lenght while eating

                if (Program.score % 4 == 0 && Program.score!= 0)// every 4th food new level
                {
                    Program.level++;
                    Console.Clear();//clears everything snake become original size
                    Game.isActive = false;
                }
                
                RandomFood();
            }

            for (int i = 0; i < Game.wall.body.Count; ++i)
            {
                if (Game.snakebyme.body[0].x == Game.wall.body[i].x && Game.snakebyme.body[0].y == Game.wall.body[i].y)//check for walls
                {
                    Console.Clear();
                    Console.SetCursorPosition(20, 10);
                    Console.WriteLine("Game over!");
                    Game.isActive = false;
                }
            }
        }
        public void RandomFood()
        {
            Game.food.body[0].x = new Random().Next(0, 40);//
            Game.food.body[0].y = new Random().Next(0, 40);

            for (int i = 0; i < Game.wall.body.Count; ++i)
            {
                if (Game.food.body[0].x == Game.wall.body[i].x && Game.food.body[0].y == Game.wall.body[i].y)
                {
                    RandomFood();
                }
                else
                {
                    continue;
                }
            }

            for (int i = 0; i < Game.snakebyme.body.Count; ++i)
            {
                if (Game.food.body[0].x == Game.snakebyme.body[i].x && Game.food.body[0].y == Game.snakebyme.body[i].y)
                {
                    RandomFood();
                }
                else
                {
                    continue;
                }
            }
        }
    }
}


