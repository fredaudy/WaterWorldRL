using System;
using System.Collections.Generic;
using System.Text;
using SadConsole.Components;
using SadConsole.Input;
using Microsoft.Xna.Framework;

namespace SadConsoleGame
{
    class MyMouseComponent : MouseConsoleComponent
    {
        public override void ProcessMouse(SadConsole.Console console, MouseConsoleState state, out bool handled)
        {
            if (state.Mouse.IsOnScreen)
            {
                console.Print(0, 0, "cellposition X : " + state.CellPosition.X + " ; Y : " + state.CellPosition.Y);
                //console.SetBackground(state.CellPosition.X, state.CellPosition.Y, Color.HotPink);
                var child = console.Children[0];
                child.Position = state.CellPosition;
                //console.Clear();
            }

            handled = false;
        }
    }
}
