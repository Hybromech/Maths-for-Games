using System;
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
            Game game = new Game();//Create a new game object
            SetTargetFPS(60);//Set target frames per second
            InitWindow(640, 480, "Tank Simulator");//Set the size of the window

            game.Init();//Call the Init method on game which will set things up

            while (!WindowShouldClose())//Keep playing the game if the window is open
            {
                game.Update();//Update the game
                game.Draw();//Draw the games sprites
            }

            game.Shutdown();//Exit the game
            CloseWindow();
        }
    }
}
