using UserDataLibrary.IRepo;
using UserDataLibrary.Models;

namespace UserDataLibrary.Repo
{
    public class UserOps : IUser
    {
        private readonly AppDbContext _context;

        public UserOps(AppDbContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}