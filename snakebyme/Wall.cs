using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snakebyme
{
    [Serializable]
    class Wall : Drawer
    {
        public Wall()
        {
            sign = '#';
        }
    }
}

