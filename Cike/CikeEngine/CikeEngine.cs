using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Cike.CikeEngine
{
    class Canvas : Form
    {
        public Canvas()
        {
            this.DoubleBuffered = true;
        }
    }
    public abstract class CikeEngine
    {
        private Vector2D screenSize = new Vector2D(512, 512);
        private string title;
        private Canvas window = null;
        private Thread gameLoopThread = null;

        public Color backgroundColor = Color.White;

        public static List<GameObject> gameObjects = new List<GameObject>();

        public CikeEngine(Vector2D screenSize, string title)
        {
            this.screenSize = screenSize;
            this.title = title;

            this.window = new Canvas();
            window.Size = new Size((int)screenSize.x, (int)screenSize.y);
            window.Text = title;
            window.Paint += Renderer;

            gameLoopThread = new Thread(GameLoop);
            gameLoopThread.Start();

            Application.Run(window);
        }

        void GameLoop()
        {
            OnLoad();
            while (gameLoopThread.IsAlive)
            {
                try
                {
                    OnDraw();
                    window.BeginInvoke((MethodInvoker)delegate { window.Refresh(); });
                    OnUpdate();
                    Thread.Sleep(1);
                }
                catch
                {

                }
            }
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(backgroundColor);

            List<GameObject> tempGameObjects = new List<GameObject>(CikeEngine.gameObjects);

            foreach(GameObject obj in tempGameObjects)
            {
                obj.Draw(g);
            }
        }

        public abstract void OnLoad();

        public abstract void OnUpdate();

        public abstract void OnDraw();

        public static GameObject CreateGameObject()
        {
            GameObject obj = new GameObject();
            AddGameObject(obj);
            return obj;
        }

        public static GameObject CreateGameObject(Shape2D shape)
        {
            GameObject obj = new GameObject(shape);
            AddGameObject(obj);
            return obj;
        }

        public static GameObject CreateGameObject(Vector2D position, Shape2D shape)
        {
            GameObject obj = new GameObject(position, shape);
            AddGameObject(obj);
            return obj;
        }

        public static GameObject CreateGameObject(Transform transform, Shape2D shape)
        {
            GameObject obj = new GameObject(transform, shape);
            AddGameObject(obj);
            return obj;
        }
        public static void AddGameObject(GameObject obj)
        {
            gameObjects.Add(obj);
        }

        public static void RemoveGameObject(GameObject obj)
        {
            gameObjects.Remove(obj);
        }
    }
}
