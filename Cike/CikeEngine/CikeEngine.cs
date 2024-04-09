using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Cike.CikeEngine
{
    class Canvas : Form
    {
        public Canvas()
        {
            this.DoubleBuffered = true;
        }
    }
    public abstract class CikeEngine
    {
        private Vector2D screenSize = new Vector2D(512, 512);
        private string title;
        private Canvas window = null;

        public CikeEngine(Vector2D screenSize, string title)
        {
            this.screenSize = screenSize;
            this.title = title;

            this.window = new Canvas();
            window.Size = new Size((int)screenSize.X, (int)screenSize.Y);
            window.Text = title;

            Application.Run(window);
        }
    }
}
