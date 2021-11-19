using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Matrix
{
    class SquareMatrix : Matrix
    {

        public SquareMatrix(int size, Operation op)
            : base(size, size, op)
        {
            matrixSizeN = size;
            matrixSizeM = matrixSizeN;
        }
        public SquareMatrix(double [,] arr)
            :base(arr)
        {
            
        }
        public SquareMatrix(Matrix matrix) : base(matrix)
        {
            if (matrix.Rows != matrix.Colls)
            {
                throw new Exception("Ошибка-ошибка!");
            }
        }
        public SquareMatrix ObrMatrix()
        {
            return GetObrMatrix(this);
        }

        public static SquareMatrix operator +(SquareMatrix a, SquareMatrix b)
        {
            return new SquareMatrix((a as Matrix) + (b as Matrix));
        }
        public static SquareMatrix operator -(SquareMatrix a, SquareMatrix b)
        {
            return new SquareMatrix((a as Matrix) - (b as Matrix));
        }
        public static SquareMatrix operator *(SquareMatrix a, SquareMatrix b)
        {
            return new SquareMatrix((a as Matrix) * (b as Matrix));
        }
        public static SquareMatrix operator *(double scalar, SquareMatrix matrix)
        {
            return new SquareMatrix(scalar * (matrix as Matrix));
        }
        public SquareMatrix TranspMatrix()
        {
            return new SquareMatrix(TransMatrix());
        }
        public double Determinant()
        {
            return GetMatrixDet(this);
        }

        private SquareMatrix GetObrMatrix(SquareMatrix m)
        {
            SquareMatrix m1 = new SquareMatrix(matrixSizeN, Operation.Zero);
            m1 = ((1 / GetMatrixDet(m)) * GetMObrsMatrix(m));
            return m1;
        }
        private SquareMatrix GetMObrsMatrix(SquareMatrix m)
        {
            SquareMatrix m2 = new SquareMatrix(matrixSizeN, Operation.Zero);
            for (int i = 0; i < m.matrixSizeN; i++)
            {
                for(int j = 0; j < m.matrixSizeM; j++)
                {
                    m2.matrixValue[i,j] = Math.Pow(-1, (1 + 1 + i + j)) * GetMatrixDet(GetMinorDet(m, i, j));
                }
            }
            return m2.TranspMatrix();
        }
        private double GetMatrixDet(SquareMatrix minor)
        {
            if (minor.matrixSizeN == 1)
            {
                return matrixValue[0, 0];
            }
            else if (minor.matrixSizeN == 2)
            {
                double res = (minor.matrixValue[0, 0] * minor.matrixValue[1, 1]) - (minor.matrixValue[1, 0] * minor.matrixValue[0, 1]);
                return res;
            }
            else
            {
                double result = 0;
                for (int i = 0; i < minor.matrixSizeN; i++)
                {
                    result += matrixValue[i, 0] * Math.Pow(-1, (1 + 1 + i)) * GetMatrixDet(GetMinorDet(minor, i, 0));
                }
                return result;
            }
        }

        private SquareMatrix GetMinorDet(SquareMatrix minor, int rows, int colls)
        {
            int mSize = matrixSizeN - 1;
            SquareMatrix M = new SquareMatrix(mSize, Operation.Zero);
            for(int i = 0; i < minor.matrixSizeN; i++)
            {
                if( i == rows)
                {
                    continue;
                }
                for(int j = 0; j < minor.matrixSizeM; j++)
                {
                    if( j == colls)
                    {
                        continue;
                    }
                    if (i > rows)
                    {
                        if (j < colls)
                        {
                            M.matrixValue[i - 1, j ] = minor.matrixValue[i, j];
                        }
                        else
                        {
                            M.matrixValue[i - 1, j - 1] = minor.matrixValue[i, j];
                        }
                    }
                    else
                    {
                        if (j < colls)
                        {
                            M.matrixValue[i, j] = minor.matrixValue[i, j];
                        }
                        else
                        {
                            M.matrixValue[i, j - 1] = minor.matrixValue[i, j];
                        }
                    }
                }
            }
            return M;
        }
    }
}
