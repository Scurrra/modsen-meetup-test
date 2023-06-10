namespace MeetUp.Models;

/// <summary>
/// Class that represents all the necessary information about the event.
/// </summary>
public class Event
{
    /// <summary>
    /// Event identifier
    /// </summary>
    /// <value></value>
    public Guid Id { get; set; }

    /// <summary>
    /// Date and time when event starts
    /// </summary>
    /// <value></value>
    public DateTime Eventstart { get; set; }

    /// <summary>
    /// Main topic/theme of the event
    /// </summary>
    /// <value></value>
    public string Topic { get; set; }

    /// <summary>
    /// Description of the event
    /// </summary>
    /// <value></value>
    public string? Description { get; set; }

    /// <summary>
    /// Plan of the event
    /// </summary>
    /// <value></value>
    public List<string>? Plan { get; set; }

    /// <summary>
    /// List of event's organizers/speakers
    /// </summary>
    /// <value></value>
    public List<string> Speakers { get; set; } = new List<string>();
}

/// <summary>
/// Class that represents all the necessary information about the event.
/// </summary>
public class EventDTO
{
    /// <summary>
    /// Event identifier
    /// </summary>
    /// <value></value>
    public Guid? Id { get; set; }
    
    /// <summary>
    /// Date and time when event starts
    /// </summary>
    /// <value></value>
    public DateTime Eventstart { get; set; }

    /// <summary>
    /// Main topic/theme of the event
    /// </summary>
    /// <value></value>
    public string Topic { get; set; }

    /// <summary>
    /// Description of the event
    /// </summary>
    /// <value></value>
    public string? Description { get; set; }

    /// <summary>
    /// Plan of the event
    /// </summary>
    /// <value></value>
    public List<string>? Plan { get; set; }

    /// <summary>
    /// List of event's organizers/speakers
    /// </summary>
    /// <value></value>
    public List<string>? Speakers { get; set; }

    /// <summary>
    /// Explicit converting `EventDTO` to `Event` with specified identificator.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>New instance of `Event` with specified identificator.</returns>
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