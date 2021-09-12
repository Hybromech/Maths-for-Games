using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Graphics_Test_Game
{
    class SpriteObject
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

        public void Load(string filename)
        {
            Image img = LoadImage(filename);
            texture = LoadTextureFromImage(img);
        }

    }
}
