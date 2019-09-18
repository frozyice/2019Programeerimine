namespace ConsoleApp1
{
    internal class Person
    {
        private string firstname;
        private string lastname;

        public Person(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public ShoppingCart ShoppingCart { get; internal set; }
    }
}