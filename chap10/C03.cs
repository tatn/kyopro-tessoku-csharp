namespace KyoproTessokuCsharp.chap10
{
    internal class C03
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int D = ReadInt();
            int X = ReadInt();

            List<int> A = new List<int>();
            A.Add(-1);
            A.Add(0);
            for (int i = 2; i <=D; i++)
            {
                A.Add(ReadInt());
            }

            int Q = ReadInt();

            int[] S = new int[Q];
            int[] T = new int[Q];
            for (int i = 0; i < Q; i++)
            {
                int[] st = ReadIntArray();
                S[i] = st[0];
                T[i] = st[1];
            }

            int[] SumArray = new int[D+1];
            for (int i = 1;i <= D; i++)
            {
                SumArray[i] = SumArray[i - 1] + A[i];
            }

            for (int i = 0; i < Q; i++)
            {
                int sPrice = SumArray[S[i]];
                int tPrice = SumArray[T[i]];

                if (sPrice == tPrice)
                {
                    Console.WriteLine("Same");
                }
                else if (sPrice < tPrice)
                {
                    Console.WriteLine(T[i]);
                }
                else
                {
                    Console.WriteLine(S[i]);
                }
            }
        }
    }
}
