namespace KyoproTessokuCsharp.chap06
{
    internal class B41
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] XY = ReadIntArray();
            int X = XY[0];
            int Y = XY[1];

            List<int[]> history = new List<int[]>();

            while (1 < X || 1 < Y)
            {
                history.Add(new int[2] { X, Y });

                if(X <= Y)
                {
                    Y = Y - X;
                }
                else
                {
                    X = X - Y;
                }
            }

            history.Reverse();
            Console.WriteLine(history.Count);
            foreach (int[] xy in history)
            {
                Console.WriteLine($"{xy[0]} {xy[1]}");
            }
        }
    }
}
