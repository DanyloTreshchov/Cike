using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cike.CikeEngine
{
    public class Input : Script
    {
        private Dictionary<Keys, bool> keyStates = new Dictionary<Keys, bool>();
        private Dictionary<Keys, bool> previousKeyStates = new Dictionary<Keys, bool>();
        private Vector2D mousePosition;
        private Dictionary<MouseButtons, bool> mouseButtonStates = new Dictionary<MouseButtons, bool>();
        private Dictionary<MouseButtons, bool> previousMouseButtonStates = new Dictionary<MouseButtons, bool>();

        public Input(Form form)
        {
            form.KeyDown += OnKeyDown;
            form.KeyUp += OnKeyUp;
            form.MouseMove += OnMouseMove;
            form.MouseDown += OnMouseDown;
            form.MouseUp += OnMouseUp;

            // Initialize key states
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
            {
                keyStates[key] = false;
                previousKeyStates[key] = false;
            }

            // Initialize mouse button states
            foreach (MouseButtons button in Enum.GetValues(typeof(MouseButtons)))
            {
                mouseButtonStates[button] = false;
                previousMouseButtonStates[button] = false;
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            keyStates[e.KeyCode] = true;
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            keyStates[e.KeyCode] = false;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            mousePosition = new Vector2D(e.Location.X, e.Location.Y);
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            mouseButtonStates[e.Button] = true;
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            mouseButtonStates[e.Button] = false;
        }

        public bool GetKeyDown(Keys key)
        {
            bool pressed = keyStates[key] && !previousKeyStates[key];
            //previousKeyStates[key] = keyStates[key];
            return pressed;
        }

        public bool GetKeyUp(Keys key)
        {
            bool released = !keyStates[key] && previousKeyStates[key];
            //previousKeyStates[key] = keyStates[key];
            return released;
        }

        public bool GetKeyPressed(Keys key)
        {
            return keyStates[key];
        }

        public bool GetMouseButtonDown(MouseButtons button)
        {
            bool pressed = mouseButtonStates[button] && !previousMouseButtonStates[button];
            //previousMouseButtonStates[button] = mouseButtonStates[button];
            return pressed;
        }

        public bool GetMouseButtonUp(MouseButtons button)
        {
            bool released = !mouseButtonStates[button] && previousMouseButtonStates[button];
            //previousMouseButtonStates[button] = mouseButtonStates[button];
            return released;
        }

        public bool GetMouseButtonPressed(MouseButtons button)
        {
            return mouseButtonStates[button];
        }

        public Vector2D GetMousePosition()
        {
            return mousePosition != null ? mousePosition : new Vector2D();
        }

        public override void OnUpdate()
        {
            
            foreach (var kvp in keyStates)
            {
                previousKeyStates[kvp.Key] = kvp.Value;
            }

            // Update previous mouse button states
            foreach (var kvp in mouseButtonStates)
            {
                previousMouseButtonStates[kvp.Key] = kvp.Value;
            }
        }

        public override void OnDraw()
        {

        }

        public override void OnLoad()
        {

        }

        public override void PassFunctionsToEngine()
        {
            base.PassFunctionsToEngine();
            
        }
    }
}
