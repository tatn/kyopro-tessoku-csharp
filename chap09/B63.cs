namespace KyoproTessokuCsharp.chap09
{
    internal class B63
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            string ReadString() => Console.ReadLine()!;

            int[] RC = ReadIntArray();
            int R = RC[0];
            int C = RC[1];

            int[] syx = ReadIntArray();
            int sy = syx[0];
            int sx = syx[1];

            int[] gyx = ReadIntArray();
            int gy = gyx[0];
            int gx = gyx[1];

            bool[,] maze = new bool[R+2,C+2];

            for (int r = 1; r <= R; r++)
            {
                string line = ReadString();
                for (int c = 1; c <=C ; c++)
                {
                    maze[r, c] = line[c - 1] == '.';
                }
            }

            int[,] distance = new int[R + 2, C + 2];
            for (int r = 1; r <= R; r++)
            {
                for (int c = 1; c <= C; c++)
                {
                    distance[r, c] = -1;
                }
            }
            distance[sy,sx] = 0;


            Queue<(int, int)> queue = new Queue<(int, int)> ();
            queue.Enqueue((sy, sx));

            while( 0 < queue.Count)
            {
                (int y, int x) = queue.Dequeue ();

                for(int dx = -1; dx <=1; dx++)
                {
                    for(int dy = -1; dy <=1; dy++)
                    {
                        if (dx == 0 && dy == 0)
                        {
                            continue;
                        }

                        if (dx * dy != 0)
                        {
                            continue;
                        }

                        int nextY = y + dy;
                        int nextX = x + dx;

                        if(maze[nextY, nextX])
                        {
                            if(distance[nextY, nextX] == -1)
                            {
                                distance[nextY, nextX] = distance[y, x] + 1;
                                queue.Enqueue((nextY, nextX));
                            }
                        }
                    }
                }
            }

            Console.WriteLine(distance[gy, gx]);
        }
    }
}
