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
    class Tank_Object
    {
        public Matrix3 Transform;//rotation scale position
        public AMath.Vector3 position;
        public AMath.Vector3 scale;
        public double rotation;
        public float rotation_speed;
        public float speed;
        public Image image;
        public Texture2D texture;
        public SceneNode sceneNode;
        private Matrix3 m;
        private Matrix3 mT;
        private Matrix3 mR;
        private Matrix3 mS;

        public Tank_Object(ref SceneNode new_sceneNode)
        {
            sceneNode = new_sceneNode;
            image = LoadImage("./assets/Images/tankRed_outline.png");
            texture = LoadTextureFromImage(image);
            //position = new AMath.Vector3(279 + texture.width/2, 201 + texture.height/2, 1);
            position = new AMath.Vector3(300, 300 , 1); //(279, 201 , 1)
            scale = new AMath.Vector3();
            rotation = 0.01;
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
        public void Update()
        {
            //update the tank
            UpdateTransform();
            Update_Input();
        }
        public void Update_Input()
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                mR.SetRotateZ(rotation);
                UpdateTransform();
                rotation += 0.01;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                mR.SetRotateZ(rotation);
                UpdateTransform();
                rotation -= 0.01;
            }
        }
        public void UpdateTransform()
        {
            //mT = mT.CreateTranslation(new AMath.Vector3(position.x, position.y, 1));
            //mS.CreateScale(scale.x, scale.y);
            m = mT * mR * mS;
            Console.WriteLine("Tank rotation" + m.m1 + " " + m.m2 + " " + m.m4 + " " + m.m5);
            sceneNode.SetTransform(m);
        }
    }
}
