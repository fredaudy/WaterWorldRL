using System;
using SadConsole;
using Console = SadConsole.Console;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SadConsoleGame
{
    class Program
    {

        public const int Width = 80;
        public const int Height = 25;

        static void Main(string[] args)
        {
            // Setup the engine and create the main window.
            SadConsole.Game.Create(Width, Height);

            // Hook the start event so we can add consoles to the system.
            SadConsole.Game.OnInitialize = Init;

            // Start the game.
            SadConsole.Game.Instance.Run();
            SadConsole.Game.Instance.Dispose();
        }

        private static void Init()
        {
            Global.CurrentScreen = new MapCellularAutomataScreen();
            Global.CurrentScreen.IsFocused = true;

            // Any startup code for your game. We will use an example console for now
            //var console = new Console(99, 99, SadConsole.Global.FontDefault.Master.GetFont(Font.FontSizes.One));
            //var childConsole = new Console(20, 3);
            //var childConsole1 = new Console(30, 3);

            //console.Position = new Point(0, 5);
            //console.Cursor.IsVisible = true;
            //console.IsFocused = true;   // mandatory for the keyboardComponent
            //console.Components.Add(new MyKeyboardComponent());
            //console.Components.Add(new MyMouseComponent());
            //console.Fill(null, Color.Goldenrod, null, null);


            //childConsole.Fill(Color.Aqua, Color.DarkKhaki, null, null);
            //childConsole.Print(1, 1, "first child");
            //childConsole.Position = new Point(1, 1);


            //childConsole1.Fill(Color.DeepPink, Color.DarkOrange, null, null);
            //childConsole1.Print(1, 1, "second child");
            //childConsole1.Position = new Point(21, 0);

            //console.Children.Add(childConsole);
            //childConsole.Children.Add(childConsole1);

            //SadConsole.Global.CurrentScreen = console;
        }
    }
}
