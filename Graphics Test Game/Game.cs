﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Graphics_Test_Game
{
    class Game
    {
        Stopwatch stopwatch = new Stopwatch();

        private long currentTime = 0;
        private long lastTime = 0;
        private float timer = 0;
        private int fps = 1;
        private int frames;

        private float deltaTime = 0.005f;

        public Tank_Object tankObj;
        public Tank_Draw tank_draw;
        public Scene scene;
        public Game()
        {
        }

        public void Init()
        {
            stopwatch.Start();
            lastTime = stopwatch.ElapsedMilliseconds;

            if (Stopwatch.IsHighResolution)
            {
                Console.WriteLine("Stopwatch high-resolution frequency: {0} ticks per second", Stopwatch.Frequency);
            }

            SceneNode root = new SceneNode(new AMath.Matrix3(), "Root");//Create the root scene node with default matrix
            SceneNode s_tank = new SceneNode("Tank");
            SceneNode s_tank_draw = new SceneNode("Tank Draw");
            s_tank.SetParent(ref root);
            root.AddChild(ref s_tank);
            
            s_tank_draw.SetParent(ref s_tank);
            s_tank.AddChild(ref s_tank_draw);

            scene = new Scene(ref root);


            tankObj = new Tank_Object(ref s_tank);
            tank_draw = new Tank_Draw(ref s_tank_draw);
            tankObj.Setup();//set matrix for tank.
            tank_draw.Setup();//set matrix for tank draw.
        }

        public void Shutdown()
        {
        }

        public void Update()
        {
            lastTime = currentTime;
            currentTime = stopwatch.ElapsedMilliseconds;
            deltaTime = (currentTime - lastTime) / 1000.0f;
            timer += deltaTime;
            if (timer >= 1)
            {
                fps = frames;
                frames = 0;
                timer -= 1;
            }
            frames++;

            // insert game logic here
            tankObj.Update();
            scene.UpdateTransforms();           
        }

        public void Draw()
        {
            BeginDrawing();

            ClearBackground(Color.WHITE);

            DrawText(fps.ToString(), 10, 10, 14, Color.RED);


            tank_draw.Draw();

          // DrawTexture(texture, 
          //     GetScreenWidth() / 2 - texture.width / 2, GetScreenHeight() / 2 - texture.height / 2, Color.WHITE);

            EndDrawing();
        }

    }
}
