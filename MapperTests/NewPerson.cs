namespace MapperTests
{
    public class NewPerson
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Adress PAdress { get; set; }

        public NewPerson(string name, string surname, Adress pAdress)
        {
            Name = name;
            Surname = surname;
            PAdress = pAdress;
        }

        public NewPerson()
        {
            
        }
    }

    public class Adress
    {
        public string Country { get; set; }
        public string City { get; set; }
        public House PHouse { get; set; }

        public Adress()
        {
            
        }

        public Adress(string country, string city, House pHouse)
        {
            Country = country;
            City = city;
            PHouse = pHouse;
        }
    }

    public class House
    {
        public string Street { get; set; }
        public int Number { get; set; }

        public House()
        {           
        }

        public House(string street, int number)
        {
            Street = street;
            Number = number;
        }
    }

    public class NewPerson2
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }

        public NewPerson2(string name, string surname, string country, string city, string street, int number)
        {
            Name = name;
            Surname = surname;
            Country = country;
            City = city;
            Street = street;
            Number = number;
        }

        public NewPerson2()
        {
            
        }
    }

}
