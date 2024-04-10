using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cike.CikeEngine;

namespace Cike
{
    class TestGame : CikeEngine.CikeEngine
    {
        public TestGame() : base (new Vector2D(512, 512), "TestGame") { }

        public override void OnDraw()
        {
            
        }

        public override void OnLoad()
        {
            Console.WriteLine("Loaded");
        }

        public override void OnUpdate()
        {
            
        }
    }
}
