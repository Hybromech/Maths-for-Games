using AMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
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
        public Player()
        {
            tank_image = LoadImage("D:/Andrew/AIE/Diploma of Digital and Interactive Games/Subjects/Math for Games/Projects/Graphics Test Game/Graphics Test Game/Images");
            texture = LoadTextureFromImage(tank_image);
            position = new AMath.Vector3();
            scale = new AMath.Vector3();
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
            mT.CreateTranslation(new AMath.Vector3(position.x, position.y, 1));
            mR.SetRotateZ(rotation);
            mS.CreateScale(scale.x, scale.y);

            m = mT * mR * mS;
            Color c = new Color(0,0,0,1);
            DrawTexture(texture, (int)m.m3, (int)m.m6,c);
        }
    }
}
