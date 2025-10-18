using System;

class Program
{
    static void Main()
    {
        double sum = 0;
        
        Console.WriteLine("Вводите числа по одному (для завершения введите 0):");
        
        while (true)
        {
            Console.Write("Введите число: ");
            string input = Console.ReadLine()!;
            
            if (double.TryParse(input, out double number))
            {
                if (number == 0)
                {
                    Console.WriteLine("Программа завершена.");
                    break;
                }
                
                sum += number;
                Console.WriteLine($"Текущая сумма: {sum}");
            }
            else
            {
                Console.WriteLine("Ошибка: введите корректное число!");
            }
        }
        
        Console.WriteLine($"Итоговая сумма: {sum}");
    }
}