using AutoMapper;
using MeetUp.Models;
using MeetUp.Profiles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeetUp.Controllers;

/// <summary>
/// API logic. Available roles are "admin" and "user".
/// </summary>
[ApiController]
[Authorize(Roles = "admin, user")]
[Route("api/[controller]")]
public class EventController : ControllerBase
{
    private readonly MeetUpContext _context;
    private readonly IMapper _mapper;

    public EventController(MeetUpContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Get all the stored events.
    /// </summary>
    /// <returns>List of events</returns>
    [HttpGet]
    public IActionResult GetEvents()
    {
        var events = _context.Events.ToArray();
        if (events.Length == 0) {
            return NotFound();
        }
        return Ok(_mapper.Map<IEnumerable<EventDTO>>(events));
    }

    /// <summary>
    /// Get event with the specified Id.
    /// </summary>
    /// <param name="id">Identifier of the event.</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public IActionResult GetEvent(Guid id)
    {
        var item = _context.Events.FirstOrDefault(e => e.Id == id);
        if (item is null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<EventDTO>(item));
    }

    /// <summary>
    /// Add new event to database.
    /// </summary>
    /// <param name="eventdto"></param>
    /// <returns></returns>
    [HttpPost]
    [Authorize(Roles = "admin")]
    public IActionResult AddEvent(EventDTO eventdto)
    {
        if (ModelState.IsValid)
        {
            _context.Events.Add(_mapper.Map<Event>(eventdto));
            _context.SaveChanges();
            return CreatedAtAction("AddEvent", new {eventdto.Id}, eventdto);
        }

        return new JsonResult("Something went wrong") { StatusCode = 500};        
    }

    /// <summary>
    /// Delete event by its identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [Authorize(Roles = "admin")]
    public IActionResult DeleteEvent(Guid id)
    {
        var item = _context.Events.FirstOrDefault(e => e.Id == id);

        if(item is null)
        {
            return NotFound();
        }

        _context.Events.Remove(item);
        _context.SaveChanges();

        return Ok(_mapper.Map<EventDTO>(item));
    }

    /// <summary>
    /// Update event by its identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="eventdto"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Authorize(Roles = "Administrator")]
    public IActionResult UpdateEvent(Guid id, EventDTO eventdto)
    {
        if(id != eventdto.Id)
        {
            return BadRequest();
        }

        var item = _context.Events.FirstOrDefault(e => e.Id == id);

        if(item is null)
        {
            return NotFound();
        }

        item = eventdto.toEvent(id);
        _context.SaveChanges();

        return Ok(_mapper.Map<EventDTO>(item));
    }
}
