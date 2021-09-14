using AMath;
using System;
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
        SceneObject tankObject = new SceneObject();
        SceneObject turretObject = new SceneObject();

        SpriteObject tankSprite = new SpriteObject();
        SpriteObject turretSprite = new SpriteObject();

        Stopwatch stopwatch = new Stopwatch();
        
        private long currentTime = 0;
        private long lastTime = 0;
        private float timer = 0;
        private int fps = 1;
        private int frames;
        private float speed;

        private float deltaTime = 0.005f;

        public Game()
        {
        }
        public void Test_matrix()
        {
            AMath.Matrix3 testma = new AMath.Matrix3();
            AMath.Matrix3 testmb = new AMath.Matrix3();

            testma = new AMath.Matrix3(10, 20, 15, 5, 6, 2, -41, -66, 7);
            testmb = new AMath.Matrix3(4, 5, 10, 6, 14, 33, 21, 74, 32);

            AMath.Matrix3 result = testma * testmb;
            Console.WriteLine("The result of the test multiply is" + result.m1 + " " + result.m2 + " " + result.m3 + " " + result.m4 + " " + result.m5 + " " + result.m6 + " " + result.m7 + " " + result.m8 + " " + result.m9 + " ");
        }
        public void Init()
        {
            tankSprite.name = "tankSprite";
            turretSprite.name = "turretSprite";
            tankObject.name = "tankObject";
            turretObject.name = "turretObject";
            tankSprite.Load("./assets/Images/tankRed_outline.png");
            turretSprite.Load("./assets/Images/barrelBlack_outline.png");
            speed = 150;
            //sprite is facing the wrong way... fix that here
            tankSprite.SetRotate(-90 * (float)(Math.PI / 180.0f));
            // sets an offset for the base, so it rotates around the centre
            Vector3 tank_s_pos = new Vector3(tankSprite.Width / 2.0f, -tankSprite.Height / 2.0f, 1);
            // set the turret offset from the tank base
            Vector3 turret_s_pos = new Vector3(0, -turretSprite.Width / 2.0f, 1);
            tankSprite.SetPosition(tank_s_pos);

            turretSprite.SetRotate(-90 * (float)(Math.PI / 180.0f));
            turretSprite.SetPosition(turret_s_pos);
            
            // set up the scene object hierarchy - parent the turret to the base,
            // then the base to the tank sceneObject

            turretObject.AddChild(turretSprite);
            tankObject.AddChild(tankSprite);
            tankObject.AddChild(turretObject);

            // having an empty object for the tank parent means we can set the
            // position/rotation of the tank without
            // affecting the offset of the base sprite

            Vector3 tankpos = new Vector3(GetScreenWidth() / 2.0f, GetScreenHeight() / 2.0f,0);
            tankObject.SetPosition(tankpos);
    
            stopwatch.Start();
            lastTime = stopwatch.ElapsedMilliseconds;

            if (Stopwatch.IsHighResolution)
            {
                Console.WriteLine("Stopwatch high-resolution frequency: {0} ticks per second", Stopwatch.Frequency);
            }                 
        
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

            if (IsKeyDown(KeyboardKey.KEY_A))
            {
                tankObject.Rotate(deltaTime);
            }
            if (IsKeyDown(KeyboardKey.KEY_D))
            {
                tankObject.Rotate(-deltaTime);
            }
            if (IsKeyDown(KeyboardKey.KEY_W))
            {
                Vector3 facing = new Vector3(tankObject.LocalTransform.m1,tankObject.LocalTransform.m4, 1);
                facing = facing * deltaTime * -speed;
                tankObject.Translate(facing);
            }
            if (IsKeyDown(KeyboardKey.KEY_S))
            {
                Vector3 facing = new Vector3(tankObject.LocalTransform.m1, tankObject.LocalTransform.m4, 1);
                facing = facing * deltaTime * speed;
                tankObject.Translate(facing);
            }

                            tankObject.Update(deltaTime);
        }

        public void Draw()
        {
            BeginDrawing();

            ClearBackground(Color.WHITE);
            
            DrawText(fps.ToString(), 10, 10, 14, Color.RED);

            tankObject.Draw();
            //DrawCircle((int)tankSprite.GlobalTransform.m3, (int)tankSprite.GlobalTransform.m6, 15, Color.RED);
            //DrawCircle((int)tankObject.GlobalTransform.m3, (int)tankObject.GlobalTransform.m6, 15, Color.BLUE);
            //DrawCircle((int)turretObject.GlobalTransform.m3, (int)turretObject.GlobalTransform.m6, 8, Color.GREEN);

            EndDrawing();
        }

    }
}
