using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cike.CikeEngine
{
    public abstract class Scene
    {
        public static List<GameObject> gameObjects = new List<GameObject>();

        public Scene()
        {

        }

        public virtual void Initialize()
        {
            foreach (GameObject gameObject in gameObjects)
            {
                CikeEngine.AddGameObject(gameObject);

                gameObject.InitializeScripts();
            }
        }

        public void Destroy()
        {
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Destroy();
            }
        }
    }
}
