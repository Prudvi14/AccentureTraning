using System.Collections.Generic;
using EventPlanningApp.Models;

namespace EventPlanningApp.Repositories;

public interface IRepository
{
    List<Event> ViewAllEvents();
    Event? ViewEventById(int id);
    bool CreateEvent(Event events);
    bool UpdateEvent(Event events);
}