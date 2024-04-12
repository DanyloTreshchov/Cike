using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cike.CikeEngine;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace Cike
{
    class TestGame : CikeEngine.CikeEngine
    {
        public TestGame() : base (new Vector2D(512, 512), "TestGame") { }

        public GameObject player = new GameObject();

        public int i = 0;

        public override void OnDraw()
        {
            
        }

        public override void OnLoad()
        {
            Console.WriteLine("Loaded");
            player.transform.scale = new Vector2D(32, 32);
            player.transform.position = new Vector2D(0, 256);
        }

        public override void OnUpdate()
        {
            player.transform.position.x += 1;
            player.transform.rotation += 1;

            GameObject gameObject = CikeEngine.CikeEngine.CreateGameObject(player.transform, new Circle2D(Color.Black, Color.Black));
            Console.WriteLine(CikeEngine.CikeEngine.gameObjects.Count());
        }
    }
}
