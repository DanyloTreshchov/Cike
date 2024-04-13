using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cike.CikeEngine;

namespace Cike
{
    public class NewScene : Scene
    {
        public override void Initialize()
        {
            gameObjects.Add(new Player());
            gameObjects.Add(new Player());

            base.Initialize();
        }

    }
}
