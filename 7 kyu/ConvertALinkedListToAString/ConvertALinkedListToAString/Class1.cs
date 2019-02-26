namespace ConvertALinkedListToAString
{
    public class Node
    {
        Node head; // головной/первый элемент
        Node tail; // последний/хвостовой элемент
        int count;  // количество элементов в списке


        public int Data { get; private set; }
        public Node Next { get; private set; }
    }

    public class Kata
    {
        public static string Stringify(Node list)
        {
            string stringList = "";

            while (list != null)
            {
                stringList += list.Data + " -> ";
                list = list.Next;
            }
            stringList += "null";


            return stringList;
        }
    }
}
