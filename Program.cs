namespace LinkedListGeneric
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //TestList();
            TestSet();
        }

        public static void TestList()
        {
            SimpleList<int> intList1 = new SimpleList<int>(1, 2, 3);
            SimpleList<int> intList2 = new SimpleList<int>(3, 4, 5, 4, 3 ,6 ,7 ,8 ,3);

            intList1.Add(100);

            int[] arr1 = intList1.ToArray();
            foreach (int i in arr1) Console.WriteLine(i);

            Console.WriteLine();

            intList2.RemoveOnce(4);
            int[] arr2 = intList2.ToArray();
            foreach (int i in arr2) Console.WriteLine(i);

            intList2.RemoveAtIndex(2);

            Console.WriteLine();

            intList2.RemoveAllOf(3);
            arr2 = intList2.ToArray();
            foreach (int i in arr2) Console.WriteLine(i);
        }

        public static void TestSet()
        {
            SimpleSet<string> stringSet1 = new SimpleSet<string>("Hallo", "Welt", "Wie", "geht", "Es", "Dir");
            SimpleSet<string> stringSet2 = new SimpleSet<string>("Hallo", "Bald", "Wochenende");

            try
            {
                stringSet1.RemoveAtIndex(1);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }

            string[] strArr = stringSet1.MergeWith(stringSet2).ToArray();
            foreach (var i in strArr) Console.WriteLine(i);

            Console.WriteLine("\n-------------------------------------------------------------\n");

            foreach (var i in stringSet1.IntersectionWith(stringSet2).ToArray()) Console.WriteLine(i);

            Console.WriteLine();

        }
    }
}
