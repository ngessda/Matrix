using System;
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
            int[,] arr = { { 1, 2, 6 }, { 2, 1, 3 }, { 0, 2, 2 } };
           SquareMatrix matrix = new SquareMatrix(arr);
            Console.WriteLine(matrix.Determinant());
            Console.ReadKey();
        }
    }
}
