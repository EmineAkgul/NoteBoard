﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using NoteBoard.Model;

namespace NoteBoard.DAL.Mapping
{
    class PasswordMapping:EntityTypeConfiguration<Password>
    {
        public PasswordMapping()
        {
            Property(p => p.PasswordText).IsRequired().HasMaxLength(16);
            HasRequired(p => p.User).WithMany(u => u.Passwords).HasForeignKey(a => a.UserID);

            Map(a => a.MapInheritedProperties());

            HasKey(p => p.PasswordNum);
            Property(p => p.PasswordNum).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

        }
    }
}
