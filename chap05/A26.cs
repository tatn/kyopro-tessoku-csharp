namespace KyoproTessokuCsharp.chap05
{
    internal class A26
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int Q = ReadInt();

            List<bool> answer = new List<bool>();
            for (int i = 0; i < Q; i++)
            {
                int X = ReadInt();

                bool isPrimeNumber = true;
                for (int j = 2; j <= Math.Sqrt(X); j++)
                {
                    if(X % j == 0)
                    {
                        isPrimeNumber = false;
                        break;
                    }
                }

                answer.Add(isPrimeNumber);
            }

            foreach (bool isPrimeNumber in answer)
            {
                Console.WriteLine(isPrimeNumber ? "Yes" : "No");
            }
        }
    }
}
