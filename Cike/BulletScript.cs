using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cike.CikeEngine;

namespace Cike
{
    public class BulletScript : Script
    {
        public override void OnDraw()
        {
            
        }

        public override void OnLoad()
        {
            
        }

        public override void OnUpdate()
        {
            gameObject.transform.position += new Vector2D((float)Math.Cos(gameObject.transform.rotation * Math.PI / 180), (float)Math.Sin(gameObject.transform.rotation * Math.PI / 180)) * TestGame.deltaTime * 0.05f;
        }
    }
}
