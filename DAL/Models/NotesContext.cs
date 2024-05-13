using Microsoft.EntityFrameworkCore;

namespace DAL.Models;
public class NotesContext : DbContext
{
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Note> Notes { get; set; }

    public NotesContext(DbContextOptions<NotesContext> options) 
    :base(options)
    {
        //Database.EnsureCreated();   //u can uncomment it now
    }
}
