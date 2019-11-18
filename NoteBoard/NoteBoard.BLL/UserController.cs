using NoteBoard.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBoard.BLL
{
    public class UserController
    {
        UserDAL _userDAL;
        public UserController()
        {
            _userDAL = new UserDAL();
        }
    }
}
