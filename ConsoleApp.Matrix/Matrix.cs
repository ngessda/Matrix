using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Matrix
{
    class Matrix
    {
        private int matrixSizeN;
        private int matrixSizeM;
        private int[,] matrix_value;
        public enum Operation
        {
            Zero,
            Input,
            Random,
            Identity,
            Transposed
        }
        public Matrix(int msN, int msM, Operation op)
        {
            matrixSizeN = msN;
            matrixSizeM = msM;
            if (matrixSizeN < 1 || matrixSizeM < 1)
            {
                Console.WriteLine("Чел ты...");
                Console.ReadKey();
            }
            else
            {
                matrix_value = new int[matrixSizeN, matrixSizeM];
            }
            switch (op)
            {
                case Operation.Zero:
                    break;
                case Operation.Input:
                    MatrixInput();
                    break;
                case Operation.Random:
                    MatrixRandom();
                    break;
                case Operation.Identity:
                    IdentityMatrix();
                    break;
                case Operation.Transposed:
                    TransMatrix();
                    break;
            }
        }
        public Matrix(int msN, int msM)
        {
            matrixSizeN = msN;
            matrixSizeM = msM;
        }

        public void MatrixInput()
        {
            for (int i = 0; i < matrixSizeN; i++)
            {
                Console.WriteLine($"Вводите данные для {i + 1}-ой строки матрицы");
                for (int j = 0; j < matrixSizeM; j++)
                {
                    Console.Write($"{j + 1} = ");
                    matrix_value[i, j] = Convert.ToInt32(Console.ReadLine());
                }
                Console.Clear();
            }
        }
        public void MatrixRandom()
        {
            Random rnd = new Random();
            for (int i = 0; i < matrixSizeN; i++)
            {
                for (int j = 0; j < matrixSizeM; j++)
                {
                    matrix_value[i, j] = rnd.Next(1, 30);
                }
            }
        }
        public void IdentityMatrix()
        {
            if(matrixSizeN != matrixSizeM)
            {
                Console.WriteLine("Чел ты...");
            }
            else
            {
                for (int i = 0; i < matrixSizeN; i++) 
                {
                    matrix_value[i, i] = 1;
                }
            }
        }
        public void TransMatrix()
        {
            int slave = 0;
            for(int i = 0; i < matrixSizeN; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    slave = matrix_value[i, j];
                    matrix_value[i, j] = matrix_value[j, i];
                    matrix_value[j, i] = slave;
                }
            }
        }

        public static Matrix operator+ (Matrix mAdd1, Matrix mAdd2)
        {
            Matrix mAddRes = new Matrix(mAdd1.matrixSizeN, mAdd1.matrixSizeM, Operation.Zero);
            for (int i = 0; i < mAdd1.matrixSizeN; i++) 
            {
                for (int j = 0; j < mAdd2.matrixSizeM; j++) 
                {
                    mAddRes.matrix_value[i, j] = mAdd1.matrix_value[i, j] + mAdd2.matrix_value[i, j];
                }
            }
            return mAddRes;
        }
        public static Matrix operator- (Matrix mAdd1, Matrix mAdd2)
        {
            Matrix mAddRes = new Matrix(mAdd1.matrixSizeN, mAdd1.matrixSizeM, Operation.Zero);
            for (int i = 0; i < mAdd1.matrixSizeN; i++)
            {
                for (int j = 0; j < mAdd2.matrixSizeM; j++)
                {
                    mAddRes.matrix_value[i, j] = mAdd1.matrix_value[i, j] - mAdd2.matrix_value[i, j];
                }
            }
            return mAddRes;
        }
        public static Matrix operator* (Matrix mMulty1, Matrix mMulty2)
        {
            if (mMulty1.matrixSizeM != mMulty2.matrixSizeN)
            {
                throw new Exception("Ты далбаеб!");
            }
            Matrix mMultyRes = new Matrix(mMulty1.matrixSizeN, mMulty2.matrixSizeM, Operation.Zero);
            for (int i = 0; i < mMulty1.matrixSizeN; i++)
            {
                for (int j = 0; j < mMulty2.matrixSizeM; j++)
                {
                    mMultyRes.matrix_value[i, j] = 0;
                    for (int k = 0; k < mMulty1.matrixSizeN; k++)
                    {
                        mMultyRes.matrix_value[i, j] += mMulty1.matrix_value[i, k] * mMulty2.matrix_value[k, j];
                    }
                }
            }
            return mMultyRes;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < matrixSizeN; i++)
            {
                for (int j = 0; j < matrixSizeM; j++)
                {
                    sb.Append($" {matrix_value[i, j]} \t");
                    if( j == matrixSizeM - 1)
                    {
                        sb.Append("");
                    }
                    else
                    {
                        sb.Append("|");
                    }
                }
                sb.AppendLine();
                sb.AppendLine();
            }
            return sb.ToString();
        }
        //--------------------------------------------------------------------------------------------------
        //public string M_Size
        //{
        //    get
        //    {
        //        return $"Размер матрицы: {matrix_size_n} : {matrix_size_m}";
        //    }
        //}
        // --------------------------------------------------------------------------------------------------
        //public void Matrix_Size()
        //{
        //    Console.Write("Введите количество строк в матрице: ");
        //    matrix_size_n = Convert.ToInt32(Console.ReadLine());
        //    Console.Write("Введите количество столбцов в матрице: ");
        //    matrix_size_m = Convert.ToInt32(Console.ReadLine());
        //    if (matrix_size_n < 1 || matrix_size_m < 1)
        //    {
        //        Console.WriteLine("Чел ты ...");
        //        Console.ReadKey();
        //    }
        //    else
        //    {
        //        matrix_value = new int[matrix_size_n, matrix_size_m];
        //    }
        //    Console.Clear();
        //}
        // --------------------------------------------------------------------------------------------------
        //public void Size_Of_Identity_Matrix()
        //{
        //    Console.Write("Введите размер единичной матрицы: ");
        //    matrix_size_n = Convert.ToInt32(Console.ReadLine());
        //    matrix_size_m = matrix_size_n;
        //    if (matrix_size_n < 1)
        //    {
        //        Console.WriteLine("Чел ты ...");
        //        Console.ReadKey();
        //    }
        //    else
        //    {
        //        matrix_value = new int[matrix_size_n, matrix_size_m];
        //    }
        //    Console.Clear();
        //}
        // --------------------------------------------------------------------------------------------------

        //private static Matrix ScaleMultiply(Matrix mMulty1, Matrix mMulty2)
        //{
        //    Matrix mMultyRes = new Matrix(mMulty1.matrixSizeN, mMulty2.matrixSizeM, Operation.Zero);
        //    for (int i = 0; i < mMulty1.matrixSizeM; i++) 
        //    {
        //        for(int j = 0; j < mMulty1.matrixSizeN; j++)
        //        {
        //            for (int l = 0; l < mMulty1.matrixSizeN; l++)
        //            {
        //                mMultyRes.matrix_value[i, j] += mMulty1.matrix_value[i, l] * mMulty2.matrix_value[l, j];
        //            }
        //        }
        //    }
        //    return mMultyRes;
        //}

        //private static int MatrixMultiply(Matrix mAdd1, Matrix mAdd2)
        //{
        //    Matrix mAddRes = new Matrix(mAdd1.matrixSizeN, mAdd2.matrixSizeM, Operation.Zero);
        //    int res;
        //    int z = 0;
        //    int x = 0;
        //    for (int i = 0; i < mAdd1.matrixSizeM;)
        //    {
        //        if(x < mAdd1.matrixSizeM)
        //        {
        //            i = z;
        //        }
        //        else
        //        {
        //            i++;
        //            z++;
        //        }
        //        res = 0;
        //        for (int j = 0; j < mAdd2.matrixSizeN; j++)
        //        {
        //            res += mAdd1.matrix_value[i, j] * mAdd2.matrix_value[j, i];
        //            if( j == mAdd2.matrixSizeN)
        //            {
        //                mAddRes.matrix_value[z, x] = res;
        //                x++;
        //            }    
        //        }
        //    }
        //}

        //public void PrintMatrix()
        //{
        //    for (int i = 0; i < matrixSizeN; i++)
        //    {
        //        for (int j = 0; j < matrixSizeM; j++)
        //        {
        //            Console.Write($"[{i + 1}, {j + 1}] = {matrix_value[i, j]} \t");
        //        }
        //        Console.WriteLine("\n");
        //    }
        //}
    }
}
