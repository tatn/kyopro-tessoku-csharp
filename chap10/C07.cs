namespace KyoproTessokuCsharp.chap10
{
    internal class C07
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();

            List<int> C = ReadIntArray().ToList();
            C.Sort();
            C.Insert(0, 0);

            int Q = ReadInt();
            int[] X = new int[Q + 1];
            for (int i = 1; i <= Q; i++)
            {
                X[i] = ReadInt();
            }

            int[] SumArray = new int[N+1];
            for(int i = 1;i <= N; i++)
            {
                SumArray[i] = SumArray[i-1] + C[i];
            }

            for (int i = 1; i <= Q; i++)
            {
                int index = Array.BinarySearch(SumArray, X[i]);

                if (index < 0)
                {
                    Console.WriteLine(~index - 1);
                }
                else
                {
                    Console.WriteLine(index);
                }
            }
        }
    }
}
