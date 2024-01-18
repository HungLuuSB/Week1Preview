namespace RainySquare
{
    internal class Program
    {
        static void Main()
        {
            int n;
            Console.Write("Input n: ");
            n = Convert.ToInt32(Console.ReadLine());
            int[,] matrix = new int[n, n];
            //Init 1st line
            int count = 1;
            matrix[0, 0] = 1;
            for (int i = 1; i < n; i++)
            {
                matrix[0,i] = matrix[0, i - 1] + count;
                count++;
            }
            //Init left crossing
            for (int i = 1; i < n; i++)
            {
                int counter = 0;
                for (int j = 1; j <= i; j++)
                {
                    matrix[j, i - j] = matrix[0,i] + 1 + counter;
                    counter++;
                }
            }
            //Init right-end column
            count = n;
            for (int i = 1; i < n; i++)
            {
                matrix[i, n - 1] = matrix[i - 1, n - 1] + count;
                count--;
            }
            //Init right crossing
            for (int i = 1; i < n; i++)
            {
                int counter = 0;
                for (int j = 1; j <= n - i - 1; j++)
                {                    
                    matrix[n - i,n - j - 1] = matrix[n - i - 1 - counter, n-1] + 1 + counter;
                    counter++;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0,4} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}