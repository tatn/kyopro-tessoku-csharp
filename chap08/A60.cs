namespace KyoproTessokuCsharp.chap08
{
    internal class A60
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int N = ReadInt();
            int[] A = ReadIntArray();

            if(N == 1)
            {
                Console.WriteLine(-1);
                return;
            }

            Stack<(int,int)> stack = new Stack<(int,int)>();
            List<int> answer = new List<int>();
            answer.Add(-1);

            for (int i = 1; i < N; i++)
            {
                stack.Push((i-1, A[i-1]));

                while (0 < stack.Count)
                {
                    (int index,int value) = stack.Peek();
                    if(value <= A[i])
                    {
                        stack.Pop();
                    }
                    else
                    {
                        break;
                    }
                }

                if (stack.Count == 0)
                {
                    answer.Add(-1);
                }
                else
                {
                    answer.Add(stack.Peek().Item1+1);
                }
            }

            Console.WriteLine(String.Join(" ", answer));

        }
    }
}
