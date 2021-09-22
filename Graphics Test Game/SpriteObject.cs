///Created by Andrew Jonas 22/09/2021
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Graphics_Test_Game
{
    class SpriteObject : SceneObject
    {
        Texture2D texture = new Texture2D();
        Image image = new Image();

        public SpriteObject()
        {
        }

        public float Width
        {
            get { return texture.width; }
        }

        public float Height
        {
            get { return texture.height; }
        }

        //Load the sprite from a file name
        public void Load(string filename)
        {
            Image img = LoadImage(filename);
            ImageResize(ref img, img.width * (int)localTransform.m1, img.height * (int)localTransform.m5);
            texture = LoadTextureFromImage(img);
            //Console.WriteLine("the image scale is" + texture.width + " " + texture.height);
        }

        public override void OnDraw()
        {
            float rotation = (float)Math.Atan2(globalTransform.m4, globalTransform.m1);//Clean the angle
            rotation *= (float)(180 / Math.PI);//convert radian into degrees since raylib requires degrees.
            Vector2 pos = new Vector2(globalTransform.m3, globalTransform.m6);//position to draw object
            
            Raylib.DrawTextureEx(texture, pos,rotation, 1, Color.WHITE);//Draw the texture
            //Console.WriteLine(name + " pos is " + GlobalTransform.m3 + " " + GlobalTransform.m6);
        }

    }
}
