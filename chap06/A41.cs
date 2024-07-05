namespace KyoproTessokuCsharp.chap06
{
    internal class A41
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int N = ReadInt();
            string S = ReadString();

            bool canPaint = false;

            for (int i = 0; i < N-2; i++)
            {
                if (S[i] == S[i+1] && S[i] == S[i + 2])
                {
                    canPaint = true;
                    break;
                }
            }

            Console.WriteLine(canPaint ? "Yes" : "No");
        }
    }
}
