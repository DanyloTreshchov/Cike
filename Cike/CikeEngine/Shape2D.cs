using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cike.CikeEngine
{
    public abstract class Shape2D
    {
        public Shape2D()
        {

        }
        public abstract void Draw(Graphics g, Vector2D position, Vector2D scale);
    }
}
