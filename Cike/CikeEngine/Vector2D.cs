using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cike.CikeEngine
{
    public class Vector2D
    {
        public float x { get; set; }
        public float y { get; set; }

        public Vector2D()
        {
            this.x = Zero().x;
            this.y = Zero().y;
        }

        public Vector2D(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2D Zero()
        {
            return new Vector2D(0, 0);
        }

        //Operators:

        public static Vector2D operator -(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.x - v2.x, v1.y - v2.y);
        }

        public static Vector2D operator +(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vector2D operator *(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.x * v2.x, v1.y * v2.y);
        }

        public static Vector2D operator *(Vector2D v, float scalar)
        {
            return new Vector2D(v.x * scalar, v.y * scalar);
        }

        public static Vector2D operator /(Vector2D v, float scalar)
        {
            return new Vector2D(v.x / scalar, v.y / scalar);
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }

        public Vector2D Normaize()
        {
            if(Magnitude() == 0)
            {
                return this;
            }
            return this / Magnitude();
        }
    }
}
