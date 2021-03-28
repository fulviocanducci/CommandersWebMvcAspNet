namespace Commanders.Models
{
    public class Todo
    {
        public Todo()
        {

        }

        public Todo(string description, bool done)
        {            
            Description = description;
            Done = done;
        }

        public Todo(int id, string description, bool done)
        {
            Id = id;
            Description = description;
            Done = done;
        }

        public int Id {get;set;}
        public string Description {get;set;}
        public bool Done {get;set;}
    }
}