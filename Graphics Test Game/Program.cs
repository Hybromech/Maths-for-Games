﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Graphics_Test_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            SetTargetFPS(60);
            InitWindow(640, 480, "Tank Simulator");

            game.Init();

            while (!WindowShouldClose())
            {
                game.Update();
                game.Draw();
            }

            game.Shutdown();
            CloseWindow();
        }
    }
}
