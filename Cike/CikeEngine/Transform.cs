using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cike.CikeEngine
{
    public class Transform
    {
        public Vector2D position = new Vector2D();
        public Vector2D scale = new Vector2D(1, 1);
        public float rotation = 0;
        public Vector2D pivot = new Vector2D();
        public Transform()
        {
            position = new Vector2D();
            scale = new Vector2D(1, 1);
            rotation = 0;
        }
        public Transform(Transform transform)
        {
            position = transform.position;
            scale = transform.scale;
            rotation = transform.rotation;
        }
        public Transform(Vector2D position)
        {
            this.position = position;
        }
        public Transform(Vector2D position, Vector2D scale)
        {
            this.position = position;
            this.scale = scale;
        }

        public void Translate(Vector2D translation)
        {
            position += translation;
        }
        public void Scale(Vector2D scale) { this.scale *= scale; }
        public void Scale(float scale) { this.scale *= scale; }
        public void Rotate(float rotation) { this.rotation += rotation; }

        public static Transform operator +(Transform t1, Transform t2)
        {
            return new Transform(t1.position + t2.position, t1.scale * t2.scale);
        }

        public static Transform operator -(Transform t1, Transform t2)
        {
            return new Transform(t1.position - t2.position, new Vector2D(t1.scale.x / t2.scale.x, t1.scale.y / t2.scale.y));
        }

        public static Transform operator *(Transform t1, Transform t2)
        {
            return new Transform(t1.position * t2.position, t1.scale * t2.scale);
        }

        public static Transform operator /(Transform t1, Transform t2)
        {
            return new Transform(new Vector2D(t1.position.x / t2.position.x, t1.position.y / t2.position.y), new Vector2D(t1.scale.x / t2.scale.x, t1.scale.y / t2.scale.y));
        }
    }
}
