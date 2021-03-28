namespace Commanders.Models
{
    public class Commander
    {
        public Commander()
        {            
        }

        public Commander(string name)
        {
            Id = 0;
            Name = name;
        }

        public Commander(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}