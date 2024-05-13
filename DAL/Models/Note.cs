using Core.Enums;

namespace DAL.Models;
public class Note
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; } = "No name yet";//is there really flow when your note doesn't has any name?
    public string Description { get; set; } = "Some description...";//just left it empty no need for this
    public bool IsActive { get; set; }
    public DateTime DeadLine { get; set; }//it's better to make names more precisly for what they stands for as DeadLineDate
    public bool IsDone { get; set; } = false;
    public NotesColor Colors { get; set; } = NotesColor.Green;
    public NotesGroup Group { get; set; } = NotesGroup.None;//i think there is a way to make Enum itself default value
    public NotesPriority Priority { get; set; } = NotesPriority.None;
}
