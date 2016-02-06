    using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
    using System.Runtime.Serialization.Formatters.Binary;

namespace snakebyme
{
    [Serializable]
    class Drawer
    {
        public List<Point> body = new List<Point>();
        public ConsoleColor color;
        public char sign;
        public Drawer()
        {
            color = ConsoleColor.Blue;
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }

        public void Save()
        {
            string data = "";
            FileStream fs = new FileStream(data, FileMode.OpenOrCreate, FileAccess.Write);
                    BinaryFormatter wr = new BinaryFormatter();
            switch (sign)
            {
                case '#':
                    data = "wall.dat";
                    break;
                case '*':
                    data = "snake.dat";
                    break;
                case '$':
                    data = "food.dat";
                    break;

                    
                    wr.Serialize(fs, this);

                    fs.Close();

            }
        }

        public void Resume()
        {    string file = "";
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            BinaryFormatter xs = new BinaryFormatter();
            switch (sign)
            {
                case '#':
                    file = "wall.dat";
                    break;
                case '$':
                    file = "food.dat";
                    break;
                case '*':
                    file = "snake.dat";
                    break;

                    

            }
        }
    }
}

