using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Matrix
{
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
    class Matrix
    {
        private int matrix_size_n;
        private int matrix_size_m;
        private int[,] matrix_value;
        public Matrix(int msN, int msM)
        {
            matrix_size_n = msN;
            matrix_size_m = msM;
            if (matrix_size_n < 1 || matrix_size_m < 1)
            {
                Console.WriteLine("Чел ты...");
                Console.ReadKey();
            }
            else
            {
                matrix_value = new int[matrix_size_n, matrix_size_m];
            }
        }
        public Matrix(int SoiM)
        {
            matrix_size_n = SoiM;
            matrix_size_m = matrix_size_n;
            if (matrix_size_n < 1)
            {
                Console.WriteLine("Чел ты...");
                Console.ReadKey();
            }
            else
            {
                matrix_value = new int[matrix_size_n, matrix_size_m];
            }
        }
        public void Input_Matrix_To_Zero()
        {
            for (int i = 0; i < matrix_size_n; i++)
            {
                for (int j = 0; j < matrix_size_m; j++)
                {
                    matrix_value[i, j] = 0;
                }
            }
        }
        public void Matrix_Input_Manually()
        {
            for (int i = 0; i < matrix_size_n; i++)
            {
                Console.WriteLine($"Вводите данные для {i + 1}-ой строки матрицы");
                for (int j = 0; j < matrix_size_m; j++)
                {
                    Console.Write($"{j + 1} = ");
                    matrix_value[i, j] = Convert.ToInt32(Console.ReadLine());
                }
                Console.Clear();
            }
        }
        public void Matrix_Input_Random()
        {
            Random rnd = new Random();
            for (int i = 0; i < matrix_size_n; i++)
            {
                for (int j = 0; j < matrix_size_m; j++)
                {
                    matrix_value[i, j] = rnd.Next(0, 2);
                }
            }
        }
        public void Return_Matrix()
        {
            for (int i = 0; i < matrix_size_n; i++)
            {
                for (int j = 0; j < matrix_size_m; j++)
                {
                    Console.Write($"{i + 1}.{j + 1} = {matrix_value[i, j]} \t");
                }
                Console.WriteLine("\n");
            }
        }
    }
}
