namespace Model
{
    public class Psycotherapist : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public List<Meeting> Calendar { get; set; }
    }
}