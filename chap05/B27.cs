namespace KyoproTessokuCsharp.chap05
{
    internal class B27
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] AB = ReadIntArray();
            int A = AB[0];
            int B = AB[1];

            Console.WriteLine(GetLCM(A,B));

        }

        static int GetGCD(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }

            return GetGCD(b, a % b);
        }

        static long GetLCM(int a, int b)
        {
            int gcd = GetGCD(a, b);
            return (long)a * (long)b / (long)gcd;
        }
    }
}
