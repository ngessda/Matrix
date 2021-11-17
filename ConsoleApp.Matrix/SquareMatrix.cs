using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Matrix
{
    class SquareMatrix : Matrix
    {
        private int sizeOfSqrMatrix;
        private int[,] matrixValue;

        public SquareMatrix(int size, Operation op)
            : base(size, op)
        {
            sizeOfSqrMatrix = size;
        }
        public int Determinant()
        {
            int counter = sizeOfSqrMatrix;
            int n = 0;
            int x = 0;
            //switch (counter)
            //{
            //    case 1:
            //        Console.WriteLine(matrixValue[sizeOfSqrMatrix, sizeOfSqrMatrix]);
            //        break;
            //    case 2:
            //        Console.WriteLine((matrixValue[0, 0] * matrixValue[1, 1]) - (matrixValue[1, 0] * matrixValue[0, 1]));
            //        break;
            //    case 3:

            //        break;
            //}
            if (counter == 1)
            {
                return matrixValue[n, x];
            }
            if (counter == 2)
            {
                return (matrixValue[n, x] * matrixValue[n + 1, x + 1]) - (matrixValue[n + 1, x] * matrixValue[n, x + 1]);
            }
            if(counter == 3)
            {
                return (matrixValue[n, x] * matrixValue[n + 1, x + 1] * matrixValue[n + 2, x + 2]) + (matrixValue[n + 2, x] * matrixValue[n, x + 1] * matrixValue[n + 1, x + 2]) + (matrixValue[n + 1, x] * matrixValue[n + 2, x + 1] * matrixValue[n, x + 2]) - (matrixValue[n + 2, x] * matrixValue[n + 1, x + 1] * matrixValue[n, x + 2]) - (matrixValue[n, x] * matrixValue[n + 2, x + 1] * matrixValue[n + 1, x + 2]) - (matrixValue[n + 1, x] * matrixValue[n, x + 1] * matrixValue[n + 2, x + 2]);
            }
            if(counter == 4)
            {

            }
            return 1;
        }
    }
}
