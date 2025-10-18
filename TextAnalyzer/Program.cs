using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== АНАЛИЗАТОР ТЕКСТА ===");
        Console.WriteLine("Введите текст для анализа:");
        
        string text = Console.ReadLine()!;
        
        if (string.IsNullOrWhiteSpace(text))
        {
            Console.WriteLine("Текст не был введен!");
            return;
        }
        
        // Анализируем текст
        AnalyzeText(text);
    }
    
    static void AnalyzeText(string text)
    {
        // Очищаем текст от лишних пробелов
        text = text.Trim();
        
        // 1. Количество слов
        string[] words = GetWords(text);
        int wordCount = words.Length;
        
        // 2. Количество предложений
        int sentenceCount = GetSentenceCount(text);
        
        // 3. Самые частые слова
        var frequentWords = GetMostFrequentWords(words);
        
        // 4. Средняя длина слов
        double averageWordLength = GetAverageWordLength(words);
        
        // Вывод результатов
        Console.WriteLine("\n=== РЕЗУЛЬТАТЫ АНАЛИЗА ===");
        Console.WriteLine($"Количество слов: {wordCount}");
        Console.WriteLine($"Количество предложений: {sentenceCount}");
        Console.WriteLine($"Средняя длина слова: {averageWordLength:F2} символов");
        
        Console.WriteLine("\nСамые частые слова:");
        foreach (var word in frequentWords)
        {
            Console.WriteLine($"  '{word.Key}' - {word.Value} раз");
        }
    }
    
    // Получение массива слов (игнорируем пунктуацию)
    static string[] GetWords(string text)
    {
        char[] separators = { ' ', ',', '.', '!', '?', ';', ':', '(', ')', '[', ']', '{', '}', '"', '\'', '\n', '\r', '\t' };
        return text.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                   .Where(word => word.Length > 0 && !string.IsNullOrWhiteSpace(word))
                   .ToArray();
    }
    
    // Подсчет предложений
    static int GetSentenceCount(string text)
    {
        char[] sentenceSeparators = { '.', '!', '?' };
        int count = 0;
        bool inSentence = false;
        
        foreach (char c in text)
        {
            if (char.IsLetterOrDigit(c) && !inSentence)
            {
                inSentence = true;
                count++;
            }
            else if (sentenceSeparators.Contains(c) && inSentence)
            {
                inSentence = false;
            }
        }
        
        return count;
    }
    
    // Получение самых частых слов
    static List<KeyValuePair<string, int>> GetMostFrequentWords(string[] words)
    {
        var wordFrequency = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        
        foreach (string word in words)
        {
            string cleanWord = word.ToLower();
            if (wordFrequency.ContainsKey(cleanWord))
            {
                wordFrequency[cleanWord]++;
            }
            else
            {
                wordFrequency[cleanWord] = 1;
            }
        }
        
        // Возвращаем топ-5 самых частых слов
        return wordFrequency
            .Where(pair => pair.Key.Length > 2) // Игнорируем короткие слова (предлоги и т.д.)
            .OrderByDescending(pair => pair.Value)
            .ThenBy(pair => pair.Key)
            .Take(5)
            .ToList();
    }
    
    // Расчет средней длины слов
    static double GetAverageWordLength(string[] words)
    {
        if (words.Length == 0) return 0;
        
        int totalLength = words.Sum(word => word.Length);
        return (double)totalLength / words.Length;
    }
}