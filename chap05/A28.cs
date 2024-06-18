namespace KyoproTessokuCsharp.chap05
{
    internal class A28
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            string[] ReadStringArray() => Console.ReadLine()!.Split();

            int N = ReadInt();

            string[] T = new string[N];
            int[] A = new int[N];

            for (int i = 0; i < N; i++)
            {
                string[] input = ReadStringArray();
                T[i] = input[0];
                A[i] = int.Parse(input[1]);                
            }

            int answer = 0;
            for (int i = 0; i < N; i++)
            {
                switch (T[i])
                {
                    case "+":
                        answer += A[i];
                        break;
                    case "-":
                        answer -= A[i];
                        if (answer < 0)
                        {
                            answer += 10000;
                        }
                        break;
                    case "*":
                        answer *= A[i];
                        break;
                    default:
                        break;
                }

                answer %= 10000;
                Console.WriteLine(answer);
            }

        }

    }
}
