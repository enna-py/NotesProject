using BL.Responses.Note;
using Core.Enums;
//using DAL.Models;
//using Moq;
//using Newtonsoft.Json;
//using System.Net;

//namespace IntegrationTests.ControllerTests;
//public class NoteControllerTests : IDisposable
//{
//    private CustomWebApiFactory _factory;
//    private HttpClient _httpClient;

//    public NoteControllerTests()
//    {
//        _factory = new CustomWebApiFactory();
//        _httpClient = _factory.CreateClient();
//    }

//    [Fact]
//    public async Task GetAllNotes_ReturnsEmptyList_WhenNoNotesExist()
//    {
//        // Arrange
//        _factory.noteRepositoryMock.Setup(repo => repo.GetAllNotesAsync())
//            .Returns(Task.FromResult(Enumerable.Empty<Note>()));

//        var client = _factory.CreateClient();

//        // Act
//        var response = await client.GetAsync("/api/notes");

//        // Assert
//        response.EnsureSuccessStatusCode(); // Check for successful status code (200 OK)
//        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

//        var content = await response.Content.ReadAsStringAsync();
//        Assert.Equal("[]", content); // Empty JSON array
//    }

    //[Fact]
    //public async Task GetAllNotes_ReturnsListOfNotes_WhenNotesExist()
    //{
    //    // Arrange
    //    var notes = new List<Note>()
    //    {
    //        new Note() { Id = Guid.NewGuid(), Name = "Note 1", Description = "Test Description 1" },
    //        new Note() { Id = Guid.NewGuid(), Name = "Note 2", Description = "Test Description 2" },
    //    };

    //    _factory.noteRepositoryMock.Setup(repo => repo.GetAllNotesAsync())
    //        .Returns(Task.FromResult());

    //    var expectedResponse = new List<NoteGetAllResponse>()
    //    {
    //        new NoteGetAllResponse(notes[0].Id, notes[0].Name, notes[0].Description, NotesGroup.None, NotesPriority.None),
    //        new NoteGetAllResponse(notes[1].Id, notes[1].Name, notes[1].Description, NotesGroup.None, NotesPriority.None),
    //    };

    //    var client = _factory.CreateClient();

    //    // Act
    //    var response = await client.GetAsync("/api/notes");

    //    // Assert
    //    response.EnsureSuccessStatusCode();
    //    Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    //    var content = await response.Content.ReadAsStringAsync();
    //    var actualResponse = JsonConvert.DeserializeObject<List<NoteGetAllResponse>>(content);

    //    Assert.Equal(expectedResponse, actualResponse);
    //}

    public void Dispose()
    {
        _factory.Dispose();
        _httpClient.Dispose();
    }
}
