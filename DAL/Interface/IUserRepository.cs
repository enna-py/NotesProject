using DAL.Models;

namespace DAL.Interface;
public interface IUserRepository
{
    public Task<Guid> AddUserAsync(User user);

    public Task<User> GetByIdAsync(Guid id);//same

    public Task<IEnumerable<User>> GetAllUsersAsync();

    //public Task<User> UpdatePatchAsync(Guid UserId, [FromBody] JsonPatchDocument UserModel);

    public Task<bool> SoftDeleteAsync(Guid id);//same

    public Task<bool> UpdateAsync(User note);

    public Task<User?> GetUserByUserName(string userName);
}
