using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cike.CikeEngine;

namespace Cike
{
    public class Projectile : Script
    {
        GameObject projectile = null;

        public Projectile(GameObject projectile)
        {
            this.projectile = projectile;
        }

        void Destroy()
        {
            projectile.Destroy();
            TestGame.RevokeScript(this);
        }

        void checkBounds()
        {
            if(projectile.transform.position.x < 0 || projectile.transform.position.x > 512 || projectile.transform.position.y < 0 || projectile.transform.position.y > 512)
            {
                Destroy();
            }
        }   

        public override void OnDraw()
        {
            
        }

        public override void OnLoad()
        {
            
        }

        public override void OnUpdate()
        {
            if(projectile != null)
            {
                projectile.transform.position += new Vector2D((float)Math.Cos(projectile.transform.rotation * Math.PI / 180), (float)Math.Sin(projectile.transform.rotation * Math.PI / 180)) * 5 * TestGame.deltaTime;
            }
            checkBounds();
        }
    }
}
