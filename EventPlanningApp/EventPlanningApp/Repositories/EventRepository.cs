using System;
using System.Collections.Generic;
using System.Linq;
using EventPlanningApp.Models;

namespace EventPlanningApp.Repositories;

public class EventRepository : IRepository
{
    private readonly EventDbContext _context;

    public EventRepository(EventDbContext context)
    {
        _context = context;
    }

    public List<Event> ViewAllEvents()
    {
        try
        {
            return _context.Events.ToList();
        }
        catch (Exception)
        {
            return new List<Event>();
        }
    }

    public Event? ViewEventById(int id)
    {
        try
        {
            return _context.Events.Find(id);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public bool CreateEvent(Event events)
    {
        try
        {
            _context.Events.Add(events);
            return _context.SaveChanges() > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool UpdateEvent(Event events)
    {
        try
        {
            _context.Events.Update(events);
            return _context.SaveChanges() > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }
}