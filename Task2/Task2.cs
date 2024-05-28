namespace Task2;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string CircleParamsFilePath, PointsFilePath;
        if(args.Length != 2){
            Console.WriteLine("Параметры (пути к файлам) указаны неверно.");
            // для отладки - когда запускаем .exe без параметров:
            CircleParamsFilePath = "Circle.txt";
            PointsFilePath = "Points.txt" ;
        }
        else{
            CircleParamsFilePath  = args[0];
            PointsFilePath = args[1];
        }
        //Читаем файл с Параметрами окружности
        //string[] lines = File.ReadAllLines("Circle.txt");        
        string[] lines = File.ReadAllLines(CircleParamsFilePath);        
        // Первая строка - координаты окружности, разделенные пробелом        
        // Вторая строка - радиус.
        Point point = new Point(lines[0]);
        
        Circle circle = new Circle(point, float.Parse(lines[1]));        
        Console.WriteLine($"Центр: ({circle.Center_X}; {circle.Center_Y}) Радиус: {circle.Radius}\n");
        
        //Читаем файл с координатами точек:
        //lines = File.ReadAllLines("Points.txt");
        lines = File.ReadAllLines(PointsFilePath);
        foreach (string str in lines ){
            point.SetFromString(str);
            circle.Check(point);
        }
    }
}

//_____________________________________________________________________________________________
public struct Circle
{   public float Center_X, Center_Y, Radius;
    public Circle(Point point, float Radius){
        this.Center_X = point.X;
        this.Center_Y = point.Y;
        this.Radius = Radius;
    }
    public int Check(Point point){
        
        // квадрат расстояния от точки до центра:
        float square_of_distance = (point.X - this.Center_X)*(point.X - this.Center_X) 
                                 + (point.Y - this.Center_Y)*(point.Y - this.Center_Y);

        // сравнить с квадратом радиуса:
        switch (Math.Sign(square_of_distance-(this.Radius)*(this.Radius))){
            case -1:
                //Console.WriteLine($"Точка ({point.X}; {point.Y}) Внутри круга");
                return 1;
            case 0:
                //Console.WriteLine($"Точка ({point.X}; {point.Y}) На Границе круга");
                return 0;            
            case 1:
                //Console.WriteLine($"Точка ({point.X}; {point.Y}) Снаружи ");
            return 2;

            default : return 0;           
        }
        

    }
}
public struct Point
{
    public float X,Y;
    public Point(int X, int Y){
        this.X = X;
        this.Y = Y;
    }
    public Point(string str ){
        this.X = float.Parse(str.Split(" ")[0]);
        this.Y = float.Parse(str.Split(" ")[1]);
    }
    public void SetFromString(string str){
        X = float.Parse(str.Split(" ")[0]);
        Y = float.Parse(str.Split(" ")[1]);
    }
}