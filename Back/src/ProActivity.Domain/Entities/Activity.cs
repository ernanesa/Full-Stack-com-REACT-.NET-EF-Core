namespace ProActivity.Domain.Entities;

public class Activity()
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public DateTime? CompletionDate { get; set; } = null;
    public Priority Priority { get; set; }

    public Activity(int id, string title, string? description) : this()
    {
        Id = id;
        Title = title;
        Description = description;
    }
    
    public void Complete()
    {
        if(CompletionDate == null) 
            CompletionDate = DateTime.Now;
        else
            throw new Exception("Activity already completed");
    }
}