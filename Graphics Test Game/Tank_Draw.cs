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
    class Tank_Draw
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
        string name;

        public Tank_Draw(ref SceneNode new_sceneNode)
        {
            sceneNode = new_sceneNode;
            tank_image = LoadImage("./assets/Images/tankRed_outline.png");
            texture = LoadTextureFromImage(tank_image);
            position = new AMath.Vector3(-texture.width / 2, -texture.height / 2, 1);
            m = new Matrix3();
            mT = new Matrix3();
            mR = new Matrix3();
            mS = new Matrix3();
            mT = mT.CreateTranslation(position);
        }
        public void Setup()
        {
            m = mT * mR * mS;
            sceneNode.SetTransform(m);
        }

        public void Draw()
        {
            AMath.Matrix3 matrix = sceneNode.GetGlobalTransform();
            float dir = compute_angle_from_vector(matrix.m2, matrix.m5);
            Console.WriteLine("the tank is being drawn at" + matrix.m7 + "," + matrix.m8);
            Vector2 vecPos = new Vector2(matrix.m7, matrix.m8);//position of object
            //Vector2 vecY = new Vector2(m.m2, m.m5);  
            //DrawLineV(vecPos, vecY, Color.GREEN);
            DrawTextureEx(texture, vecPos, dir, 1, Color.WHITE);
        }
        public float compute_angle_from_vector(float x, float y)
        {
            //Console.WriteLine("my is " + y + "mx is " + x);
            //use atan2
            double angle = Math.Atan((double)(y / x) * 180 / Math.PI + 90);//forward heading

            if (x < 0)
            {
                angle = 270 - (Math.Atan(y / -x) * 180 / Math.PI);
            }
            else
            {
                angle = 90 + (Math.Atan(y / x) * 180 / Math.PI);
            }

            return (float)angle;//direction
            //formula theta = tan–1(y / x)
        }
    }
}
