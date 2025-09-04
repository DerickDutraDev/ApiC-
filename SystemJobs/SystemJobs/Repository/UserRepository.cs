using Microsoft.EntityFrameworkCore;
using SystemJobs.Data;
using SystemJobs.Models;
using SystemJobs.Repository.Interfaces;

namespace SystemJobs.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly SystemTaskDBContext _dbContext;

        public UserRepository(SystemTaskDBContext systemTaskDBContext)
        {
            _dbContext = systemTaskDBContext;
        }

        public async Task<UserModel> SearchUserById(int id)
        {
            return await _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public async Task<List<UserModel>> SearchAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> CreateUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            
            return user;
        }

        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel userId = await SearchUserById(id);
            
            if(userId == null)
            {
                throw new Exception($"User with ID {id} not found.");
            }

           userId.Name = user.Name;
           userId.Email = user.Email;

            _dbContext.Users.Update(userId);
            await _dbContext.SaveChangesAsync();

            return userId;
        }

        public async Task<bool> DeleteUser(int id)
        {
            UserModel userId = await SearchUserById(id);

            if (userId == null)
            {
                throw new Exception($"User with ID {id} not found.");
            }

            _dbContext.Users.Remove(userId);
            await _dbContext.SaveChangesAsync();

            return true;

        }

    }
}
