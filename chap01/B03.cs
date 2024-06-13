namespace KyoproTessokuCsharp.chap01
{
    internal class B03
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] A = ReadIntArray();

            bool isMatch = false;

            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    for (int k = j + 1; k < N; k++)
                    {
                        if (A[i] + A[j] + A[k] == 1000)
                        {
                            isMatch = true;
                        }

                        if (isMatch)
                        {
                            break;
                        }
                    }

                    if (isMatch)
                    {
                        break;
                    }

                }

                if (isMatch)
                {
                    break;
                }
            }

            Console.WriteLine(isMatch ? "Yes" : "No");

        }
    }
}
