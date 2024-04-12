using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Cike.CikeEngine
{
    public class Circle2D : Shape2D
    {
        public Color drawColor = Color.FromArgb(255, 255, 255, 0);
        public Color fillColor = Color.FromArgb(255, 255, 255, 0);
        public Circle2D()
        {

        }
        public Circle2D(Color drawColor, Color fillColor)
        {
            this.drawColor = drawColor;
            this.fillColor = fillColor;
        }

        public override void Draw(Graphics g, Vector2D position, Vector2D scale)
        {
            g.FillEllipse(new SolidBrush(fillColor), position.x, position.y, scale.x, scale.y);
            g.DrawEllipse(new Pen(drawColor), position.x, position.y, scale.x, scale.y);
        }
    }
}
