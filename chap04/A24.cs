namespace KyoproTessokuCsharp.chap04
{
    internal class A24
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] A = ReadIntArray();

            int answer = 0;
            int[] dp =new int[N+1];
            List<int> minValues = new List<int>();
            for (int i = 0; i < N; i++)
            {
                int minValueIndex = minValues.BinarySearch(A[i]);
                if(minValueIndex < 0)
                {
                    minValueIndex = ~minValueIndex;

                    dp[i] = minValueIndex + 1;

                    if(minValues.Count <= minValueIndex)
                    {
                        minValues.Add(A[i]);
                        answer = Math.Max(answer, minValues.Count);
                    }
                    else
                    {
                        minValues[minValueIndex] = A[i];
                    }
                }
                else
                {
                    dp[i] = minValueIndex + 1;
                    minValues[minValueIndex] = A[i];
                }

            }

            Console.WriteLine(answer);
        }
    }
}
