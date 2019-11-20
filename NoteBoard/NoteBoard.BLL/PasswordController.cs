using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteBoard.DAL.Repositories;
using NoteBoard.Model;


namespace NoteBoard.BLL
{
    public class PasswordController
    {
        PasswordDAL _passwordDAL;
        public PasswordController()
        {
            _passwordDAL = new PasswordDAL();
        }

        public bool Add(Password password)
        {
            List<Password> passwords = GetAllByUser(password.UserID);
            passwords = passwords.OrderByDescending(a => a.CreatedDate).Take(3).ToList();

            if (passwords.FirstOrDefault(a => a.PasswordText == password.PasswordText) != null)
            {
                throw new Exception("Son 3 Şifreden farklı bir şifre giriniz.!");
            }

            if(passwords.FirstOrDefault()!=null) //varsa silsin yoksa silmeye çalışıp patlamasın.!
                Delete(passwords.First());

            password.IsActive = true;
            password.CreatedDate = DateTime.Now;

            return _passwordDAL.Add(password) > 0;
        }

        public List<Password> GetAllByUser(int userID)
        {
            return _passwordDAL.GetAll().Where(a => a.UserID == userID).ToList();
        }

        public bool Delete(Password password)
        {
            password.IsActive = false;
            password.ModifiedDate = DateTime.Now;
            return _passwordDAL.Update(password) > 0;
        }

        public Password GetActivePassword(int userID)
        {
            List<Password> allPasswords = GetAllByUser(userID);
            return allPasswords.Where(a => a.IsActive).SingleOrDefault();
        }

    }
}
