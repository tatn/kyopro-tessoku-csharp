namespace KyoproTessokuCsharp.chap06
{
    internal class A37
    {
        public static void Main(string[] args)
        {
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            long[] NMB = ReadLongArray();
            long N = NMB[0];
            long M = NMB[1];
            long B = NMB[2];

            long[] A = ReadLongArray();
            long[] C = ReadLongArray();

            long sumA = A.Sum();
            long sumC = C.Sum();

            long answer = sumA * M + sumC * N + M * N * B;

            Console.WriteLine(answer);

        }
    }
}
