using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoteBoard.Model;
using NoteBoard.BLL;

namespace NoteBoard.UI.Winform
{
    public partial class frmMain : Form
    {
        User _user;
        PasswordController _passController;
        NoteController _noteController;
        public frmMain(User user)
        {
            InitializeComponent();
            _user = user;
            _passController = new PasswordController();
            _noteController = new NoteController();
        }

        private void LblUserPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Password pass = _passController.GetActivePassword(_user.UserID);
            frmChangePassword frm = new frmChangePassword(pass);
            frm.Owner = this.Owner; 
            frm.Show();
            this.Close();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void FillNotes()
        {
            List<Note> notes = _noteController.GetNotesByUser(_user.UserID);
            lstNotes.DisplayMember = "Title";
            lstNotes.ValueMember = "NoteID";
            lstNotes.DataSource = notes;

           // lstNotes.SelectedIndex = -1;
        }

        private void AddNote()
        {
            Note note = new Note();
            note.Title = txtTitle.Text;
            note.Content = txtContent.Text;
            note.UserID = _user.UserID;

            bool result = _noteController.Add(note);
            if (result)
            {
                MessageBox.Show("Notunuz Eklendi.");
                txtTitle.Clear();
                txtContent.Clear();
                FillNotes();
            }
            else
            {
                MessageBox.Show("Notunuz kayıt edilemedi.!");
            }
        }

        private void UpdateNote()
        {
            int noteID = (int)lstNotes.SelectedValue;
            Note selected = _noteController.GetByID(noteID);

            selected.Title = txtTitle.Text;
            selected.Content = txtContent.Text;

            bool result = _noteController.Update(selected);
            if (result)
            {
                MessageBox.Show("Notunuz Güncellendi.");
                txtTitle.Clear();
                txtContent.Clear();
                FillNotes();
            }
            else
            {
                MessageBox.Show("Notunuz Güncellenemedi.!");
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (lstNotes.SelectedIndex < 0)
            {
                AddNote();
            }
            else
            {
                UpdateNote();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (lstNotes.SelectedIndex < 0)
            {
                MessageBox.Show("Not Seçiniz.!");
                return;
            }

            int noteID = (int)lstNotes.SelectedValue;
            Note selected = _noteController.GetByID(noteID);
            bool result = _noteController.Delete(selected);
            if (result)
            {
                MessageBox.Show("Not başarıyla silindi.");
                FillNotes();
            }
            else
            {
                MessageBox.Show("Not silinemedi.!");
            }
        }

        private void LstNotes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
