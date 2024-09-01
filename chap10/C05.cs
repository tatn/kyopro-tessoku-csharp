namespace KyoproTessokuCsharp.chap10
{
    internal class C05
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int N = ReadInt();

            int[] digit = new int[10];
            int nDivided = N -1;
            for (int i = 0; i < 10; i++)
            {
                if (nDivided % 2 == 1)
                {
                    digit[i] = 1;
                }

                nDivided /= 2;
            }


            Console.WriteLine(String.Join("", digit.Reverse().Select(d => d == 0 ? "4" : "7")));
        }
    }
}

