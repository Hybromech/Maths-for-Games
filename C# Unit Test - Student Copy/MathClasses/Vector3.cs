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
        public float[,] mod_array;

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
            mod_array = new float[3, 1] { { mx, }, { my }, { mz } };//create 2d array
        }
        public void update_matrix()
        {
            x = mod_array[0, 0];
            y = mod_array[1, 0];
            z = mod_array[2, 0];
        }

        //Vector3 Arithmetic
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

        //Dot product
        public float Dot(Vector3 v)
        {
            float result = x * v.x + y * v.y + z * v.z;
            return result;
        }
        //Cross product
        public Vector3 Cross(Vector3 b)
        {
            Vector3 cross_product = new Vector3(y * b.z - z * b.y, z * b.x - x * b.z, x * b.y - y * b.x);
            return cross_product;
        }
        //Magnitude
        public float Magnitude()
        {
            float mag = (float)Math.Sqrt(x * x + y * y + z * z);
            return mag;
        }
        //Normalise
        public Vector3 Normalize()
        {
            float mag = this.Magnitude();
            Vector3 normal = new Vector3(x / mag, y / mag, z / mag);
            return normal;
        }

    }
}
