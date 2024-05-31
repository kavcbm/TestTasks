namespace Task4;
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        int[] array,original;
        string[] lines;
        int maxValue, minValue;
        double average;

        try{
            lines = File.ReadAllLines(args[0]);
        }
        catch (Exception e){
            Console.WriteLine(e.Message);
            Console.WriteLine( "\n Читаем из файла srcArray.txt");
            lines = File.ReadAllLines("srcArray.txt");
        }
        
        // Пустые строки не считаем
        original = (from x in lines where x.Length > 0 select int.Parse(x)).ToArray(); 

        array = new int[original.Length];
        Array.Copy(original,array, original.Length);
                
        maxValue = array.Max<int>();
        int index = Array.IndexOf(array, maxValue);

        Console.WriteLine($"{string.Join(",", array)} Среднее: {array.Average()}\n________");

        int step = 0;
        
        // алгоритм приведения массива:
        // приближать максимально удаленное значение к среднему. Шаг это изменение одного элемента на единицу
        // но это еще надо строго доказать что кол-во ходов будет минимальным
        while(array.Max()!=array.Min()) 
        {
            maxValue = array.Max<int>();
            minValue = array.Min<int>();
            average  = array.Average();            
            //Console.WriteLine($"max-aver = {maxValue} - {average} = {maxValue - average}  aver-min ={average - minValue}= {average- minValue}");
            if(maxValue - average >= average - minValue){
                // Уменьшаем максимсальное значение на единицу:
                array[Array.IndexOf(array, maxValue)]--;
            }
            else if(maxValue - average < average - minValue)
            {
                array[Array.IndexOf(array, minValue)]++;
            }
            
            //Для визуализации:
            //Console.WriteLine($"{string.Join(",", array)} Среднее: {array.Average()}");
            //Console.ReadKey();
            
            step++;
        }
        Console.WriteLine($"Исходный массив: {string.Join(",", original)}");
        Console.WriteLine($"Приводится  к  : {string.Join(",", array)}");
        Console.WriteLine($"за {step} ходов");
    }

}
