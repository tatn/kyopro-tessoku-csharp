namespace KyoproTessokuCsharp.chap06
{
    internal class B36
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            string ReadString() => Console.ReadLine()!;

            int[] NK = ReadIntArray();
            int N = NK[0];
            int K = NK[1];

            string S = ReadString();

            int onCount = S.Where(x => x == '1').Count();

            Console.WriteLine( (K-onCount) % 2 == 0 ? "Yes" : "No" );
        }
    }
}
