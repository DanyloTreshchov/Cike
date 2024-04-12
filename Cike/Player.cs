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

        public int i = 0;

        CikeEngine.Input input = new CikeEngine.Input();

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
            movement = movement.Normaize();
            Vector2D prevPos = player.transform.position;
            player.transform.position += movement * TestGame.deltaTime;
            Vector2D newPos = player.transform.position;
            float speed = (newPos - prevPos).Magnitude();
            Vector2D mousePos = Input.GetLocalMousePos();
            float angle = (float)(Math.Atan2(mousePos.y - player.transform.position.y, mousePos.x - player.transform.position.x) * 180 / Math.PI);
            Console.WriteLine(angle);
            player.transform.rotation = angle;
            Console.WriteLine(speed);
            float fps = 1 / TestGame.deltaTime * 1000;
        }
    }
}
