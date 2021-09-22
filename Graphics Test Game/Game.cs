///Created by Andrew Jonas 22/09/2021
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
        //Setup Scene Objects and variables
        SceneObject WorldObject = new SceneObject();
        SceneObject tankObject = new SceneObject(1.8f);
        SceneObject turretObject = new SceneObject(1.8f);

        SpriteObject tankSprite = new SpriteObject();
        SpriteObject turretSprite = new SpriteObject();

        List<SceneObject> bulletObjects = new List<SceneObject>();
        Stopwatch stopwatch = new Stopwatch();
        
        private long currentTime = 0;
        private long lastTime = 0;
        private float timer = 0;
        private int fps = 1;
        private int frames;
        private float speed;
        private float bullet_speed;
        private bool can_shoot;
        private float timer1;
        private float reload_time;
        private float start_time;

        private float deltaTime = 0.005f;

        public Game()
        {
        }
        //Remove and Object from a list
        public static void RemoveObjectFromList(ref SceneObject so, ref List<SceneObject>list)
        {
            Console.WriteLine("A bullet has been destroyed");
            Console.WriteLine("List size is" + " " + list.Count);
            so.Parent.RemoveChild(so);
            list.Remove(so);
            so = null;
        }
        public void UpdateTimer(ref float timer)
        {
            float game_time = stopwatch.ElapsedMilliseconds * 0.001f;
            timer = game_time - start_time;
            if (timer >= reload_time)
            {
                can_shoot = true;
                timer = 0;
            }
        }
        public void SetTimer(float timer)
        {
            float game_time = stopwatch.ElapsedMilliseconds * 0.001f;
            if (timer == 0)
            {
                start_time = game_time;
            }
        }
        //A method to test matrix multiplication
        public static void Test_matrix()
        {
            AMath.Matrix3 testma = new AMath.Matrix3();
            AMath.Matrix3 testmb = new AMath.Matrix3();

            testma = new AMath.Matrix3(10, 20, 15, 5, 6, 2, -41, -66, 7);
            testmb = new AMath.Matrix3(4, 5, 10, 6, 14, 33, 21, 74, 32);

            AMath.Matrix3 result = testma * testmb;
            Console.WriteLine("The result of the test multiply is" + result.m1 + " " + result.m2 + " " + result.m3 + " " + result.m4 + " " + result.m5 + " " + result.m6 + " " + result.m7 + " " + result.m8 + " " + result.m9 + " ");
        }
        //Initialise game objects
        public void Init()
        {
            can_shoot = true;
            reload_time = 0.2f;
            speed = 150;
            bullet_speed = 600;
            
            tankSprite.name = "tankSprite";
            turretSprite.name = "turretSprite";
            tankObject.name = "tankObject";
            turretObject.name = "turretObject";
            tankSprite.Load("./assets/Images/tank.png");
            turretSprite.Load("./assets/Images/barrelBlack_outline.png");
            
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
            WorldObject.AddChild(tankObject);

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
            //Calcuate delta time
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
            //Input handling
            if (IsKeyDown(KeyboardKey.KEY_A))
            {
                tankObject.Rotate(deltaTime);
            }
            if (IsKeyDown(KeyboardKey.KEY_D))
            {
                tankObject.Rotate(-deltaTime);
            }
            if (IsKeyDown(KeyboardKey.KEY_Q))
            {
                turretObject.Rotate(deltaTime);
            }
            if (IsKeyDown(KeyboardKey.KEY_E))
            {
                turretObject.Rotate(-deltaTime);
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
            if (IsKeyDown(KeyboardKey.KEY_SPACE))
            {
                    SetTimer(timer1);
                if (can_shoot)
                {
                    //Create a new bullet
                    SceneObject bulletObject = new SceneObject();
                    SpriteObject bulletSprite = new SpriteObject();
                    //bulletSprite.SetScale(0.9f, 0.9f);
                    bulletSprite.Load("./assets/Images/bullet.png");
                    bulletSprite.SetRotate(90 * (float)(Math.PI / 180.0f));
                    bulletSprite.SetPosition(new Vector3(-turretSprite.Height / 2 + 11, turretSprite.Width / 2 - 7, 1.0f));

                    bulletObject.AddChild(bulletSprite);
                    turretObject.AddChild(bulletObject);
                    Vector3 pos = new Vector3(bulletObject.Parent.GlobalTransform.m1 + turretSprite.Height * -1, bulletObject.Parent.GlobalTransform.m2, 1);
                    bulletObject.SetPosition(pos);
                    turretObject.RemoveChild(bulletObject);//Detach the bullet
                    WorldObject.AddChild(bulletObject);
                    bulletObject.SetLocalTransform(bulletObject.Parent.GlobalTransform * bulletObject.GlobalTransform);
                    bulletObjects.Add(bulletObject);
                }
                can_shoot = false;
            }
            SceneObject junk = null;
            foreach (var b in bulletObjects)
            {
                    Vector3 facing = new Vector3(b.LocalTransform.m1, b.LocalTransform.m4, 1);
                    facing = facing * deltaTime * -bullet_speed;
                    b.Translate(facing);
                Console.WriteLine(b.GlobalTransform.m3);
                if (b.GlobalTransform.m3 < 0 || b.GlobalTransform.m3 > (float)GetScreenWidth() || b.GlobalTransform.m6 < 0 || b.GlobalTransform.m6 > (float)GetScreenHeight())
                {
                    junk = b;
                }
            }
            if(junk != null)
            RemoveObjectFromList(ref junk, ref bulletObjects);

            WorldObject.Update(deltaTime);
            UpdateTimer(ref timer1);
            
        }

        public void Draw()
        {
            BeginDrawing();

            ClearBackground(Color.WHITE);

            DrawText(fps.ToString(), 10, 10, 14, Color.RED);
            //DrawText(timer1.ToString(), 10, 10, 14, Color.RED);
            
            WorldObject.Draw();
            
            //DrawCircle((int)tankSprite.GlobalTransform.m3, (int)tankSprite.GlobalTransform.m6, 5, Color.RED);
            //DrawCircle((int)tankObject.GlobalTransform.m3, (int)tankObject.GlobalTransform.m6, 5, Color.BLUE);
            DrawCircle((int)turretObject.GlobalTransform.m3, (int)turretObject.GlobalTransform.m6, 2, Color.GREEN);
            //if (bulletObject != null)
            //    DrawCircle((int)bulletObject.GlobalTransform.m3, (int)bulletObject.GlobalTransform.m6, 2, Color.MAGENTA);
            EndDrawing();
        }

    }
}
