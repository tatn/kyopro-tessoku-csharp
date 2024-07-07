namespace KyoproTessokuCsharp.chap08
{
    internal class B52
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NX = ReadIntArray();
            int N = NX[0];
            int X = NX[1];

            string A = ReadString();

            char[] chars = A.ToCharArray();

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(X);
            chars[X - 1] = '@';

            while (0 < queue.Count)
            {
                int index = queue.Dequeue();

                if(1 <= index - 1)
                {
                    if (chars[index-2] == '.')
                    {
                        chars[index - 2] = '@';
                        queue.Enqueue(index-1);
                    }

                }

                if(index + 1 <= N)
                {
                    if (chars[index] == '.')
                    {
                        chars[index] = '@';
                        queue.Enqueue(index + 1);
                    }
                }

            }

            Console.WriteLine(string.Join("",chars.Select(c=>c.ToString())));
        }
    }
}
