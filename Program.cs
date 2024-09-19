using System;

class MyClass
{
    static void Main()
    {
        Console.WriteLine("Введите выражение, в формате а + b");
        string? input = Console.ReadLine();
        
        if (input == null) 
        {
            Console.WriteLine("Введена пустая строка.");
            return;
        }

        // Убираем все пробелы в полученной строке
        input = input.Replace(" ", "");

        // Метод TryParse не может перобразовать string с числом в котором десятичная часть выделена точкой в decimal, 
        // если число написано через точку, заменяем на запятую.
        if (input.Contains('.')) input = input.Replace('.', ',');

        // Поиск оператора действия, его индекс будет опеределять где заканчивается одно число и начинается другое
        char op = FindOperand(input, out int idx);

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
            _ => 0
        };

        // Вывод результата на консоль
        Console.WriteLine($"{firstNum} {op} {secondNum} = {result}");
    }
    static char FindOperand(string str, out int idx)
    {
        char op;
        if (str.Contains('+'))
        {
            idx = str.IndexOf('+');
            op = '+';
        }
        else if (str.Contains('/'))
        {
            idx = str.IndexOf('/');
            op = '/';
        }
        else if (str.Contains('*'))
        {
            idx = str.IndexOf('*');
            op = '*';
        }
        else
        {
            idx = str.IndexOf('-', 1);
            op = '-';
        }

        return op;
    }
}