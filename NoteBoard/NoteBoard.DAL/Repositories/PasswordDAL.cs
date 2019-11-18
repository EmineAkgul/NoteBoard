using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteBoard.Model;

namespace NoteBoard.DAL.Repositories
{
    public class PasswordDAL
    {
        NoteBoardDbContext db;
        public PasswordDAL()
        {
             db = new NoteBoardDbContext();
        }

        public int Add(Password password)
        {
            db.Entry(password).State = System.Data.Entity.EntityState.Added;
            return db.SaveChanges();
        }

        public int Update(Password password)
        {
            db.Entry(password).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }

        public int Delete(int password)
        {
            db.Entry(password).State = System.Data.Entity.EntityState.Deleted;
            return db.SaveChanges();
        }

        public List<Password> GetAll()
        {
            return db.Passwords.ToList();
        }

        public Password GetByID(int passID)
        {
            return db.Passwords.FirstOrDefault(a => a.PasswordNum == passID);
        }
    }
}
