
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventPlanning.DataAccess;

public class EventsController : Controller
{
    private readonly EventDbContext _context;

    public EventsController(EventDbContext context)
    {
        _context = context;
    }

    // GET: EVENTS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Events.ToListAsync());
    }

    // GET: EVENTS/Details/5
    public async Task<IActionResult> Details(int? eventid)
    {
        if (eventid == null)
        {
            return NotFound();
        }

        var event = await _context.Events
            .FirstOrDefaultAsync(m => m.EventId == eventid);
        if (event == null)
        {
            return NotFound();
        }

        return View(event);
    }

    // GET: EVENTS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: EVENTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("EventId,Name,Date,Location,Type,Budget")] Event event)
    {
        if (ModelState.IsValid)
        {
            _context.Add(event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(event);
    }

    // GET: EVENTS/Edit/5
    public async Task<IActionResult> Edit(int? eventid)
    {
        if (eventid == null)
        {
            return NotFound();
        }

        var event = await _context.Events.FindAsync(eventid);
        if (event == null)
        {
            return NotFound();
        }
        return View(event);
    }

    // POST: EVENTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? eventid, [Bind("EventId,Name,Date,Location,Type,Budget")] Event event)
    {
        if (eventid != event.EventId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(event);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(event.EventId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(event);
    }

    // GET: EVENTS/Delete/5
    public async Task<IActionResult> Delete(int? eventid)
    {
        if (eventid == null)
        {
            return NotFound();
        }

        var event = await _context.Events
            .FirstOrDefaultAsync(m => m.EventId == eventid);
        if (event == null)
        {
            return NotFound();
        }

        return View(event);
    }

    // POST: EVENTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? eventid)
    {
        var event = await _context.Events.FindAsync(eventid);
        if (event != null)
        {
            _context.Events.Remove(event);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool EventExists(int? eventid)
    {
        return _context.Events.Any(e => e.EventId == eventid);
    }
}
