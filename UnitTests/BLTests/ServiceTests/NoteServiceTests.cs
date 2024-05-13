using AutoMapper;
using BL.Handler.NoteHandler.NoteRequests;
using BL.Services;
using Core.Enums;
using Core.Exeptions;
using DAL.Models;
using DAL.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace UnitTests.BLTests.ServiceTests;
public class NoteServiceTests
{
    private readonly Mock<NoteRepository> _mockNoteRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<UserRepository> _mockUserRepository;
    private readonly Mock<NotesContext> _mockContext;
    private readonly NoteService _noteService;
    private readonly Note Note;
    public NoteServiceTests()
    {
        _mockContext = new Mock<NotesContext>(new DbContextOptionsBuilder<NotesContext>().Options);
        _mockUserRepository = new Mock<UserRepository>(_mockContext.Object);
        _mockNoteRepository = new Mock<NoteRepository>(_mockContext.Object);
        _mockMapper = new Mock<IMapper>();
        _noteService = new NoteService(_mockNoteRepository.Object, _mockMapper.Object, _mockUserRepository.Object);
        Note = new Note
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
    }

    [Fact]
    public async Task NoteGetByIdAsync_CorrectData_ReturnsNoteAsync()
    {
        _mockNoteRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(Note);

        var result = await _noteService.GetByIdAsync(Note.Id);

        result.Should().NotBeNull();
        result.Colors.Should().Be(NotesColor.Blue);
        result.Id.Should().Be(Note.Id);
        result.Name.Should().Be(Note.Name);
        result.DeadLine.Should().Be(Note.DeadLine);
        result.Description.Should().Be(Note.Description);
        result.Group.Should().Be(Note.Group);
        result.IsActive.Should().Be(Note.IsActive);
        result.IsDone.Should().Be(Note.IsDone);
        result.UserId.Should().Be(Note.UserId);
    }

    [Fact]
    public void NoteGetByIdAsync_InCorrectData_ThrowEntityNotFoundExeption()
    {
        var act = () => _noteService.GetByIdAsync(Guid.NewGuid());

        act.Should().ThrowAsync<EntityNotFoundException>();
    }

    [Fact]
    public async Task AddNoteAsync_CorrectData_ReturnsGuidAsync()
    {
        var user = new User();

        var request = new NoteAddRequest(Note.Name, Note.Description, Note.UserId);

        _mockUserRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(user);

        _mockNoteRepository.Setup(x => x.AddNoteAsync(It.IsAny<Note>())).ReturnsAsync(Note.Id);

        var result = await _noteService.AddNoteAsync(request);

        _mockNoteRepository.Verify(x => x.AddNoteAsync(It.IsAny<Note>()), Times.Once);

        result.Should().Be(Note.Id);
    }

    [Fact]
    public void AddNoteAsync_InCorrectData_ThrowEntityNotFoundExeption()
    {
        var request = new NoteAddRequest(Note.Name, Note.Description, Guid.NewGuid());

        var act = () => _noteService.AddNoteAsync(request);

        act.Should().ThrowAsync<EntityNotFoundException>();
    }

    [Fact]
    public async Task DeleteNote_CorrectData_ReturnsTrue()
    {
        _mockNoteRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(Note);

        _mockNoteRepository.Setup(x => x.SoftDeleteAsync(It.IsAny<Guid>())).ReturnsAsync(true);

        var result = await _noteService.DeleteNote(Note.Id);

        _mockNoteRepository.Verify(x => x.SoftDeleteAsync(It.IsAny<Guid>()), Times.Once);

        result.Should().Be(true);
    }

    [Fact]
    public void DeleteNote_InCorrectData_ThrowEntityNotFoundExeption()
    {
        var act = () => _noteService.DeleteNote(Guid.NewGuid());

        act.Should().ThrowAsync<EntityNotFoundException>();
    }

    [Fact]
    public async Task ChangeNoteColor_CorrectData_RetursTrue()
    {
        var request = new ChangeColorRequest(Note.Id, NotesColor.Red);

        _mockNoteRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(Note);

        _mockNoteRepository.Setup(x => x.UpdateAsync(It.IsAny<Note>())).ReturnsAsync(true);

        var result = await _noteService.ChangeColor(request);

        _mockNoteRepository.Verify(x => x.UpdateAsync(It.IsAny<Note>()), Times.Once);

        result.Should().Be(true);
    }

    [Fact]
    public void ChangeNoteColor_InCorrectData_ThrowEntityNotFoundExeption()
    {
        var request = new ChangeColorRequest(Guid.NewGuid(), NotesColor.Red);

        var act = () => _noteService.ChangeColor(request);

        act.Should().ThrowAsync<EntityNotFoundException>();
    }

    [Fact]
    public async Task ChangeNoteDescription_CorrectData_RetursTrue()
    {
        var request = new ChangeDescriptionRequest(Note.Id, "Test description");

        _mockNoteRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(Note);

        _mockNoteRepository.Setup(x => x.UpdateAsync(It.IsAny<Note>())).ReturnsAsync(true);

        var result = await _noteService.ChangeDescription(request);

        _mockNoteRepository.Verify(x => x.UpdateAsync(It.IsAny<Note>()), Times.Once);

        result.Should().Be(true);
    }

    [Fact]
    public void ChangeNoteDescription_InCorrectData_ThrowEntityNotFoundExeption()
    {
        var request = new ChangeDescriptionRequest(Guid.NewGuid(), "Test description");

        var act = () => _noteService.ChangeDescription(request);

        act.Should().ThrowAsync<EntityNotFoundException>();
    }

    [Fact]
    public async Task ChangeNoteGroup_CorrectData_RetursTrue()
    {
        var request = new ChangeGroupRequest(Note.Id, NotesGroup.Hobby);

        _mockNoteRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(Note);

        _mockNoteRepository.Setup(x => x.UpdateAsync(It.IsAny<Note>())).ReturnsAsync(true);

        var result = await _noteService.ChangeGroup(request);

        _mockNoteRepository.Verify(x => x.UpdateAsync(It.IsAny<Note>()), Times.Once);

        result.Should().Be(true);
    }

    [Fact]
    public void ChangeNoteGroup_InCorrectData_ThrowEntityNotFoundExeption()
    {
        var request = new ChangeGroupRequest(Guid.NewGuid(), NotesGroup.Hobby);

        var act = () => _noteService.ChangeGroup(request);

        act.Should().ThrowAsync<EntityNotFoundException>();
    }

    [Fact]
    public async Task ChangeNoteName_CorrectData_RetursTrue()
    {
        var request = new ChangeNameRequest(Note.Id, "Test name");

        _mockNoteRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(Note);

        _mockNoteRepository.Setup(x => x.UpdateAsync(It.IsAny<Note>())).ReturnsAsync(true);

        var result = await _noteService.ChangeName(request);

        _mockNoteRepository.Verify(x => x.UpdateAsync(It.IsAny<Note>()), Times.Once);

        result.Should().Be(true);
    }

    [Fact]
    public void ChangeNoteName_InCorrectData_ThrowEntityNotFoundExeption()
    {
        var request = new ChangeNameRequest(Guid.NewGuid(), "Test name");

        var act = () => _noteService.ChangeName(request);

        act.Should().ThrowAsync<EntityNotFoundException>();
    }

    [Fact]
    public async Task ChangeNotePriority_CorrectData_RetursTrue()
    {
        var request = new ChangePriorityRequest(Note.Id, NotesPriority.Important);

        _mockNoteRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(Note);

        _mockNoteRepository.Setup(x => x.UpdateAsync(It.IsAny<Note>())).ReturnsAsync(true);

        var result = await _noteService.ChangePriority(request);

        _mockNoteRepository.Verify(x => x.UpdateAsync(It.IsAny<Note>()), Times.Once);

        result.Should().Be(true);
    }

    [Fact]
    public void ChangeNotePriority_InCorrectData_ThrowEntityNotFoundExeption()
    {
        var request = new ChangePriorityRequest(Guid.NewGuid(), NotesPriority.Important);

        var act = () => _noteService.ChangePriority(request);

        act.Should().ThrowAsync<EntityNotFoundException>();
    }

    [Fact]
    public async Task ChangeNoteDeadLine_CorrectData_RetursTrue()
    {
        var request = new ChangeDeadLineRequest(Note.Id, DateTime.Now.AddDays(12));

        _mockNoteRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(Note);

        _mockNoteRepository.Setup(x => x.UpdateAsync(It.IsAny<Note>())).ReturnsAsync(true);

        var result = await _noteService.ChangeDeadLine(request);

        _mockNoteRepository.Verify(x => x.UpdateAsync(It.IsAny<Note>()), Times.Once);

        result.Should().Be(true);
    }

    [Fact]
    public void ChangeNoteDeadLine_InCorrectData_ThrowEntityNotFoundExeption()
    {
        var request = new ChangeDeadLineRequest(Guid.NewGuid(), DateTime.Now.AddDays(12));

        var act = () => _noteService.ChangeDeadLine(request);

        act.Should().ThrowAsync<EntityNotFoundException>();
    }

    [Fact]
    public async Task ChangeNoteDone_CorrectData_RetursTrue()
    {
        var request = new ChangeIsDoneRequest(Note.Id);

        _mockNoteRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(Note);

        _mockNoteRepository.Setup(x => x.UpdateAsync(It.IsAny<Note>())).ReturnsAsync(true);

        var result = await _noteService.ChangeDone(request);

        _mockNoteRepository.Verify(x => x.UpdateAsync(It.IsAny<Note>()), Times.Once);

        result.Should().Be(true);
    }

    [Fact]
    public void ChangeNoteDone_InCorrectData_ThrowEntityNotFoundExeption()
    {
        var request = new ChangeIsDoneRequest(Guid.NewGuid());

        var act = () => _noteService.ChangeDone(request);

        act.Should().ThrowAsync<EntityNotFoundException>();
    }
}
