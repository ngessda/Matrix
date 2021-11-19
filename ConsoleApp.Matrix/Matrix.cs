using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Matrix
{
    class Matrix
    {
        protected int matrixSizeN;
        protected int matrixSizeM;
        protected double[,] matrixValue;
        public enum Operation
        {
            Zero,
            Input,
            Random,
            Identity
        }

        public Matrix(int msN, int msM, Operation op)
        {
            if (msN < 1 || msM < 1)
            {
                throw new Exception("Чел ты...");
            }
            else
            {
                matrixSizeN = msN;
                matrixSizeM = msM;
                matrixValue = new double[matrixSizeN, matrixSizeM];
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
                }
            }
        }

        public Matrix(double [,] arr)
        {
            matrixValue = arr.Clone() as double[,];
            matrixSizeN = arr.GetLength(0);
            matrixSizeM = arr.GetLength(1);
        }
        public void MatrixInput()
        {
            for (int i = 0; i < matrixSizeN; i++)
            {
                Console.WriteLine($"Вводите данные для {i + 1}-ой строки матрицы");
                for (int j = 0; j < matrixSizeM; j++)
                {
                    Console.Write($"{j + 1} = ");
                    matrixValue[i, j] = Convert.ToInt32(Console.ReadLine());
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
                    matrixValue[i, j] = rnd.Next(1, 30);
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
                    matrixValue[i, i] = 1;
                }
            }
        }
        public Matrix TransMatrix()
        {
            Matrix newM = new Matrix(matrixSizeN, matrixSizeM, Operation.Zero);
            //int slave = 0;
            for(int i = 0; i < matrixSizeN; i++)
            {
                for(int j = 0; j < matrixSizeM; j++)
                {
                    newM.matrixValue[i, j] = matrixValue[j, i];
                    //slave = matrix_value[i, j];
                    //matrix_value[i, j] = matrix_value[j, i];
                    //matrix_value[j, i] = slave;
                }
            }
            return newM;
        }

        public static Matrix operator+ (Matrix mAdd1, Matrix mAdd2)
        {
            Matrix mAddRes = new Matrix(mAdd1.matrixSizeN, mAdd1.matrixSizeM, Operation.Zero);
            for (int i = 0; i < mAdd1.matrixSizeN; i++) 
            {
                for (int j = 0; j < mAdd2.matrixSizeM; j++) 
                {
                    mAddRes.matrixValue[i, j] = mAdd1.matrixValue[i, j] + mAdd2.matrixValue[i, j];
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
                    mAddRes.matrixValue[i, j] = mAdd1.matrixValue[i, j] - mAdd2.matrixValue[i, j];
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
                    mMultyRes.matrixValue[i, j] = 0;
                    for (int k = 0; k < mMulty2.matrixSizeN; k++)
                    {
                        mMultyRes.matrixValue[i, j] += mMulty1.matrixValue[i, k] * mMulty2.matrixValue[k, j];
                    }
                }
            }
            return mMultyRes;
        }
        public static Matrix operator*(double nValue, Matrix mMulty)
        {
            Matrix mRes = new Matrix(mMulty.matrixSizeN, mMulty.matrixSizeM, Operation.Zero);
            for(int i = 0; i < mMulty.matrixSizeN; i++)
            {
                for(int j = 0; j < mMulty.matrixSizeM; j++)
                {
                    mRes.matrixValue[i, j] = nValue * mMulty.matrixValue[i, j];
                }
            }
            return mRes;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < matrixSizeN; i++)
            {
                for (int j = 0; j < matrixSizeM; j++)
                {
                    sb.Append($" {matrixValue[i, j]} \t");
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
        //public Matrix(int msN, Operation op)
        //{
        //    if(msN < 1)
        //    {
        //        throw new Exception("Чел ты...");
        //    }
        //    else
        //    {
        //        matrixSizeN = msN;
        //        matrixSizeM = matrixSizeN;
        //        switch (op)
        //        {
        //            case Operation.Zero:
        //                break;
        //            case Operation.Input:
        //                MatrixInput();
        //                break;
        //            case Operation.Random:
        //                MatrixRandom();
        //                break;
        //            case Operation.Identity:
        //                IdentityMatrix();
        //                break;
        //        }
        //    }
        //}
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
