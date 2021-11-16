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
            Matrix matrix1 = new Matrix(3, 3,Matrix.Operation.Random);
            Matrix matrix2 = new Matrix(3, 3, Matrix.Operation.Random);
            Console.WriteLine("--------------------------------------------------------------------");
            Matrix matrix3 = matrix1 * matrix2;
            matrix3.PrintMatrix();
            Console.ReadKey();
        }
    }
}
