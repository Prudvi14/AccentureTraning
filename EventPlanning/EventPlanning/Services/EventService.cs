using EventPlanning.DataAccess;

namespace EventPlanning.Services
{
    public class EventService
    {
        private readonly IRepository _repository;

        public EventService(IRepository repository)
        {
            _repository = repository;
        }

        public List<DataAccess.Event> ViewAllEvents()
        {
            return _repository.ViewAllEvents();
        }

        public DataAccess.Event ViewEventById(int id)
        {
            return _repository.ViewEventById(id);
        }

        public bool CreateEvent(DataAccess.Event events)
        {
            return _repository.CreateEvent(events);
        }

        public bool UpdateEvent(DataAccess.Event events)
        {
            return _repository.UpdateEvent(events);
        }
    }
}