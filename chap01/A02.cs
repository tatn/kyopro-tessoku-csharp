namespace KyoproTessokuCsharp.chap01
{
    internal class A02
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NX = ReadIntArray();
            int N = NX[0];
            int X = NX[1];

            int[] A = ReadIntArray();

            string answer = "No";
            for (int i = 0; i < N; i++)
            {
                if (A[i] == X)
                {
                    answer = "Yes";
                    break;
                }
            }
            Console.WriteLine(answer);
        }
    }
}
