using System;

namespace CustomLinkedList
{
    public class StartUp
    {
        public static void Main()
        {
            DynamicList<string> dynamicList = new DynamicList<string>();

            dynamicList.Add("Pesho");
            dynamicList.Add("Gosho");
            dynamicList.Add("Ivan");
            dynamicList.Add("100qn");
            dynamicList.Add("Grigor");

            dynamicList.Remove("Grigor");

            bool isThere = dynamicList.Contains("Ivan");

            isThere = dynamicList.Contains("Petkan");

            int count = dynamicList.Count;

            int indexOf = dynamicList.IndexOf("Gosho");

            dynamicList.Remove("Pesho");

            dynamicList.Remove("100qn");

            dynamicList.Remove("Marmarosho");

            dynamicList.RemoveAt(1);

            dynamicList.RemoveAt(1000);

            dynamicList.RemoveAt(-100);
        }
    }
}
