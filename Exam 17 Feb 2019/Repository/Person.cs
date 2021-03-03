namespace Repository
{
    using System;
    public class Person
    {
        public Person(string name, int age, DateTime birthdate)
        {
            Name = name;
            Age = age;
            Birthdate = birthdate;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
