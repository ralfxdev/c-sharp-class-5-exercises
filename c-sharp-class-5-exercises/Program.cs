//Escribir un programa que solicite la carga de valores positivos, hasta que el usuario
//ingrese un cero, luego muestre cual fue el numero mayor ingresado y el menor.
using System.Text.RegularExpressions;

static void exercise1()
{
    int n=0, max = int.MinValue, min = int.MaxValue;
    do
    {
        
        try
        {
            Console.WriteLine("Ingrese un número positivo: ");
            n = Convert.ToInt32(Console.ReadLine());
            if (n > max) max = n;
            if (n < min && n != 0) min = n;
        }
        catch (FormatException)
        {
            Console.WriteLine("Entrada no válida. Intente nuevamente.");
            continue;
        }
    } while (n != 0);

    Console.WriteLine($"El max es: {max} y el min es {min}");
}

//Adivinar el Número que está pensando
static void exercise2()
{
    int n;
    Console.WriteLine("Anota un número: ");
    n = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine($"Multiplica tu número x 2");
    Console.ReadLine();
    n = n * 2;
    Console.WriteLine($"Ahora sumale 8");
    Console.ReadLine();
    n = n + 8;
    Console.WriteLine($"Multiplica tu número x 5");
    Console.ReadLine();
    n = n * 5;
    Console.WriteLine($"Anota el resultado: ");
    string input = Console.ReadLine()!;

    input = input.Substring(0, input.Length - 1);

    int result = Convert.ToInt32(input);
    result = result - 4;

    Console.WriteLine($"Tu número es {result}");
}

//Contador de palabras
static void exercise3()
{
    try
    {
        Console.WriteLine("Ingrese una frase:");
        string input = Console.ReadLine()!;

        int wordCount = 0;
        int vowelCount = 0;
        int index = 0;
        while (index < input.Length)
        {
            while (index < input.Length && input[index] == ' ')
                index++;

            if (index < input.Length)
            {
                wordCount++;
                Console.Write($"Palabra -> ");

                int wordVowelCount = 0;
                while (index < input.Length && input[index] != ' ')
                {
                    char currentChar = input[index];
                    Console.Write($"{currentChar} ");
                    if (IsVowel(currentChar))
                        wordVowelCount++;
                    index++;
                }

                Console.WriteLine($"- Vocales -> {wordVowelCount}");
                vowelCount += wordVowelCount;
            }
        }

        Console.WriteLine($"Total de palabras -> [{wordCount}]");
        Console.WriteLine($"Total de vocales -> [{vowelCount}]");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

static bool IsVowel(char c)
{
    c = char.ToLower(c);
    return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
}

//Palíndromos
static void exercise4()
{
    Console.WriteLine("Ingrese una palabra:");
    string word = Console.ReadLine()!;

    try
    {
        if (isPalindrome(word))
        {
            Console.WriteLine("La palabra ingresada es un palíndromo.");
        }
        else
        {
            Console.WriteLine("La palabra ingresada NO es un palíndromo.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Ocurrió un error: " + ex.Message);
    }
}

static bool isPalindrome(string word)
{
    word = Regex.Replace(word.ToLower(), "[^a-z]", "");

    for (int i = 0; i < word.Length / 2; i++)
    {
        if (word[i] != word[word.Length - i - 1])
        {
            return false;
        }
    }
    return true;
}

//Menú
int opt =0;

do
{
    try
    {
        Console.WriteLine("╔═══════════════════════════╗");
        Console.WriteLine("║            Menú           ║");
        Console.WriteLine("╠═══════════════════════════╣");
        Console.WriteLine("║ [1] Ejercicio 1           ║");
        Console.WriteLine("║ [2] Ejercicio 2           ║");
        Console.WriteLine("║ [3] Ejercicio 3           ║");
        Console.WriteLine("║ [4] Ejercicio 4           ║");
        Console.WriteLine("║ [0] Salir                 ║");
        Console.WriteLine("╚═══════════════════════════╝");

        opt = Convert.ToInt32(Console.ReadLine());

        switch (opt)
        {
            case 1:
                exercise1();
                break;
            case 2:
                exercise2();
                break;
            case 3:
                exercise3();
                break;
            case 4:
                exercise4();
                break;
            case 0:
                Console.WriteLine("Saliendo del programa.");
                break;
            default:
                Console.WriteLine("No es una opción válida");
                break;
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Entrada no válida. Intente nuevamente.");
    }

} while (opt != 0);