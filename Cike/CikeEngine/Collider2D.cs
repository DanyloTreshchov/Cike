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
        public GameObject gameObject;
        
        public Collider2D(GameObject gameObject)
        {
            this.gameObject = gameObject;
            polygons = new Polygon[1];
            polygons[0] = new Polygon(new Vector2D[] { new Vector2D(-0.5f, -0.5f), new Vector2D(0.5f, -0.5f), new Vector2D(0.5f, 0.5f), new Vector2D(-0.5f, 0.5f) });
        }

        public Collider2D(GameObject gameObject, Polygon[] polygons)
        {
            this.gameObject = gameObject;
            this.polygons = polygons;
        }

        bool PolygonCollision(Polygon p1, Polygon p2, Transform t1, Transform t2)
        {
            Vector2D pos1 = t1.position;
            Vector2D pos2 = t2.position;
            Vector2D scale1 = t1.scale;
            Vector2D scale2 = t2.scale;

            Polygon temp = new Polygon(new Vector2D[p1.points.Length]);
            foreach (Vector2D point in p1.points)
            {
                Vector2D rotatedPoint = new Vector2D(point.x * (float)Math.Cos(t1.rotation * Math.PI / 180) - point.y * (float)Math.Sin(t1.rotation * Math.PI / 180), point.x * (float)Math.Sin(t1.rotation * Math.PI / 180) + point.y * (float)Math.Cos(t1.rotation * Math.PI / 180));
                rotatedPoint *= scale1;
                rotatedPoint += pos1;
                temp.points[p1.points.ToList().IndexOf(point)] = rotatedPoint;
            }
            p1 = temp;

            temp = new Polygon(new Vector2D[p2.points.Length]);
            foreach (Vector2D point in p2.points)
            {
                Vector2D rotatedPoint = new Vector2D(point.x * (float)Math.Cos(t2.rotation * Math.PI / 180) - point.y * (float)Math.Sin(t2.rotation * Math.PI / 180), point.x * (float)Math.Sin(t2.rotation * Math.PI / 180) + point.y * (float)Math.Cos(t2.rotation * Math.PI / 180));
                rotatedPoint *= scale2;
                rotatedPoint += pos2;
                temp.points[p2.points.ToList().IndexOf(point)] = rotatedPoint;
            }
            p2 = temp;

            for (int i = 0; i < p1.points.Length; i++)
            {
                Vector2D p1Start = p1.points[i];
                Vector2D p1End = p1.points[(i + 1) % p1.points.Length];
                Vector2D edge = p1End - p1Start;
                Vector2D normal = new Vector2D(-edge.y, edge.x);
                float minA = float.MaxValue;
                float maxA = float.MinValue;
                for (int j = 0; j < p1.points.Length; j++)
                {
                    float projected = normal.x * p1.points[j].x + normal.y * p1.points[j].y;
                    if (projected < minA)
                    {
                        minA = projected;
                    }
                    if (projected > maxA)
                    {
                        maxA = projected;
                    }
                }
                float minB = float.MaxValue;
                float maxB = float.MinValue;
                for (int j = 0; j < p2.points.Length; j++)
                {
                    float projected = normal.x * p2.points[j].x + normal.y * p2.points[j].y;
                    if (projected < minB)
                    {
                        minB = projected;
                    }
                    if (projected > maxB)
                    {
                        maxB = projected;
                    }
                }
                if (maxA < minB || maxB < minA)
                {
                    return false;
                }
            }
            return true;
        }

        public List<GameObject> Colliding()
        {
            List<GameObject> colliding = new List<GameObject>();
            foreach (GameObject go in CikeEngine.gameObjects)
            {
                if (go.collider == null || go == this.gameObject)
                {
                    continue;
                }
                else
                {
                    foreach (Polygon p1 in polygons)
                    {
                        foreach (Polygon p2 in go.collider.polygons)
                        {
                            if (PolygonCollision(p1, p2, this.gameObject.transform, go.transform))
                            {
                                colliding.Add(go);
                            }
                        }
                    }
                }
            }
            return colliding;
        }
        
    }
}