using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath
{
    public class Vector4
    {
        public float x, y, z, w;
        public float[,] mod_array;

        public Vector4()
        {
            x = 0;
            y = 0;
            z = 0;
            w = 0;
        }
        public Vector4(float mx, float my, float mz, float mw)
        {
            x = mx;
            y = my;
            z = mz;
            w = mw;
            mod_array = new float[4, 1] { {x},{y},{z},{w} };//create 2d array
        }
        //Vector4 Arithmetic
        public static Vector4 operator +(Vector4 v3a, Vector4 v3b)
        {
            return Vector4Addition(v3a, v3b);
        }
        static Vector4 Vector4Addition(Vector4 v3a, Vector4 v3b)
        {
            return new Vector4(v3a.x + v3b.x, v3a.y + v3b.y, v3a.z + v3b.z, v3a.w + v3b.w);
        }
        public static Vector4 operator -(Vector4 v3a, Vector4 v3b)
        {
            return Vector3Subtraction(v3a, v3b);
        }
        static Vector4 Vector3Subtraction(Vector4 v3a, Vector4 v3b)
        {
            return new Vector4(v3a.x - v3b.x, v3a.y - v3b.y, v3a.z - v3b.z, v3a.w - v3b.w);
        }
        public static Vector4 operator *(float scale_factor, Vector4 v3)
        {
            return Vector3Scale(scale_factor, v3);
        }
        public static Vector4 operator *(Vector4 v3, float scale_factor)
        {
            return Vector3Scale(scale_factor, v3);
        }
        static Vector4 Vector3Scale(float scale_factor, Vector4 v3)
        {
            v3.x *= scale_factor;
            v3.y *= scale_factor;
            v3.z *= scale_factor;
            v3.w *= scale_factor;
            return v3;
        }
        //Dot product
        public float Dot(Vector4 v)
        {
            float result = x * v.x + y * v.y + z * v.z + w * v.w;
            return result;
        }
        //Cross product
        public Vector4 Cross(Vector4 b)
        {
            Vector4 cross_product = new Vector4(y * b.z - z * b.y, z * b.x - x * b.z, x * b.y - y * b.x,0);
            return cross_product;
        }
        //Magnitude
        public float Magnitude()
        {
            float mag = (float)Math.Sqrt(x * x + y * y + z * z + w * w);
            return mag;
        }
        //Normalise
        public Vector4 Normalize()
        {
            float mag = this.Magnitude();
            Vector4 normal = new Vector4(x / mag, y / mag, z / mag, w / mag);
            return normal;
        }
        public void update_matrix()
        {
            x = mod_array[0, 0];
            y = mod_array[1, 0];
            z = mod_array[2, 0];
            z = mod_array[3, 0];
        }
    }
}

