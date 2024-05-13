using AutoMapper;
using BL.Handler.UserHandler.UserRequests;
using BL.Interfaces;
using BL.Responses.User;
using Core.Exeptions;
using DAL.Interface;
using DAL.Models;

namespace BL.Services;
public class UserService : IServiceUser
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<Guid> AddUserAsync(UserAddRequest request)
    {
        var user = await _userRepository.GetUserByUserName(request.UserName);
        if (user != null)
        {
            throw new EntityNotFoundException($"User with this user name: {request.UserName} already exists");
        }

        var userDb = new User()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Email = request.Email,
            Password = request.Password,
            UserName = request.UserName,
            IsActive = true,
        };

        return await _userRepository.AddUserAsync(userDb);
    }
    //rework changers
    public async Task<bool> ChangeEmail(ChangeEmailRequest request)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user == null)
        {
            throw new EntityNotFoundException($"User with id: {request.UserId} was not found");
        }

        user.Email = request.Email;
        return await _userRepository.UpdateAsync(user);
    }

    public async Task<bool> ChangeName(ChangeNameUserRequest request)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user == null)
        {
            throw new EntityNotFoundException($"User with id: {request.UserId} was not found");
        }

        user.Name = request.NewName;
        return await _userRepository.UpdateAsync(user);
    }

    public async Task<bool> ChangePassword(ChangePasswordRequest request)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user == null)
        {
            throw new EntityNotFoundException($"User with id: {request.UserId} was not found");
        }

        user.Name = request.NewPassword;
        return await _userRepository.UpdateAsync(user);
    }

    public async Task<bool> ChangeUserName(ChangeUserNameRequest request)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user == null)
        {
            throw new EntityNotFoundException($"User with id: {request.UserId} was not found");
        }

        user.UserName = request.NewUserName;
        return await _userRepository.UpdateAsync(user);
    }

    public async Task<IEnumerable<UserGetAllResponse>> GetAllAsync()
    {
        var allUsers = await _userRepository.GetAllUsersAsync();
        if (allUsers == null)
        {
            return new List<UserGetAllResponse>();
        }

        return _mapper.Map<IEnumerable<UserGetAllResponse>>(allUsers);
    }

    public async Task<User> GetByIdAsync(Guid Id)
    {
        var user = await _userRepository.GetByIdAsync(Id);
        if (user == null)
        {
            throw new EntityNotFoundException($"User with id: {Id} was not found");
        }

        return user;
    }
    public async Task<bool> DeleteUser(Guid Id)
    {
        var user = await _userRepository.GetByIdAsync(Id);
        if (user == null)
        {
            throw new EntityNotFoundException($"User with id: {Id} was not found");
        }

        user.IsActive = false;
        return await _userRepository.UpdateAsync(user);
    }
}
