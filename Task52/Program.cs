// Задача 52.
// Задайте двумерный массив из целых чисел.
// Найдите среднее арифметическое элементов в каждом столбце.  
// Например, задан массив:  
// 1 4 7 2  
// 5 9 2 3  
// 8 4 2 4  
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.

int GeneratorRandomInt(int minValue, int maxValue)  // генератор Random int в диапазоне [min,max]
{
    Random rnd = new Random();
    return rnd.Next(minValue, maxValue + 1);
}

int[,] CreateMatrixRndInt(int rows, int columns, int min, int max)  // создает массив
{
    int[,] matrix = new int[rows, columns];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = GeneratorRandomInt(min, max);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)     // вывод массива в консоль
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        // Console.Write("[");
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (j < matrix.GetLength(1) - 1) Console.Write($"{matrix[i, j]} ");
            else Console.Write($"{matrix[i, j]}");
        }
        // Console.WriteLine("]");
        Console.WriteLine();
    }
}

double[] CountAverageInColumnsArray2D(int[,] matrix)  // среднее арифметическое каждого столбца
{
    double[] arrayResults = new double[matrix.GetLength(1)];

    for (int i = 0; i < matrix.GetLength(1); i++)   // columns
    {
        int sumColumns = 0;
        for (int j = 0; j < matrix.GetLength(0); j++)   // rows
        {
            sumColumns += matrix[j, i];
        }

        double aver = (double)sumColumns / matrix.GetLength(0);
        // Console.WriteLine($"i:{i} sum:{sumColumns}, aver:{aver}");   // для проверки
        arrayResults[i] = Math.Round(aver, 1, MidpointRounding.ToZero);
    }
    return arrayResults;
}

void PrintArray(double[] array)
{
    // Console.Write("[");
    for (int i = 0; i < array.Length; i++)
    {
        if (i < array.Length - 1) Console.Write($"{array[i]}; ");
        else Console.Write($"{array[i]}");
    }
    // Console.WriteLine("]");
    Console.WriteLine();
}


Console.Clear();
int matrixSizeMin = 3;
int matrixSizeMax = 4;
int matrixElemMin = 1;
int matrixElemMax = 9;
int matrixRow = GeneratorRandomInt(matrixSizeMin, matrixSizeMax);
int matrixCol = GeneratorRandomInt(matrixSizeMin, matrixSizeMax);
int[,] array2D = CreateMatrixRndInt(matrixRow, matrixCol, matrixElemMin, matrixElemMax);
// int[,] array2D = {
//     {1,4,7,2},
//     {5,9,2,3},
//     {8,4,2,4}
//     };
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3. - при округлении ToZero
// Среднее арифметическое каждого столбца: 4,7; 5,7; 3,7; 3. - при округлении AwayFromZero

PrintMatrix(array2D);
Console.WriteLine();

// массив с расчетом ср. арифметического по столбцам
double[] averArray = CountAverageInColumnsArray2D(array2D);

// вывод в консоль результата
Console.Write($"Среднее арифметическое каждого столбца: ");
PrintArray(averArray);
Console.WriteLine();
