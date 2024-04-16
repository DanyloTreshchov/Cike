using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cike.CikeEngine
{
    public class Collider2D
    {
        public Polygon[] polygons;
        
        public Collider2D(Polygon[] polygons)
        {
            this.polygons = polygons;
        }

        public event Action<Collider2D> OnCollision;

        public void CheckCollision(Collider2D other)
        {
            foreach (Polygon p1 in polygons)
            {
                foreach (Polygon p2 in other.polygons)
                {
                    if (p1.Intersects(p2))
                    {
                        OnCollision?.Invoke(this);
                    }
                }
            }
        }
        

    }
}