using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Cike.CikeEngine
{
    public class Sprite2D : Shape2D
    {
        public Image genericSprite = Image.FromFile("./Graphics/Sprites/unknown.png");
        public Image sprite { get; set; }

        public Sprite2D()
        {
            this.sprite = genericSprite;
        }
        public Sprite2D(string path)
        {
            sprite = Image.FromFile(path);
        }
        public Sprite2D(Image image)
        {
            sprite = image;
        }
        public override void Draw(Graphics g, Vector2D position, Vector2D scale)
        {
            g.DrawImage(sprite, position.x, position.y, scale.x, scale.y);
        }
    }
}
