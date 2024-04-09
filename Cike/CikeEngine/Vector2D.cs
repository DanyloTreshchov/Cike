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
        public float X { get; set; }
        public float Y { get; set; }

        public Vector2D()
        {
            this.X = Zero().X;
            this.Y = Zero().Y;
        }

        public Vector2D(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Vector2D Zero()
        {
            return new Vector2D(0, 0);
        }

        //Operators:

        public static Vector2D operator -(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static Vector2D operator +(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector2D operator *(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.X * v2.X, v1.Y * v2.Y);
        }

        public static Vector2D operator *(Vector2D v, float scalar)
        {
            return new Vector2D(v.X * scalar, v.Y * scalar);
        }

        public static Vector2D operator /(Vector2D v, float scalar)
        {
            return new Vector2D(v.X / scalar, v.Y / scalar);
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(X * X + Y * Y);
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
