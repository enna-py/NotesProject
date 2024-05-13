using AutoMapper;
using BL.Handler.UserHandler.UserRequests;
using BL.Services;
using Core.Exeptions;
using DAL.Models;
using DAL.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace UnitTests.BLTests.ServiceTests;
public class UserServiceTests
{
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<UserRepository> _mockUserRepository;
    private readonly Mock<NotesContext> _mockContext;
    private readonly UserService _userService;
    private readonly User User;

    public UserServiceTests()
    {
        _mockContext = new Mock<NotesContext>(new DbContextOptionsBuilder<NotesContext>().Options);
        _mockUserRepository = new Mock<UserRepository>(_mockContext.Object);
        _mockMapper = new Mock<IMapper>();
        _userService = new UserService(_mockUserRepository.Object, _mockMapper.Object);
        User = new User
        {
            Id = Guid.NewGuid(),
            Name = "Test Name",
            Email = "testemail@gmail.com",
            Password = "123456789009",
            UserName = "Test User Name",
            IsActive = true,
        };
    }

    [Fact]
    public async void AddUserAsync_CorrectData_ReturnsGuid()
    {
        //arange
        var request = new UserAddRequest(User.Name, User.Email, User.Password, User.UserName);
        _mockUserRepository.Setup(x => x.AddUserAsync(It.IsAny<User>())).ReturnsAsync(User.Id);

        //Act
        var result = await _userService.AddUserAsync(request);

        //assert
        _mockUserRepository.Verify(x => x.AddUserAsync(It.IsAny<User>()), Times.Once);
        result.Should().Be(User.Id);
    }

    [Fact]
    public void AddUserAsync_InCorrectData_ThrowEntityNotFoundExeption()
    {
        //arange
        var request = new UserAddRequest(User.Name, User.Email, User.Password, User.UserName);
        var act = () => _userService.AddUserAsync(request);

        act.Should().ThrowAsync<EntityNotFoundException>();
    }

    [Fact]
    public async void GetById_CorrectData_ReturnsUser()
    {
        //arange
        _mockUserRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(User);

        //act
        var result = await _userService.GetByIdAsync(User.Id);

        //assert
        result.Should().NotBeNull();
        result.UserName.Should().Be(User.UserName);
        result.Name.Should().Be(User.Name);
        result.Password.Should().Be(User.Password);
        result.IsActive.Should().Be(User.IsActive);
    }

    [Fact]
    public void GetById_InCorrectData_ThrowEntityNotFoundExeption()
    {
        var act = () => _userService.GetByIdAsync(Guid.NewGuid());

        act.Should().ThrowAsync<EntityNotFoundException>();
    }

    [Fact]
    public async void DeleteUser_CorrectData_ReturnTrue()
    {
        //arange
        _mockUserRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(User);
        _mockUserRepository.Setup(x => x.UpdateAsync(It.IsAny<User>())).ReturnsAsync(true);

        //act
        var result = await _userService.DeleteUser(User.Id);

        //assert
        result.Should().Be(true);
    }

    [Fact]
    public void DeleteUser_InCorrectData_ThrowEntityNotFoundExeption()
    {
        var act = () => _userService.DeleteUser(Guid.NewGuid());

        act.Should().ThrowAsync<EntityNotFoundException>();
    }

    [Fact]
    public async void ChangeEmail_CorrectData_ReturnTrue()
    {
        var request = new ChangeEmailRequest(User.Id, User.Email);

        _mockUserRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(User);
        _mockUserRepository.Setup(x => x.UpdateAsync(It.IsAny<User>())).ReturnsAsync(true);

        var result = await _userService.ChangeEmail(request);

        _mockUserRepository.Verify(x => x.UpdateAsync(It.IsAny<User>()), Times.Once);
        result.Should().BeTrue();
    }

    [Fact]
    public void ChangeEmail_InCorrectData_ThrowEntityNotFoundExeption()
    {
        var request = new ChangeEmailRequest(User.Id, User.Email);

        var act = () => _userService.ChangeEmail(request);

        act.Should().ThrowAsync<EntityNotFoundException>();
    }

    [Fact]
    public async void ChangeName_CorrectData_ReturnTrue()
    {
        var request = new ChangeNameUserRequest(User.Id, User.Name);

        _mockUserRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(User);
        _mockUserRepository.Setup(x => x.UpdateAsync(It.IsAny<User>())).ReturnsAsync(true);

        var result = await _userService.ChangeName(request);

        _mockUserRepository.Verify(x => x.UpdateAsync(It.IsAny<User>()), Times.Once);
        result.Should().BeTrue();
    }

    [Fact]
    public void ChangeName_InCorrectData_ThrowEntityNotFoundExeption()
    {
        var request = new ChangeNameUserRequest(User.Id, User.Name);

        var act = () => _userService.ChangeName(request);

        act.Should().ThrowAsync<EntityNotFoundException>();
    }

    [Fact]
    public async void ChangePassword_CorrectData_ReturnTrue()
    {
        var request = new ChangePasswordRequest(User.Id, User.Password);

        _mockUserRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(User);
        _mockUserRepository.Setup(x => x.UpdateAsync(It.IsAny<User>())).ReturnsAsync(true);

        var result = await _userService.ChangePassword(request);

        _mockUserRepository.Verify(x => x.UpdateAsync(It.IsAny<User>()), Times.Once);
        result.Should().BeTrue();
    }

    [Fact]
    public void ChangePassword_InCorrectData_ThrowEntityNotFoundExeption()
    {
        var request = new ChangePasswordRequest(User.Id, User.Password);

        var act = () => _userService.ChangePassword(request);

        act.Should().ThrowAsync<EntityNotFoundException>();
    }

    [Fact]
    public async void ChangeUserName_CorrectData_ReturnTrue()
    {
        var request = new ChangeUserNameRequest(User.Id, User.UserName);

        _mockUserRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(User);
        _mockUserRepository.Setup(x => x.UpdateAsync(It.IsAny<User>())).ReturnsAsync(true);

        var result = await _userService.ChangeUserName(request);

        _mockUserRepository.Verify(x => x.UpdateAsync(It.IsAny<User>()), Times.Once);
        result.Should().BeTrue();
    }

    [Fact]
    public void ChangeUserName_InCorrectData_ThrowEntityNotFoundExeption()
    {
        var request = new ChangeUserNameRequest(User.Id, User.UserName);

        var act = () => _userService.ChangeUserName(request);

        act.Should().ThrowAsync<EntityNotFoundException>();
    }
}
