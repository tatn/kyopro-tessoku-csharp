namespace KyoproTessokuCsharp.chap01
{
    internal class B04
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;

            string nString = ReadString();
            int n = nString.Length;

            int answer = 0;
            for (int i = 0; i < n; i++)
            {
                int bit = int.Parse(nString[n - 1 - i].ToString());
                answer += bit * (1 << i);
            }
            Console.WriteLine(answer);
        }
    }
}
