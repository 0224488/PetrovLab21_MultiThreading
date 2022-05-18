using System;
using System.Collections.Generic;
using System.Threading;

namespace PetrovLab21_MultiThreading
{
	class Program
	{
		// Имеется пустой участок земли (двумерный массив) и план сада, который необходимо реализовать. 
		// Эту задачу выполняют два садовника, которые не хотят встречаться друг с другом. 
		// Первый садовник начинает работу с верхнего левого угла сада и перемещается слева направо, 
		// сделав ряд, он спускается вниз. 
		// Второй садовник начинает работу с нижнего правого угла сада и перемещается снизу вверх, 
		// сделав ряд, он перемещается влево. 
		// Если садовник видит, что участок сада уже выполнен другим садовником, он идет дальше. 
		// Садовники должны работать параллельно. Создать многопоточное приложение, моделирующее работу садовников

		private static int[,] array;

		static void Main(string[] args)
		{
			Console.WriteLine("Введите количество строк");
			int rows = int.Parse(Console.ReadLine());
			Console.WriteLine("Введите количество столбцов");
			int columns = int.Parse(Console.ReadLine());

			array = new int[rows, columns];

			Thread thread1 = new Thread(() => gardener1(rows, columns));
			Thread thread2 = new Thread(() => gardener2(rows, columns));

			thread1.Start();
			thread2.Start();

			thread1.Join();
			thread2.Join();

			for(int i = 0; i < rows; i++)
			{
				for(int j = 0; j < columns; j++)
				{
					Console.Write($"{array[i, j]} ");
				}
				Console.WriteLine();
			}

			Console.ReadLine();
		}

		private static void gardener1(int rows, int columns)
		{
			for(int i = 0; i < rows; i++)
			{
				for(int j = 0; j < columns; j++)
				{
					if(array[i, j] == 0)
						array[i, j] = 1;
					Thread.Sleep(10);
				}
			}
		}

		private static void gardener2(int rows, int columns)
		{
			for(int i = columns - 1; i > 0; i--)
			{
				for(int j = rows - 1; j > 0; j--)
				{
					if(array[j, i] == 0)
						array[j, i] = 2;
					Thread.Sleep(10);
				}
			}
		}

	}
}
