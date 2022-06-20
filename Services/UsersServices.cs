using MarcusDesafio.Data;
using MarcusDesafio.Models;

namespace MarcusDesafio.Services
{
    public class UsersServices
    {
        private readonly dbContext _context;
        public UsersServices(dbContext context)
        {
            _context = context;
        }
        public async Task<bool> validateUser(User user)
        {
            var result = _context.User.Where(x => x.Username.Contains(user.Username));
            if (result.Any())
                return false;
            return true;
        }
    }
}
