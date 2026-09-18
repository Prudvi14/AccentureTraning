using Capstone.DAL.Models;

namespace Capstone.DAL.Repository
{
    public interface IRepository
    {
        public bool Authenticate(User user);

        public List<ServiceRequest> ViewRequests();

        public List<ServiceRequest> ViewRequests(string userName);

        public int RaiseRequest(ServiceRequest newRequest);

        public ServiceRequest? GetRequestById(int requestId);

        public bool ReOpenRequest(ServiceRequest request);

        public List<ServiceRequest> GetRequestBySP(string userName);

        public bool CloseRequest(int requestId);

        public bool DeleteRequest(int requestId);

        public User? GetUser(string userName);
    }
}