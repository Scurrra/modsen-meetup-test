namespace MeetUp.Models;

public class Event
{
    public Guid Id { get; set; }

    public DateTime Eventstart { get; set; }

    public string Topic { get; set; }

    public string? Description { get; set; }

    public List<string>? Plan { get; set; }

    public List<string> Speakers { get; set; } = new List<string>();
}

public class EventDTO
{
    public Guid? Id { get; set; }
    public DateTime Eventstart { get; set; }

    public string Topic { get; set; }

    public string? Description { get; set; }

    public List<string>? Plan { get; set; }

    public List<string>? Speakers { get; set; }

    public Event toEvent(Guid id)
    {
        return new Event {
            Id = id,
            Eventstart = Eventstart,
            Topic = Topic,
            Description = Description,
            Plan = Plan,
            Speakers = Speakers ?? new List<string>()
        };
    }
}