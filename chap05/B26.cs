namespace KyoproTessokuCsharp.chap05
{
    internal class B26
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int N = ReadInt();

            bool[] isNotPrime = new bool[N+1];

            for (int i = 2; i*i <= N ; i++)
            {
                for (int j = 2; i * j <= N; j++)
                {
                    if(isNotPrime[i * j])
                    {
                        continue;
                    }

                    isNotPrime[j * i] = true;
                }

            }
            for (int i = 2; i <= N; i++)
            {
                if (!isNotPrime[i])
                {
                    Console.WriteLine(i);
                }

            }
        }
    }
}
