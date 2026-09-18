using System.Collections.Generic;

namespace EventPlanning.DataAccess
{
    public interface IRepository
    {
        List<Event> ViewAllEvents();

        Event ViewEventById(int id);

        bool CreateEvent(Event events);

        bool UpdateEvent(Event events);
    }
}