using Maths_Library_Andrew_Jonas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using static Raylib.Raylib;

namespace Project2D
{
    class Player
    {
        public Matrix3 Transform;//rotation scale position
        public Maths_Library_Andrew_Jonas.Vector3 position;
        public Maths_Library_Andrew_Jonas.Vector3 scale;
        public double rotation;
        public float rotation_speed;
        public float speed;
        public Image tank_image;
        public Texture2D texture;
        public Player()
        {
            
            tank_image = LoadImage("../aie-logo-dark.jpg");
            texture = LoadTextureFromImage(tank_image);
            Transform = new Matrix3();//create a new transform for the player.
        }

        public void Update()
        { 
            //update the tank
        }
        public void Draw()
        {
            Matrix3 m = new Matrix3();
            Matrix3 mT = new Matrix3();
            Matrix3 mR = new Matrix3();
            Matrix3 mS = new Matrix3();
            mT.CreateTranslation(new Maths_Library_Andrew_Jonas.Vector3(position.x, position.y, 1));
            mR.SetRotateZ(rotation);
            mS.CreateScale(scale.x, scale.y);

            m = mT * mR * mS;
            Color c = new Color(0,0,0,1);
            DrawTexture(texture, (int)m.m3, (int)m.m6,c);
        }
    }
}
