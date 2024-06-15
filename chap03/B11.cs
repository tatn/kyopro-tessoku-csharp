namespace KyoproTessokuCsharp.chap03
{
    internal class B11
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] A = ReadIntArray();
            int Q = ReadInt();

            int[] X = new int[Q];
            for (int i = 0; i < Q; i++)
            {
                X[i] = ReadInt();
            }
            
            int[] ASorted = A.OrderBy(x => x).ToArray();

            for (int i = 0; i < Q; i++)
            {
                int index = Array.BinarySearch(ASorted, X[i]);

                if(0 <= index)
                {
                    Console.WriteLine(index);
                }
                else
                {
                    Console.WriteLine(~index);
                }
            }
        }
    }
}
