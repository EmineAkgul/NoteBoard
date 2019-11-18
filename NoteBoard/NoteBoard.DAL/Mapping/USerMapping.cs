using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using NoteBoard.Model;

namespace NoteBoard.DAL.Mapping
{
    class USerMapping:EntityTypeConfiguration<User>
    {
        public USerMapping()
        {
            Property(a => a.FirstName).IsRequired().HasMaxLength(20);
            Property(a => a.LastName).IsRequired().HasMaxLength(30);
            Property(a => a.UserName).IsRequired().HasMaxLength(18);

            HasKey(a => a.UserID);
            Property(a => a.UserID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Map(a => a.MapInheritedProperties()); ///kalıtım aldığı propları da maple ve aynı yeerde tut
            HasIndex(a => a.UserName).IsUnique();



        }
    }
}
