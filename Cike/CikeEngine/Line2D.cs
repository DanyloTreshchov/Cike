using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Cike.CikeEngine
{
    public class Line2D : Shape2D
    {
        public Color color = Color.Black;
        public Line2D()
        {

        }
        public Line2D(Color color)
        {
            this.color = color;
        }
        public override void Draw(Graphics g, Vector2D position, Vector2D scale)
        {
            g.DrawLine(new Pen(color), position.x, position.y, scale.x, scale.y);
        }
    }
}
