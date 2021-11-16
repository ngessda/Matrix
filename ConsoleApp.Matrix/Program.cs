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
            Matrix matrix = new Matrix();
            matrix.Size_Of_Identity_Matrix();
            Console.WriteLine(matrix.M_Size);
            matrix.Matrix_Input_Random();
            matrix.Return_Matrix();
            Console.ReadKey();
        }
    }
}
