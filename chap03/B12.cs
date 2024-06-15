namespace KyoproTessokuCsharp.chap03
{
    internal class B12
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int N = ReadInt();

            double left = 0.0;
            double right = 50.0;
            double delta = 0.001;

            while (delta <= right - left)
            {
                double m = (left + right) / 2.0;
                double y = m * m * m + m;

                if (y <= N)
                {
                    left = m;
                }
                else
                {
                    right = m;
                }
            }

            Console.WriteLine(left);
        }
    }
}
