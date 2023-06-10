using AutoMapper;
using MeetUp.Models;
using MeetUp.Profiles;

using Microsoft.AspNetCore.Mvc;

namespace MeetUp.Controllers;

[ApiController]
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

    [HttpGet]
    public IActionResult GetEvents()
    {
        var events = _context.Events.ToArray();
        if (events.Length == 0) {
            return NotFound();
        }
        return Ok(_mapper.Map<IEnumerable<EventDTO>>(events));
    }

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

    [HttpPost]
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

    [HttpDelete("{id}")]
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

    [HttpPut("{id}")]
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
