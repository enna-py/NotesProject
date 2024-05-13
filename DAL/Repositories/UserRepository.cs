using DAL.Interface;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;
public class UserRepository : IUserRepository
{
    private readonly NotesContext _context;

    public UserRepository(NotesContext context)
    {
        _context = context;
    }
    public virtual async Task<Guid> AddUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
        return  await _context.SaveChangesAsync() > 0 ? user.Id : Guid.Empty;
    }

    public virtual async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async virtual Task<User> GetByIdAsync(Guid id)
    {
        return await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
    }

    public virtual async Task<User?> GetUserByUserName(string userName)
    {
        return await _context.Users.FirstOrDefaultAsync(user => user.UserName == userName);
    }

    public virtual async Task<bool> SoftDeleteAsync(Guid id)
    {
        var user = await _context.Users.FirstAsync(x => x.Id == id);

        user.IsActive = false;
        //_context.Update(user);
        return await _context.SaveChangesAsync() > 0;
    }

    //public async Task<User> UpdatePatchAsync(Guid UserId, [FromBody] JsonPatchDocument UserModel)
    //{
    //    var user = await _context.Users.FindAsync(UserId);
    //    UserModel.ApplyTo(user);
    //    await _context.SaveChangesAsync();

    //    return user;
    //}
    public virtual async Task<bool> UpdateAsync(User user)
    {
        _context.Update(user);
        return await _context.SaveChangesAsync() > 0;
    }
}
