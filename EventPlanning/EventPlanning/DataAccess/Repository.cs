using Microsoft.EntityFrameworkCore;
namespace EventPlanning.DataAccess
{
    public class Repository : IRepository
    {
        private readonly EventDbContext _context;

        public Repository(EventDbContext context)
        {
            _context = context;
        }

        public List<Event> ViewAllEvents()
        {
            return _context.Events.ToList();
        }

        public Event ViewEventById(int id)
        {
            return _context.Events.FirstOrDefault(e => e.EventId == id);
        }

        public bool CreateEvent(Event events)
        {
            try
            {
                _context.Events.Add(events);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateEvent(Event events)
        {
            try
            {
                _context.Events.Update(events);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}