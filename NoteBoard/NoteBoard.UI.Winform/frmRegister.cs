using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoteBoard.BLL;
using NoteBoard.Model;

namespace NoteBoard.UI.Winform
{
    public partial class frmRegister : Form
    {
        UserController _userController;
        public frmRegister()
        {
            InitializeComponent();
            _userController = new UserController();
        }

        private void BtnKayit_Click(object sender, EventArgs e)
        {
            if (txtSifre.Text != txtSifreTekrar.Text)
            {
                MessageBox.Show("Şifreler Eşleşmiyor.!");
                return;
            }

            User newUser = new User();
            newUser.FirstName = txtAd.Text;
            newUser.LastName = txtSoyad.Text;
            newUser.UserName = txtKAdi.Text;
            newUser.UserRole = UserRole.Standart;
            newUser.Passwords.Add(new Password()
            {
                PasswordText = txtSifre.Text
            });

            try
            {
                bool result = _userController.Add(newUser);
                if (result)
                {
                    MessageBox.Show("Kayıt Başarılı. Kullanıcı onay süreciniz başladı.");
                    this.Close();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void FrmRegister_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
