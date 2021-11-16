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
            Matrix matrix = new Matrix(4, 4,Matrix.Operation.Random);
            Console.WriteLine(matrix);
            Console.WriteLine("======================================== \n \n");
            matrix.TransMatrix();
            Console.WriteLine(matrix);
            Console.ReadKey();
        }
    }
}
