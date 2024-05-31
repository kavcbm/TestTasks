namespace Task1;
using System;

class Program  
{   
    static void Main(string[] args)
    {
         int n=5, m=4;         
         try{
            n = int.Parse(args[0]);
            m = int.Parse(args[1]);            
         }         
         catch(Exception e){
            Console.WriteLine($"Неверно указаны параметры. По умолчанию n = {n}, m = {m}");
            Console.WriteLine(e.Message);            
         }         
         
         RoundArray roundArray = new RoundArray(n);

         Console.WriteLine($"Кругорой массив при n = {n} имеет вид:");
         roundArray.ShowFirstElements(30);
         
         // Вывести первые 20 элементов пути.            
         // Согласно условию задачи это каждый (m-1)-вый элемент кругового массива:
         Console.WriteLine($"\n\n Путь для интервала длиной m = {m} :");
         roundArray.ShowPath(m, 20);

         Console.WriteLine();
         Console.ReadKey();    
    }
    
    public class RoundArray
    {
        public int[] Base; // Массив, который будет крутиться
        
        public RoundArray(int BaseLength=1){          
            // Parameters:
            //   BaseLength:
            //     Длина базового массива. То есть  полного круга            

            Base = new int[BaseLength];                        
            
            for (int i = 0; i < BaseLength; i++){
                Base[i] = i+1;                
            }
        }
        
        public void ShowFirstElements(int numberOfElemements, string delimiter = ","){
            for(int i = 0; i < numberOfElemements; i++){
                Console.Write($"{Base[i%Base.Length]} {(i < numberOfElemements-1  ? delimiter : String.Empty)} ");
            }
        }
        public void ShowPath(int segmentLength, int PathLength = 10, string delimiter = ","){
        //
        // Summary:
        //     Выводит путь в консоль. Путь тоже круговой массив.
        //
        // Parameters:
        //   segmentLength:
        //     Длина интервала
            
            for (int i=0; i<PathLength; i++){                
                Console.Write($"{Base[((segmentLength-1)*i)%Base.Length]} {(i < PathLength-1  ? delimiter : String.Empty)}");
            }
        }

    }
}
    
    


