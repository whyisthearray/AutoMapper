using AutoMapper;
using NUnit.Framework;

namespace MapperTests
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public void Map_MappingFromObjectToT_ReturnT_Test()
        {
            var toMapping = new House("Zelena", 1);
            var expected = new NewPerson2();
            var actual = Mapper.Mapping<NewPerson2>(toMapping);
            Assert.AreEqual(expected.GetType(), actual.GetType());
        }

        [Test]
        public void Mapping_TypesHaveSameProperties_PropertiesValuesIsEqual_Test()
        {

            var toMapping = new { Number = 23 };
            const int expected = 23;
            var actual = Mapper.Mapping<House>(toMapping).Number;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Mapping_TypesHaveSameProperties_PropertiesValuesIsEqual_Test2()
        {
            var toMapping = new {Street = "Zelena"};
            const string expected = "Zelena";
            var actual = Mapper.Mapping<House>(toMapping).Street;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Mapping_PropertyHaveSameNameButDifferentRegistry_PropertiesValuesIsEqual_Test()
        {
            var toMapping = new
            {
                street = "Zelena",
                number = 1
            };
            var expected = new House("Zelena", 1);
            var actual = Mapper.Mapping<House>(toMapping);
            Assert.IsTrue(
                expected.Street == actual.Street &&
                expected.Number == actual.Number
                );
        }

        [Test]
        public void Mapping_PropertyHaveSameNameButDifferentType_ValueNotChange_Test()
        {
            var toMapping = new
            {
                street = "Zelena",
                number = 1f
            };
            var expected = new House("Zelena", 0);
            var actual = Mapper.Mapping<House>(toMapping);
            Assert.IsTrue(
                expected.Street == actual.Street &&
                expected.Number == actual.Number
                );
        }

        [Test]
        public void Mapping_IgnoreSomeProperty_PropertiesValuesIsNotChange_Test()
        {
            var toMapping = new {Street = "Zelena", Number = 1};
            const int expected = 0;
            var actual = Mapper.Mapping<House>(toMapping, ignoredProperties: new[] {"Number"}).Number;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Mapping_IgnoreSomeProperty_PropertiesValuesIsNotChange_Test2()
        {
            var toMapping = new { Street = "Zelena", Number = 1 };
            const string expected = null;
            var actual = Mapper.Mapping<House>(toMapping, ignoredProperties: new[] { "Street" }).Street;
            Assert.AreEqual(expected, actual);
        }
       
        [Test]
        public void Mapping_IgnoredPropertyWithOwnProperties_PropertiesVaulesNotChange_Test()
        {
            var toMapping = new
            {
                Country = "Ukraine",
                City = "Lviv",
                PHouse = new House("Zelena", 1)
            };

            var expected = new NewPerson2
            {
                Name = null,
                Surname = null,
                Country = "Ukraine",
                City = "Lviv",
                Street = null,
                Number = 0
            };
            var actual = Mapper.Mapping<NewPerson2>(toMapping, ignoredProperties: new[] { "PHouse" });
            Assert.IsTrue(
                expected.Name == actual.Name &&
                expected.Surname == actual.Surname &&
                expected.Country == actual.Country &&
                expected.City == actual.City &&
                expected.Street == actual.Street &&
                expected.Number == actual.Number                
                );
        }

        [Test]
        public void Mapping_IgnoredPropertyWithOwnProperties_PropertiesVaulesNotChange_Test2()
        {
            var toMapping = new
            {
                Name = "Alex",
                Surname = "Albul",
                PAdress = new Adress
                {
                    Country = "Ukraine",
                    City = "Lviv",
                    PHouse = new House("Zelena", 1)
                }
            };

            var expected = new NewPerson2
            {
                Name = "Alex",
                Surname = "Albul",
                Country = null,
                City = null,
                Street = null,
                Number = 0
            };
            var actual = Mapper.Mapping<NewPerson2>(toMapping, ignoredProperties: new[] { "PAdress" });
            Assert.IsTrue(
                expected.Name == actual.Name &&
                expected.Surname == actual.Surname &&
                expected.Country == actual.Country &&
                expected.City == actual.City &&
                expected.Street == actual.Street &&
                expected.Number == actual.Number
                );
        }
       
        [Test]
        public void Mapping_IgnoredParametersCase_Test1()
        {
            var toMapping = new
            {
                Name = "Alex",
                Surname = "Albul",
                PAdress = new Adress
                {
                    Country = "Ukraine",
                    City = "Lviv",
                    PHouse = new House("Zelena", 1)
                }
            };
            var expected = new NewPerson2
            {
                Name = "Alex",
                Surname = "Albul",
                Country = "Ukraine",
                City = null,
                Street = null,
                Number = 1
            };
            var actual = Mapper.Mapping<NewPerson2>(toMapping,ignoredProperties:new []{"City","Street"});
            Assert.IsTrue(
                expected.Name == actual.Name &&
                expected.Surname == actual.Surname &&
                expected.Country == actual.Country &&
                expected.City == actual.City &&
                expected.Street == actual.Street &&
                expected.Number == actual.Number
                );


        }

        [Test]
        public void Mapping_IgnoredParametersCase_Test2()
        {
            var toMapping = new
            {
                Name = "Alex",
                Surname = "Albul",
                PAdress = new Adress
                {
                    Country = "Ukraine",
                    City = "Lviv",
                    PHouse = new House
                    {
                        Street = "Zelena",
                        Number = 1
                    }
                }
            };
            var expected = new NewPerson2
            {
                Name = "Alex",
                Surname = null,
                Country = null,
                City = "Lviv",
                Street = "Zelena",
                Number = 1
            };
            var actual = Mapper.Mapping<NewPerson2>(toMapping,ignoredProperties:new []{"Surname","Country"});
            Assert.IsTrue(
                expected.Name == actual.Name &&
                expected.Surname == actual.Surname &&
                expected.Country == actual.Country &&
                expected.City == actual.City &&
                expected.Street == actual.Street &&
                expected.Number == actual.Number
                );
        }
              
        [Test]
        public void Test2()
        {

            var pHouse = new House("Trakt Hlynyanskuy", 153);
            var pAdress = new Adress("Ukraine", "Lviv", pHouse);
            var toMapping = new NewPerson("Alex", "Albul", pAdress);           
            var expected = new NewPerson2(
                "Alex",
                "Albul",
                "Ukraine",
                "Lviv",
                "Trakt Hlynyanskuy",
                153
                );
            var actual = Mapper.Mapping<NewPerson2>(toMapping);           
            Assert.IsTrue(
                expected.Name==actual.Name &&
                expected.Surname == actual.Surname &&
                expected.Country == actual.Country &&
                expected.City == actual.City &&
                expected.Street==actual.Street &&
                expected.Number ==actual.Number                                                              
                );
        }
    }
}
