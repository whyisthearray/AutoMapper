namespace MapperTests
{

    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public Person()
        {
            this.Name = string.Empty;
            this.Surname = string.Empty;
            this.Age = 0;
        }

        public Person(string name, string surname, int age)
        {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
        }
    }

    public class Person2
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public Person2()
        {
            this.Name = string.Empty;
            this.Surname = string.Empty;
            this.Age = 0;
        }

        public Person2(string name, string surname, int age)
        {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
        }
    }
}

