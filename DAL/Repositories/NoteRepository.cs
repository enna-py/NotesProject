using DAL.Interface;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;
public class NoteRepository : INoteRepository
{
    private readonly NotesContext _context;

    public NoteRepository(NotesContext context)
    {
        _context = context;
    }
    public virtual async Task<Guid> AddNoteAsync(Note note)
    {
        await _context.Notes.AddAsync(note);
        var result = await _context.SaveChangesAsync();
        return result > 0 ? note.Id : Guid.Empty;
    }

    public virtual async Task<IEnumerable<Note>> GetAllNotesAsync()
    {
        return await _context.Notes.ToListAsync();
    }

    public virtual async Task<Note> GetByIdAsync(Guid id)
    {
        return await _context.Notes.FirstOrDefaultAsync(note => note.Id == id);
    }

    public virtual async Task<bool> SoftDeleteAsync(Guid id)
    {
        var note = await _context.Notes.FirstOrDefaultAsync(x => x.Id == id);
        note.IsActive = false;
        _context.Update(note);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    //public async Task<Note> UpdatePatchAsync(Guid NoteId, JsonPatchDocument noteModel)
    //{
    //    var note = await _context.Notes.FindAsync(NoteId);
    //    noteModel.ApplyTo(note);
    //    await _context.SaveChangesAsync();

    //    return note;
    //}
    public virtual async Task<bool> UpdateAsync(Note note)
    {
        _context.Update(note);
        return await _context.SaveChangesAsync() > 0;
    }
}
