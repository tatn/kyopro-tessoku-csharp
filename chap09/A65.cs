namespace KyoproTessokuCsharp.chap09
{
    internal class A65
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] A = ReadIntArray();

            int[] answer = new int[N];

            for (int i = N-2; 0<=i; i--)
            {
                int bossIndex = A[i];
                answer[bossIndex - 1] += 1 + answer[i+1];
            }

            Console.WriteLine(string.Join(" ", answer));

        }

    }
}
