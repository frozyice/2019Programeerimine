namespace ConsoleApp1
{
    internal class Person
    {
        private string Firstname;
        private string Lastname;
        public ShoppingCart ShoppingCart { get; set; }

        public Person(string firstname, string lastname)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
        }

        public override string ToString()
        {
            return Firstname;
        }

        
    }
}