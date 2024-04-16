using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cike.CikeEngine
{
    public class Polygon
    {
        public Vector2D[] points;
        public Polygon(Vector2D[] points)
        {
            this.points = points;
        }

        public bool Intersects(Polygon other)
        {
            for (int i = 0; i < points.Length; i++)
            {
                Vector2D p1 = points[i];
                Vector2D p2 = points[(i + 1) % points.Length];
                Vector2D normal = new Vector2D(p2.y - p1.y, p1.x - p2.x);
                double minA = 0;
                double maxA = 0;
                for (int j = 0; j < points.Length; j++)
                {
                    double projected = normal.x * points[j].x + normal.y * points[j].y;
                    if (j == 0)
                    {
                        minA = projected;
                        maxA = projected;
                    }
                    else
                    {
                        if (projected < minA)
                        {
                            minA = projected;
                        }
                        if (projected > maxA)
                        {
                            maxA = projected;
                        }
                    }
                }
                double minB = 0;
                double maxB = 0;
                for (int j = 0; j < other.points.Length; j++)
                {
                    double projected = normal.x * other.points[j].x + normal.y * other.points[j].y;
                    if (j == 0)
                    {
                        minB = projected;
                        maxB = projected;
                    }
                    else
                    {
                        if (projected < minB)
                        {
                            minB = projected;
                        }
                        if (projected > maxB)
                        {
                            maxB = projected;
                        }
                    }
                }
                if (maxA < minB || maxB < minA)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
