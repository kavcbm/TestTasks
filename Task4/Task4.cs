namespace Task4;

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
            original = lines.Select(x=>Int32.Parse(x)).ToArray();
            
        }
        catch{
            lines = File.ReadAllLines("srcArray.txt");
            original = lines.Select(x=>Int32.Parse(x)).ToArray();            
        }
        array = original;
        
        Console.WriteLine(array.Max().GetType());
        maxValue = array.Max<int>();
        int index = Array.IndexOf(array, maxValue);

        Console.WriteLine($"[{index}] = {maxValue}");
        Console.WriteLine($"{string.Join(",", array)} Среднее: {array.Average()}\n________");

        int step = 0;
        
        // алгоритм приведения массива придумал, 
        // но это еще надо строго доказать что кол-во ходов будет минимальным
        while((array.Max()!=array.Min()) )
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
            Console.WriteLine($"{string.Join(",", array)} Среднее: {array.Average()}");
            Console.ReadKey();
            step++;
        }
        Console.WriteLine($"Исходный массив: {string.Join(",", original)}");
        Console.WriteLine($"Приводится  к  : {string.Join(",", array)}");
        Console.WriteLine($"за {step} ходов");
    }

}
