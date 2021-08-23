using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Vector4
    {
        public float x, y, z, w;

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
        }

        public static Vector4 operator +(Vector4 v3a, Vector4 v3b)
        {
            //Vector3 result = new Vector3();
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

    }
}
