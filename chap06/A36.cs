namespace KyoproTessokuCsharp.chap06
{
    internal class A36
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NK = ReadIntArray();
            int N = NK[0];
            int K = NK[1];

            int minimumMove = 2 * N - 2;

            int diff = K - minimumMove;

            Console.WriteLine(0<=diff && diff % 2 == 0 ? "Yes" : "No");
        }
    }
}
