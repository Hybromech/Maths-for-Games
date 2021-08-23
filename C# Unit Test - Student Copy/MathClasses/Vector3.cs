using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Vector3
    {
        public float x, y, z;

        public Vector3()
        {
            x = 0;
            y = 0;
            z = 0;
        }
        public Vector3(float mx, float my, float mz)
        {
            x = mx;
            y = my;
            z = mz;
        }

        public static Vector3 operator +(Vector3 v3a, Vector3 v3b)
            {
                return Vector3Addition(v3a, v3b);
            }
        static Vector3 Vector3Addition(Vector3 v3a, Vector3 v3b)
        {
            return new Vector3(v3a.x + v3b.x, v3a.y + v3b.y, v3a.z + v3b.z);
        }
        public static Vector3 operator -(Vector3 v3a, Vector3 v3b)
        {
            return Vector3Subtraction(v3a, v3b);
        }
        static Vector3 Vector3Subtraction(Vector3 v3a, Vector3 v3b)
        {
            return new Vector3(v3a.x - v3b.x, v3a.y - v3b.y, v3a.z - v3b.z);
        }
        public static Vector3 operator *(float scale_factor, Vector3 v3)
        {
            return Vector3Scale(scale_factor, v3);
        }
        public static Vector3 operator *(Vector3 v3, float scale_factor)
        {
            return Vector3Scale(scale_factor, v3);
        }
        static Vector3 Vector3Scale(float scale_factor, Vector3 v3)
        {
            v3.x *= scale_factor;
            v3.y *= scale_factor;
            v3.z *= scale_factor;
            return v3;
        }

    }
}
