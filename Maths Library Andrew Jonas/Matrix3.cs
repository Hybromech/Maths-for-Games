using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMath
{
    public class Matrix3
    {
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9;
        public float[,] mod_array;
        public Matrix3()
        {
            //Identity matrix
            m1 = 1; m2 = 0; m3 = 0; 
            m4 = 0; m5 = 1; m6 = 0;
            m7 = 0; m8 = 0; m9 = 1;
            mod_array = new float[3, 3] { { m1, m2, m3 }, { m4, m5, m6 }, { m7, m8, m9 } };//create 2d array
        }
        public Matrix3(float n1, float n2, float n3, float n4, float n5, float n6, float n7, float n8, float n9)
        {
            m1 = n1; m2 = n2; m3 = n3;
            m4 = n4; m5 = n5; m6 = n6;
            m7 = n7; m8 = n8; m9 = n9;
            mod_array = new float[3, 3] { { m1, m2, m3 }, { m4, m5, m6 }, { m7, m8, m9 } };//create 2d array
        }

        public Matrix3 CreateTranslation(Vector3 vec)//Create a translation matrix
        {
            mod_array[0, 2] = vec.x;//set m3
            mod_array[1, 2] = vec.y;//set m6
            mod_array[2, 2] = vec.z;//set m9
                                    //Console.WriteLine
            update_matrix();
            return new Matrix3(1, 0, vec.x,
                               0, 1, vec.y,
                               0, 0 ,vec.z);
        
        }

        public Matrix3 CreateScale(float xscale, float yscale)
        {
            mod_array[0, 0] = xscale;
            mod_array[1, 1] = yscale;
            update_matrix();
            return new Matrix3(xscale,  0,    0, 
                                 0,   yscale, 0,
                                 0,     0,    1);
        }

        public void SetRotateX(double angle)
        {
            float cosA = (float)Math.Cos(angle);
            float sinA = (float)Math.Sin(angle);
            float invert_sinA = -(float)Math.Sin(angle);

            m1 = 1; m2 = 0; m3 = 0; //Identity matrix
            m4 = 0; m5 = cosA; m6 = sinA;
            m7 = 0; m8 = invert_sinA; m9 = cosA;

            mod_array[1, 1] = m5;//m5
            mod_array[1, 2] = m6;//m6
            mod_array[2, 1] = m8;//m8
            mod_array[2, 2] = m9;//m9
        }
        public void SetRotateY(double angle)
        {
            float cosA = (float)Math.Cos(angle);
            float sinA = (float)Math.Sin(angle);
            float invert_sinA = -(float)Math.Sin(angle);

            m1 = cosA; m2 = 0; m3 = invert_sinA;
            m4 = 0;    m5 = 1; m6 = 0;
            m7 = sinA; m8 = 0; m9 = cosA;

            mod_array[0, 0] = m1;
            mod_array[0, 2] = m3;
            mod_array[2, 0] = m7;
            mod_array[2, 2] = m9;
        }
        public void SetRotateZ(double angle)
        {
            float cosA = (float)Math.Cos(angle);
            float sinA = (float)Math.Sin(angle);
            float invert_sinA = -(float)Math.Sin(angle);

            m1 = cosA;        m2 = sinA; m3 = 0;
            m4 = invert_sinA; m5 = cosA; m6 = 0;
            m7 = 0;           m8 = 0; m9 = 1;

            mod_array[0, 0] = m1;
            mod_array[0, 1] = m2;
            mod_array[1, 0] = m4;
            mod_array[1, 1] = m5;
        }
        //Opperator overloads

        public static Matrix3 operator *(Matrix3 a, Matrix3 b)
        {
            return MatrixMultiply(a,b);   
        }
        public static Vector3 operator *(Matrix3 a, Vector3 b)
        {
            return MatrixMultiply(a,b);
        }

        //Matrix multiplication

        void update_matrix()
        {
            m1 = mod_array[0,0];
            m2 = mod_array[0,1];
            m3 = mod_array[0, 2];
            m4 = mod_array[1,0];
            m5 = mod_array[1, 1];
            m6 = mod_array[1, 2];
            m7 = mod_array[2, 0];
            m8 = mod_array[2, 1];
            m9 = mod_array[2, 2];
        }
        static Matrix3 MatrixMultiply(Matrix3 ma, Matrix3 mb)
        {
            int row, col, matrix_size;
            matrix_size = ma.mod_array.GetLength(0);
            Matrix3 new_matrix = new Matrix3();

            //list row matrix a
            Vector3[] row_matrix = new Vector3[3];
            row_matrix[0] = new Vector3(ma.m1, ma.m2, ma.m3);
            row_matrix[1] = (new Vector3(ma.m4, ma.m5, ma.m6));
            row_matrix[2] = (new Vector3(ma.m7, ma.m8, ma.m9));
            //list columb matrix b
            Vector3[] col_matrix = new Vector3[3];
            col_matrix[0] = new Vector3(mb.m1, mb.m4, mb.m7);
            col_matrix[1] = (new Vector3(mb.m2, mb.m5, mb.m8));
            col_matrix[2] = (new Vector3(mb.m3, mb.m6, mb.m9));

            for (row = 0; row < matrix_size; row++)
            {
                for (col = 0; col < matrix_size; col++)
                {
                    new_matrix.mod_array[row, col] = row_matrix[row].Dot(col_matrix[col]);
                }
            }
            new_matrix.update_matrix();//update matrix with array values.
            return new_matrix;
        }
        static Vector3 MatrixMultiply(Matrix3 ma, Vector3 mb)
        {
            int row, col, matrix_size;
            matrix_size = ma.mod_array.Length;
            Vector3 new_matrix = new Vector3();

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