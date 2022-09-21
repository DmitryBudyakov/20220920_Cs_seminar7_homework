// Задача 50. 
// Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, 
// и возвращает значение этого элемента или же указание, что такого элемента нет.  
// Например, задан массив:
// 1 4 7 2  
// 5 9 2 3  
// 8 4 2 4  
// 1,7 -> такого числа в массиве нет

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

bool IsElemInArray2D(int[,] matrix, int rows, int columns)  // проверка есть ли индексы в массиве
{
    if (rows < matrix.GetLength(0)
        && columns < matrix.GetLength(1)
        ) return true;
    else return false;
}

int GetElemInArray2D(int[,] matrix, int row, int col)   // возврат элемента массива по индексу
{
    return matrix[row, col];
}

Console.Clear();
int matrixSizeMin = 3;
int matrixSizeMax = 5;
int matrixElemMin = 1;
int matrixElemMax = 9;
int matrixRow = GeneratorRandomInt(matrixSizeMin, matrixSizeMax);
int matrixCol = GeneratorRandomInt(matrixSizeMin, matrixSizeMax);
int[,] array2D = CreateMatrixRndInt(matrixRow, matrixCol, matrixElemMin, matrixElemMax);

// ввод пользователем номера строки и столбца в массиве
Console.Write("Введите номер строки в двумерном массиве: ");
int rowId = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите номер столбца в двумерном массиве: ");
int columnId = Convert.ToInt32(Console.ReadLine());
Console.WriteLine();

PrintMatrix(array2D);
Console.WriteLine();

// проверка, есть запрашиваемый элемент в массиве или нет и вывод в консоль
bool checkExist = IsElemInArray2D(array2D, rowId, columnId);
if (checkExist)
{
    int element = GetElemInArray2D(array2D, rowId, columnId);
    Console.WriteLine($"{rowId},{columnId} -> {element}\n");
}
else Console.WriteLine($"{rowId},{columnId} -> Такого числа в массиве нет.\n");
