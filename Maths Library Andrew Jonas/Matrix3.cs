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
        }
        public Matrix3(float n1, float n2, float n3, float n4, float n5, float n6, float n7, float n8, float n9)
        {
            m1 = n1; m2 = n2; m3 = n3;
            m4 = n4; m5 = n5; m6 = n6;
            m7 = n7; m8 = n8; m9 = n9;
        }

        public Matrix3 CreatePosition(Vector3 vec)//Create a translation matrix
        {                                     
            return new Matrix3(1, 0, vec.x,
                               0, 1, vec.y,
                               0, 0 ,vec.z);
        }
        public Matrix3 CreateScale(float xscale, float yscale)
        {
            return new Matrix3(xscale, 0, 0,
                                 0, yscale, 0,
                                 0, 0, 1);
        }
        public void SetPosition(Vector3 vec)//Set a translation matrix
        {
            m3 = vec.x;
            m6 = vec.y;
            m9 = 1; //m9 must be 1 or else no translation will be applied.
        }
        public void Translate(Vector3 vec)
        {
            m3 += vec.x;
            m6 += vec.y;
        }
        public void SetScale(float xscale, float yscale)
        {
            m1 = xscale;
            m5 = yscale;
        }
        public void Scale(float xscale, float yscale)
        {
            m1 *= xscale;
            m5 *= yscale;
        }
        public void RotateZ(double angle)
        {
            float cosA = (float)Math.Cos(angle);
            float sinA = (float)Math.Sin(angle);
            float invert_sinA = -(float)Math.Sin(angle);
            m1 += cosA;
            m2 += sinA;
            m4 += invert_sinA;
            m5 += cosA;
        }
        public void SetRotateX(double angle)
        {
            float cosA = (float)Math.Cos(angle);
            float sinA = (float)Math.Sin(angle);
            float invert_sinA = -(float)Math.Sin(angle);

             m5 = cosA; m6 = sinA;
             m8 = invert_sinA; m9 = cosA;
        }
        public void SetRotateY(double angle)
        {
            float cosA = (float)Math.Cos(angle);
            float sinA = (float)Math.Sin(angle);
            float invert_sinA = -(float)Math.Sin(angle);

            m1 = cosA; m3 = invert_sinA;
            m7 = sinA; m9 = cosA;     
        }
        public void SetRotateZ(double angle)
        {
            float cosA = (float)Math.Cos(angle);
            float sinA = (float)Math.Sin(angle);
            float invert_sinA = -(float)Math.Sin(angle);

            m1 = cosA;        m2 = sinA;
            m4 = invert_sinA; m5 = cosA;
                   
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
        void update_matrix(float[,] r)
        {
            m1 = r[0,0];
            m2 = r[0,1];
            m3 = r[0, 2];
            m4 = r[1,0];
            m5 = r[1, 1];
            m6 = r[1, 2];
            m7 = r[2, 0];
            m8 = r[2, 1];
            m9 = r[2, 2];
        }
        static Matrix3 MatrixMultiply(Matrix3 ma, Matrix3 mb)
        {
            int row, col, matrix_size;
            matrix_size = 3;
            Matrix3 n = new Matrix3();

            float[,] mrray = new float[3,3];
        
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
                    mrray[row, col] =  row_matrix[row].Dot(col_matrix[col]);
                }
            }
            n.update_matrix(mrray);//update matrix with array values.
            return n;
        }
        static Vector3 MatrixMultiply(Matrix3 ma, Vector3 vb)
        {
            int row, col, matrix_size;
            matrix_size = ma.mod_array.GetLength(0);
            Vector3 new_vector = new Vector3();

            //list row matrix a
            Vector3[] row_matrix = new Vector3[3];
            row_matrix[0] = new Vector3(ma.m1, ma.m2, ma.m3);
            row_matrix[1] = (new Vector3(ma.m4, ma.m5, ma.m6));
            row_matrix[2] = (new Vector3(ma.m7, ma.m8, ma.m9));

            float[] row_vector = new float[3];
            row_vector[0] = vb.x;
            row_vector[1] = vb.y;
            row_vector[2] = vb.z;

            for (row = 0; row < matrix_size; row++)
            {
               row_vector[row] = row_matrix[row].Dot(vb);
            }
            return new Vector3(row_vector[0], row_vector[1], row_vector[2]);
        }
    }
}