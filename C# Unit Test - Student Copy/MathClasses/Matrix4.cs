using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Matrix4
    {
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16;
        public float[,] mod_array;
        public Matrix4()
        {
            m1 = 1; m2 = 0; m3 = 0; m4 = 0;
            m5 = 0; m6 = 1; m7 = 0; m8 = 0;
            m9 = 0; m10= 0; m11= 1; m12= 0;
            m13= 0; m14= 0; m15= 0; m16= 1;
        }
        public Matrix4(float n1, float n2, float n3, float n4, float n5, float n6, float n7, float n8, float n9, float n10, float n11, float n12, float n13, float n14, float n15, float n16)
        {
            m1 = n1; m2 = n2; m3 = n3; m10 = n10; m13 = n13;
            m4 = n4; m5 = n5; m6 = n6; m11 = n11; m14 = n14;
            m7 = n7; m8 = n8; m9 = n9; m12 = n12; m15 = n15;
            m16 = n16;
            mod_array = new float[4, 4] { { m1, m2, m3, m4 }, { m5, m6, m7,m8 }, { m9, m10, m11,m12 },{ m13,m14,m15,m16 } };//create 2d array
        }
        public void SetRotateX(float angle)
        {
            float cosA = (float)Math.Cos(angle);
            float sinA = (float)Math.Sin(angle);
            float invert_sinA = -(float)Math.Sin(angle);

            m1 = 1; m2 = 0; m3 = 0; m4 = 0;
            m5 = 0; m6 = cosA; m7 = invert_sinA; m8 = 0;
            m9 = 0; m10 = sinA; m11 = cosA; m12 = 0;
            m13 = 0; m14 = 0; m15 = 0; m16 = 1;
        }
        public void SetRotateY(float angle)
        {
            float cosA = (float)Math.Cos(angle);
            float sinA = (float)Math.Sin(angle);
            float invert_sinA = -(float)Math.Sin(angle);

            m1 = cosA; m2 = 0; m3 = sinA; m4 = 0;
            m5 = 0; m6 = 1; m7 = 0; m8 = 0;
            m9 = invert_sinA; m10 = 0; m11 = cosA; m12 = 0;
            m13 = 0; m14 = 0; m15 = 0; m16 = 1;
        }
        public void SetRotateZ(float angle)
        {
            float cosA = (float)Math.Cos(angle);
            float sinA = (float)Math.Sin(angle);
            float invert_sinA = -(float)Math.Sin(angle);

            m1 = cosA; m2 = invert_sinA; m3 = 0; m4 = 0;
            m5 = sinA; m6 = cosA; m7 = 0; m8 = 0;
            m9 = 0; m10 = 0; m11 = 1; m12 = 0;
            m13 = 0; m14 = 0; m15 = 0; m16 = 1;
        }

        void update_matrix()
        {
            m1 = mod_array[0, 0];
            m2 = mod_array[0, 1];
            m3 = mod_array[0, 2];
            m4 = mod_array[0, 3];
            m5 = mod_array[1, 0];
            m6 = mod_array[1, 1];
            m7 = mod_array[1, 2];
            m8 = mod_array[1, 3];
            m9 = mod_array[2, 0];
            m10 = mod_array[2, 1];
            m11 = mod_array[2, 2];
            m12 = mod_array[2, 3];
            m13 = mod_array[3, 0];
            m14 = mod_array[3, 1];
            m15 = mod_array[3, 2];
            m16 = mod_array[3, 3];
        }

        //Opperator overloads

        public static Matrix4 operator *(Matrix4 a, Matrix4 b)
        {
            return MatrixMultiply(a, b);
        }
        public static Vector4 operator *(Matrix4 a, Vector4 b)
        {
            return MatrixMultiply(a, b);
        }

        static Matrix4 MatrixMultiply(Matrix4 ma, Matrix4 mb)
        {
            int row, col, matrix_size;
            matrix_size = ma.mod_array.Length;
            Matrix4 new_matrix = new Matrix4();

            for (row = 0; row < matrix_size; row++)
            {
                for (col = 0; col < matrix_size; col++)
                {
                    //Find C[row,col]   
                    for (int i = 0; i < matrix_size; i++)
                    {
                        new_matrix.mod_array[row, col] = ma.mod_array[row, col] + ma.mod_array[row, i] * mb.mod_array[i, col];
                        new_matrix.update_matrix();//update matrix with array values.
                    }
                }
            }
            return new_matrix;
        }
        static Vector4 MatrixMultiply(Matrix4 ma, Vector4 mb)
        {
            int row, col, matrix_size;
            matrix_size = ma.mod_array.Length;
            Vector4 new_matrix = new Vector4();

            for (row = 0; row < matrix_size; row++)
            {
                for (col = 0; col < matrix_size; col++)
                {
                    //Find C[row,col]   
                    for (int i = 0; i < matrix_size; i++)
                    {
                        new_matrix.mod_array[row, col] = ma.mod_array[row, col] + ma.mod_array[row, i] * mb.mod_array[i, col];
                        new_matrix.update_matrix();//update matrix with array values.
                    }
                }
            }
            return new_matrix;
        }

    }
}
