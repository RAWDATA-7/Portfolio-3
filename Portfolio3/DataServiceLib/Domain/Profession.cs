namespace DataServiceLib.Domain
{
    public class Profession
    {
        public string ActorId { get; set; }
	    public string Name { get; set; }

        public override string ToString()
        {
            return $"ActorId = {ActorId}, Name = {Name}";
        }
    }
}
