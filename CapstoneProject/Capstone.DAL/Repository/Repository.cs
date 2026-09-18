using Capstone.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Capstone.DAL.Repository
{
    public class Repository : IRepository
    {
        private readonly HelpDeskDbContext _context;

        private const string StatusNew = "New";
        private const string StatusClosed = "Closed";

        public Repository(HelpDeskDbContext context)
        {
            _context = context;
        }

        public bool Authenticate(User user)
        {
            try
            {
                if (user == null || string.IsNullOrWhiteSpace(user.UserName) || string.IsNullOrWhiteSpace(user.Password))
                    return false;

                var matchedUser = _context.Users
                    .FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);

                return matchedUser != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Authenticate: {ex.Message}");
                return false;
            }
        }

        public List<ServiceRequest> ViewRequests()
        {
            try
            {
                return _context.ServiceRequests
                    .Include(r => r.Status)
                    .OrderByDescending(r => r.RaisedOn)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ViewRequests: {ex.Message}");
                return new List<ServiceRequest>();
            }
        }

        public List<ServiceRequest> ViewRequests(string userName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userName))
                    return new List<ServiceRequest>();

                return _context.ServiceRequests
                    .Include(r => r.Status)
                    .Where(r => r.RaisedBy == userName)
                    .OrderByDescending(r => r.RaisedOn)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ViewRequests(userName): {ex.Message}");
                return new List<ServiceRequest>();
            }
        }

        public int RaiseRequest(ServiceRequest newRequest)
        {
            try
            {
                if (newRequest == null)
                    return 0;

                var newStatusId = GetOrCreateStatusId(StatusNew);

                newRequest.RaisedOn = DateTime.Now;
                newRequest.ReqStatus = newStatusId;
                newRequest.Justification ??= string.Empty;

                _context.ServiceRequests.Add(newRequest);
                _context.SaveChanges();

                return newRequest.RequestId;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in RaiseRequest: {ex.Message}");
                return 0;
            }
        }

        public ServiceRequest? GetRequestById(int requestId)
        {
            try
            {
                return _context.ServiceRequests
                    .Include(r => r.Status)
                    .FirstOrDefault(r => r.RequestId == requestId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetRequestById: {ex.Message}");
                return null;
            }
        }

        public bool ReOpenRequest(ServiceRequest request)
        {
            try
            {
                if (request == null)
                    return false;

                var existingRequest = _context.ServiceRequests.FirstOrDefault(r => r.RequestId == request.RequestId);
                if (existingRequest == null)
                    return false;

                existingRequest.Justification = request.Justification;
                existingRequest.ReqStatus = GetOrCreateStatusId(StatusNew);

                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ReOpenRequest: {ex.Message}");
                return false;
            }
        }

        public List<ServiceRequest> GetRequestBySP(string userName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userName))
                    return new List<ServiceRequest>();

                return _context.ServiceRequests
                    .Include(r => r.Status)
                    .Where(r => r.RaisedBy.Contains(userName))
                    .OrderByDescending(r => r.RaisedOn)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetRequestBySP: {ex.Message}");
                return new List<ServiceRequest>();
            }
        }

        public bool CloseRequest(int requestId)
        {
            try
            {
                var existingRequest = _context.ServiceRequests.FirstOrDefault(r => r.RequestId == requestId);
                if (existingRequest == null)
                    return false;

                existingRequest.ReqStatus = GetOrCreateStatusId(StatusClosed);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CloseRequest: {ex.Message}");
                return false;
            }
        }

        public bool DeleteRequest(int requestId)
        {
            try
            {
                var existingRequest = _context.ServiceRequests.FirstOrDefault(r => r.RequestId == requestId);
                if (existingRequest == null)
                    return false;

                _context.ServiceRequests.Remove(existingRequest);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteRequest: {ex.Message}");
                return false;
            }
        }

        public User? GetUser(string userName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userName))
                    return null;

                return _context.Users
                    .Include(u => u.Role)
                    .FirstOrDefault(u => u.UserName == userName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetUser: {ex.Message}");
                return null;
            }
        }

        private int GetOrCreateStatusId(string description)
        {
            var status = _context.Statuses.FirstOrDefault(s => s.Description == description);
            if (status != null)
                return status.StatusId;

            var newStatus = new Status { Description = description };
            _context.Statuses.Add(newStatus);
            _context.SaveChanges();
            return newStatus.StatusId;
        }
    }
}