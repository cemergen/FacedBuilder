namespace FacedBuilder
{
    public class Person
    {
        public string StreetAddress, PostCode, City;
        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5}", StreetAddress, PostCode, City, CompanyName, Position, AnnualIncome);
        }
    }

    public class PersonBuilder
    {
        protected Person person = new Person();
        public PersonJobBuider Works => new PersonJobBuider(person);
        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);

        public static implicit operator Person(PersonBuilder pb)
        {
            return pb.person;
        }

    }
    public class PersonJobBuider : PersonBuilder
    {
        public PersonJobBuider(Person person)
        {
            this.person = person;
        }

        public PersonJobBuider At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }
        public PersonJobBuider AsA(string position)
        {
            person.Position = position;
            return this;
        }
    }
    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person)
        {
            this.person = person;
        }

        public PersonAddressBuilder PostCode(string postCode)
        {
            person.PostCode = postCode;
            return this;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            PersonBuilder bp = new PersonBuilder();
            Person person = bp.Works.At("Cem").Lives.PostCode("1231");
        }

    }
}
