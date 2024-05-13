using BL.Handler.NoteHandler.NoteRequests;
using BL.Interfaces;
using Core.Exeptions;
using Microsoft.AspNetCore.Mvc;

namespace notesApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class NoteController : Controller
{
    private readonly IServiceNote _service;

    public NoteController(IServiceNote service)
    {
        _service = service;
    }

    [HttpGet("GetAllNotes")]
    public async Task<IActionResult> GetAllNotes()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{noteId}")]
    public async Task<IActionResult> GetNote(Guid noteId)
    {
        try
        {
            return Ok(await _service.GetByIdAsync(noteId));
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost("AddNote")]
    public async Task<IActionResult> AddNote(NoteAddRequest request)
    {
        try
        {
            return Ok(await _service.AddNoteAsync(request));
        }
        catch (EntityNotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("DeleteNote")]
    public async Task<IActionResult> SoftDeleteNote(Guid id)
    {
        try
        {
            return Ok(await _service.DeleteNote(id));
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPatch("ChangeColor")]
    public async Task<IActionResult> ChangeColor(ChangeColorRequest request)
    {
        try
        {
            return Ok(await _service.ChangeColor(request));
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPatch("ChangeIsDone")]
    public async Task<IActionResult> ChangeDone(ChangeIsDoneRequest request)
    {
        try
        {
            return Ok(await _service.ChangeDone(request));
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPatch("ChangeDescription")]
    public async Task<IActionResult> ChangeDescription(ChangeDescriptionRequest request)
    {
        try
        {
            return Ok(await _service.ChangeDescription(request));
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPatch("ChangeGroup")]
    public async Task<IActionResult> ChangeGroup(ChangeGroupRequest request)
    {
        try
        {
            return Ok(await _service.ChangeGroup(request));
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPatch("ChangeName")]
    public async Task<IActionResult> ChangeName(ChangeNameRequest request)
    {
        try
        {
            return Ok(await _service.ChangeName(request));
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPatch("ChangePriority")]
    public async Task<IActionResult> ChangePriority(ChangePriorityRequest request)
    {
        try
        {
            return Ok(await _service.ChangePriority(request));
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPatch("ChangeDeadLine")]
    public async Task<IActionResult> ChangeDeadLine(ChangeDeadLineRequest request)
    {
        try
        {
            return Ok(await _service.ChangeDeadLine(request));
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
