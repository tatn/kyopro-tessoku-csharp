namespace KyoproTessokuCsharp.chap01
{
    internal class A04
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int N = ReadInt();

            int[] bytes = new int[10];

            int number = N;
            for (int i = 0; i < 10; i++)
            {
                bytes[10 - i - 1] = number % 2;
                number /= 2;
            }

            Console.WriteLine(String.Join("", bytes.Select(x => x.ToString())));
        }
    }
}
