using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cike.CikeEngine
{
    internal class Input
    {
        private static string KeyboardState = "";

        private static string MouseButtonsState = "";

        private static Vector2D LocalMousePosition = new Vector2D();

        //Returinig Inputs

        public static Vector2D GetLocalMousePos()
        {
            return LocalMousePosition;
        }

        public static bool MouseButtonDown(MouseButtons button)
        {
            return MouseButtonsState.Contains(button.ToString() + '$');
        }

        public static bool KeyButtonDown(Keys key)
        {
            return KeyboardState.Contains(key.ToString() + '$');
        }

        //Getting Inputs
        public static void MouseMoveInputEvent(object sender, MouseEventArgs e)
        {
            LocalMousePosition = new Vector2D(e.Location.X, e.Location.Y);
        }

        public static void MouseButtonDownInputEvent(object sender, MouseEventArgs e)
        {
            MouseButtonsState += e.Button.ToString() + '$';
            Console.WriteLine($"{e.Button.ToString()} was pressed! MouseButtonsState: {MouseButtonsState}");
        }

        public static void MouseButtonUpInputEvent(object sender, MouseEventArgs e)
        {
            MouseButtonsState = MouseButtonsState.Remove(MouseButtonsState.IndexOf(e.Button.ToString() + '$'), e.Button.ToString().Length + 1);
            Console.WriteLine($"{e.Button.ToString()} was released! MouseButtonsState: {MouseButtonsState}, index {MouseButtonsState.IndexOf(e.Button.ToString())}, length {e.Button.ToString().Length}");
        }

        public static void KeyboardButtonDownEvent(object sebder, KeyEventArgs e)
        {
            KeyboardState += KeyboardState.Contains(e.KeyCode.ToString() + '$') ? null : e.KeyCode.ToString() + '$';
            Console.WriteLine($"{e.KeyCode.ToString()} was pressed! KeyboardButtonsState: {KeyboardState}");
        }

        public static void KeyboardButtonUpEvent(object sebder, KeyEventArgs e)
        {
            KeyboardState = KeyboardState.Remove(KeyboardState.IndexOf(e.KeyCode.ToString() + '$'), e.KeyCode.ToString().Length + 1);
            Console.WriteLine($"{e.KeyCode.ToString()} was released! MouseButtonsState: {KeyboardState}, index {KeyboardState.IndexOf(e.KeyCode.ToString())}, length {e.KeyCode.ToString().Length}");
        }
    }
}
