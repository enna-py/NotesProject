using DAL.Models;

namespace DAL.Interface;
//Строгая не строгая типизщация
public interface INoteRepository
{
    public Task<Guid> AddNoteAsync(Note note);

    public Task<Note> GetByIdAsync(Guid id);

    public Task<IEnumerable<Note>> GetAllNotesAsync();

    public Task<bool> SoftDeleteAsync(Guid id);

    public Task<bool> UpdateAsync(Note note);
}
