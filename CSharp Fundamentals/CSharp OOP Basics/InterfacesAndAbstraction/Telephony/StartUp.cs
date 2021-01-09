using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var phoneNumbers = Console.ReadLine()
            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

        var urls = Console.ReadLine()
            .Split();

        for (int i = 0; i < phoneNumbers.Length; i++)
        {
            try
            {
                SmartPhone smartPhone = new SmartPhone();
                smartPhone.PhoneNumber = phoneNumbers[i];
                Console.WriteLine(smartPhone.Calling(phoneNumbers[i]));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        for (int i = 0; i < urls.Length; i++)
        {
            try
            {
                SmartPhone smartPhone = new SmartPhone();
                smartPhone.Url = urls[i];
                Console.WriteLine(smartPhone.Browse(urls[i]));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

