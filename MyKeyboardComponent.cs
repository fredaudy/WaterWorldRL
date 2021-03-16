using System;
using System.Collections.Generic;
using System.Text;
using SadConsole.Components;
using SadConsole.Input;
using Microsoft.Xna.Framework;

namespace SadConsoleGame
{
    class MyKeyboardComponent : KeyboardConsoleComponent
    {
        public override void ProcessKeyboard(SadConsole.Console console, Keyboard info, out bool handled)
        {
            if (info.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.Escape))
            {
                Environment.Exit(0);
            }
            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Space))
            {
                var cursorPos = console.Cursor.Position;
                console.SetGlyph(cursorPos.X, cursorPos.Y + 1, 1, Color.Aquamarine);
                console.SetGlyph(cursorPos.X, cursorPos.Y - 1, 3);
                console.SetGlyph(cursorPos.X, cursorPos.Y, 5);
                //console.DefaultBackground = Color.White.GetRandomColor(SadConsole.Global.Random);
                //console.Clear();
            }
            handled = false;
        }
    }
}
