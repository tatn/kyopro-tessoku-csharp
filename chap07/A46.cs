namespace KyoproTessokuCsharp.chap07
{
    internal class A46
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int N = ReadInt();
            int[] X = new int[N + 1];
            int[] Y = new int[N + 1];

            for (int i = 1; i <= N; i++)
            {
                int[] XY = ReadIntArray();
                X[i] = XY[0];
                Y[i] = XY[1];
            }

            List<int> path = GetPath3(N, X, Y);

            //Console.WriteLine(GetDitance(N,X,Y,path));

            foreach (int i in path)
            {
                Console.WriteLine(i);
            }
        }

        //20.126314408004625 9809.110154752316 5162
        public static List<int> GetPath3(int N, int[] X, int[] Y)
        {
            List<int> path = new List<int>();
            for (int i = 1; i <= N; i++)
            {
                path.Add(i);
            }
            path.Add(1);

            Random random = new Random();

            double distance = GetDitance(N, X, Y, path);
            int loopCount = 400000;
            for (int i = 0; i < loopCount; i++)
            {
                int randomMin = random.Next(1, N);
                int randomMax = random.Next(randomMin, N);

                path.Reverse(randomMin, randomMax - randomMin + 1);
                double distanceNew = GetDitance(N, X, Y, path);

                if (distanceNew <= distance)
                {
                    distance = distanceNew;
                }
                else
                {
                    double diff = distance - distanceNew;
                    double t = 30.0 - 28.0 * i / loopCount;

                    if (random.NextDouble() < Math.Pow(Math.E, diff / t))
                    {
                        distance = distanceNew;
                    }
                    else
                    {
                        path.Reverse(randomMin, randomMax - randomMin + 1);
                    }
                }
            }

            return path;
        }


        // 15.585946365531811 10705.278841192876 4754
        public static List<int> GetPath2(int N, int[] X, int[] Y)
        {
            List<int> path = new List<int>();
            for (int i = 1; i <= N; i++)
            {
                path.Add(i);
            }
            path.Add(1);

            Random random = new Random();

            double distance = GetDitance(N, X, Y, path);
            int loopCount = 400000;
            for (int i = 0; i < loopCount; i++)
            {
                int randomMin = random.Next(1, N);
                int randomMax = random.Next(randomMin, N);

                path.Reverse(randomMin, randomMax - randomMin + 1);
                double distanceNew = GetDitance(N, X, Y, path);

                if (distanceNew < distance)
                {
                    distance = distanceNew;
                }
                else
                {
                    path.Reverse(randomMin, randomMax - randomMin + 1);
                }
            }

            return path;
        }


        //17.469413449533647 12317.29631774833 4230
        public static List<int> GetPath1(int N, int[] X, int[] Y)
        {
            List<int> path = new List<int>();
            bool[] visited = new bool[N + 1];

            int currentCity = 1;
            path.Add(currentCity);
            visited[currentCity] = true;

            for (int count = 1; count < N; count++)
            {
                // N - 1 回 のループ
                int nextCity = 0;
                double distance = 2.0 * 1000;
                for (int i = 1; i <= N; i++)
                {
                    if (visited[i])
                    {
                        continue;
                    }

                    double newDistance = Math.Sqrt(
                          (X[currentCity] - X[i]) * (X[currentCity] - X[i])
                        + (Y[currentCity] - Y[i]) * (Y[currentCity] - Y[i])
                    );
                    if (newDistance < distance)
                    {
                        distance = newDistance;
                        nextCity = i;
                    }
                }

                path.Add(nextCity);
                visited[nextCity] = true;
                currentCity = nextCity;
            }

            path.Add(1);
            return path;
        }

        public static double GetDitance(int N, int[] X, int[] Y, List<int> path)
        {
            double distance = 0.0;
            for (int i = 0; i < N; i++)
            {
                int city1 = path[i];
                int city2 = path[i + 1];
                distance += Math.Sqrt(
                         (X[city1] - X[city2]) * (X[city1] - X[city2])
                       + (Y[city1] - Y[city2]) * (Y[city1] - Y[city2])
                   );
            }

            return distance;
        }
    }
}
