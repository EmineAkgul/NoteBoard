using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteBoard.DAL.Mapping;
using NoteBoard.Model;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NoteBoard.DAL
{
    class NoteBoardDbContext:DbContext
    {
        public NoteBoardDbContext():base("server=.;database=NoteBoard;uid=sa;pwd=123")
        {
            Database.SetInitializer(new NoteBoardDbInitializer());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Password> Passwords { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new NoteMapping());
            modelBuilder.Configurations.Add(new PasswordMapping());
            modelBuilder.Configurations.Add(new USerMapping());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
