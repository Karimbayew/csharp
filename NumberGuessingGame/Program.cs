using System;

class Program
{
    static void Main()
    {
        Random random = new Random();
        int secretNumber = random.Next(1, 11); // Число от 1 до 10 включительно
        int attempts = 0;
        
        Console.WriteLine("Я загадал число от 1 до 10. Попробуйте угадать!");
        
        while (true)
        {
            Console.Write("Ваша попытка: ");
            string input = Console.ReadLine()!;
            
            if (int.TryParse(input, out int guess))
            {
                attempts++;
                
                if (guess == secretNumber)
                {
                    Console.WriteLine($"Поздравляю! Вы угадали число {secretNumber} за {attempts} попыток!");
                    break;
                }
                else if (guess < secretNumber)
                {
                    Console.WriteLine("Загаданное число БОЛЬШЕ");
                }
                else
                {
                    Console.WriteLine("Загаданное число МЕНЬШЕ");
                }
            }
            else
            {
                Console.WriteLine("Ошибка: введите целое число от 1 до 10!");
            }
        }
        
        Console.ReadKey();
    }
}