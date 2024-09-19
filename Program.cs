using System;

class MyClass
{
    static void Main()
    {
        string? input = Console.ReadLine();
        // Убираем все пробелы в полученной строке
        if (input != null) input = input.Replace(" ", "");
        else
        {
            Console.WriteLine("Введена пустая строка.");
            return;
        }
        // Метод TryParse не может перобразовать string с числом с точкой в decimal, если число написано через точку, заменяем на запятую.
        if (input.Contains('.')) input = input.Replace('.', ',');

        // Поиск оператора действия, его индекс будет опеределять где заканчивается одно число и начинается другое
        int idx;
        char op;
        if (input.Contains('+'))
        {
            idx = input.IndexOf('+');
            op = '+';
        }
        else if (input.Contains('/'))
        {
            idx = input.IndexOf('/');
            op = '/';
        }
        else if (input.Contains('*'))
        {
            idx = input.IndexOf('*');
            op = '*';
        }
        else
        {
            idx = input.IndexOf('-', 1);
            op = '-';
        }

        // Прерывание программы, если разделитель не найден
        if (idx == -1)
        {
            Console.WriteLine("Данные введены неверно.\nПроверьте правильность введенных данных");
            return;
        }

        // Преобразование частей исходной строки в числа, с проверкой корректности ввода. Прерывание выполнения, в случае ошибки ввода
        if (!Decimal.TryParse(input[..idx], out decimal firstNum))
        {
            Console.WriteLine("Первое число введено неверно");
            return;
        }
        if (!Decimal.TryParse(input[(idx + 1)..], out decimal secondNum))
        {
            Console.WriteLine("Второе число введено неверно");
            return;
        }

        // Вычислние результата операции        
        var result = op switch
        {
            '+' => firstNum + secondNum,
            '-' => firstNum - secondNum,
            '/' => firstNum / secondNum,
            '*' => firstNum * secondNum,
            _ => 0,
        };

        // Вывод результата на консоль
        Console.WriteLine(result);
    }
}