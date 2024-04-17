using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cike.CikeEngine;

namespace Cike
{
    class Player : CikeEngine.Script
    {
        public GameObject player = new GameObject();

        public GameObject platform = new GameObject();

        public int i = 0;

        public override void OnDraw()
        {

        }

        public override void OnLoad()
        {
            Console.WriteLine("Loaded");
            player.transform.scale = new Vector2D(64, 64);
            player.transform.position = new Vector2D(256, 256);

            platform.transform.scale = new Vector2D(512, 32);
            platform.transform.position = new Vector2D(256, 480);
            platform.collider = new Collider2D(platform);
        }

        public int count = 0;

        public override void OnUpdate()
        {
            Vector2D movement = new Vector2D();

            if (TestGame.input.GetKeyPressed(Keys.W))
            {
                movement.y -= 1;
            }
            if (TestGame.input.GetKeyPressed(Keys.S))
            {
                movement.y += 1;
            }
            if (TestGame.input.GetKeyPressed(Keys.A))
            {
                movement.x -= 1;
            }
            if (TestGame.input.GetKeyPressed(Keys.D))
            {
                movement.x += 1;
            }

            if(TestGame.input.GetKeyDown(Keys.Space))
            {
                GameObject projectile = new GameObject(new Vector2D(player.transform.position.x, player.transform.position.y), new Sprite2D());
                projectile.transform.scale = new Vector2D(16, 16);
                projectile.transform.rotation = player.transform.rotation;
                Projectile p = new Projectile(projectile);
                p.PassFunctionsToEngine();
                Console.WriteLine(count++);
            }

            if (TestGame.input.GetKeyUp(Keys.Space))
            {
                GameObject projectile = new GameObject(new Vector2D(player.transform.position.x, player.transform.position.y), new Sprite2D());
                projectile.transform.scale = new Vector2D(16, 16);
                projectile.transform.rotation = player.transform.rotation;
                projectile.collider = new Collider2D(projectile);
                Projectile p = new Projectile(projectile);
                p.PassFunctionsToEngine();
                Console.WriteLine(count++);
            }

            movement = movement.Normaize();
            Vector2D prevPos = player.transform.position;
            player.transform.position += movement * TestGame.deltaTime;
            Vector2D newPos = player.transform.position;
            float speed = (newPos - prevPos).Magnitude();
            Vector2D mousePos = TestGame.input.GetMousePosition();
            float angle = (float)(Math.Atan2(mousePos.y - player.transform.position.y, mousePos.x - player.transform.position.x) * 180 / Math.PI);
            player.transform.rotation = angle;

            //Console.WriteLine($"Objects: {TestGame.gameObjects.Count()}, Scripts: {TestGame.scripts.Count()}");
        }
    }
}
