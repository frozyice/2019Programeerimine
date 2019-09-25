namespace ConsoleApp1
{
    public class Person
    {
        public string Firstname;
        public string Lastname;
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

        public Color FavoriteColor { get; set; }


        public enum Color
        {
            Unknown,
            Red,
            Orange,
            Yellow,
            Green,
            Blue,
            Violete,
            White,
            Black
        }

        
    }
}