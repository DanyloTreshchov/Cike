using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cike.CikeEngine;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Cike
{
    public class TestGame : CikeEngine.CikeEngine
    {
        public Random r = new Random();

        public TestGame() : base (new Vector2D(512, 512), "TestGame") 
        {
            Player player = new Player();
            passScript(player);
            Console.WriteLine("TestGame Loaded");
            Run();
        }

        
    }
}
