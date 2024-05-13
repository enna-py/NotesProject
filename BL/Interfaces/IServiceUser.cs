using BL.Handler.UserHandler.UserRequests;
using BL.Responses.User;
using DAL.Models;

namespace BL.Interfaces;
public interface IServiceUser
{
    public Task<User> GetByIdAsync(Guid Id);

    public Task<IEnumerable<UserGetAllResponse>> GetAllAsync();

    public Task<Guid> AddUserAsync(UserAddRequest request);

    public Task<bool> ChangeEmail(ChangeEmailRequest request);

    public Task<bool> ChangeName(ChangeNameUserRequest request);

    public Task<bool> ChangePassword(ChangePasswordRequest request);

    public Task<bool> ChangeUserName(ChangeUserNameRequest request);

    public Task<bool> DeleteUser(Guid Id);
}
