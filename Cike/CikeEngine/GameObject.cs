using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cike.CikeEngine
{
    public class GameObject
    {
        public Transform transform = new Transform();
        public Shape2D shape = new Sprite2D();
        public Collider2D collider = null;
        public string tag = "Untagged";


        public GameObject()
        {
            CikeEngine.AddGameObject(this);
        }
        public GameObject(Shape2D shape)
        {
            this.shape = shape;

            CikeEngine.AddGameObject(this);
        }
        public GameObject(Vector2D position, Shape2D shape)
        {
            this.transform.position = position;
            this.shape = shape;

            CikeEngine.AddGameObject(this);
        }
        public GameObject(Transform transform, Shape2D shape)
        {
            this.transform = transform;
            this.shape = shape;

            CikeEngine.AddGameObject(this);
        }
        public void Draw(Graphics g)
        {
            g.TranslateTransform(this.transform.pivot.x + this.transform.position.x, this.transform.pivot.y + this.transform.position.y);
            g.RotateTransform(this.transform.rotation);
            g.TranslateTransform(-1 * (this.transform.pivot.x + this.transform.position.x), -1 * (this.transform.pivot.y + this.transform.position.y));
            this.shape.Draw(g, this.transform.position - this.transform.scale / 2, this.transform.scale);
            g.ResetTransform();
        }

        public void Destroy()
        {
            if(this.shape is IDisposable)
            {
                (this.shape as IDisposable).Dispose();
            }
            CikeEngine.RemoveGameObject(this);
        }
    }
}
