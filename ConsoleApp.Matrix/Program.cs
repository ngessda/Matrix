﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            //Matrix matrix = new Matrix(4, 4,Matrix.Operation.Random);
            //Console.WriteLine(matrix);
            //Console.WriteLine("======================================== \n \n");
            //Console.WriteLine(matrix.);
            //double[,] arr = { { 11, 2, 6 }, { 24, 1, 3 }, { 0, 2, 22 } };
            SquareMatrix matrix = new SquareMatrix(3, Matrix.Operation.Random);
            Console.WriteLine(matrix);
            Console.WriteLine(matrix.ObrMatrix() * matrix);
            Console.ReadKey();
        }
    }
}
