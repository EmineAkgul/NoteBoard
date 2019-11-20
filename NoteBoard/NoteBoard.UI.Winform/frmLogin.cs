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
    public partial class frmLogin : Form
    {
        UserController _userController;

        public frmLogin()
        {
            InitializeComponent();
            _userController = new UserController();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegister frm = new frmRegister();
            frm.Owner = this;
            frm.Show();
            this.Hide();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            User currentUser = _userController.GetByLogin(txtKAdi.Text, txtSifre.Text);
            if (currentUser != null)
            {
                if (currentUser.UserRole == UserRole.Standart)
                {
                    frmMain frm = new frmMain();
                    frm.Owner = this;
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    frmAdmin frm = new frmAdmin();
                    frm.Owner = this;
                    frm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Bilgileri.!");
            }


        }
    }
}
