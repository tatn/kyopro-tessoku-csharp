namespace KyoproTessokuCsharp.chap01
{
    internal class B01
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] AB = ReadIntArray();
            int A = AB[0];
            int B = AB[1];

            Console.WriteLine(A + B);
        }
    }
}
