using Core.Enums;
using DAL.Interface;
using DAL.Models;
using DAL.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

namespace UnitTests.RepositoryTests;

public class NoteRepositoryTests
{
    private readonly INoteRepository _mockNoteRepository;
    private readonly Mock<NotesContext> _mockContext;

    public NoteRepositoryTests()
    {
        _mockContext = new Mock<NotesContext>(new DbContextOptionsBuilder<NotesContext>().Options);
        _mockNoteRepository = new NoteRepository(_mockContext.Object);
    }

    [Fact]
    public async Task GetNoteById_DataCorrect_ReturnsNoteAsync()
    {
        var note = new Note
        {
            Colors = NotesColor.Blue,
            DeadLine = DateTime.Now.AddDays(12),
            Description = "description",
            Group = NotesGroup.Personal,
            Id = Guid.NewGuid(),
            IsActive = true,
            IsDone = default,
            Name = "TestName",
            Priority = NotesPriority.None,
            UserId = Guid.NewGuid(),
        };

        _mockContext.Setup(x => x.Notes).ReturnsDbSet(new List<Note> { note });

        var result = await _mockNoteRepository.GetByIdAsync(note.Id);

        result.Should().NotBeNull();
        result.Colors.Should().Be(NotesColor.Blue);
        result.Id.Should().Be(note.Id);
        result.Name.Should().Be(note.Name);
        result.DeadLine.Should().Be(note.DeadLine);
        result.Description.Should().Be(note.Description);
        result.Group.Should().Be(note.Group);
        result.IsActive.Should().Be(note.IsActive);
        result.IsDone.Should().Be(note.IsDone);
        result.UserId.Should().Be(note.UserId);
    }

    [Fact]
    public async Task DeleteNote_CorrectData_ReturnsTrue()
    {
        var note = new Note
        {
            Colors = NotesColor.Blue,
            DeadLine = DateTime.Now.AddDays(12),
            Description = "description",
            Group = NotesGroup.Personal,
            Id = Guid.NewGuid(),
            IsActive = true,
            IsDone = default,
            Name = "TestName",
            Priority = NotesPriority.None,
            UserId = Guid.NewGuid(),
        };

        _mockContext.Setup(x => x.Notes).ReturnsDbSet(new List<Note> { note });
        _mockContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        var result = await _mockNoteRepository.SoftDeleteAsync(note.Id);

        _mockContext.Verify(x => x.Update(It.IsAny<Note>()), Times.Once);
        note.IsActive.Should().BeFalse();
    }

    [Fact]
    public async Task AddNote_CorrectData_ReturnsNoteId()
    {
        //arrange
        var userId = Guid.NewGuid();

        var note = new Note
        {
            Colors = NotesColor.Blue,
            DeadLine = DateTime.Now.AddDays(12),
            Description = "description",
            Group = NotesGroup.Personal,
            Id = Guid.NewGuid(),
            IsActive = true,
            IsDone = default,
            Name = "TestName",
            Priority = NotesPriority.None,
            UserId = userId,
        };

        _mockContext.Setup(x => x.Notes).ReturnsDbSet(new List<Note>());
        _mockContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        //act
        var result = await _mockNoteRepository.AddNoteAsync(note);

        //assert
        _mockContext.Verify(x => x.Notes.AddAsync(It.IsAny<Note>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task UpdateNote_CorrectData_ReturnsTrue()
    {
        var note = new Note
        {
            Colors = NotesColor.Blue,
            DeadLine = DateTime.Now.AddDays(12),
            Description = "description",
            Group = NotesGroup.Personal,
            Id = Guid.NewGuid(),
            IsActive = true,
            IsDone = default,
            Name = "TestName",
            Priority = NotesPriority.None,
            UserId = Guid.NewGuid(),
        };

        _mockContext.Setup(x => x.Notes).ReturnsDbSet(new List<Note> { note });
        _mockContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        var result = await _mockNoteRepository.UpdateAsync(note);

        _mockContext.Verify(x => x.Update(It.IsAny<Note>()), Times.Once);
    }
}
