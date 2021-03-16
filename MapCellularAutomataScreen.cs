using System;
using System.Collections.Generic;
using System.Text;
using SadConsole;
using Console = SadConsole.Console;
using ScrollingConsole = SadConsole.ScrollingConsole;
using Microsoft.Xna.Framework;
using SadConsole.Input;
using MapGeneration;

namespace SadConsoleGame
{
    class MapCellularAutomataScreen : ScrollingConsole
    {
        public ScrollingConsole MapConsole { get; }

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

        public List<Cell> cellWater2display { get; set; }
        public List<Cell> cellGround2display { get; set; }
        public CellularAutomata cellularAutomata { get; set; }
        public int _mapScreenWidth { get; private set; }
        public int _mapScreeHeight { get; private set; }

        public MapCellularAutomataScreen() : base(Program.Width, Program.Height)
        {
            this._mapScreenWidth = 300;
            this._mapScreeHeight = 300;
            //var _mapScreenWidth = (int)((Global.RenderWidth / Global.FontDefault.Size.X) * 1.0);
            //var _mapScreeHeight = (int)((Global.RenderHeight / Global.FontDefault.Size.Y) * 1.0);

            // setup map
            this.MapConsole = new ScrollingConsole(1, 1);
            this.MapConsole.Resize(_mapScreenWidth, _mapScreeHeight, false, new Rectangle(0, 0, Program.Width, Program.Height));
            this.MapConsole.Parent = this;
            this.MapConsole.IsFocused = true;
            this.MapConsole.IsVisible = true;

            cellWater2display = new List<Cell>();
            cellWater2display.Add(new Cell(Color.DeepSkyBlue, Color.Black, 247));
            cellWater2display.Add(new Cell(Color.CadetBlue, Color.Black, 247));
            cellWater2display.Add(new Cell(Color.LightBlue, Color.Black, 247));

            cellGround2display = new List<Cell>();
            cellGround2display.Add(new Cell(Color.DarkKhaki, Color.Black, 35));
            cellGround2display.Add(new Cell(Color.Goldenrod, Color.Black, 35));
            cellGround2display.Add(new Cell(Color.PaleGoldenrod, Color.Black, 35));

            cellularAutomata = new CellularAutomata(this._mapScreenWidth, this._mapScreeHeight, 57, 4, 3, 4);
            cellularAutomata.SetInitialMap();

            var rnd = new Random();
            for (int x = 0; x < cellularAutomata.newMap.GetLength(0); x++)
            {
                for (int y = 0; y < cellularAutomata.newMap.GetLength(1); y++)
                {
                    int i = rnd.Next(3);
                    if (cellularAutomata.newMap[x, y] == 1)
                    {
                        cellWater2display[i].CopyAppearanceTo(MapConsole[x, y]);
                    }
                    else
                    {
                        cellGround2display[i].CopyAppearanceTo(MapConsole[x, y]);
                    }
                }
            }

        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.F1))
            {
                cellularAutomata.SetGenerate1StepMap();
                var rnd = new Random();
                this.MapConsole.Resize(_mapScreenWidth, _mapScreeHeight, true, new Rectangle(0, 0, Program.Width, Program.Height));
                for (int x = 0; x < cellularAutomata.newMap.GetLength(0); x++)
                {
                    for (int y = 0; y < cellularAutomata.newMap.GetLength(1); y++)
                    {
                        int i = rnd.Next(3);
                        if (cellularAutomata.newMap[x, y] == 1)
                        {
                            cellWater2display[i].CopyAppearanceTo(MapConsole[x, y]);
                        }
                        else
                        {
                            cellGround2display[i].CopyAppearanceTo(MapConsole[x, y]);
                        }
                    }
                }
            }
            if (info.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Left))
            {
                MapConsole.ViewPort = new Rectangle(MapConsole.ViewPort.Left - 1, MapConsole.ViewPort.Top, 100, 100);
            }

            if (info.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Right))
            {
                MapConsole.ViewPort = new Rectangle(MapConsole.ViewPort.Left + 1, MapConsole.ViewPort.Top, 100, 100);
            }

            if (info.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Up))
            {
                MapConsole.ViewPort = new Rectangle(MapConsole.ViewPort.Left, MapConsole.ViewPort.Top - 1, 100, 100);
            }

            if (info.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Down))
            {
                MapConsole.ViewPort = new Rectangle(MapConsole.ViewPort.Left, MapConsole.ViewPort.Top + 1, 100, 100);
            }

            return false;
        }
    }
}