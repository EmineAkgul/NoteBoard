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
    public partial class frmChangePassword : Form
    {
        PasswordController _passwordController;
        Password _pass;
        public frmChangePassword(Password pass)
        {
            InitializeComponent();
            _pass = pass;
            _passwordController = new PasswordController();

        }

        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            if (txtOldPassword.Text != _pass.PasswordText)
            {
                MessageBox.Show("Şifreniz Yanlış.!");
                return;
            }
            else if (txtNewPassword.Text != txtNewPassAgain.Text)
            {
                MessageBox.Show("Şifreler Uyuşmuyor.!");
            }
            Password newPassword = new Password();
            newPassword.PasswordText = txtNewPassword.Text;
            newPassword.UserID = _pass.UserID;

            try
            {
                bool result = _passwordController.Add(newPassword);
                if (result)
                {
                    MessageBox.Show("Şifreniz Güncellendi.");
                }
                else
                {
                    MessageBox.Show("Şifreniz Güncellenemedi.!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void FrmChangePassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
