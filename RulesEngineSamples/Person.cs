namespace RulesEngineSamples
{
   public class Person
    {
       public string Name { get; set; }
       public string Number { get; set; }
       public string Email { get; set; }
       public Role Role { get; set; }
    }

    public class Card
    {
        public string PersonNumber { get; set; }
        public string CardNumber { get; set; }
        public bool Active { get; set; }
    }

    public enum Role
    {
        Admin,
        User
    }
}
