using System;
using System.Collections.Generic;
using System.Text;
using SadConsole;
using Console = SadConsole.Console;
using Microsoft.Xna.Framework;
using SadConsole.Input;

namespace SadConsoleGame
{
    class MapScreen : ContainerConsole
    {
        public Console MapConsole { get; }

        public Cell PlayerGlyph { get; set; }

        private Point _playerPosition;

        public Point PlayerPosition
        {
            get => _playerPosition;
            private set 
            {
                MapConsole.Clear(_playerPosition.X, _playerPosition.Y);
                _playerPosition = value;
                PlayerGlyph.CopyAppearanceTo(MapConsole[_playerPosition.X, _playerPosition.Y]);
            }
        }


        public MapScreen()
        {
            var _mapScreenWidth = (int)((Global.RenderWidth / Global.FontDefault.Size.X) * 1.0);
            var _mapScreeHeight = (int)((Global.RenderHeight / Global.FontDefault.Size.Y) * 1.0);

            // setup map
            this.MapConsole = new Console(_mapScreenWidth, _mapScreeHeight);
            this.MapConsole.DrawBox(new Rectangle(0, 0, _mapScreenWidth, _mapScreeHeight)
                , new Cell(Color.DarkGoldenrod, Color.DarkGoldenrod));
            this.MapConsole.Parent = this;

            // setup player glyph
            PlayerGlyph = new Cell(Color.White, Color.Black, 1);
            _playerPosition = new Point(1, 1);
            PlayerGlyph.CopyAppearanceTo(MapConsole[PlayerPosition.X, PlayerPosition.Y]);
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            Point newPlayerPosition = PlayerPosition;

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Up))
            {
                newPlayerPosition += SadConsole.Directions.North;
            }
            else if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Down))
            {
                newPlayerPosition += SadConsole.Directions.South;
            }

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Left))
            {
                newPlayerPosition += SadConsole.Directions.West;
            }
            else if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Right))
            {
                newPlayerPosition += SadConsole.Directions.East;
            }

            if (newPlayerPosition != PlayerPosition)
            {
                PlayerPosition = newPlayerPosition;
                return true;
            }

            return false;
        }
    }
}
