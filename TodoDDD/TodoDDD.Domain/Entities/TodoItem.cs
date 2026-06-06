namespace TodoDDD.Domain.Entities;

public class TodoItem
{
    public Guid Id { get; private set; }

    public  string Title { get; private set; }

    public bool IsCompleted { get; private set; }

    private TodoItem()
    {
    }

    public TodoItem(string title)
    {
        Id = Guid.NewGuid();
        Title = title;
        IsCompleted = false;
    }

    public void Complete()
    {
        IsCompleted = true;
    }
    public void UpdateTitle(string title)
    {
        Title = title;
    }
}