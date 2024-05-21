public class Program
{
    public static void Main()
    {
        //NO.1
        Console.WriteLine("Nomer 1");
        NoSatu(15);
        
        //NO. 2
        Console.WriteLine("Nomer 2");
        NoDua(5);

        //NO. 3
        Console.WriteLine("Nomer 3");
        NoTiga([12, 9, 13, 6, 10, 4, 7, 2]);
    }

    static void NoSatu(int number)
    {
        int n = number;
        for (int i = 1; i <= n; i++)
        {
            if (i % 3 == 0 && i % 4 == 0)
            {
                Console.Write("OKYES ");
            }
            else if (i % 3 == 0)
            {
                Console.Write("OK ");
            }
            else if (i % 4 == 0)
            {
                Console.Write("YES ");
            }
            else
            {
                Console.Write($"{i} ");
            }
        }
        Console.WriteLine($"\n");
    }

    static void NoDua(int number)
    {
        Console.WriteLine("Section a");
        int d = number;
        for (int i = 1; i <= d; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }

        Console.WriteLine($"\n");
        Console.WriteLine("Section b");
        for (int i = 1; i <= d; i++)
        {
            Console.Write(i);
            for (int j = 1; j < i; j++)
            {
                Console.Write(i - j);
            }
            Console.WriteLine();
        }

        Console.WriteLine($"\n");
        Console.WriteLine("Section c");
        int length = 1;
        string change = "+";
        for (int i = 1; i <= d; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write(length);
                change = length == 5 ? "-" : length == 1 ? "+" : change;
                length = change.Equals("-") ? length - 1 : length + 1;
            }
            Console.WriteLine();
        }

        Console.WriteLine($"\n");
        Console.WriteLine("Section d");
        for (int i = 0; i < d; i++)
        {
            for (int j = 0; j < d; j++)
            {
                if (j % 2 == 0)
                {
                        Console.Write((1 + (j * d) + i) + " ");
                }
                else
                {
                        Console.Write(((d * (j + 1) - i)) + " ");
                }
            }
            Console.WriteLine() ;
        }
        Console.WriteLine($"\n");
    }

    static void NoTiga(int[] matrix)
    {
            int[] number = matrix;
            int kelipatanTiga = 0;
            for (int i = 0; i < number.Length; i++)
            {
                kelipatanTiga = number[i] % 3 == 0 ? kelipatanTiga + 1 : kelipatanTiga;
            }

            int[] newNumber = new int[number.Length - kelipatanTiga];
            int index = 0;
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] % 3 != 0)
                {
                    newNumber[index] = number[i];
                    index++;
                }
            }
            SortArray(newNumber);
            Console.WriteLine("[" + string.Join(", ", newNumber) + "]");
    }

    static int[] SortArray(int[] matrix)
    {
        int[] sortMatrix = matrix;
        for (int i = 0; i < matrix.Length; i++)
        {
            for(int j = 0; j < matrix.Length - 1; j++)
            {
                if (matrix[j] > matrix[j+1])
                {
                    int temp = matrix[j];
                    matrix[j] = matrix[j+1];
                    matrix[j+1] = temp; 
                }
            }
        }
        return sortMatrix;
    }
}
