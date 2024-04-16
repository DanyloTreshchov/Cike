using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection;

namespace Cike.CikeEngine
{
    public class Canvas : Form
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

        public static float deltaTime = 0;

        public static Input input = null;

        public static List<GameObject> gameObjects = new List<GameObject>();

        public static List<Script> scripts = new List<Script>();

        public CikeEngine(Vector2D screenSize, string title)
        {
            this.screenSize = screenSize;
            this.title = title;

            this.window = new Canvas();
            window.Size = new Size((int)screenSize.x, (int)screenSize.y);
            window.Text = title;
            window.Paint += Renderer;

            window.FormBorderStyle = FormBorderStyle.FixedSingle;
            window.MaximizeBox = false;

            input = new Input(window);

        
        }

        public void Run()
        {
            gameLoopThread = new Thread(GameLoop);
            gameLoopThread.Start();
            Application.Run(window);
        }

        public void passScript(Script script)
        {
            scripts.Add(script);
            script.PassFunctionsToEngine();
        }

        public static void RevokeScript(Script script)
        {
            scripts.Remove(script);
            onLoad -= script.OnLoad;
            onUpdate -= script.OnUpdate;
            onDraw -= script.OnDraw;
        }

        void GameLoop()
        {
            try
            {
                onLoad();
            }
            catch { }
            DateTime startTime = DateTime.Now;
            while (gameLoopThread.IsAlive)
            {
                try
                {
                    onDraw();
                    window.BeginInvoke((MethodInvoker)delegate { window.Refresh(); });
                    DateTime endTime = DateTime.Now;
                    TimeSpan timeSpan = endTime - startTime;
                    deltaTime = (float)timeSpan.TotalMilliseconds;
                    onUpdate();
                    input.OnUpdate();
                    startTime = DateTime.Now;
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

            List<GameObject> tempGameObjects;

            lock (CikeEngine.gameObjects)
            {
                try
                {
                    tempGameObjects = gameObjects.ToList();
                }
                catch (ArgumentException)
                {
                    return;
                }
            }

            foreach (GameObject obj in tempGameObjects)
            {
                obj.Draw(g);
            }
        }

        public delegate void OnLoad();
        private static OnLoad onLoad;
        public delegate void OnUpdate();
        private static OnUpdate onUpdate;
        public delegate void OnDraw();
        private static OnDraw onDraw;

        public static void GetOnLoad(OnLoad onLoadVoid)
        {
            onLoad += onLoadVoid;
        }

        public static void GetOnUpdate(OnUpdate onUpdateVoid)
        {
            onUpdate += onUpdateVoid;
        }

        public static void GetOnDraw(OnDraw onDrawVoid)
        {
            onDraw += onDrawVoid;
        }

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

    public static class ReflectiveEnumerator
    {
        static ReflectiveEnumerator() { }

        public static IEnumerable<T> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class, IComparable<T>
        {
            List<T> objects = new List<T>();
            foreach (Type type in
                Assembly.GetAssembly(typeof(T)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
            {
                objects.Add((T)Activator.CreateInstance(type, constructorArgs));
            }
            objects.Sort();
            return objects;
        }
    }
}
