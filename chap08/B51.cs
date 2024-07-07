namespace KyoproTessokuCsharp.chap08
{
    internal class B51
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;

            string S = ReadString();
            Stack<int> indexes = new Stack<int>();

            for (int i = 0; i < S.Length; i++)
            {
                switch (S[i])
                {
                    case '(':
                        indexes.Push(i + 1);
                        break;
                    case ')':
                        Console.WriteLine($"{indexes.Pop()} {i + 1}");
                        break;
                }
            }
        }
    }
}
