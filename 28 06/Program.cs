using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("№1 перестановка строки\n");
        string str = "Sanek";
        List<string> permutations = GetPermutations(str);

        foreach (string permutation in permutations)
        {
            Console.WriteLine(permutation);
        }

        Console.WriteLine("\n==============================\n");

        Console.WriteLine("№2 чч:мм\n");
        string textWithTimes = "Встреча в 14:30, обед в 12:00 и ужин в 19:45.";
        string timePattern = @"\b([01]?[0-9]|2[0-3]):[0-5][0-9]\b";
        MatchCollection timeMatches = Regex.Matches(textWithTimes, timePattern);

        foreach (Match match in timeMatches)
        {
            Console.WriteLine(match.Value);
        }

        Console.WriteLine("\n==============================\n");

        Console.WriteLine("№3 слова где есть выделение нот\n");
        string textWithNotes = "рекурсия, матч, собака, дефамация";
        string notePattern = @"\b\w*(до|ре|ми|фа|соль|ля|си)\w*\b";
        MatchCollection noteMatches = Regex.Matches(textWithNotes, notePattern, RegexOptions.IgnoreCase);

        foreach (Match match in noteMatches)
        {
            Console.WriteLine(match.Value);
        }
    }

    static List<string> GetPermutations(string str)
    {
        var result = new List<string>();
        Permute(str.ToCharArray(), 0, str.Length - 1, result);
        return result;
    }

    static void Permute(char[] arr, int l, int r, List<string> result)
    {
        if (l == r)
        {
            result.Add(new string(arr));
        }
        else
        {
            for (int i = l; i <= r; i++)
            {
                Swap(ref arr[l], ref arr[i]);
                Permute(arr, l + 1, r, result);
                Swap(ref arr[l], ref arr[i]); 
            }
        }
    }

    static void Swap(ref char a, ref char b)
    {
        char temp = a;
        a = b;
        b = temp;
    }
}
