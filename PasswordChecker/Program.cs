using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Проверка надежности пароля");
        Console.WriteLine("Критерии надежности:");
        Console.WriteLine("- Длина не менее 8 символов");
        Console.WriteLine("- Содержит хотя бы одну цифру");
        Console.WriteLine("- Содержит хотя бы одну заглавную букву");
        Console.WriteLine("- Содержит хотя бы один специальный символ (!@#$%^&*)");
        Console.WriteLine();
        
        Console.Write("Введите пароль для проверки: ");
        string password = Console.ReadLine()!;
        
        // Проверяем критерии
        bool isLongEnough = CheckLength(password);
        bool hasDigit = CheckDigit(password);
        bool hasUpperCase = CheckUpperCase(password);
        bool hasSpecialChar = CheckSpecialChar(password);
        
        Console.WriteLine();
        
        // Выводим результаты проверки
        if (isLongEnough && hasDigit && hasUpperCase && hasSpecialChar)
        {
            Console.WriteLine("✅ Пароль надежный! Все критерии выполнены.");
        }
        else
        {
            Console.WriteLine("❌ Пароль ненадежный. Не выполнены следующие критерии:");
            
            if (!isLongEnough)
                Console.WriteLine("   - Длина менее 8 символов");
            
            if (!hasDigit)
                Console.WriteLine("   - Отсутствуют цифры");
            
            if (!hasUpperCase)
                Console.WriteLine("   - Отсутствуют заглавные буквы");
            
            if (!hasSpecialChar)
                Console.WriteLine("   - Отсутствуют специальные символы (!@#$%^&*)");
        }
        
        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
    
    // Проверка длины пароля
    static bool CheckLength(string password)
    {
        return password.Length >= 8;
    }
    
    // Проверка наличия цифр
    static bool CheckDigit(string password)
    {
        return password.Any(char.IsDigit);
    }
    
    // Проверка наличия заглавных букв
    static bool CheckUpperCase(string password)
    {
        return password.Any(char.IsUpper);
    }
    
    // Проверка наличия специальных символов
    static bool CheckSpecialChar(string password)
    {
        char[] specialChars = { '!', '@', '#', '$', '%', '^', '&', '*' };
        return password.Any(c => specialChars.Contains(c));
    }
}