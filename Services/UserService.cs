using Microsoft.EntityFrameworkCore;
using WeatherForecastUI.Context;
using WeatherForecastUI.Model;

namespace WeatherForecastUI.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<List<User>> GetActiveUsers();

    }

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<List<User>> GetActiveUsers()
        {
            return await _context.Users.Where(y => y.Status == 1).OrderBy(x => x.Id).ToListAsync();
        }

        //Add New User Record
        public async Task<bool> AddNewUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return true;
        }

        //Get User Record by Id
        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        //Update User Data
        public async Task<bool> UpdateUserDetails(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return true;
        }

        //Delete User Data
        public async Task<bool> DeleteUser(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
