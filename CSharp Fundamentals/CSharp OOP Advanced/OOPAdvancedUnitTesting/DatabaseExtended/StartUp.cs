using System;

namespace DatabaseExtended
{
    public class StartUp
    {
        public static void Main()
        {
            Person person = new Person("Gosho", 777);
            PersonDataBase personDataBase = new PersonDataBase();
            personDataBase.Add(person);
        }
    }
}
