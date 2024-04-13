using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cike.CikeEngine;

namespace Cike
{
    class PlayerScript : CikeEngine.Script
    {
        public GameObject player = new GameObject();

        public int i = 0;

        CikeEngine.Input input = new CikeEngine.Input();

        public override void OnDraw()
        {

        }

        public override void OnLoad()
        {
            Console.WriteLine("Loaded");
            gameObject.transform.scale = new Vector2D(32, 32);
            gameObject.transform.position = new Vector2D(0, 256);
        }

        public override void OnUpdate()
        {
            Vector2D movement = new Vector2D();

            if (Input.KeyButtonDown(Keys.W))
            {
                movement.y -= 1;
            }
            if (Input.KeyButtonDown(Keys.S))
            {
                movement.y += 1;
            }
            if (Input.KeyButtonDown(Keys.A))
            {
                movement.x -= 1;
            }
            if (Input.KeyButtonDown(Keys.D))
            {
                movement.x += 1;
            }

            if(gameObject.transform.position.x < 0)
            {
                Scene newScene = new NewScene();
                TestGame.ChangeScene(newScene);
            }

            movement = movement.Normaize();
            Vector2D prevPos = gameObject.transform.position;
            gameObject.transform.position += movement * TestGame.deltaTime;
            Vector2D newPos = gameObject.transform.position;
            float speed = (newPos - prevPos).Magnitude();
            Vector2D mousePos = Input.GetLocalMousePos();
            float angle = (float)(Math.Atan2(mousePos.y - gameObject.transform.position.y, mousePos.x - gameObject.transform.position.x) * 180 / Math.PI);
            gameObject.transform.rotation = angle;
            float fps = 1 / TestGame.deltaTime * 1000;
        }
    }
}
