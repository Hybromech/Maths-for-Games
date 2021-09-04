using AMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;

namespace Graphics_Test_Game
{
    class Player
    {
        public Matrix3 Transform;//rotation scale position
        public AMath.Vector3 position;
        public AMath.Vector3 scale;
        public double rotation;
        public float rotation_speed;
        public float speed;
        public Image tank_image;
        public Texture2D texture;
        public SceneNode sceneNode;
        private Matrix3 m;
        private Matrix3 mT;
        private Matrix3 mR;
        private Matrix3 mS;
        
        public Player(ref SceneNode new_sceneNode)
        {
            sceneNode = new_sceneNode;
            tank_image = LoadImage("./assets/Images/tankRed_outline.png");
            texture = LoadTextureFromImage(tank_image);
            position = new AMath.Vector3(279,201,1);
            scale = new AMath.Vector3();
            rotation = 0.01;
            m = new Matrix3();
            mT = new Matrix3();
            mR = new Matrix3();
            mS = new Matrix3();
            mT = mT.CreateTranslation(position);
        }

        public void Update()
        { 
            //update the tank
        }
        public void Update_Input()
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                mR.SetRotateZ(rotation); 
                UpdateTransform();
                rotation += 0.01;
            }
        }
        public void UpdateTransform()
        { 
            //mT = mT.CreateTranslation(new AMath.Vector3(position.x, position.y, 1));
            //mS.CreateScale(scale.x, scale.y);
            m = mT * mR * mS;
            sceneNode.SetTransform(m);
        }
        public void Draw()
        {
            //AMath.Vector3 v = sceneNode.G
            Vector2 vec = new Vector2(m.m7, m.m8);//vector
            float dir = compute_dir_from_matrix(m);
            Console.WriteLine("dir is " + (float)(dir * 180 / Math.PI));
            DrawTextureEx(texture, vec, (float)(dir * 180 / Math.PI), 1, Color.WHITE);
            //Console.WriteLine("m7" + m.m3 + "m8" + m.m6);
        }
        public float compute_dir_from_matrix(Matrix3 matrix)
        {
            Console.WriteLine("my is " + matrix.m5 + "mx is " + matrix.m2);
            double theta = Math.Atan((double)(matrix.m5 / matrix.m2));//forward heading
            return (float)theta;//direction
            //formula theta = tan–1(y / x)
        }

    }
}
