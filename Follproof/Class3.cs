using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Follprooff
{
    public static class Slau
    {
        static public double Determinant(double[,] matrix, int n)
        {
            if (n == 1) // если матрица первого порядка, то ее определитель есть единственный элемент;
                return matrix[0, 0]; // возвращаем его;
            if (allOfFirstElenemtAreZero(matrix, n)) // если есть нулевой столбец, то определитель равен 0;
                return 0;
            int comparisons; // число перестановок строк;
            sortArrayByFirstElenemt(matrix, n, out comparisons); // сортируем матрицу по первым элементам строк;
            for (int i = 1; i < n; ++i) // итерация методом Гаусса;
            {
                double index = matrix[i, 0] / matrix[0, 0];
                for (int j = 0; j < n; ++j)
                    matrix[i, j] -= index * matrix[0, j];
            } // где зануляется первый столбец с 1 по n - 1 строки;
              //printMatrix(matrix, n);  можно распечатывать промежуточную матрицу;
            return matrix[0, 0] * Math.Pow(-1, comparisons) * Determinant(generateSubMatrix(matrix, n), n - 1);
            // возвращаем определитель рекурсивно;
        }
        // статический метод для сваппинга 2х линейных массивов; 
        static private void swapArray(double[,] matrix, int index, int lengthOfMatrix)
        {
            for (int i = 0; i < lengthOfMatrix; ++i)
                swapDouble(ref matrix[index, i], ref matrix[index + 1, i]);
        }
        // статический метод для своппинга 2х элементов;
        static private void swapDouble(ref double Buffer1, ref double Buffer2)
        {
            double Tmp = Buffer1;
            Buffer1 = Buffer2;
            Buffer2 = Tmp;
        }
        // сортировка матрицы по первым элементам строк модифицированным методом пузырька;
        static private void sortArrayByFirstElenemt(double[,] matrix, int n, out int comparisons)
        {
            comparisons = new int();
            bool flagOfSwapping = true;
            int numberOfIteration = new int();
            while (flagOfSwapping) // цикл выполняется пока есть хотя бы одна перестановка в ходе итерации;
            {
                flagOfSwapping = false;
                for (int i = 0; i < n - 1 - numberOfIteration; ++i)
                    if (matrix[i, 0] < matrix[i + 1, 0])
                    {
                        swapArray(matrix, i, n);
                        flagOfSwapping = true;
                        ++comparisons;
                    }
                numberOfIteration++;
            }
        }
        // статический метод вывода матрицы на экран;
        static private void printMatrix(double[,] matrix, int n)
        {
            Console.WriteLine();
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                    Console.Write("{0:f2}\t", matrix[i, j]);
                Console.WriteLine();
            }
        }
        // статический метод выделения подматрицы размера n - 1;
        static private double[,] generateSubMatrix(double[,] matrix, int n)
        {
            double[,] subMatrix = new double[n - 1, n - 1];
            for (int i = 1; i < n; ++i) // выделяется подматрица со строк [1, n);
                for (int j = 1; j < n; ++j) // .. cтолбцов [1; n);
                    subMatrix[i - 1, j - 1] = matrix[i, j];
            return subMatrix;
        }
        // статический метод проверки первого столбца на равенства нулевому;
        static private bool allOfFirstElenemtAreZero(double[,] matrix, int n)
        {
            for (int i = 0; i < n; ++i)
                if (matrix[i, 0] != 0)
                    return false;
            return true;
        }
        public static double[] Calculation(int dim, double[,] masA, double[] masB)
        {
            double[] masX = new double[dim];
            for (int i = 0; i < dim; i++)
            {
                masX[i] = 0;
                masB[i] /= masA[i, i];
                for (int j = 0; j < dim; j++)
                    if (i != j)
                        masA[i, j] /= (-1) * masA[i, i];
                masA[i, i] = 0;
            }
            int count = 1;
            while (count != 7)
            {
                for (int i = 0; i < dim; i++)
                {
                    masX[i] = 0;
                    //Console.Write("x{0}({1}) = ", (i + 1), count);
                    masX[i] += masB[i];
                    //Console.Write("{0}", masB[i]);
                    for (int j = 0; j < dim; j++)
                    {
                        masX[i] += masA[i, j] * masX[j];
                        //Console.Write(" + ({0})*({1})", masA[i, j], masX[j]);
                    }
                    //Console.WriteLine(" = {0}", masX[i]);
                }
                count++;
                //Console.WriteLine();
            }
            for (int j = 0; j < dim; j++)
                Console.WriteLine("x{0} = {1}; ", (j + 1), masX[j]);
            return masX;
        }
    }
}
