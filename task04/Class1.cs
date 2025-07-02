namespace task04
{
    public interface ISpaceship
{
    void MoveForward();      // Движение вперед
    void Rotate(int angle);  // Поворот на угол (градусы)
    void Fire();             // Выстрел ракетой
    int Speed { get; }       // Скорость корабля
    int FirePower { get; }   // Мощность выстрела
}

public class Cruiser : ISpaceship
{
    public int Speed { get; } = 50;
    public int FirePower { get; } = 80;
    
    public void MoveForward()
    {
        Console.WriteLine($"Cruiser speed : {Speed}");
    }
    
    public void Rotate(int angle)
    {
        Console.WriteLine($"Cruiser angle degree : {angle}");
    }
    
    public void Fire()
    {
        Console.WriteLine($"Cruiser fire power: {FirePower}");
    }
}

    public class Fighter : ISpaceship
    {
        public int Speed { get; } = 100;
        public int FirePower { get; } = 30;

        public void MoveForward()
        {
            Console.WriteLine($"Fighter speed : {Speed}");
        }

        public void Rotate(int angle)
        {
            Console.WriteLine($"Fighter angle degree: {angle}");
        }

        public void Fire()
        {
            Console.WriteLine($"Fighter fire power: {FirePower}");
        }
    }
 }