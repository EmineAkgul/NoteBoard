using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteBoard.Model;

namespace NoteBoard.DAL.Repositories
{
    public class NoteDAL
    {
        NoteBoardDbContext db;
        public NoteDAL()
        {
            db = new NoteBoardDbContext();
        }

        public int Add(Note note)
        {
            db.Entry(note).State = System.Data.Entity.EntityState.Added;
            return db.SaveChanges();
        }

        public int Update(Note note)
        {
            db.Entry(note).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }

        public int Delete(Note note)
        {
            db.Entry(note).State = System.Data.Entity.EntityState.Deleted;
            return db.SaveChanges();
        }

        public List<Note> GetAll()
        {
            return db.Notes.ToList();
        }

        public Note GetByID(int noteID)
        {
            return db.Notes.FirstOrDefault(a => a.NoteID == noteID);
        }

    }
}
