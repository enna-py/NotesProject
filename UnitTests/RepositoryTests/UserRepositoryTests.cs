using DAL.Interface;
using DAL.Models;
using DAL.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

namespace UnitTests.RepositoryTests;
public class UserRepositoryTests
{
    private readonly IUserRepository _mockUserRepository;
    private readonly Mock<NotesContext> _mockContext;

    public UserRepositoryTests()
    {
        _mockContext = new Mock<NotesContext>(new DbContextOptionsBuilder<NotesContext>().Options);
        _mockUserRepository = new UserRepository(_mockContext.Object);
    }

    [Fact]
    public async Task GetUserById_DataCorrect_ReturnsUserAsync()
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = "Test",
            Email = "Test@gmail.com",
            Password = "123456789000",
            UserName = "Test",
            IsActive = true,
        };

        _mockContext.Setup(x => x.Users).ReturnsDbSet(new List<User> { user });

        var result = await _mockUserRepository.GetByIdAsync(user.Id);

        result.Should().NotBeNull();
        result.Id.Should().Be(user.Id);
        result.Name.Should().Be(user.Name);
        result.UserName.Should().Be(user.UserName);
        result.Email.Should().Be(user.Email);
        result.Password.Should().Be(user.Password);
        result.IsActive.Should().BeTrue();
    }

    [Fact]
    public async Task AddUser_DataCorrect_ReturnsUserId()
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = "Test",
            Email = "Test@gmail.com",
            Password = "123456789000",
            UserName = "Test",
            IsActive = true,
        };

        _mockContext.Setup(x => x.Users).ReturnsDbSet(new List<User> { user });
        _mockContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        var result = await _mockUserRepository.AddUserAsync(user);

        _mockContext.Verify(x => x.Users.AddAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task DeleteUser_CorrectData_ReturnsTrue()
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = "Test",
            Email = "Test@gmail.com",
            Password = "123456789000",
            UserName = "Test",
            IsActive = true,
        };

        _mockContext.Setup(x => x.Users).ReturnsDbSet(new List<User> { user });
        _mockContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        var result = await _mockUserRepository.SoftDeleteAsync(user.Id);

        user.IsActive.Should().BeFalse();
    }

    [Fact]
    public async Task UpdateUser_CorrectData_ReturnsTrue()
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = "Test",
            Email = "Test@gmail.com",
            Password = "123456789000",
            UserName = "Test",
            IsActive = true,
        };

        _mockContext.Setup(x => x.Users).ReturnsDbSet(new List<User> { user });
        _mockContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        var result = await _mockUserRepository.UpdateAsync(user);

        _mockContext.Verify(x => x.Update(It.IsAny<User>()), Times.Once);
    }
}
