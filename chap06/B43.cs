namespace KyoproTessokuCsharp.chap06
{
    internal class B43
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            int[] A = ReadIntArray();

            int[] incorrectAnswer = new int[N];

            for (int i = 0; i < M; i++)
            {
                incorrectAnswer[A[i] - 1] += 1;
            }

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(M - incorrectAnswer[i]);
            }
        }
    }
}
