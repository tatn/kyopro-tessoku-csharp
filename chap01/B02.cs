namespace KyoproTessokuCsharp.chap01
{
    internal class B02
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] AB = ReadIntArray();
            int A = AB[0];
            int B = AB[1];

            string answer = "No";
            for (int i = A; i <= B; i++)
            {
                if (100 % i == 0)
                {
                    answer = "Yes";
                    break;
                }
            }

            Console.WriteLine(answer);
        }
    }
}
